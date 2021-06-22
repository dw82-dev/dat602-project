
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
            this.userOnlineData = new System.Windows.Forms.DataGridView();
            this.playersOnlineLabel = new System.Windows.Forms.Label();
            this.activeQuestData = new System.Windows.Forms.DataGridView();
            this.userQuestData = new System.Windows.Forms.DataGridView();
            this.questProgressLabel = new System.Windows.Forms.Label();
            this.savedQuestLabel = new System.Windows.Forms.Label();
            this.administrationButton = new System.Windows.Forms.Button();
            this.highScoresLabel = new System.Windows.Forms.Label();
            this.highScoreData = new System.Windows.Forms.DataGridView();
            this.joinQuestButton = new System.Windows.Forms.Button();
            this.newQuestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userOnlineData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeQuestData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userQuestData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highScoreData)).BeginInit();
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
            this.logoutButton.Size = new System.Drawing.Size(103, 23);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // userOnlineData
            // 
            this.userOnlineData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userOnlineData.Location = new System.Drawing.Point(599, 140);
            this.userOnlineData.Name = "userOnlineData";
            this.userOnlineData.Size = new System.Drawing.Size(170, 330);
            this.userOnlineData.TabIndex = 2;
            // 
            // playersOnlineLabel
            // 
            this.playersOnlineLabel.AutoSize = true;
            this.playersOnlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersOnlineLabel.Location = new System.Drawing.Point(595, 117);
            this.playersOnlineLabel.Name = "playersOnlineLabel";
            this.playersOnlineLabel.Size = new System.Drawing.Size(123, 20);
            this.playersOnlineLabel.TabIndex = 3;
            this.playersOnlineLabel.Text = "Players Online";
            // 
            // activeQuestData
            // 
            this.activeQuestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activeQuestData.Location = new System.Drawing.Point(366, 140);
            this.activeQuestData.Name = "activeQuestData";
            this.activeQuestData.Size = new System.Drawing.Size(170, 139);
            this.activeQuestData.TabIndex = 4;
            // 
            // userQuestData
            // 
            this.userQuestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userQuestData.Location = new System.Drawing.Point(366, 331);
            this.userQuestData.Name = "userQuestData";
            this.userQuestData.Size = new System.Drawing.Size(170, 139);
            this.userQuestData.TabIndex = 5;
            // 
            // questProgressLabel
            // 
            this.questProgressLabel.AutoSize = true;
            this.questProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questProgressLabel.Location = new System.Drawing.Point(362, 117);
            this.questProgressLabel.Name = "questProgressLabel";
            this.questProgressLabel.Size = new System.Drawing.Size(161, 20);
            this.questProgressLabel.TabIndex = 6;
            this.questProgressLabel.Text = "Quests in Progress";
            // 
            // savedQuestLabel
            // 
            this.savedQuestLabel.AutoSize = true;
            this.savedQuestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savedQuestLabel.Location = new System.Drawing.Point(362, 308);
            this.savedQuestLabel.Name = "savedQuestLabel";
            this.savedQuestLabel.Size = new System.Drawing.Size(148, 20);
            this.savedQuestLabel.TabIndex = 7;
            this.savedQuestLabel.Text = "My Saved Quests";
            // 
            // administrationButton
            // 
            this.administrationButton.Location = new System.Drawing.Point(193, 522);
            this.administrationButton.Name = "administrationButton";
            this.administrationButton.Size = new System.Drawing.Size(103, 23);
            this.administrationButton.TabIndex = 8;
            this.administrationButton.Text = "Administration";
            this.administrationButton.UseVisualStyleBackColor = true;
            this.administrationButton.Click += new System.EventHandler(this.administrationButton_Click);
            // 
            // highScoresLabel
            // 
            this.highScoresLabel.AutoSize = true;
            this.highScoresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoresLabel.Location = new System.Drawing.Point(23, 117);
            this.highScoresLabel.Name = "highScoresLabel";
            this.highScoresLabel.Size = new System.Drawing.Size(107, 20);
            this.highScoresLabel.TabIndex = 10;
            this.highScoresLabel.Text = "High Scores";
            // 
            // highScoreData
            // 
            this.highScoreData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.highScoreData.Location = new System.Drawing.Point(27, 140);
            this.highScoreData.Name = "highScoreData";
            this.highScoreData.Size = new System.Drawing.Size(269, 330);
            this.highScoreData.TabIndex = 9;
            // 
            // joinQuestButton
            // 
            this.joinQuestButton.Location = new System.Drawing.Point(407, 522);
            this.joinQuestButton.Name = "joinQuestButton";
            this.joinQuestButton.Size = new System.Drawing.Size(103, 23);
            this.joinQuestButton.TabIndex = 11;
            this.joinQuestButton.Text = "Join Quest";
            this.joinQuestButton.UseVisualStyleBackColor = true;
            this.joinQuestButton.Click += new System.EventHandler(this.joinQuestButton_Click);
            // 
            // newQuestButton
            // 
            this.newQuestButton.Location = new System.Drawing.Point(666, 522);
            this.newQuestButton.Name = "newQuestButton";
            this.newQuestButton.Size = new System.Drawing.Size(103, 23);
            this.newQuestButton.TabIndex = 12;
            this.newQuestButton.Text = "New Quest";
            this.newQuestButton.UseVisualStyleBackColor = true;
            this.newQuestButton.Click += new System.EventHandler(this.newQuestButton_Click);
            // 
            // QuestSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.newQuestButton);
            this.Controls.Add(this.joinQuestButton);
            this.Controls.Add(this.highScoresLabel);
            this.Controls.Add(this.highScoreData);
            this.Controls.Add(this.administrationButton);
            this.Controls.Add(this.savedQuestLabel);
            this.Controls.Add(this.questProgressLabel);
            this.Controls.Add(this.userQuestData);
            this.Controls.Add(this.activeQuestData);
            this.Controls.Add(this.playersOnlineLabel);
            this.Controls.Add(this.userOnlineData);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "QuestSelectionForm";
            this.Text = "Quest Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestSelectionForm_FormClosing);
            this.Load += new System.EventHandler(this.QuestSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userOnlineData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeQuestData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userQuestData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highScoreData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.DataGridView userOnlineData;
        private System.Windows.Forms.Label playersOnlineLabel;
        private System.Windows.Forms.DataGridView activeQuestData;
        private System.Windows.Forms.DataGridView userQuestData;
        private System.Windows.Forms.Label questProgressLabel;
        private System.Windows.Forms.Label savedQuestLabel;
        private System.Windows.Forms.Button administrationButton;
        private System.Windows.Forms.Label highScoresLabel;
        private System.Windows.Forms.DataGridView highScoreData;
        private System.Windows.Forms.Button joinQuestButton;
        private System.Windows.Forms.Button newQuestButton;
    }
}