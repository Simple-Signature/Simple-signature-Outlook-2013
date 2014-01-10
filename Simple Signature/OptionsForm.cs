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
    public partial class OptionsForm : Form
    {
        SimpleSign parent = null;
        public OptionsForm(SimpleSign s)
        {
            parent = s;
            InitializeComponent();
            this.BackColor = Color.FromArgb(142, 68, 173);
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.lastNameTextBox.Text = Properties.Settings.Default.LastName;
            this.firstNameTextBox.Text = Properties.Settings.Default.FirstName;
            this.phoneTextBox.Text = Properties.Settings.Default.Phone;
            this.emailTextBox.Text = Properties.Settings.Default.Email;
            this.jobTextBox.Text = Properties.Settings.Default.Job;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastName = this.lastNameTextBox.Text;
            Properties.Settings.Default.FirstName = this.firstNameTextBox.Text;
            Properties.Settings.Default.Email = this.emailTextBox.Text;
            Properties.Settings.Default.Phone = this.phoneTextBox.Text;
            Properties.Settings.Default.Job = this.jobTextBox.Text;
            Properties.Settings.Default.Save();
            parent.updateCampaigns();
            this.Close();
        }

    }
}
