
namespace WizardQuestGUIApp
{
    partial class LoginForm
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
            this.wizardQuestLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.wizardPicture = new System.Windows.Forms.PictureBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wizardPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardQuestLabel
            // 
            this.wizardQuestLabel.AutoSize = true;
            this.wizardQuestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardQuestLabel.Location = new System.Drawing.Point(76, 15);
            this.wizardQuestLabel.Name = "wizardQuestLabel";
            this.wizardQuestLabel.Size = new System.Drawing.Size(142, 25);
            this.wizardQuestLabel.TabIndex = 0;
            this.wizardQuestLabel.Text = "Wizard Quest";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(44, 258);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(46, 307);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // wizardPicture
            // 
            this.wizardPicture.Image = global::WizardQuestGUIApp.Properties.Resources.wizard02;
            this.wizardPicture.Location = new System.Drawing.Point(47, 60);
            this.wizardPicture.Name = "wizardPicture";
            this.wizardPicture.Size = new System.Drawing.Size(197, 166);
            this.wizardPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.wizardPicture.TabIndex = 3;
            this.wizardPicture.TabStop = false;
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(47, 275);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(197, 20);
            this.usernameText.TabIndex = 4;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(47, 324);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(197, 20);
            this.passwordText.TabIndex = 5;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(47, 373);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete Account";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(169, 373);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 426);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.wizardPicture);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.wizardQuestLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.wizardPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wizardQuestLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.PictureBox wizardPicture;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button loginButton;
    }
}