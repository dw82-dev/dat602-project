
namespace WizardQuestGUIApp
{
    partial class NewQuestForm
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
            this.questNameText = new System.Windows.Forms.TextBox();
            this.questNameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questNameText
            // 
            this.questNameText.Location = new System.Drawing.Point(31, 59);
            this.questNameText.Name = "questNameText";
            this.questNameText.Size = new System.Drawing.Size(274, 20);
            this.questNameText.TabIndex = 5;
            // 
            // questNameLabel
            // 
            this.questNameLabel.AutoSize = true;
            this.questNameLabel.Location = new System.Drawing.Point(32, 34);
            this.questNameLabel.Name = "questNameLabel";
            this.questNameLabel.Size = new System.Drawing.Size(124, 13);
            this.questNameLabel.TabIndex = 4;
            this.questNameLabel.Text = "Enter a new Quest name";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(230, 90);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // NewQuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 140);
            this.Controls.Add(this.questNameText);
            this.Controls.Add(this.questNameLabel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewQuestForm";
            this.Text = "New Quest Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox questNameText;
        private System.Windows.Forms.Label questNameLabel;
        private System.Windows.Forms.Button okButton;
    }
}