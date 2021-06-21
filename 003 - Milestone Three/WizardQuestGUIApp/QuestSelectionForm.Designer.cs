﻿
namespace WizardQuestGUIApp
{
    partial class QuestSelectionForm
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.usersOnlineData = new System.Windows.Forms.DataGridView();
            this.playersOnlineLabel = new System.Windows.Forms.Label();
            this.activeQuestData = new System.Windows.Forms.DataGridView();
            this.userQuestData = new System.Windows.Forms.DataGridView();
            this.questProgressLabel = new System.Windows.Forms.Label();
            this.savedQuestLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usersOnlineData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeQuestData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userQuestData)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(208, 34);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(365, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Welcome to Wizard Quest Username";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(27, 522);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // usersOnlineData
            // 
            this.usersOnlineData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersOnlineData.Location = new System.Drawing.Point(27, 140);
            this.usersOnlineData.Name = "usersOnlineData";
            this.usersOnlineData.Size = new System.Drawing.Size(170, 330);
            this.usersOnlineData.TabIndex = 2;
            // 
            // playersOnlineLabel
            // 
            this.playersOnlineLabel.AutoSize = true;
            this.playersOnlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersOnlineLabel.Location = new System.Drawing.Point(23, 103);
            this.playersOnlineLabel.Name = "playersOnlineLabel";
            this.playersOnlineLabel.Size = new System.Drawing.Size(123, 20);
            this.playersOnlineLabel.TabIndex = 3;
            this.playersOnlineLabel.Text = "Players Online";
            // 
            // activeQuestData
            // 
            this.activeQuestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activeQuestData.Location = new System.Drawing.Point(437, 140);
            this.activeQuestData.Name = "activeQuestData";
            this.activeQuestData.Size = new System.Drawing.Size(170, 139);
            this.activeQuestData.TabIndex = 4;
            // 
            // userQuestData
            // 
            this.userQuestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userQuestData.Location = new System.Drawing.Point(437, 331);
            this.userQuestData.Name = "userQuestData";
            this.userQuestData.Size = new System.Drawing.Size(170, 139);
            this.userQuestData.TabIndex = 5;
            // 
            // questProgressLabel
            // 
            this.questProgressLabel.AutoSize = true;
            this.questProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questProgressLabel.Location = new System.Drawing.Point(433, 103);
            this.questProgressLabel.Name = "questProgressLabel";
            this.questProgressLabel.Size = new System.Drawing.Size(152, 20);
            this.questProgressLabel.TabIndex = 6;
            this.questProgressLabel.Text = "Quest in Progress";
            // 
            // savedQuestLabel
            // 
            this.savedQuestLabel.AutoSize = true;
            this.savedQuestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savedQuestLabel.Location = new System.Drawing.Point(433, 308);
            this.savedQuestLabel.Name = "savedQuestLabel";
            this.savedQuestLabel.Size = new System.Drawing.Size(148, 20);
            this.savedQuestLabel.TabIndex = 7;
            this.savedQuestLabel.Text = "My Saved Quests";
            // 
            // QuestSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.savedQuestLabel);
            this.Controls.Add(this.questProgressLabel);
            this.Controls.Add(this.userQuestData);
            this.Controls.Add(this.activeQuestData);
            this.Controls.Add(this.playersOnlineLabel);
            this.Controls.Add(this.usersOnlineData);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "QuestSelectionForm";
            this.Text = "Quest Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestSelectionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.usersOnlineData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeQuestData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userQuestData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.DataGridView usersOnlineData;
        private System.Windows.Forms.Label playersOnlineLabel;
        private System.Windows.Forms.DataGridView activeQuestData;
        private System.Windows.Forms.DataGridView userQuestData;
        private System.Windows.Forms.Label questProgressLabel;
        private System.Windows.Forms.Label savedQuestLabel;
    }
}