using Microsoft.CognitiveServices.Speech;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpellHelper
{
    public partial class MainForm : Form
    {
        DataTable _ResultData = new DataTable();
        private SpeechSynthesizer? _SpeechSynthesizer = null;
        private bool _TranslatorEnabled = false;

        private HashSet<string> _WordList = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        WMPLib.WindowsMediaPlayer _MediaPlayer = new WMPLib.WindowsMediaPlayer();
        Porter2Stemmer.EnglishPorter2Stemmer _Stemmer = new Porter2Stemmer.EnglishPorter2Stemmer();

        private string _ConfigPath = "config.txt";
        private ConfigObject _Config = new ConfigObject();


        public MainForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            _ResultData.Columns.Add("Word");
            _ResultData.Columns.Add("Audio");
            _ResultData.Columns.Add("Translate");
            _ResultData.Columns.Add("PartOfSpeech");
            _ResultData.Columns.Add("Phonetic");
            _ResultData.Columns.Add("Definition");
            dataGridView1.DataSource = _ResultData;

            _Config.Read(_ConfigPath);
            cboLanguages.Items.AddRange(_Config.Languages);
            cboLanguages.Text = _Config.TranslateTo;
            chkUseWordList.Checked = _Config.UseWordList;
            chkUseTranslator.Checked = _Config.UseTranslator;
            chkUseSpeech.Checked = _Config.UseSpeech;

            InitSpeech(_Config.MSSpeechKey, _Config.MSSpeechRegion);
            CheckTranslatorKey(_Config.MSTranslatorKey, _Config.MSTranslatorRegion);
            LoadWordList(_Config.WordListPath);
        }

        private void InitSpeech(string key, string region)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(region))
                {
                    throw new Exception("Speech Key/Region is empty.");
                }
                var speechConfig = SpeechConfig.FromSubscription(key, region);
                speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural";
                _SpeechSynthesizer = new SpeechSynthesizer(speechConfig);
                chkUseSpeech.Enabled = true;

            }
            catch (Exception ex)
            {
                _SpeechSynthesizer = null;
                chkUseSpeech.Enabled = false;
                Console.WriteLine(ex.Message);
            }
        }

        private void CheckTranslatorKey(string key, string region)
        {
            _TranslatorEnabled = !string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(region);
            cboLanguages.Enabled = _TranslatorEnabled;
            chkUseTranslator.Enabled = _TranslatorEnabled;
        }

        private bool LoadWordList(string path)
        {
            if (!File.Exists(path)) return false;

            _WordList.Clear();
            txtFilterFile.Text = Path.GetFileName(path);

            //int count = 0;
            //int transCount = 0;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    string[] word = (sr.ReadLine() ?? "").Split(',');
                    _WordList.Add(word[0].Trim());
                    //if (!_WordList.ContainsKey(word[0]))
                    //{
                    //    count++;
                    //    if (word.Length > 1)
                    //    {
                    //        transCount++;
                    //        _WordList.Add(word[0], word[1]);
                    //    }
                    //    else
                    //    {
                    //        _WordList.Add(word[0], null);
                    //    }
                    //}
                }
            }
            txtWords.Text = $"{_WordList.Count:N0}";
            //txtTranslated.Text = $"{transCount:N0}";

            txtInput.AutoCompleteCustomSource.Clear();
            string[] list = new string[_WordList.Count];
            _WordList.CopyTo(list, 0);
            txtInput.AutoCompleteCustomSource.AddRange(list);
            return true;
        }

        static async Task<List<WordInfo>?> DictionaryQuery(string text)
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri($"https://api.dictionaryapi.dev/api/v2/entries/en/{text}");

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
            string responseText = await response.Content.ReadAsStringAsync();
            if (responseText.StartsWith("["))
            {
                JArray? array = JsonConvert.DeserializeObject<JArray>(responseText);
                if (array == null) return null;

                List<WordInfo> result = new List<WordInfo>();
                foreach (JObject obj in array.Cast<JObject>())
                {
                    JArray? phonetics = obj["phonetics"] as JArray;
                    JArray? meanings = obj["meanings"] as JArray;
                    string word = (obj["word"]?.ToString() ?? "") ?? "";
                    string phonetic = "";
                    string audio = "";

                    if (phonetics != null)
                    {
                        foreach (var p in phonetics)
                        {
                            string t = p["text"]?.ToString() ?? "";
                            if (!string.IsNullOrWhiteSpace(t)) phonetic = t;

                            string a = p["audio"]?.ToString() ?? "";
                            if (!string.IsNullOrWhiteSpace(a)) audio = a;
                        }
                    }

                    if (meanings != null)
                    {
                        foreach (var meaning in meanings)
                        {
                            string partOfSpeech = (meaning["partOfSpeech"]?.ToString() ?? "");
                            if (meaning["definitions"] is JArray definitions)
                            {
                                foreach (var definition in definitions)
                                {
                                    WordInfo wordInfo = new()
                                    {
                                        Word = word,
                                        Audio = audio,
                                        Phonetic = phonetic,
                                        PartOfSpeech = partOfSpeech,
                                        Definition = definition["definition"]?.ToString() ?? ""
                                    };
                                    result.Add(wordInfo);
                                    break;
                                }
                            }
                        }
                    }
                    break;

                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> Translate(string textToTranslate, string toLang)
        {
            // Input and output languages are defined as parameters.
            string route = $"/translate?api-version=3.0&from=en&to={toLang}";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            int retry = 3;
            while (true)
            {
                try
                {
                    using (var client = new HttpClient())
                    using (var request = new HttpRequestMessage())
                    {
                        // Build the request.
                        request.Method = HttpMethod.Post;
                        request.RequestUri = new Uri("https://api.cognitive.microsofttranslator.com/" + route);
                        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                        request.Headers.Add("Ocp-Apim-Subscription-Key", _Config.MSTranslatorKey);
                        request.Headers.Add("Ocp-Apim-Subscription-Region", _Config.MSTranslatorRegion);

                        // Send the request and get response.
                        HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                        // Read response as a string.
                        string result = await response.Content.ReadAsStringAsync();
                        var responseBody = JsonConvert.DeserializeObject<JArray>(result);
                        string res = responseBody?[0]?["translations"]?[0]?["text"]?.ToString()??"";
                        return res;
                    }
                }
                catch
                {
                    if (--retry <= 0)
                    {
                        throw;
                    }
                }
            }
        }

        char[] replaceChar = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        HashSet<string> prefixes = new HashSet<string>()
        {"di" , "under","equi", "mini",  "macro",  "infra", "peri",
         "prime",  "retro","emi","quad","penta","hex","sept","dec",
         "uni","bi","tri","oct","deca","cent","kilo","mega","fore","post","pre","pro","anti","dis","ab","in","il","ir","im","mis",
         "non","un","ante","contra","contro","counter","a","auto","bene","co", "con", "com","col","de","en","ex","extra","homo","hyper",
         "inter","intra","intro","mal","micro","mono","multi","ob","op","over","para","per","poly","re","back","semi","sub","sup","super","supra",
         "sur","sym","syn","tele","trans"};

        HashSet<string> suffixs = new HashSet<string>()
        {
            "er" ,"or" ,"an" ,"ian" ,"ant" ,"ent" ,"ar" ,"ate" ,"ee" ,"eer" ,"ese" ,"ess" ,"ic" ,"ician" ,"ist" ,"ster" ,"al" ,"age" ,"ance" ,
            "ence" ,"ancy" ,"ency" ,"dom" ,"hood" ,"ics" ,"ism" ,"ity" ,"ty","logy" ,"ment" ,"ness" ,"ory" ,"ship" ,"tion","ation" ,"sion" ,
            "ure" ,"ture" ,"en" ,"fy","ify" ,"ish" ,"ize" , "ise" ,"le" ,"able","ible","ary" ,"ful","ical" ,"id" ,"ior","ive","less" ,"like",
            "ly" ,"ous","proof" ,"ward","y" ,"way","wise"
        };

        #region
        //字首/字根 | 意義
        //uni- | one（一、單一）
        //bi- | two, double（二、雙）
        //tri- | three（三）
        //oct- | eight（八）
        //deca- | ten（十）
        //cent | hundred（百、百分之一）
        //kilo- | thousand（千）
        //mega- | million, large（百萬、大量的）
        //fore- | before, front（前面）
        //post- | after（後面）
        //pre- | before（之前）
        //pro- | forward（向前）for, in favor of（支持、擁護）
        //anti- | against, opposite（反對、對抗、相反）
        //dis- | not（否定）apart, away（分開、除去）
        //ab- | away, off（離開）
        //in-
        //il-
        //ir-
        //im- | not, without（否定）
        //mis- | wrong（錯誤）
        //non- | no, not（無、沒有）
        //un- | no, not（無、非）+ adj.opposite（相反）+ V.
        //ante-
        //anti- | before（在…之前）
        //contra-
        //contro-
        //counter- | against, opposite （反對、相反、對抗）
        //a- | lack（缺乏）toward（朝向）（加強語氣）
        //auto- | self（自己、自動）
        //bene- | good（好的）
        //con-
        //co-
        //com-
        //col- | with, together （一起）
        //de- | down（向下）away, off（離開、去除）
        //en- | make, put into（使變成…、置放…之中）
        //ex- | out（向外）before（先前）
        //extra- | beyond（超過）outside（以外的）
        //homo- | same（相同的）
        //hyper- | over, beyond, above（在…之上、超越…）
        //in-
        //im- | into（向內）
        //inter- | between, among（在…之間、其中）
        //intra-
        //intro- | within, into （在…裡面、向內）
        //mal- | bad（壞的、不好的）
        //micro- | small（小的）
        //mono- | one, single（單一的）
        //multi- | many, much（多、大量）
        //ob-
        //op- | toward（朝向）against（對抗）
        //over（全面）
        //para- | beside（在…旁邊）similar（相似）
        //per- | through, completely（穿越、徹底地）
        //poly- | many, much（多、多數）
        //re- | again（再次）
        //back（回到）
        //semi- |  half（一半）
        //sub-
        //sup- | under, beneath（在…之下）（次要）
        //super-
        //supra- | over, above（在…之上、超越）
        //sur- | over（超過）
        //sym-
        //syn- | same, together（相同、共同、一起）
        //tele- | far（遠）
        //trans- | through, across（穿越）

        //字尾 (suffix) | 意義
        //-er
        //-or | 從事…的人、用來…的物品
        //-an
        //-ian | 同類或同族群的人
        //-ant
        //-ent | 從事…的人、執行…的人
        //-ar | 做…的人
        //-ate | 執行某職務的人、使成為…的人
        //-ee | 做…的人、被…的人
        //-eer | 從事…的人、與…有關的人
        //-ese | 某國家的人/語言
        //-ess | 女性
        //-ic | 做…的人
        //-ician | 精通…的人、高手
        //-ist | 從事…職業/研究的人、…主義者
        //-ster | 做…的人、是…的人
        //-al | 狀態、行為、動作
        //-age | 性質、行為、狀態
        //-ance
        //-ence
        //-ancy
        //-ency | 狀態、性質、情況、行為
        //-dom | 領域、性質、狀態
        //-hood | 狀態、性質、時期
        //-ic(s) | 學術、學科
        //-ism | 主義、行為、學派
        //-ity
        //-ty | 狀態、性質
        //-logy | 學說
        //-ment | 行為的過程或結果、性質、狀態
        //-ness | 性質、情況、狀態
        //-ory | 有…性質的、場所
        //-ship | 狀態、身份、關係
        //-tion
        //-ation
        //-sion | 行為的過程或結果
        //-ure
        //-ture | 行爲的狀態或結果
        //-ate | 使變成
        //-en | 使變成
        //-fy
        //-ify | 使…化、使成為…
        //-ish | 造成…、做…
        //-ize
        //-ise | 使成為、…化
        //-le | 反覆、連續動作
        //-able
        //-ible | 能夠…的
        //-al | 關於…的
        //-ant
        //-ent | …狀態的
        //-ar | 具…的性質
        //-ary | 關於…的
        //-ate | 有…性質的
        //-en | 由…製成的、有…性質的
        //-ful | 充滿…的
        //-ic | 屬於…的、有…性質的
        //-ical | 屬於…的、與…有關的
        //-id | 具…的性質、…狀態的
        //-ior | 有…性質的
        //-ish | 有…性質的、如…的
        //-ive | 有…性質的
        //-less | 沒有…的
        //-like | 像…的、有…特質的
        //-ly | 有…性質的
        //-ous | 充滿…的
        //-proof | 防止…的
        //-ward | 方式、位置
        //-y | 含有…的、如…的
        //-ly | 以…的方式（加在形容詞後）
        //-ward(s) | 朝…方向的
        //-way(s)
        //-wise | 方向、位置
        #endregion

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _ResultData.Clear();
            Grid_Translate.Visible = _TranslatorEnabled && chkUseTranslator.Checked;
            string translateTo = (_TranslatorEnabled && chkUseTranslator.Checked) ? cboLanguages.Text : "";
            await PutChar(txtInput.Text, translateTo);
        }

        private async Task PutChar(string word, string translateTo)
        {
            int replaceAt = word.IndexOf('?');
            if (replaceAt < 0)
            {
                CheckAndTranslate(word, translateTo);
            }
            else
            {
                string before = word.Substring(0, replaceAt);
                string after = replaceAt >= word.Length ? "" : word[(replaceAt + 1)..];
                List<Task> tasks = new List<Task>();
                foreach (char ch in replaceChar)
                {
                    tasks.Add(PutChar(before + ch + after, translateTo));
                }
                await Task.WhenAll(tasks);
            }
        }

        private async void root_Click(object sender, EventArgs e)
        {
            string stem = _Stemmer.Stem(txtInput.Text).Value;

            _ResultData.Clear();
            string translateTo = (_TranslatorEnabled && chkUseTranslator.Checked) ? cboLanguages.Text : "";
            await CheckAndTranslate(txtInput.Text, translateTo);
            HashSet<string> queryWord = new HashSet<string>();
            queryWord.Add(txtInput.Text);
            foreach (string str in prefixes)
            {
                string word = str + txtInput.Text;
                if (queryWord.Contains(word)) continue;
                queryWord.Add(word);
                CheckAndTranslate(word, translateTo);
            }

            foreach (string str in suffixs)
            {
                string word = txtInput.Text + str;
                if (queryWord.Contains(word)) continue;
                queryWord.Add(word);
                CheckAndTranslate(word, translateTo);
            }

            if (txtInput.Text != stem)
            {
                if (!queryWord.Contains(stem))
                {
                    CheckAndTranslate(stem, translateTo);
                    queryWord.Add(stem);
                }
                foreach (string str in prefixes)
                {
                    string word = str + stem;
                    if (queryWord.Contains(word)) continue;
                    queryWord.Add(word);
                    CheckAndTranslate(word, translateTo);
                }

                foreach (string str in suffixs)
                {
                    string word = stem + str;
                    if (queryWord.Contains(word)) continue;
                    queryWord.Add(word);
                    CheckAndTranslate(word, translateTo);
                }
            }
        }

        private async Task CheckAndTranslate(string word, string translateTo)
        {
            if (chkUseWordList.Checked && !_WordList.Contains(word)) return;

            var wordInfos = await DictionaryQuery(word);
            if (wordInfos == null) return;

            string translate = "";
            if (!string.IsNullOrWhiteSpace(translateTo))
                translate = await Translate(word, translateTo);

            foreach (var wordInfo in wordInfos)
            {
                string definition = wordInfo.Definition;
                if (!string.IsNullOrWhiteSpace(translateTo))
                    definition = await Translate(definition, translateTo);

                DataRow row = _ResultData.Rows.Add();
                row["Word"] = word;
                row["Audio"] = wordInfo.Audio;
                row["Translate"] = translate;
                row["PartOfSpeech"] = wordInfo.PartOfSpeech;
                row["Phonetic"] = wordInfo.Phonetic;
                row["Definition"] = definition;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileName = $"{DateTime.Now:yyyyMMdd}export.csv";

            HashSet<string> hash = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    hash.Add(parts[0].Trim());
                }
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (DataRow row in _ResultData.Rows)
                {
                    string word = (row["Word"] as string)?.Trim() ?? "";
                    string translate = (row["Translate"] as string)?.Trim() ?? "";
                    sw.WriteLine(word + "," + translate);
                    hash.Add(word);
                }
            }
        }

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            await Speech();
        }

        private async Task Speech()
        {
            if (dataGridView1.SelectedCells.Count == 0) return;
            int idx = dataGridView1.SelectedCells[0].RowIndex;

            if (idx < 0) return;
            DataRowView row = _ResultData.DefaultView[idx];

            if (chkUseSpeech.Checked && _SpeechSynthesizer != null)
            {
                string word = (row["word"] as string ?? "");
                await _SpeechSynthesizer.StopSpeakingAsync();
                await _SpeechSynthesizer.SpeakTextAsync(word);
            }
            else
            {
                string url = (row["Audio"] as string ?? "");
                _MediaPlayer.URL = url;
                _MediaPlayer.controls.play();
            }
        }

        //private async void btnTranslate_Click(object sender, EventArgs e)
        //{
        //    if (_WordListPath == null) return;

        //    int taskLimit = 30;
        //    int transCount = 0;
        //    List<Task> tasks = new List<Task>();
        //    Dictionary<string, string> newDict = new Dictionary<string, string>();
        //    foreach (var kv in _WordList)
        //    {
        //        if (kv.Value == null)
        //        {
        //            tasks.Add(TranslateWordAndInsert(kv.Key, newDict));
        //            if (tasks.Count >= taskLimit)
        //            {
        //                await Task.WhenAll(tasks);
        //                transCount += tasks.Count;
        //                tasks.Clear();
        //                txtTranslated.Text = $"{transCount:N0}";
        //            }
        //        }
        //        else
        //        {
        //            newDict.Add(kv.Key, kv.Value);
        //            transCount++;
        //            txtTranslated.Text = $"{transCount:N0}";
        //        }
        //    }
        //    await Task.WhenAll(tasks);
        //    transCount += tasks.Count;
        //    txtTranslated.Text = $"{transCount:N0}";

        //    _WordList = newDict;
        //    using (FileStream fs = new FileStream(_WordListPath, FileMode.Create))
        //    using (StreamWriter sw = new StreamWriter(fs))
        //    {
        //        foreach (var kv in _WordList)
        //        {
        //            if (kv.Value == null)
        //            {
        //                sw.WriteLine($"{kv.Key}");
        //            }
        //            else
        //            {
        //                sw.WriteLine($"{kv.Key},{kv.Value}");
        //            }
        //        }
        //    }
        //}

        //private async Task TranslateWordAndInsert(string word, Dictionary<string, string> wordList)
        //{
        //    string translated = await Translate(word);
        //    if (translated == word)
        //    {
        //        wordList.Add(word, null);
        //    }
        //    else
        //    {
        //        wordList.Add(word, translated);
        //    }
        //}

        private void btnLoadFilterFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (LoadWordList(openFileDialog1.FileName))
                {
                    _Config.WordListPath = openFileDialog1.FileName;
                    _Config.Write(_ConfigPath);
                }
            }
        }

        private void cboLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Config.TranslateTo = cboLanguages.Text;
            _Config.Write(_ConfigPath);
        }

        private void chkUseWordList_Click(object sender, EventArgs e)
        {
            _Config.UseWordList = chkUseWordList.Checked;
            _Config.Write(_ConfigPath);
        }

        private void chkUseSpeech_Click(object sender, EventArgs e)
        {
            _Config.UseSpeech = chkUseSpeech.Checked;
            _Config.Write(_ConfigPath);
        }

        private void chkUseTranslator_Click(object sender, EventArgs e)
        {
            _Config.UseTranslator = chkUseTranslator.Checked;
            _Config.Write(_ConfigPath);
        }

        private void btnAPIKeys_Click(object sender, EventArgs e)
        {
            using APIKeysForm form = new APIKeysForm(_Config);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _Config.MSTranslatorKey = form.MSTranslatorKey;
                _Config.MSTranslatorRegion = form.MSTranslatorRegion;
                _Config.MSSpeechKey = form.MSSpeechKey;
                _Config.MSSpeechRegion = form.MSSpeechRegion;
                _Config.Write(_ConfigPath);

                InitSpeech(_Config.MSSpeechKey, _Config.MSSpeechRegion);
                CheckTranslatorKey(_Config.MSTranslatorKey, _Config.MSTranslatorRegion);
            }
        }

        private async void btnSpeech_Click(object sender, EventArgs e)
        {
            await Speech();
        }
    }

    public class WordInfo
    {
        public string Word = "";
        public string Audio = "";
        public string PartOfSpeech = "";
        public string Phonetic = "";
        public string Definition = "";
    }
}
