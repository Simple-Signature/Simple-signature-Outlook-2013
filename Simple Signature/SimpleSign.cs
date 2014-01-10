using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Newtonsoft.Json;
using System.Configuration;

namespace Simple_Signature
{
    public partial class SimpleSign
    {
        const string PR_SMTP_ADDRESS = "http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
        Outlook.Inspectors inspectors;
        Outlook.MailItem mailItem;
        public Signatures[] campaigns;
        public Signatures currentSignature;
        static string path = (System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName + "\\Roaming\\Microsoft\\Signatures\\").Replace("\\","\\\\");

        private void SimpleSign_Startup(object sender, System.EventArgs e)
        {
            this.Application.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
            Globals.SimpleSign.Application.OptionsPagesAdd += new Outlook.ApplicationEvents_11_OptionsPagesAddEventHandler(Application_OptionsPagesAdd);
            Globals.Ribbons.RibbonExplorer.parent = this;
            Globals.Ribbons.RibbonMail.parent = this;
            if (Properties.Settings.Default.URLSimpleSign == "")
            {
                Properties.Settings.Default.URLSimpleSign ="http://simplesignature.meteor.com/";
                if (System.Configuration.ConfigurationManager.AppSettings != null && System.Configuration.ConfigurationManager.AppSettings["firm"] != null || System.Configuration.ConfigurationManager.AppSettings["firm"] != "")
                {
                    Properties.Settings.Default.Firm = System.Configuration.ConfigurationManager.AppSettings["firm"];
                    Properties.Settings.Default.mailInterne = new System.Collections.Specialized.StringCollection();
                    Properties.Settings.Default.mailInterne.AddRange(System.Configuration.ConfigurationManager.AppSettings["mailInterne"].Split(';'));
                }
            }
            if (Properties.Settings.Default.FirstName == "")
            {
                this.getInfoFromUser();
            }
            if (Properties.Settings.Default.Firm == "")
            {
                new WelcomeForm(this).Show();
            }
            else
            {
                this.updateCampaigns();
            }           
        }

        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            mailItem = Item as Outlook.MailItem;

            if (mailItem != null)
            {
                if (currentSignature != null)
                {
                    int interne = 0;
                    int externe = 0;
                    foreach (Outlook.Recipient recip in mailItem.Recipients)
                    {
                        string smtpAddress = recip.PropertyAccessor.GetProperty(PR_SMTP_ADDRESS).ToString();
                        if (smtpAddress != null && smtpAddress.Split('@')[1] != null && (Properties.Settings.Default.mailInterne == null || !Properties.Settings.Default.mailInterne.Contains(smtpAddress.Split('@')[1])))
                        {
                            externe++;
                        }
                        else
                        {
                            interne++;
                        }
                    }
                    GET(Properties.Settings.Default.URLSimpleSign + "API/stats/" + currentSignature.Firm+"/"+currentSignature.Id + "/" + externe+"/"+interne);
                }
            }
        }

        private void getInfoFromUser()
        {
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
            {
                User user = User.FindByIdentity(ctx, UserPrincipal.Current.UserPrincipalName);
                if (user != null)
                {
                    Properties.Settings.Default.FirstName = user.GivenName;
                    Properties.Settings.Default.LastName = user.Surname;
                    Properties.Settings.Default.Email = user.EmailAddress;
                    Properties.Settings.Default.Phone = user.VoiceTelephoneNumber;
                    Properties.Settings.Default.Job = user.Title;
                }
            }
        }


        public void updateCampaigns()
        {
            string response = GET(Properties.Settings.Default.URLSimpleSign +"API/signs/"+ Properties.Settings.Default.Firm + "/" + Properties.Settings.Default.Service);
            if(response !="erreur") {
                response = response.Replace("PATHAPPDATA", path);
                response = response.Replace("VARIABLE_NAME", Properties.Settings.Default.FirstName + " " + Properties.Settings.Default.LastName);
                response = response.Replace("VARIABLE_JOB", Properties.Settings.Default.Job);
                response = response.Replace("VARIABLE_PHONE", Properties.Settings.Default.Phone);
                response = response.Replace("VARIABLE_MAIL", Properties.Settings.Default.Email);
                campaigns = JsonConvert.DeserializeObject<Signatures[]>(response);
                campaigns = campaigns.OrderBy(sign => sign.CreatedAt).ToArray();
                Globals.Ribbons.RibbonMail.SignatureGallery.Items.Clear();
                foreach (var signature in campaigns)
	            {
                    Microsoft.Office.Tools.Ribbon.RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                    item.Label = signature.Name;
                    item.Image = Base64ToImage(signature.Image);
                    item.ScreenTip = signature.Name;
                    Globals.Ribbons.RibbonMail.SignatureGallery.Items.Add(item);
	            }
                WebClient webClient = new WebClient();
                foreach (var item in response.Split(new string[] { "<img alt=\\\"\\\" src=\\\"" }, StringSplitOptions.None))
                {
                    if (item.StartsWith(path))
                    {
                        string file = item.Split(new string[] { "\"" }, StringSplitOptions.None)[0];
                        if(!File.Exists(file))
                        {
                            string url = Properties.Settings.Default.URLSimpleSign + "cfs/files/images/" + file.Split(new string[] { path }, StringSplitOptions.None)[1].Split(new string[] { "\\" }, StringSplitOptions.None)[0];
                            webClient.DownloadFile(url, url.Replace(Properties.Settings.Default.URLSimpleSign + "cfs/files/images/",path));
                        }
                    }
                }
                
            }           
        }

