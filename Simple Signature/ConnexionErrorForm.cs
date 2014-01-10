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
    public partial class ConnexionErrorForm : Form
    {
        public ConnexionErrorForm(String s)
        {
            InitializeComponent();
            if (s == "noAccount")
            {
                this.label2.Text = "Il semble que vous n'avez pas créé";
                this.label3.Text = "de compte Simple Signature";
            }       
        }

        public ConnexionErrorForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
