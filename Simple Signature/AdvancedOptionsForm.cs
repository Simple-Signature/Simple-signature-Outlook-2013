using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple_Signature
{
    public partial class AdvancedOptionsForm : Form
    {
        SimpleSign parent = null;
        public AdvancedOptionsForm(SimpleSign s)
        {
            parent = s;
            InitializeComponent();
            this.BackColor = Color.FromArgb(142, 68, 173);
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.firmTextBox.Text = Properties.Settings.Default.Firm;
            this.serviceTextBox.Text = Properties.Settings.Default.Service;
            this.urlTextBox.Text = Properties.Settings.Default.URLSimpleSign;
            if (Properties.Settings.Default.mailInterne != null && Properties.Settings.Default.mailInterne.Cast<string>() != null)
            {
                this.mailTextBox.Lines = Properties.Settings.Default.mailInterne.Cast<string>().ToArray<string>();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Firm = this.firmTextBox.Text;
            Properties.Settings.Default.Service = this.serviceTextBox.Text;
            Properties.Settings.Default.URLSimpleSign = this.urlTextBox.Text;
            if (Properties.Settings.Default.mailInterne != null)
            {
                Properties.Settings.Default.mailInterne.Clear();
            }
            else
            {
                Properties.Settings.Default.mailInterne= new System.Collections.Specialized.StringCollection();
            }
            Properties.Settings.Default.mailInterne.AddRange(this.mailTextBox.Lines);
            Properties.Settings.Default.Save();
            parent.updateCampaigns();
            this.Close();
        }

        private void cancelButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
