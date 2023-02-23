
namespace SpellHelper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRoot = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Grid_Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Phonetic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_PartOfSpeech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Translate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Definition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilterFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWords = new System.Windows.Forms.TextBox();
            this.btnLoadFilterFile = new System.Windows.Forms.Button();
            this.chkUseWordList = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAPIKeys = new System.Windows.Forms.Button();
            this.cboLanguages = new System.Windows.Forms.ComboBox();
            this.chkUseTranslator = new System.Windows.Forms.CheckBox();
            this.chkUseSpeech = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpeech = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtInput.Location = new System.Drawing.Point(12, 90);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(266, 25);
            this.txtInput.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(284, 90);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRoot
            // 
            this.btnRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoot.Location = new System.Drawing.Point(361, 90);
            this.btnRoot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(111, 25);
            this.btnRoot.TabIndex = 3;
            this.btnRoot.Text = "Derivative";
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.root_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(577, 90);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(134, 25);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grid_Word,
            this.Grid_Phonetic,
            this.Grid_PartOfSpeech,
            this.Grid_Translate,
            this.Grid_Definition});
            this.dataGridView1.Location = new System.Drawing.Point(12, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(701, 384);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Grid_Word
            // 
            this.Grid_Word.DataPropertyName = "Word";
            this.Grid_Word.HeaderText = "Word";
            this.Grid_Word.Name = "Grid_Word";
            this.Grid_Word.ReadOnly = true;
            // 
            // Grid_Phonetic
            // 
            this.Grid_Phonetic.DataPropertyName = "Phonetic";
            this.Grid_Phonetic.FillWeight = 120F;
            this.Grid_Phonetic.HeaderText = "Phonetic";
            this.Grid_Phonetic.Name = "Grid_Phonetic";
            this.Grid_Phonetic.ReadOnly = true;
            this.Grid_Phonetic.Width = 120;
            // 
            // Grid_PartOfSpeech
            // 
            this.Grid_PartOfSpeech.DataPropertyName = "PartOfSpeech";
            this.Grid_PartOfSpeech.FillWeight = 80F;
            this.Grid_PartOfSpeech.HeaderText = "Speech";
            this.Grid_PartOfSpeech.Name = "Grid_PartOfSpeech";
            this.Grid_PartOfSpeech.ReadOnly = true;
            this.Grid_PartOfSpeech.Width = 80;
            // 
            // Grid_Translate
            // 
            this.Grid_Translate.DataPropertyName = "Translate";
            this.Grid_Translate.HeaderText = "Translate";
            this.Grid_Translate.Name = "Grid_Translate";
            this.Grid_Translate.ReadOnly = true;
            // 
            // Grid_Definition
            // 
            this.Grid_Definition.DataPropertyName = "Definition";
            this.Grid_Definition.FillWeight = 200F;
            this.Grid_Definition.HeaderText = "Definition";
            this.Grid_Definition.Name = "Grid_Definition";
            this.Grid_Definition.ReadOnly = true;
            this.Grid_Definition.Width = 200;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Word List";
            // 
            // txtFilterFile
            // 
            this.txtFilterFile.BackColor = System.Drawing.Color.White;
            this.txtFilterFile.Location = new System.Drawing.Point(116, 20);
            this.txtFilterFile.Name = "txtFilterFile";
            this.txtFilterFile.ReadOnly = true;
            this.txtFilterFile.Size = new System.Drawing.Size(154, 25);
            this.txtFilterFile.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Words";
            // 
            // txtWords
            // 
            this.txtWords.BackColor = System.Drawing.Color.White;
            this.txtWords.Location = new System.Drawing.Point(334, 20);
            this.txtWords.Name = "txtWords";
            this.txtWords.ReadOnly = true;
            this.txtWords.Size = new System.Drawing.Size(86, 25);
            this.txtWords.TabIndex = 11;
            this.txtWords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLoadFilterFile
            // 
            this.btnLoadFilterFile.Location = new System.Drawing.Point(437, 19);
            this.btnLoadFilterFile.Name = "btnLoadFilterFile";
            this.btnLoadFilterFile.Size = new System.Drawing.Size(129, 26);
            this.btnLoadFilterFile.TabIndex = 14;
            this.btnLoadFilterFile.Text = "Load Word List";
            this.btnLoadFilterFile.UseVisualStyleBackColor = true;
            this.btnLoadFilterFile.Click += new System.EventHandler(this.btnLoadFilterFile_Click);
            // 
            // chkUseWordList
            // 
            this.chkUseWordList.AutoSize = true;
            this.chkUseWordList.Checked = true;
            this.chkUseWordList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseWordList.Location = new System.Drawing.Point(577, 22);
            this.chkUseWordList.Name = "chkUseWordList";
            this.chkUseWordList.Size = new System.Drawing.Size(123, 22);
            this.chkUseWordList.TabIndex = 15;
            this.chkUseWordList.Text = "Use WordList";
            this.chkUseWordList.UseVisualStyleBackColor = true;
            this.chkUseWordList.Click += new System.EventHandler(this.chkUseWordList_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAPIKeys
            // 
            this.btnAPIKeys.Location = new System.Drawing.Point(577, 55);
            this.btnAPIKeys.Name = "btnAPIKeys";
            this.btnAPIKeys.Size = new System.Drawing.Size(134, 26);
            this.btnAPIKeys.TabIndex = 16;
            this.btnAPIKeys.Text = "API Keys";
            this.btnAPIKeys.UseVisualStyleBackColor = true;
            this.btnAPIKeys.Click += new System.EventHandler(this.btnAPIKeys_Click);
            // 
            // cboLanguages
            // 
            this.cboLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguages.FormattingEnabled = true;
            this.cboLanguages.Location = new System.Drawing.Point(116, 55);
            this.cboLanguages.Name = "cboLanguages";
            this.cboLanguages.Size = new System.Drawing.Size(121, 26);
            this.cboLanguages.TabIndex = 17;
            this.cboLanguages.SelectedIndexChanged += new System.EventHandler(this.cboLanguages_SelectedIndexChanged);
            // 
            // chkUseTranslator
            // 
            this.chkUseTranslator.AutoSize = true;
            this.chkUseTranslator.Checked = true;
            this.chkUseTranslator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseTranslator.Location = new System.Drawing.Point(257, 57);
            this.chkUseTranslator.Name = "chkUseTranslator";
            this.chkUseTranslator.Size = new System.Drawing.Size(139, 22);
            this.chkUseTranslator.TabIndex = 18;
            this.chkUseTranslator.Text = "Use Translator";
            this.chkUseTranslator.UseVisualStyleBackColor = true;
            this.chkUseTranslator.Click += new System.EventHandler(this.chkUseTranslator_Click);
            // 
            // chkUseSpeech
            // 
            this.chkUseSpeech.AutoSize = true;
            this.chkUseSpeech.Checked = true;
            this.chkUseSpeech.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseSpeech.Location = new System.Drawing.Point(413, 57);
            this.chkUseSpeech.Name = "chkUseSpeech";
            this.chkUseSpeech.Size = new System.Drawing.Size(131, 22);
            this.chkUseSpeech.TabIndex = 19;
            this.chkUseSpeech.Text = "Use MS Speech";
            this.chkUseSpeech.UseVisualStyleBackColor = true;
            this.chkUseSpeech.Click += new System.EventHandler(this.chkUseSpeech_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "TranslateTo";
            // 
            // btnSpeech
            // 
            this.btnSpeech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpeech.Location = new System.Drawing.Point(486, 90);
            this.btnSpeech.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSpeech.Name = "btnSpeech";
            this.btnSpeech.Size = new System.Drawing.Size(80, 25);
            this.btnSpeech.TabIndex = 21;
            this.btnSpeech.Text = "Speech";
            this.btnSpeech.UseVisualStyleBackColor = true;
            this.btnSpeech.Click += new System.EventHandler(this.btnSpeech_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 518);
            this.Controls.Add(this.btnSpeech);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkUseSpeech);
            this.Controls.Add(this.chkUseTranslator);
            this.Controls.Add(this.cboLanguages);
            this.Controls.Add(this.btnAPIKeys);
            this.Controls.Add(this.chkUseWordList);
            this.Controls.Add(this.btnLoadFilterFile);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFilterFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRoot);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtInput);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "SpellHelper";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRoot;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Phonetic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_PartOfSpeech;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Translate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Definition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilterFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.Button btnLoadFilterFile;
        private System.Windows.Forms.CheckBox chkUseWordList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAPIKeys;
        private System.Windows.Forms.ComboBox cboLanguages;
        private System.Windows.Forms.CheckBox chkUseTranslator;
        private System.Windows.Forms.CheckBox chkUseSpeech;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSpeech;
    }
}

