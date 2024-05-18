using System.Windows.Forms;
using System;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{

    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.main11 = new System.Windows.Forms.Button();
            this.main12 = new System.Windows.Forms.Button();
            this.main13 = new System.Windows.Forms.Button();
            this.main14 = new System.Windows.Forms.Button();
            this.main21 = new System.Windows.Forms.Button();
            this.main22 = new System.Windows.Forms.Button();
            this.main23 = new System.Windows.Forms.Button();
            this.main24 = new System.Windows.Forms.Button();
            this.main31 = new System.Windows.Forms.Button();
            this.main32 = new System.Windows.Forms.Button();
            this.main41 = new System.Windows.Forms.Button();
            this.main46 = new System.Windows.Forms.Button();
            this.main42 = new System.Windows.Forms.Button();
            this.main43 = new System.Windows.Forms.Button();
            this.main44 = new System.Windows.Forms.Button();
            this.main45 = new System.Windows.Forms.Button();
            this.Updater_215 = new System.Windows.Forms.Button();
            this.update_211 = new System.Windows.Forms.Button();
            this.update213 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.group = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.main33 = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.main16 = new System.Windows.Forms.Button();
            this.main410 = new System.Windows.Forms.Button();
            this.main34 = new System.Windows.Forms.Button();
            this.main17 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Enabled = false;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(29, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1229, 5);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(105, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Գործողություններ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(419, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Տեղեկատուներ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(704, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Հաշվետվություններ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(1000, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Կարգաբերումներ";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Enabled = false;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Location = new System.Drawing.Point(26, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1229, 5);
            this.label7.TabIndex = 19;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Enabled = false;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Location = new System.Drawing.Point(26, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(5, 508);
            this.label8.TabIndex = 20;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Enabled = false;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Location = new System.Drawing.Point(331, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(5, 508);
            this.label9.TabIndex = 21;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Enabled = false;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Location = new System.Drawing.Point(636, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(5, 508);
            this.label10.TabIndex = 22;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Enabled = false;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Location = new System.Drawing.Point(941, 76);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(5, 508);
            this.label11.TabIndex = 23;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Enabled = false;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Location = new System.Drawing.Point(1251, 76);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(5, 508);
            this.label12.TabIndex = 24;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Enabled = false;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Location = new System.Drawing.Point(26, 582);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1229, 5);
            this.label13.TabIndex = 25;
            this.label13.Text = "label13";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(34, 151);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(295, 430);
            this.label14.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.Enabled = false;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(339, 152);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(296, 425);
            this.label15.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Enabled = false;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(641, 152);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(296, 425);
            this.label16.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.LightGray;
            this.label17.Enabled = false;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(949, 152);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(299, 428);
            this.label17.TabIndex = 29;
            // 
            // main11
            // 
            this.main11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main11.ForeColor = System.Drawing.Color.Brown;
            this.main11.Location = new System.Drawing.Point(36, 158);
            this.main11.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main11.Name = "main11";
            this.main11.Size = new System.Drawing.Size(289, 68);
            this.main11.TabIndex = 30;
            this.main11.Text = "Այցելուի սպասարկում";
            this.main11.UseVisualStyleBackColor = true;
            this.main11.Click += new System.EventHandler(this.main11_Click);
            // 
            // main12
            // 
            this.main12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main12.ForeColor = System.Drawing.Color.Brown;
            this.main12.Location = new System.Drawing.Point(36, 307);
            this.main12.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main12.Name = "main12";
            this.main12.Size = new System.Drawing.Size(289, 61);
            this.main12.TabIndex = 31;
            this.main12.Text = "գնում, տեղափոխում, վաճառք, ծախս";
            this.main12.UseVisualStyleBackColor = true;
            this.main12.Click += new System.EventHandler(this.main12_Click);
            // 
            // main13
            // 
            this.main13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main13.ForeColor = System.Drawing.Color.Brown;
            this.main13.Location = new System.Drawing.Point(36, 374);
            this.main13.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main13.Name = "main13";
            this.main13.Size = new System.Drawing.Size(289, 61);
            this.main13.TabIndex = 32;
            this.main13.Text = "Գույքագրում";
            this.main13.UseVisualStyleBackColor = true;
            this.main13.Click += new System.EventHandler(this.main13_Click);
            // 
            // main14
            // 
            this.main14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main14.ForeColor = System.Drawing.Color.Brown;
            this.main14.Location = new System.Drawing.Point(36, 441);
            this.main14.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main14.Name = "main14";
            this.main14.Size = new System.Drawing.Size(289, 61);
            this.main14.TabIndex = 33;
            this.main14.Text = "Նախնական պատվեր";
            this.main14.UseVisualStyleBackColor = true;
            this.main14.Click += new System.EventHandler(this.main14_Click);
            // 
            // main21
            // 
            this.main21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main21.ForeColor = System.Drawing.Color.Maroon;
            this.main21.Location = new System.Drawing.Point(344, 156);
            this.main21.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main21.Name = "main21";
            this.main21.Size = new System.Drawing.Size(284, 69);
            this.main21.TabIndex = 34;
            this.main21.Text = "Ճաշացուցակ";
            this.main21.UseVisualStyleBackColor = true;
            this.main21.Click += new System.EventHandler(this.main21_Click);
            // 
            // main22
            // 
            this.main22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main22.ForeColor = System.Drawing.Color.Maroon;
            this.main22.Location = new System.Drawing.Point(344, 230);
            this.main22.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main22.Name = "main22";
            this.main22.Size = new System.Drawing.Size(284, 70);
            this.main22.TabIndex = 35;
            this.main22.Text = "նյութ, սպասք, հիմնական";
            this.main22.UseVisualStyleBackColor = true;
            this.main22.Click += new System.EventHandler(this.main22_Click);
            // 
            // main23
            // 
            this.main23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main23.ForeColor = System.Drawing.Color.Maroon;
            this.main23.Location = new System.Drawing.Point(344, 305);
            this.main23.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main23.Name = "main23";
            this.main23.Size = new System.Drawing.Size(284, 69);
            this.main23.TabIndex = 36;
            this.main23.Text = "Ստանդարտ պատվերներ";
            this.main23.UseVisualStyleBackColor = true;
            this.main23.Click += new System.EventHandler(this.main23_Click_1);
            // 
            // main24
            // 
            this.main24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main24.ForeColor = System.Drawing.Color.Maroon;
            this.main24.Location = new System.Drawing.Point(344, 379);
            this.main24.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main24.Name = "main24";
            this.main24.Size = new System.Drawing.Size(284, 59);
            this.main24.TabIndex = 37;
            this.main24.Text = "Գործընկերներ";
            this.main24.UseVisualStyleBackColor = true;
            this.main24.Click += new System.EventHandler(this.main24_Click);
            // 
            // main31
            // 
            this.main31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main31.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main31.ForeColor = System.Drawing.Color.DarkGreen;
            this.main31.Location = new System.Drawing.Point(649, 158);
            this.main31.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main31.Name = "main31";
            this.main31.Size = new System.Drawing.Size(284, 60);
            this.main31.TabIndex = 39;
            this.main31.Text = "Պաշարի շարժ";
            this.main31.UseVisualStyleBackColor = true;
            this.main31.Click += new System.EventHandler(this.main31_Click);
            // 
            // main32
            // 
            this.main32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main32.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main32.ForeColor = System.Drawing.Color.DarkGreen;
            this.main32.Location = new System.Drawing.Point(649, 222);
            this.main32.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main32.Name = "main32";
            this.main32.Size = new System.Drawing.Size(284, 60);
            this.main32.TabIndex = 40;
            this.main32.Text = "Առևտուր";
            this.main32.UseVisualStyleBackColor = true;
            this.main32.Click += new System.EventHandler(this.main32_Click);
            // 
            // main41
            // 
            this.main41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main41.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main41.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main41.ForeColor = System.Drawing.Color.MidnightBlue;
            this.main41.Location = new System.Drawing.Point(954, 206);
            this.main41.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main41.Name = "main41";
            this.main41.Size = new System.Drawing.Size(289, 54);
            this.main41.TabIndex = 44;
            this.main41.Text = "Աշխատատեղեր";
            this.main41.UseVisualStyleBackColor = true;
            this.main41.Click += new System.EventHandler(this.main41_Click);
            // 
            // main46
            // 
            this.main46.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main46.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main46.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main46.ForeColor = System.Drawing.Color.MidnightBlue;
            this.main46.Location = new System.Drawing.Point(954, 488);
            this.main46.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main46.Name = "main46";
            this.main46.Size = new System.Drawing.Size(284, 51);
            this.main46.TabIndex = 45;
            this.main46.Text = "ՀԴՄ";
            this.main46.UseVisualStyleBackColor = true;
            this.main46.Click += new System.EventHandler(this.main46_Click);
            // 
            // main42
            // 
            this.main42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main42.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main42.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main42.ForeColor = System.Drawing.Color.MidnightBlue;
            this.main42.Location = new System.Drawing.Point(954, 263);
            this.main42.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main42.Name = "main42";
            this.main42.Size = new System.Drawing.Size(289, 47);
            this.main42.TabIndex = 46;
            this.main42.Text = "Սեղաններ";
            this.main42.UseVisualStyleBackColor = true;
            this.main42.Click += new System.EventHandler(this.main42_Click);
            // 
            // main43
            // 
            this.main43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main43.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main43.ForeColor = System.Drawing.Color.MidnightBlue;
            this.main43.Location = new System.Drawing.Point(954, 313);
            this.main43.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main43.Name = "main43";
            this.main43.Size = new System.Drawing.Size(139, 54);
            this.main43.TabIndex = 47;
            this.main43.Text = "Ճաշերի խմբեր";
            this.main43.UseVisualStyleBackColor = true;
            this.main43.Click += new System.EventHandler(this.main43_Click);
            // 
            // main44
            // 
            this.main44.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main44.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main44.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main44.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main44.ForeColor = System.Drawing.Color.MidnightBlue;
            this.main44.Location = new System.Drawing.Point(954, 371);
            this.main44.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main44.Name = "main44";
            this.main44.Size = new System.Drawing.Size(289, 53);
            this.main44.TabIndex = 48;
            this.main44.Text = "պատվերի լրացումներ";
            this.main44.UseVisualStyleBackColor = true;
            this.main44.Click += new System.EventHandler(this.main44_Click);
            // 
            // main45
            // 
            this.main45.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main45.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main45.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main45.ForeColor = System.Drawing.Color.MidnightBlue;
            this.main45.Location = new System.Drawing.Point(954, 429);
            this.main45.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main45.Name = "main45";
            this.main45.Size = new System.Drawing.Size(289, 54);
            this.main45.TabIndex = 49;
            this.main45.Text = "աշխատակիցներ";
            this.main45.UseVisualStyleBackColor = true;
            this.main45.Click += new System.EventHandler(this.main45_Click);
            // 
            // Updater_215
            // 
            this.Updater_215.Location = new System.Drawing.Point(834, 15);
            this.Updater_215.Margin = new System.Windows.Forms.Padding(4);
            this.Updater_215.Name = "Updater_215";
            this.Updater_215.Size = new System.Drawing.Size(64, 29);
            this.Updater_215.TabIndex = 51;
            this.Updater_215.Text = "215";
            this.Updater_215.UseVisualStyleBackColor = true;
            this.Updater_215.Visible = false;
            this.Updater_215.Click += new System.EventHandler(this.Updater_215_Click);
            // 
            // update_211
            // 
            this.update_211.Location = new System.Drawing.Point(905, 15);
            this.update_211.Margin = new System.Windows.Forms.Padding(4);
            this.update_211.Name = "update_211";
            this.update_211.Size = new System.Drawing.Size(64, 29);
            this.update_211.TabIndex = 52;
            this.update_211.Text = "211";
            this.update_211.UseVisualStyleBackColor = true;
            this.update_211.Visible = false;
            this.update_211.Click += new System.EventHandler(this.update_211_Click);
            // 
            // update213
            // 
            this.update213.Location = new System.Drawing.Point(976, 18);
            this.update213.Margin = new System.Windows.Forms.Padding(4);
            this.update213.Name = "update213";
            this.update213.Size = new System.Drawing.Size(64, 29);
            this.update213.TabIndex = 54;
            this.update213.Text = "211";
            this.update213.UseVisualStyleBackColor = true;
            this.update213.Visible = false;
            this.update213.Click += new System.EventHandler(this.update213_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1049, 18);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(64, 29);
            this.button13.TabIndex = 56;
            this.button13.Text = "111";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Visible = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // group
            // 
            this.group.Location = new System.Drawing.Point(1120, 18);
            this.group.Margin = new System.Windows.Forms.Padding(4);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(64, 29);
            this.group.TabIndex = 57;
            this.group.Text = "group";
            this.group.UseVisualStyleBackColor = true;
            this.group.Visible = false;
            this.group.Click += new System.EventHandler(this.group_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(1191, 18);
            this.button14.Margin = new System.Windows.Forms.Padding(4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(64, 29);
            this.button14.TabIndex = 58;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Visible = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.Brown;
            this.button15.Location = new System.Drawing.Point(408, 442);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(139, 82);
            this.button15.TabIndex = 59;
            this.button15.Text = "Թարմացում և գույքագրում";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // main33
            // 
            this.main33.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main33.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main33.ForeColor = System.Drawing.Color.DarkGreen;
            this.main33.Location = new System.Drawing.Point(649, 286);
            this.main33.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main33.Name = "main33";
            this.main33.Size = new System.Drawing.Size(284, 82);
            this.main33.TabIndex = 60;
            this.main33.Text = "Դիտարկում";
            this.main33.UseVisualStyleBackColor = true;
            this.main33.Click += new System.EventHandler(this.main15_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.Peru;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.ForeColor = System.Drawing.Color.White;
            this.HelpButton.Location = new System.Drawing.Point(-1, 1);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(35, 33);
            this.HelpButton.TabIndex = 61;
            this.HelpButton.Text = "?";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(954, 156);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 47);
            this.button1.TabIndex = 66;
            this.button1.Text = "select the language";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.Location = new System.Drawing.Point(1162, 156);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 47);
            this.button2.TabIndex = 68;
            this.button2.Text = "Հայ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.radioButton5);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(958, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 142);
            this.panel1.TabIndex = 69;
            this.panel1.Visible = false;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(3, 115);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(94, 24);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Espaniol";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(3, 86);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(91, 24);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Russian";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 57);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(90, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "German";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 28);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "English";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(101, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Armenian";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // main16
            // 
            this.main16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main16.ForeColor = System.Drawing.Color.Brown;
            this.main16.Location = new System.Drawing.Point(36, 230);
            this.main16.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main16.Name = "main16";
            this.main16.Size = new System.Drawing.Size(104, 71);
            this.main16.TabIndex = 70;
            this.main16.Text = "Առաքման պատվեր";
            this.main16.UseVisualStyleBackColor = true;
            this.main16.Click += new System.EventHandler(this.main16_Click);
            // 
            // main410
            // 
            this.main410.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main410.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main410.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main410.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main410.ForeColor = System.Drawing.Color.MidnightBlue;
            this.main410.Location = new System.Drawing.Point(1100, 313);
            this.main410.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main410.Name = "main410";
            this.main410.Size = new System.Drawing.Size(143, 54);
            this.main410.TabIndex = 71;
            this.main410.Text = "Առցանց խմբեր";
            this.main410.UseVisualStyleBackColor = true;
            this.main410.Click += new System.EventHandler(this.main410_Click);
            // 
            // main34
            // 
            this.main34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main34.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main34.ForeColor = System.Drawing.Color.DarkGreen;
            this.main34.Location = new System.Drawing.Point(649, 373);
            this.main34.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main34.Name = "main34";
            this.main34.Size = new System.Drawing.Size(284, 82);
            this.main34.TabIndex = 72;
            this.main34.Text = "պատրաստման ընթացքը";
            this.main34.UseVisualStyleBackColor = true;
            this.main34.Click += new System.EventHandler(this.main34_Click);
            // 
            // main17
            // 
            this.main17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.main17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.main17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main17.ForeColor = System.Drawing.Color.Brown;
            this.main17.Location = new System.Drawing.Point(143, 230);
            this.main17.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.main17.Name = "main17";
            this.main17.Size = new System.Drawing.Size(182, 71);
            this.main17.TabIndex = 73;
            this.main17.Text = "Առաքման պատվերի մշակում";
            this.main17.UseVisualStyleBackColor = true;
            this.main17.Click += new System.EventHandler(this.main17_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1280, 606);
            this.Controls.Add(this.main17);
            this.Controls.Add(this.main34);
            this.Controls.Add(this.main410);
            this.Controls.Add(this.main16);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.main33);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.group);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.update213);
            this.Controls.Add(this.update_211);
            this.Controls.Add(this.Updater_215);
            this.Controls.Add(this.main45);
            this.Controls.Add(this.main44);
            this.Controls.Add(this.main43);
            this.Controls.Add(this.main42);
            this.Controls.Add(this.main46);
            this.Controls.Add(this.main41);
            this.Controls.Add(this.main32);
            this.Controls.Add(this.main31);
            this.Controls.Add(this.main24);
            this.Controls.Add(this.main23);
            this.Controls.Add(this.main22);
            this.Controls.Add(this.main21);
            this.Controls.Add(this.main14);
            this.Controls.Add(this.main13);
            this.Controls.Add(this.main12);
            this.Controls.Add(this.main11);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitForm()
            //Ֆորմայի չափսերը դարձնում ենք լիաէկրան
        {
            decimal screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            decimal screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            decimal kw = screenWidth / this.Width;
            decimal kh = screenHeight / this.Height;
            foreach (Control control in this.Controls)
            {
                 control.Left = (int)(control.Left * (double)kw);
                control.Top = (int)(control.Top * (double)kh);
                control.Width = (int)(control.Width * (double)kw);
                control.Height = (int)(control.Height * (double)kh);
            }
             this.Width = (int)screenWidth;
             this.Height = (int)screenHeight;
        }
        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Button main11;
        private Button main12;
        private Button main13;
        private Button main14;
        private Button main21;
        private Button main22;
        private Button main26;
        private Button main31;
        private Button main32;
        private Button main41;
        private Button main46;
        private Button main42;
        private Button main43;
        private Button main44;
        private Button main45;
        private Button Updater_215;
        private Button main23;
        private Button update_211;
        private Button update213;
        private Button button13;
        private Button main24;
        private Button group;
        private Button button14;
        private Button button15;
        private Button main33;
        private Button HelpButton;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private Button main16;
        private Button main410;
        private Button main34;
        private Button main17;
    }
}

