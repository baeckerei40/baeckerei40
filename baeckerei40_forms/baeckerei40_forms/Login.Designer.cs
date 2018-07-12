namespace baeckerei40_forms
{
    partial class Login
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.LabelUser = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.richTextBoxBeschreibung = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(91, 210);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // LabelUser
            // 
            this.LabelUser.AutoSize = true;
            this.LabelUser.Location = new System.Drawing.Point(24, 163);
            this.LabelUser.Name = "LabelUser";
            this.LabelUser.Size = new System.Drawing.Size(49, 13);
            this.LabelUser.TabIndex = 1;
            this.LabelUser.Text = "Benutzer";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(80, 159);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 2;
            this.textBoxUser.Text = "Manager";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Passwort";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(80, 186);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 4;
            // 
            // richTextBoxBeschreibung
            // 
            this.richTextBoxBeschreibung.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBoxBeschreibung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxBeschreibung.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxBeschreibung.Name = "richTextBoxBeschreibung";
            this.richTextBoxBeschreibung.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxBeschreibung.Size = new System.Drawing.Size(286, 147);
            this.richTextBoxBeschreibung.TabIndex = 5;
            this.richTextBoxBeschreibung.Text = "Beschreibung:  \nSie können sich als Manager, \nVertieb oder Produktion einloggen.\n" +
    "\nJe nach Benutzer sind einige Tabs deaktiviert.\n\nEs wird kein Passwort benötigt." +
    "";
            this.richTextBoxBeschreibung.TextChanged += new System.EventHandler(this.richTextBoxBeschreibung_TextChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 267);
            this.Controls.Add(this.richTextBoxBeschreibung);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.LabelUser);
            this.Controls.Add(this.buttonLogin);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label LabelUser;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.RichTextBox richTextBoxBeschreibung;
    }
}