using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace Simple_Signature
{
    public partial class RibbonMail
    {
        public SimpleSign parent = null;
        private void RibbonMail_Load(object sender, RibbonUIEventArgs e)
        {
            this.SignatureGallery.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signature_Click);
        }

        private void signature_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Tools.Ribbon.RibbonGallery item = sender as Microsoft.Office.Tools.Ribbon.RibbonGallery;
            if (item.SelectedItem != null)
            {
                parent.updateSignature(item.SelectedItem.Label);
            }

        }
    }
}
