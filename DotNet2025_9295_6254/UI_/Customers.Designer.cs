namespace UI_
{
    partial class Customers
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            panel1 = new Panel();
            button6 = new Button();
            checkBox1 = new CheckBox();
            Phone = new TextBox();
            Adress = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            Name = new TextBox();
            label2 = new Label();
            panelID = new Panel();
            button7 = new Button();
            ID = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            panelID.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(594, 77);
            button1.Name = "button1";
            button1.Size = new Size(122, 38);
            button1.TabIndex = 0;
            button1.Text = "הראה לקוח";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(594, 209);
            button2.Name = "button2";
            button2.Size = new Size(122, 38);
            button2.TabIndex = 1;
            button2.Text = "מחק לקוח";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(594, 121);
            button3.Name = "button3";
            button3.Size = new Size(122, 38);
            button3.TabIndex = 2;
            button3.Text = "הראה את כל הלקוחות";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(594, 165);
            button4.Name = "button4";
            button4.Size = new Size(122, 38);
            button4.TabIndex = 2;
            button4.Text = "צור לקוח";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(594, 253);
            button5.Name = "button5";
            button5.Size = new Size(122, 38);
            button5.TabIndex = 3;
            button5.Text = "עדכן לקוח";
            button5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(Phone);
            panel1.Controls.Add(Adress);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Name);
            panel1.Location = new Point(99, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(396, 171);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // button6
            // 
            button6.Location = new Point(78, 132);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 7;
            button6.Text = "אישור";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(290, 107);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(56, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "מועדון";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Phone
            // 
            Phone.Location = new Point(3, 44);
            Phone.Name = "Phone";
            Phone.Size = new Size(100, 23);
            Phone.TabIndex = 5;
            // 
            // Adress
            // 
            Adress.Location = new Point(122, 44);
            Adress.Name = "Adress";
            Adress.Size = new Size(100, 23);
            Adress.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 23);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "טלפון";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(180, 23);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "כתובת";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(306, 23);
            label1.Name = "label1";
            label1.Size = new Size(24, 15);
            label1.TabIndex = 1;
            label1.Text = "שם";
            // 
            // Name
            // 
            Name.Location = new Point(246, 44);
            Name.Name = "Name";
            Name.Size = new Size(84, 23);
            Name.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(260, 15);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 8;
            label2.Text = "הכנס -id";
            // 
            // panelID
            // 
            panelID.Controls.Add(button7);
            panelID.Controls.Add(ID);
            panelID.Controls.Add(label2);
            panelID.Location = new Point(164, 62);
            panelID.Name = "panelID";
            panelID.Size = new Size(331, 44);
            panelID.TabIndex = 9;
            // 
            // button7
            // 
            button7.Location = new Point(27, 12);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 8;
            button7.Text = "אישור";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // ID
            // 
            ID.Location = new Point(145, 12);
            ID.Name = "ID";
            ID.Size = new Size(100, 23);
            ID.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(369, 23);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 8;
            label5.Text = "ID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(351, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(36, 23);
            textBox1.TabIndex = 9;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelID);
            Controls.Add(panel1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);

            Text = "Customers";
            Load += Customers_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelID.ResumeLayout(false);
            panelID.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Panel panel1;
        private Label label1;
        private TextBox Name;
        private Label label4;
        private Label label3;
        private TextBox Phone;
        private TextBox Adress;
        private CheckBox checkBox1;
        private Button button6;
        private Label label2;
        private Panel panelID;
        private TextBox ID;
        private Button button7;
        private TextBox textBox1;
        private Label label5;
    }
}