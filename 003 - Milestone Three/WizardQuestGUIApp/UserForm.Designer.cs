
namespace WizardQuestGUIApp
{
    partial class UserForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.emailText = new System.Windows.Forms.TextBox();
            this.lockedCheckBox = new System.Windows.Forms.CheckBox();
            this.administratorCheckBox = new System.Windows.Forms.CheckBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.totalScoreLabel = new System.Windows.Forms.Label();
            this.totalScoreNumeric = new System.Windows.Forms.NumericUpDown();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.userIDNumeric = new System.Windows.Forms.NumericUpDown();
            this.loginAttemptsNumeric = new System.Windows.Forms.NumericUpDown();
            this.loginAttemptsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.totalScoreNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIDNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginAttemptsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(335, 25);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Wizard Quest User Administration";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 404);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(103, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(244, 404);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(103, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(128, 106);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(207, 20);
            this.usernameText.TabIndex = 4;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(128, 132);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(207, 20);
            this.passwordText.TabIndex = 5;
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(128, 187);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(207, 20);
            this.emailText.TabIndex = 6;
            // 
            // lockedCheckBox
            // 
            this.lockedCheckBox.AutoSize = true;
            this.lockedCheckBox.Location = new System.Drawing.Point(128, 266);
            this.lockedCheckBox.Name = "lockedCheckBox";
            this.lockedCheckBox.Size = new System.Drawing.Size(62, 17);
            this.lockedCheckBox.TabIndex = 8;
            this.lockedCheckBox.Text = "Locked";
            this.lockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // administratorCheckBox
            // 
            this.administratorCheckBox.AutoSize = true;
            this.administratorCheckBox.Location = new System.Drawing.Point(128, 289);
            this.administratorCheckBox.Name = "administratorCheckBox";
            this.administratorCheckBox.Size = new System.Drawing.Size(86, 17);
            this.administratorCheckBox.TabIndex = 9;
            this.administratorCheckBox.Text = "Administrator";
            this.administratorCheckBox.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(14, 113);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(14, 135);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 11;
            this.passwordLabel.Text = "Password";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(14, 190);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 12;
            this.emailLabel.Text = "Email";
            // 
            // totalScoreLabel
            // 
            this.totalScoreLabel.AutoSize = true;
            this.totalScoreLabel.Location = new System.Drawing.Point(14, 216);
            this.totalScoreLabel.Name = "totalScoreLabel";
            this.totalScoreLabel.Size = new System.Drawing.Size(62, 13);
            this.totalScoreLabel.TabIndex = 13;
            this.totalScoreLabel.Text = "Total Score";
            // 
            // totalScoreNumeric
            // 
            this.totalScoreNumeric.Location = new System.Drawing.Point(128, 214);
            this.totalScoreNumeric.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.totalScoreNumeric.Name = "totalScoreNumeric";
            this.totalScoreNumeric.Size = new System.Drawing.Size(207, 20);
            this.totalScoreNumeric.TabIndex = 14;
            // 
            // userIDLabel
            // 
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Location = new System.Drawing.Point(16, 85);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(40, 13);
            this.userIDLabel.TabIndex = 16;
            this.userIDLabel.Text = "UserID";
            // 
            // userIDNumeric
            // 
            this.userIDNumeric.Location = new System.Drawing.Point(128, 80);
            this.userIDNumeric.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.userIDNumeric.Name = "userIDNumeric";
            this.userIDNumeric.Size = new System.Drawing.Size(207, 20);
            this.userIDNumeric.TabIndex = 17;
            // 
            // loginAttemptsNumeric
            // 
            this.loginAttemptsNumeric.Location = new System.Drawing.Point(128, 158);
            this.loginAttemptsNumeric.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.loginAttemptsNumeric.Name = "loginAttemptsNumeric";
            this.loginAttemptsNumeric.Size = new System.Drawing.Size(207, 20);
            this.loginAttemptsNumeric.TabIndex = 18;
            // 
            // loginAttemptsLabel
            // 
            this.loginAttemptsLabel.AutoSize = true;
            this.loginAttemptsLabel.Location = new System.Drawing.Point(16, 165);
            this.loginAttemptsLabel.Name = "loginAttemptsLabel";
            this.loginAttemptsLabel.Size = new System.Drawing.Size(77, 13);
            this.loginAttemptsLabel.TabIndex = 19;
            this.loginAttemptsLabel.Text = "Login Attempts";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 450);
            this.Controls.Add(this.loginAttemptsLabel);
            this.Controls.Add(this.loginAttemptsNumeric);
            this.Controls.Add(this.userIDNumeric);
            this.Controls.Add(this.userIDLabel);
            this.Controls.Add(this.totalScoreNumeric);
            this.Controls.Add(this.totalScoreLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.administratorCheckBox);
            this.Controls.Add(this.lockedCheckBox);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserForm";
            this.Text = "User Administration";
            ((System.ComponentModel.ISupportInitialize)(this.totalScoreNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIDNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginAttemptsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label totalScoreLabel;
        public System.Windows.Forms.TextBox usernameText;
        public System.Windows.Forms.TextBox passwordText;
        public System.Windows.Forms.TextBox emailText;
        public System.Windows.Forms.CheckBox lockedCheckBox;
        public System.Windows.Forms.CheckBox administratorCheckBox;
        public System.Windows.Forms.NumericUpDown totalScoreNumeric;
        private System.Windows.Forms.Label userIDLabel;
        public System.Windows.Forms.NumericUpDown userIDNumeric;
        public System.Windows.Forms.NumericUpDown loginAttemptsNumeric;
        private System.Windows.Forms.Label loginAttemptsLabel;
    }
}