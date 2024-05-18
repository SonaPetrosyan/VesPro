namespace WindowsFormsApp4
{
    partial class HelpDialogForm
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
            this.richTextBoxHelpContent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxHelpContent
            // 
            this.richTextBoxHelpContent.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBoxHelpContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxHelpContent.ForeColor = System.Drawing.SystemColors.InfoText;
            this.richTextBoxHelpContent.Location = new System.Drawing.Point(-4, 2);
            this.richTextBoxHelpContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxHelpContent.Name = "richTextBoxHelpContent";
            this.richTextBoxHelpContent.Size = new System.Drawing.Size(1045, 463);
            this.richTextBoxHelpContent.TabIndex = 0;
            this.richTextBoxHelpContent.Text = "";
            this.richTextBoxHelpContent.TextChanged += new System.EventHandler(this.richTextBoxHelpContent_TextChanged);
            // 
            // HelpDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1032, 458);
            this.Controls.Add(this.richTextBoxHelpContent);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HelpDialogForm";
            this.Text = "Օգնություն";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxHelpContent;
    }
}