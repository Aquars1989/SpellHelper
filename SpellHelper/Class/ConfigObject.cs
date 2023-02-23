using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpellHelper
{
    public class ConfigObject
    {
        public string[] Languages { get; set; } = new string[] { "zh-TW" };
        public string TranslateTo { get; set; } = "zh-TW";
        public string WordListPath { get; set; } = "WordList.txt";
        public bool UseWordList { get; set; } = true;
        public bool UseTranslator { get; set; } = false;
        public bool UseSpeech { get; set; } = false;
        public string MSTranslatorKey { get; set; } = "";
        public string MSTranslatorRegion { get; set; } = "";
        public string MSSpeechKey { get; set; } = "";
        public string MSSpeechRegion { get; set; } = "";

        private string _EncTranslatorKey = "Dsf!3g%m#";
        private string _EncSpeechKey = "%f@hy^ndK";
        public void Read(string path)
        {
            if (!File.Exists(path)) return;

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split("=");
                if (parts.Length != 2) continue;

                string key = parts[0].Trim().ToLower();
                string value = parts[1].Trim();
                switch (key)
                {
                    case "languages":
                        Languages = value.Split(",");
                        break;
                    case "translateto":
                        TranslateTo = value;
                        break;
                    case "wordlistpath":
                        WordListPath = value;
                        break;
                    case "useWorklist":
                        UseWordList = value == "Y";
                        break;
                    case "usetranslator":
                        UseTranslator = value == "Y";
                        break;
                    case "usespeech":
                        UseSpeech = value == "Y";
                        break;
                    case "mstranslatorkey":
                        MSTranslatorKey = StringEncrypt.AesDecryptBase64(value, _EncTranslatorKey);
                        break;
                    case "mstranslatorregion":
                        MSTranslatorRegion = value;
                        break;
                    case "msspeechkey":
                        MSSpeechKey = StringEncrypt.AesDecryptBase64(value, _EncSpeechKey);
                        break;
                    case "msspeechregion":
                        MSSpeechRegion = value;
                        break;
                }
            }

        }

        public void Write(string path)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Languages={string.Join(",", Languages)}");
            output.AppendLine($"TranslateTo={TranslateTo}");
            output.AppendLine($"WordListPath={WordListPath}");
            output.AppendLine($"UseWorkList={(UseWordList ? "Y" : "N")}");
            output.AppendLine($"UseTranslator={(UseTranslator ? "Y" : "N")}");
            output.AppendLine($"UseSpeech={(UseSpeech ? "Y" : "N")}");
            output.AppendLine($"MSTranslatorKey={StringEncrypt.AesEncryptBase64(MSTranslatorKey, _EncTranslatorKey)}");
            output.AppendLine($"MSTranslatorRegion={MSTranslatorRegion}");
            output.AppendLine($"MSSpeechKey={StringEncrypt.AesEncryptBase64(MSSpeechKey, _EncSpeechKey)}");
            output.AppendLine($"MSSpeechRegion={MSSpeechRegion}");
            File.WriteAllText(path, output.ToString());
        }
    }
}