        void Application_OptionsPagesAdd(Outlook.PropertyPages Pages)
        {
            Pages.Add(new OptionsForm(this));
        }

        private void mailItem_Open(ref bool Cancel)
        {
            Boolean interne = true;
            foreach (Outlook.Recipient recip in mailItem.Recipients)
            {
                string smtpAddress = recip.PropertyAccessor.GetProperty(PR_SMTP_ADDRESS).ToString();
                if (smtpAddress != null && smtpAddress.Split('@')[1] != null && (Properties.Settings.Default.mailInterne == null || !Properties.Settings.Default.mailInterne.Contains(smtpAddress.Split('@')[1])))
                {
                    interne = false;
                    break;
                }
            }
            if (interne)
            {
                mailItem.HTMLBody = mailItem.HTMLBody.Replace("<div class=WordSection1>", "<div class=WordSection1><br/><br/><div id='signature'>" + Signatures.getDefaultInterne(campaigns, this).Value + "</div>");
            }
            else
            {
                mailItem.HTMLBody = mailItem.HTMLBody.Replace("<div class=WordSection1>", "<div class=WordSection1><br/><br/><div id='signature'>" + Signatures.getFirstExterne(campaigns, this).Value + "</div>");
            }
            mailItem.Open -= mailItem_Open;
        }

        void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {           
            mailItem = Inspector.CurrentItem as Outlook.MailItem;

            if (mailItem != null)
            {
                if (campaigns.Length != 0)
                {
                    if (mailItem.EntryID == null)
                    {
                        if (mailItem.HTMLBody != "" && mailItem.HTMLBody.Contains("<div class=WordSection1>"))
                        {
                            mailItem.Open += new Outlook.ItemEvents_10_OpenEventHandler(mailItem_Open);
                        }
                        else
                        {
                            mailItem.HTMLBody = "<br/><br/><div id='signature'>" + Signatures.getDefaultInterne(campaigns, this).Value + "</div>" + mailItem.HTMLBody;
                        }
                        mailItem.PropertyChange += RecipientsPropertyChange;
                    }
                }
            }
            
           
        }

        private void RecipientsPropertyChange(string name)
        {
            if (name == "CC")
            {
                Boolean interne = true;
                foreach (Outlook.Recipient recip in mailItem.Recipients)
                {
                    string smtpAddress = recip.PropertyAccessor.GetProperty(PR_SMTP_ADDRESS).ToString();
                    if (smtpAddress != null && smtpAddress.Split('@')[1] != null && (Properties.Settings.Default.mailInterne==null || !Properties.Settings.Default.mailInterne.Contains(smtpAddress.Split('@')[1])))
                    {
                        interne = false;
                        break;
                    }
                }
                string body = mailItem.HTMLBody;
                System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("(\\<div\\ id='signature'\\>).{0,}?(\\</div\\>)|(\\<div\\ id=signature\\>).{0,}?(\\</div\\>)");
                if (interne)
                {
                    body = myRegex.Replace(body.Replace("\r\n", ""), "<div id='signature'>" + Signatures.getDefaultInterne(campaigns, this).Value + "</div>", 1);
                }
                else
                {
                    body = myRegex.Replace(body.Replace("\r\n", ""), "<div id='signature'>" + Signatures.getFirstExterne(campaigns, this).Value + "</div>", 1);
                }
                mailItem.HTMLBody = body;
            }
        }

        public void updateSignature(string name)
        {
                string body = mailItem.HTMLBody;
                System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex("(\\<div\\ id='signature'\\>).{0,}?(\\</div\\>)|(\\<div\\ id=signature\\>).{0,}?(\\</div\\>)");
                body = myRegex.Replace(body.Replace("\r\n", ""), "<div id='signature'>" + Signatures.getSignature(campaigns, this, name).Value + "</div>", 1);
                mailItem.HTMLBody = body;         
        }

        private void SimpleSign_Shutdown(object sender, System.EventArgs e)
        {
        }

        public System.Drawing.Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            if(base64String != null)
            {
                byte[] imageBytes = Convert.FromBase64String(base64String.Replace("data:image/png;base64,",""));
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                return image;
            }
            return null;
        }

        string GET(string url) 
        {
            Console.Write(url);
            try {
                using (WebClient client = new WebClient())
                {
                    string s = client.DownloadString(url);
                    return s;
                }
            }
            catch (Exception ex) {
                if(ex.Message=="Le serveur distant a retourné une erreur : (400) Demande incorrecte.")
                    new ConnexionErrorForm("noAccount").Show();
                else
                    new ConnexionErrorForm().Show();
                return "erreur";
            }
        }

        #region Code généré par VSTO

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(SimpleSign_Startup);
            this.Shutdown += new System.EventHandler(SimpleSign_Shutdown);
        }
        
        #endregion
    }
}
