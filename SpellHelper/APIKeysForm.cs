using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpellHelper
{
    public partial class APIKeysForm : Form
    {
        private string _MSTranslatorKey = "";

        private string _MSSpeechKey = "";

        public string MSTranslatorKey => txtMSTranslatorKey.Text== _NoChange? _MSTranslatorKey : txtMSTranslatorKey.Text;
        public string MSTranslatorRegion => txtMSTranslatorRegion.Text;
        public string MSSpeechKey => txtMSSpeechKey.Text == _NoChange ? _MSSpeechKey : txtMSSpeechKey.Text;
        public string MSSpeechRegion => txtMSSpeechRegion.Text;
        
        private string _NoChange= "-No Change-";

        public APIKeysForm(ConfigObject config)
        {
            InitializeComponent();

            _MSTranslatorKey = config.MSTranslatorKey;
            _MSSpeechKey = config.MSSpeechKey;
            txtMSTranslatorKey.Text = string.IsNullOrWhiteSpace(_MSTranslatorKey) ? "" : _NoChange;
            txtMSTranslatorRegion.Text = config.MSTranslatorRegion;
            txtMSSpeechKey.Text = string.IsNullOrWhiteSpace(_MSSpeechKey) ? "" : _NoChange;
            txtMSSpeechRegion.Text = config.MSSpeechRegion;
        }
    }
}
