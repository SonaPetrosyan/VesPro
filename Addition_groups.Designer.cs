namespace WindowsFormsApp4
{
    partial class Addition_groups
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SaveButton = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Savebutton1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Gainsboro;
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SaveButton.FlatAppearance.BorderSize = 2;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(657, -123);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 10);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            // 
            // message
            // 
            this.message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.Orange;
            this.message.Location = new System.Drawing.Point(756, -120);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(366, 10);
            this.message.TabIndex = 16;
            this.message.Tag = "4";
            this.message.Text = "message";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.message.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 6;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1175, 338);
            this.dataGridView1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 36);
            this.label1.TabIndex = 19;
            this.label1.Text = "Հավելումների խմբերը";
            // 
            // Savebutton1
            // 
            this.Savebutton1.BackColor = System.Drawing.Color.Gainsboro;
            this.Savebutton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Savebutton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Savebutton1.FlatAppearance.BorderSize = 2;
            this.Savebutton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.Savebutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Savebutton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebutton1.Location = new System.Drawing.Point(449, 11);
            this.Savebutton1.Name = "Savebutton1";
            this.Savebutton1.Size = new System.Drawing.Size(110, 36);
            this.Savebutton1.TabIndex = 21;
            this.Savebutton1.Text = "Save";
            this.Savebutton1.UseVisualStyleBackColor = false;
            this.Savebutton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(565, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 30);
            this.label2.TabIndex = 20;
            this.label2.Tag = "4";
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "group";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "խումբ";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name_1";
            this.Column2.HeaderText = "անուն հայ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 325;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "name_2";
            this.Column3.HeaderText = "անուն անգլ․";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 325;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "name_3";
            this.Column4.HeaderText = "անուն ռուս";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 325;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "deleted";
            this.Column5.HeaderText = "deleted";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Addition_groups
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1200, 425);
            this.Controls.Add(this.Savebutton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.message);
            this.Name = "Addition_groups";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Savebutton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
