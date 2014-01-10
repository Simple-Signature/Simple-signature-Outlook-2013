namespace Simple_Signature
{
    partial class AdvancedOptionsForm
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
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.ou = new System.Windows.Forms.Label();
            this.firmTextBox = new System.Windows.Forms.TextBox();
            this.serviceTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.LinkLabel();
            this.saveButton = new System.Windows.Forms.Button();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.ForeColor = System.Drawing.Color.White;
            this.LastNameLabel.Location = new System.Drawing.Point(167, 42);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(69, 13);
            this.LastNameLabel.TabIndex = 0;
            this.LastNameLabel.Text = "Firm\'s name *";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.ForeColor = System.Drawing.Color.White;
            this.firstNameLabel.Location = new System.Drawing.Point(157, 72);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(79, 13);
            this.firstNameLabel.TabIndex = 1;
            this.firstNameLabel.Text = "Service\'s name";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.ForeColor = System.Drawing.Color.White;
            this.emailLabel.Location = new System.Drawing.Point(103, 102);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(133, 13);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "URL de Simple Signature *";
            // 
            // ou
            // 
            this.ou.AutoSize = true;
            this.ou.ForeColor = System.Drawing.Color.White;
            this.ou.Location = new System.Drawing.Point(440, 146);
            this.ou.Name = "ou";
            this.ou.Size = new System.Drawing.Size(19, 13);
            this.ou.TabIndex = 5;
            this.ou.Text = "ou";
            // 
            // firmTextBox
            // 
            this.firmTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firmTextBox.Location = new System.Drawing.Point(249, 42);
            this.firmTextBox.Name = "firmTextBox";
            this.firmTextBox.Size = new System.Drawing.Size(293, 13);
            this.firmTextBox.TabIndex = 6;
            // 
            // serviceTextBox
            // 
            this.serviceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serviceTextBox.Location = new System.Drawing.Point(249, 72);
            this.serviceTextBox.Name = "serviceTextBox";
            this.serviceTextBox.Size = new System.Drawing.Size(293, 13);
            this.serviceTextBox.TabIndex = 7;
            // 
            // urlTextBox
            // 
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlTextBox.Location = new System.Drawing.Point(249, 102);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(293, 13);
            this.urlTextBox.TabIndex = 8;
            // 
            // cancelButton
            // 
            this.cancelButton.ActiveLinkColor = System.Drawing.Color.White;
            this.cancelButton.AutoSize = true;
            this.cancelButton.DisabledLinkColor = System.Drawing.Color.White;
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.LinkColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(484, 146);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(43, 13);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.TabStop = true;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.VisitedLinkColor = System.Drawing.Color.Black;
            this.cancelButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cancelButton_LinkClicked);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LimeGreen;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(458, 196);
            this.saveButton.Name = "saveButton";
            this.saveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.saveButton.Size = new System.Drawing.Size(84, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Enregistrer";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // mailTextBox
            // 
            this.mailTextBox.AcceptsReturn = true;
            this.mailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mailTextBox.Location = new System.Drawing.Point(249, 132);
            this.mailTextBox.Multiline = true;
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(293, 58);
            this.mailTextBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(116, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Domaine de messagerie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(89, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Example : (a@b.c) entrez b.c ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "S\'il y a plusieurs domaines, un sur chaque ligne";
            // 
            // AdvancedOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(619, 231);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.serviceTextBox);
            this.Controls.Add(this.firmTextBox);
            this.Controls.Add(this.ou);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.LastNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedOptionsForm";
            this.ShowIcon = false;
            this.Text = "Simple Signature - Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label ou;
        private System.Windows.Forms.TextBox firmTextBox;
        private System.Windows.Forms.TextBox serviceTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.LinkLabel cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}