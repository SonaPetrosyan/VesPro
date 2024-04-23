using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp4
{
     partial class users
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
            this.message = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HelpButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchBox2 = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.Orange;
            this.message.Location = new System.Drawing.Point(136, 512);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(366, 30);
            this.message.TabIndex = 9;
            this.message.Tag = "4";
            this.message.Text = "message";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.message.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dataGridView1.Location = new System.Drawing.Point(2, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 6;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1128, 440);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.HelpButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SearchBox2);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 58);
            this.panel1.TabIndex = 16;
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.Orange;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.ForeColor = System.Drawing.Color.White;
            this.HelpButton.Location = new System.Drawing.Point(4, 3);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(35, 33);
            this.HelpButton.TabIndex = 66;
            this.HelpButton.Text = "?";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(114, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "search";
            // 
            // SearchBox2
            // 
            this.SearchBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SearchBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox2.Location = new System.Drawing.Point(58, 32);
            this.SearchBox2.Name = "SearchBox2";
            this.SearchBox2.Size = new System.Drawing.Size(186, 24);
            this.SearchBox2.TabIndex = 37;
            this.SearchBox2.TextChanged += new System.EventHandler(this.SearchBox2_TextChanged);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AddButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddButton.FlatAppearance.BorderSize = 2;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(315, 23);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(60, 32);
            this.AddButton.TabIndex = 36;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SaveButton.FlatAppearance.BorderSize = 2;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(778, 19);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 36);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(11, 503);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(47, 40);
            this.richTextBox1.TabIndex = 67;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Login";
            this.Column2.HeaderText = "Login";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Password";
            this.Column3.HeaderText = "Password";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Passqart";
            this.Column4.HeaderText = "Passqart";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Position";
            this.Column5.HeaderText = "Position";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Name";
            this.Column6.HeaderText = "Name";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "manager";
            this.Column7.HeaderText = "manager";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "orderer";
            this.Column8.HeaderText = "orderer";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "editor";
            this.Column9.HeaderText = "editor";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "previous";
            this.Column10.HeaderText = "previous";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Width = 50;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "observer";
            this.Column11.HeaderText = "observer";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column11.Width = 50;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "workplace";
            this.Column12.HeaderText = "workplace";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.Width = 50;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Holl";
            this.Column13.HeaderText = "Holl";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.Width = 50;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Restaurant";
            this.Column14.HeaderText = "Restaurant";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.Width = 50;
            // 
            // users
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1129, 551);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.message);
            this.Controls.Add(this.panel1);
            this.Name = "users";
            this.ResizeBegin += new System.EventHandler(this.users_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.users_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label message;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button SaveButton;
        private Label label2;
        private TextBox SearchBox2;
        private Button AddButton;
        private Button HelpButton;
        private RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewCheckBoxColumn Column7;
        private DataGridViewCheckBoxColumn Column8;
        private DataGridViewCheckBoxColumn Column9;
        private DataGridViewCheckBoxColumn Column10;
        private DataGridViewCheckBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
    }
 
}
