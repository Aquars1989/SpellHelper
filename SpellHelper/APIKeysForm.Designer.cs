
namespace SpellHelper
{
    partial class APIKeysForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMSTranslatorKey = new System.Windows.Forms.TextBox();
            this.txtMSTranslatorRegion = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMSSpeechRegion = new System.Windows.Forms.TextBox();
            this.txtMSSpeechKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "API Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Region";
            // 
            // txtMSTranslatorKey
            // 
            this.txtMSTranslatorKey.Location = new System.Drawing.Point(94, 44);
            this.txtMSTranslatorKey.Name = "txtMSTranslatorKey";
            this.txtMSTranslatorKey.Size = new System.Drawing.Size(296, 22);
            this.txtMSTranslatorKey.TabIndex = 3;
            // 
            // txtMSTranslatorRegion
            // 
            this.txtMSTranslatorRegion.Location = new System.Drawing.Point(94, 72);
            this.txtMSTranslatorRegion.Name = "txtMSTranslatorRegion";
            this.txtMSTranslatorRegion.Size = new System.Drawing.Size(296, 22);
            this.txtMSTranslatorRegion.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(234, 204);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(315, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "MS Translator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "MS Speech";
            // 
            // txtMSSpeechRegion
            // 
            this.txtMSSpeechRegion.Location = new System.Drawing.Point(94, 165);
            this.txtMSSpeechRegion.Name = "txtMSSpeechRegion";
            this.txtMSSpeechRegion.Size = new System.Drawing.Size(296, 22);
            this.txtMSSpeechRegion.TabIndex = 11;
            // 
            // txtMSSpeechKey
            // 
            this.txtMSSpeechKey.Location = new System.Drawing.Point(94, 137);
            this.txtMSSpeechKey.Name = "txtMSSpeechKey";
            this.txtMSSpeechKey.Size = new System.Drawing.Size(296, 22);
            this.txtMSSpeechKey.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Region";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "API Key";
            // 
            // APIKeysForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 238);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMSSpeechRegion);
            this.Controls.Add(this.txtMSSpeechKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMSTranslatorRegion);
            this.Controls.Add(this.txtMSTranslatorKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "APIKeysForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMSTranslatorKey;
        private System.Windows.Forms.TextBox txtMSTranslatorRegion;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMSSpeechRegion;
        private System.Windows.Forms.TextBox txtMSSpeechKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}