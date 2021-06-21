
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
            ((System.ComponentModel.ISupportInitialize)(this.usersOnlineData)).BeginInit();
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
            this.usersOnlineData.Size = new System.Drawing.Size(240, 330);
            this.usersOnlineData.TabIndex = 2;
            // 
            // QuestSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.usersOnlineData);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "QuestSelectionForm";
            this.Text = "Quest Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestSelectionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.usersOnlineData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.DataGridView usersOnlineData;
    }
}