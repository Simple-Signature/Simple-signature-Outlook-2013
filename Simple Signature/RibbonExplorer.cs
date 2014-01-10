using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace Simple_Signature
{
    public partial class RibbonExplorer
    {
        public SimpleSign parent = null;
        private void RibbonExplorer_Load(object sender, RibbonUIEventArgs e)
        {
            this.showOptions.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.showOptions_Click);
            this.showAdvancedOptions.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.showAdvancedOptions_Click);
        }

        private void showOptions_Click(object sender, RibbonControlEventArgs e)
        {
            new OptionsForm(parent).Show();
        }
        private void showAdvancedOptions_Click(object sender, RibbonControlEventArgs e)
        {
            new AdvancedOptionsForm(parent).Show();
        }
    }
}
