
namespace WizardQuestGUIApp
{
    partial class AdministrationForm
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
            this.progressLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.usersLabel = new System.Windows.Forms.Label();
            this.globalUserData = new System.Windows.Forms.DataGridView();
            this.activeQuestData = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.killQuestButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.globalUserData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeQuestData)).BeginInit();
            this.SuspendLayout();
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(8, 122);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(161, 20);
            this.progressLabel.TabIndex = 13;
            this.progressLabel.Text = "Quests in Progress";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(138, 41);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(346, 25);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "Wizard Quest Administration Portal";
            // 
            // usersLabel
            // 
            this.usersLabel.AutoSize = true;
            this.usersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersLabel.Location = new System.Drawing.Point(282, 122);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(169, 20);
            this.usersLabel.TabIndex = 15;
            this.usersLabel.Text = "Wizard Quest Users";
            // 
            // globalUserData
            // 
            this.globalUserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.globalUserData.Location = new System.Drawing.Point(286, 145);
            this.globalUserData.Name = "globalUserData";
            this.globalUserData.Size = new System.Drawing.Size(203, 330);
            this.globalUserData.TabIndex = 14;
            // 
            // activeQuestData
            // 
            this.activeQuestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activeQuestData.Location = new System.Drawing.Point(12, 145);
            this.activeQuestData.Name = "activeQuestData";
            this.activeQuestData.Size = new System.Drawing.Size(232, 330);
            this.activeQuestData.TabIndex = 16;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 509);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(103, 23);
            this.backButton.TabIndex = 17;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // killQuestButton
            // 
            this.killQuestButton.Location = new System.Drawing.Point(141, 509);
            this.killQuestButton.Name = "killQuestButton";
            this.killQuestButton.Size = new System.Drawing.Size(103, 23);
            this.killQuestButton.TabIndex = 18;
            this.killQuestButton.Text = "Kill Quest";
            this.killQuestButton.UseVisualStyleBackColor = true;
            this.killQuestButton.Click += new System.EventHandler(this.killQuestButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(518, 145);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(103, 23);
            this.newButton.TabIndex = 19;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(518, 192);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(103, 23);
            this.modifyButton.TabIndex = 20;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(518, 239);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(103, 23);
            this.deleteButton.TabIndex = 21;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 553);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.killQuestButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.activeQuestData);
            this.Controls.Add(this.usersLabel);
            this.Controls.Add(this.globalUserData);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdministrationForm";
            this.Text = "Wizard Quest Administration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministrationForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.globalUserData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeQuestData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.DataGridView globalUserData;
        private System.Windows.Forms.DataGridView activeQuestData;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button killQuestButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button deleteButton;
    }
}