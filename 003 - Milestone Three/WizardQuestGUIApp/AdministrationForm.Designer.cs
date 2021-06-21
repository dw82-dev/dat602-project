
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
            this.gloablUserData = new System.Windows.Forms.DataGridView();
            this.activeQuestData = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gloablUserData)).BeginInit();
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
            this.usersLabel.Location = new System.Drawing.Point(392, 122);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(169, 20);
            this.usersLabel.TabIndex = 15;
            this.usersLabel.Text = "Wizard Quest Users";
            // 
            // allUserData
            // 
            this.gloablUserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gloablUserData.Location = new System.Drawing.Point(396, 145);
            this.gloablUserData.Name = "allUserData";
            this.gloablUserData.Size = new System.Drawing.Size(218, 330);
            this.gloablUserData.TabIndex = 14;
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
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 631);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.activeQuestData);
            this.Controls.Add(this.usersLabel);
            this.Controls.Add(this.gloablUserData);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdministrationForm";
            this.Text = "AdministrationForm";
            ((System.ComponentModel.ISupportInitialize)(this.gloablUserData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeQuestData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.DataGridView gloablUserData;
        private System.Windows.Forms.DataGridView activeQuestData;
        private System.Windows.Forms.Button backButton;
    }
}