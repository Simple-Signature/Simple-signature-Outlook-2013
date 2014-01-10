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
    public partial class WelcomeForm : Form
    {
        SimpleSign parent = null;
        public WelcomeForm(SimpleSign s)
        {
            parent = s;
            InitializeComponent();
            this.BackColor = Color.FromArgb(142, 68, 173);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Firm = this.firmTextBox.Text;
            Properties.Settings.Default.Service = this.serviceTextBox.Text;
            if (Properties.Settings.Default.mailInterne != null)
            {
                Properties.Settings.Default.mailInterne.Clear();
            }
            else
            {
                Properties.Settings.Default.mailInterne = new System.Collections.Specialized.StringCollection();
            }
            Properties.Settings.Default.mailInterne.AddRange(this.mailTextBox.Lines);
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.LastName == "" || Properties.Settings.Default.FirstName=="" || Properties.Settings.Default.Email=="" || Properties.Settings.Default.Phone=="" || Properties.Settings.Default.Job=="")
            {
                new OptionsForm(parent).Show();
                this.Close();
            }
            else
            {
                parent.updateCampaigns();
                this.Close();
            }           
        }
    }
}
