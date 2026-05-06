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
            showCustomer = new Button();
            deleteCustomer = new Button();
            showAllCustomers = new Button();
            createCustomer = new Button();
            updateCustomer = new Button();
            panel1 = new Panel();
            textBox1 = new TextBox();
            label5 = new Label();
            confirmCreate = new Button();
            checkBox1 = new CheckBox();
            Phone = new TextBox();
            Adress = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            NameTextBox = new TextBox();
            label2 = new Label();
            panelID = new Panel();
            confirmAction = new Button();
            ID = new TextBox();
            UpName = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            UpAdress = new TextBox();
            UpPhone = new TextBox();
            checkBox2 = new CheckBox();
            UpdateConfirm = new Button();
            label6 = new Label();
            UpID = new TextBox();
            panelUpdate = new Panel();
            panelDelete = new Panel();
            DeleteConfirm = new Button();
            IDdelete = new TextBox();
            label10 = new Label();
            panelShowAll = new Panel();
            closeShowAll = new Button();
            labelFilter = new Label();
            filterTextBox = new TextBox();
            dataGridViewCustomers = new DataGridView();
            filterByClub = new Button();
            panel1.SuspendLayout();
            panelID.SuspendLayout();
            panelUpdate.SuspendLayout();
            panelDelete.SuspendLayout();
            panelShowAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            SuspendLayout();
            // 
            // showCustomer
            // 
            showCustomer.Location = new Point(849, 128);
            showCustomer.Margin = new Padding(4, 5, 4, 5);
            showCustomer.Name = "showCustomer";
            showCustomer.Size = new Size(174, 63);
            showCustomer.TabIndex = 0;
            showCustomer.Text = "Show Customer";
            showCustomer.UseVisualStyleBackColor = true;
            showCustomer.Click += showCustomer_Click;
            // 
            // deleteCustomer
            // 
            deleteCustomer.Location = new Point(849, 348);
            deleteCustomer.Margin = new Padding(4, 5, 4, 5);
            deleteCustomer.Name = "deleteCustomer";
            deleteCustomer.Size = new Size(174, 63);
            deleteCustomer.TabIndex = 1;
            deleteCustomer.Text = "Delete Customer";
            deleteCustomer.UseVisualStyleBackColor = true;
            deleteCustomer.Click += deleteCustomer_Click;
            // 
            // showAllCustomers
            // 
            showAllCustomers.Location = new Point(849, 202);
            showAllCustomers.Margin = new Padding(4, 5, 4, 5);
            showAllCustomers.Name = "showAllCustomers";
            showAllCustomers.Size = new Size(174, 63);
            showAllCustomers.TabIndex = 2;
            showAllCustomers.Text = "Show All Customers";
            showAllCustomers.UseVisualStyleBackColor = true;
            showAllCustomers.Click += showAllCustomers_Click;
            // 
            // createCustomer
            // 
            createCustomer.Location = new Point(849, 275);
            createCustomer.Margin = new Padding(4, 5, 4, 5);
            createCustomer.Name = "createCustomer";
            createCustomer.Size = new Size(174, 63);
            createCustomer.TabIndex = 2;
            createCustomer.Text = "Create Customer";
            createCustomer.UseVisualStyleBackColor = true;
            createCustomer.Click += createCustomer_Click;
            // 
            // updateCustomer
            // 
            updateCustomer.Location = new Point(849, 422);
            updateCustomer.Margin = new Padding(4, 5, 4, 5);
            updateCustomer.Name = "updateCustomer";
            updateCustomer.Size = new Size(174, 63);
            updateCustomer.TabIndex = 3;
            updateCustomer.Text = "Update Customer";
            updateCustomer.UseVisualStyleBackColor = true;
            updateCustomer.Click += updateCustomer_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(confirmCreate);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(Phone);
            panel1.Controls.Add(Adress);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(NameTextBox);
            panel1.Location = new Point(44, 221);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(282, 285);
            panel1.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(221, 146);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(50, 31);
            textBox1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(241, 116);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(30, 25);
            label5.TabIndex = 8;
            label5.Text = "ID";
            // 
            // confirmCreate
            // 
            confirmCreate.Location = new Point(111, 220);
            confirmCreate.Margin = new Padding(4, 5, 4, 5);
            confirmCreate.Name = "confirmCreate";
            confirmCreate.Size = new Size(107, 38);
            confirmCreate.TabIndex = 7;
            confirmCreate.Text = "OK";
            confirmCreate.UseVisualStyleBackColor = true;
            confirmCreate.Click += confirmCreate_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(125, 181);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(146, 29);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Club Member";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Phone
            // 
            Phone.Location = new Point(4, 73);
            Phone.Margin = new Padding(4, 5, 4, 5);
            Phone.Name = "Phone";
            Phone.Size = new Size(141, 31);
            Phone.TabIndex = 5;
            // 
            // Adress
            // 
            Adress.Location = new Point(4, 146);
            Adress.Margin = new Padding(4, 5, 4, 5);
            Adress.Name = "Adress";
            Adress.Size = new Size(141, 31);
            Adress.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 38);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 3;
            label4.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 116);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 25);
            label3.TabIndex = 2;
            label3.Text = "Address";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(221, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(153, 73);
            NameTextBox.Margin = new Padding(4, 5, 4, 5);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(118, 31);
            NameTextBox.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(371, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 25);
            label2.TabIndex = 8;
            label2.Text = "Enter ID";
            // 
            // panelID
            // 
            panelID.Controls.Add(confirmAction);
            panelID.Controls.Add(ID);
            panelID.Controls.Add(label2);
            panelID.Location = new Point(169, 77);
            panelID.Margin = new Padding(4, 5, 4, 5);
            panelID.Name = "panelID";
            panelID.Size = new Size(484, 67);
            panelID.TabIndex = 9;
            // 
            // confirmAction
            // 
            confirmAction.Location = new Point(39, 20);
            confirmAction.Margin = new Padding(4, 5, 4, 5);
            confirmAction.Name = "confirmAction";
            confirmAction.Size = new Size(107, 38);
            confirmAction.TabIndex = 8;
            confirmAction.Text = "OK";
            confirmAction.UseVisualStyleBackColor = true;
            confirmAction.Click += confirmAction_Click;
            // 
            // ID
            // 
            ID.Location = new Point(207, 20);
            ID.Margin = new Padding(4, 5, 4, 5);
            ID.Name = "ID";
            ID.Size = new Size(141, 31);
            ID.TabIndex = 8;
            // 
            // UpName
            // 
            UpName.Location = new Point(168, 157);
            UpName.Margin = new Padding(4, 5, 4, 5);
            UpName.Name = "UpName";
            UpName.Size = new Size(118, 31);
            UpName.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(217, 127);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(59, 25);
            label9.TabIndex = 1;
            label9.Text = "Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(68, 127);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(77, 25);
            label8.TabIndex = 2;
            label8.Text = "Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(92, 19);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(62, 25);
            label7.TabIndex = 3;
            label7.Text = "Phone";
            // 
            // UpAdress
            // 
            UpAdress.Location = new Point(4, 157);
            UpAdress.Margin = new Padding(4, 5, 4, 5);
            UpAdress.Name = "UpAdress";
            UpAdress.Size = new Size(141, 31);
            UpAdress.TabIndex = 4;
            // 
            // UpPhone
            // 
            UpPhone.Location = new Point(15, 49);
            UpPhone.Margin = new Padding(4, 5, 4, 5);
            UpPhone.Name = "UpPhone";
            UpPhone.Size = new Size(141, 31);
            UpPhone.TabIndex = 5;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(140, 226);
            checkBox2.Margin = new Padding(4, 5, 4, 5);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(146, 29);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "Club Member";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // UpdateConfirm
            // 
            UpdateConfirm.Location = new Point(4, 226);
            UpdateConfirm.Margin = new Padding(4, 5, 4, 5);
            UpdateConfirm.Name = "UpdateConfirm";
            UpdateConfirm.Size = new Size(107, 38);
            UpdateConfirm.TabIndex = 7;
            UpdateConfirm.Text = "OK";
            UpdateConfirm.UseVisualStyleBackColor = true;
            UpdateConfirm.Click += UpdateConfirm_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(256, 19);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(30, 25);
            label6.TabIndex = 8;
            label6.Text = "ID";
            // 
            // UpID
            // 
            UpID.Location = new Point(236, 49);
            UpID.Margin = new Padding(4, 5, 4, 5);
            UpID.Name = "UpID";
            UpID.Size = new Size(50, 31);
            UpID.TabIndex = 9;
            // 
            // panelUpdate
            // 
            panelUpdate.Controls.Add(label6);
            panelUpdate.Controls.Add(checkBox2);
            panelUpdate.Controls.Add(label7);
            panelUpdate.Controls.Add(label8);
            panelUpdate.Controls.Add(UpAdress);
            panelUpdate.Controls.Add(UpdateConfirm);
            panelUpdate.Controls.Add(UpPhone);
            panelUpdate.Controls.Add(label9);
            panelUpdate.Controls.Add(UpID);
            panelUpdate.Controls.Add(UpName);
            panelUpdate.Location = new Point(349, 221);
            panelUpdate.Margin = new Padding(4, 5, 4, 5);
            panelUpdate.Name = "panelUpdate";
            panelUpdate.Size = new Size(304, 285);
            panelUpdate.TabIndex = 10;
            panelUpdate.Paint += panelUpdate_Paint;
            // 
            // panelDelete
            // 
            panelDelete.Controls.Add(DeleteConfirm);
            panelDelete.Controls.Add(IDdelete);
            panelDelete.Controls.Add(label10);
            panelDelete.Location = new Point(169, 145);
            panelDelete.Margin = new Padding(4, 5, 4, 5);
            panelDelete.Name = "panelDelete";
            panelDelete.Size = new Size(484, 67);
            panelDelete.TabIndex = 10;
            // 
            // DeleteConfirm
            // 
            DeleteConfirm.Location = new Point(39, 20);
            DeleteConfirm.Margin = new Padding(4, 5, 4, 5);
            DeleteConfirm.Name = "DeleteConfirm";
            DeleteConfirm.Size = new Size(107, 38);
            DeleteConfirm.TabIndex = 8;
            DeleteConfirm.Text = "OK";
            DeleteConfirm.UseVisualStyleBackColor = true;
            DeleteConfirm.Click += DeleteConfirm_Click;
            // 
            // IDdelete
            // 
            IDdelete.Location = new Point(207, 20);
            IDdelete.Margin = new Padding(4, 5, 4, 5);
            IDdelete.Name = "IDdelete";
            IDdelete.Size = new Size(141, 31);
            IDdelete.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(371, 25);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(75, 25);
            label10.TabIndex = 8;
            label10.Text = "Enter ID";
            // 
            // panelShowAll
            // 
            panelShowAll.Controls.Add(filterByClub);
            panelShowAll.Controls.Add(closeShowAll);
            panelShowAll.Controls.Add(labelFilter);
            panelShowAll.Controls.Add(filterTextBox);
            panelShowAll.Controls.Add(dataGridViewCustomers);
            panelShowAll.Location = new Point(20, 77);
            panelShowAll.Margin = new Padding(4, 5, 4, 5);
            panelShowAll.Name = "panelShowAll";
            panelShowAll.Size = new Size(821, 492);
            panelShowAll.TabIndex = 11;
            // 
            // closeShowAll
            // 
            closeShowAll.Location = new Point(704, 15);
            closeShowAll.Margin = new Padding(4, 5, 4, 5);
            closeShowAll.Name = "closeShowAll";
            closeShowAll.Size = new Size(78, 31);
            closeShowAll.TabIndex = 3;
            closeShowAll.Text = "X";
            closeShowAll.UseVisualStyleBackColor = true;
            closeShowAll.Click += closeShowAll_Click;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(15, 20);
            labelFilter.Margin = new Padding(4, 0, 4, 0);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(54, 25);
            labelFilter.TabIndex = 2;
            labelFilter.Text = "Filter:";
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(77, 20);
            filterTextBox.Margin = new Padding(4, 5, 4, 5);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.PlaceholderText = "Search by Name";
            filterTextBox.Size = new Size(174, 31);
            filterTextBox.TabIndex = 1;
            filterTextBox.TextChanged += filterTextBox_TextChanged;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(15, 55);
            dataGridViewCustomers.Margin = new Padding(4, 5, 4, 5);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.RowHeadersWidth = 62;
            dataGridViewCustomers.Size = new Size(767, 368);
            dataGridViewCustomers.TabIndex = 0;
            // 
            // filterByClub
            // 
            filterByClub.Location = new Point(356, 17);
            filterByClub.Name = "filterByClub";
            filterByClub.Size = new Size(256, 34);
            filterByClub.TabIndex = 4;
            filterByClub.Text = "only club members";
            filterByClub.UseVisualStyleBackColor = true;
            filterByClub.Click += filterByClub_Click;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(panelShowAll);
            Controls.Add(panelDelete);
            Controls.Add(panelUpdate);
            Controls.Add(panelID);
            Controls.Add(panel1);
            Controls.Add(updateCustomer);
            Controls.Add(createCustomer);
            Controls.Add(showAllCustomers);
            Controls.Add(deleteCustomer);
            Controls.Add(showCustomer);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Customers";
            Text = "Customers";
            Load += Customers_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelID.ResumeLayout(false);
            panelID.PerformLayout();
            panelUpdate.ResumeLayout(false);
            panelUpdate.PerformLayout();
            panelDelete.ResumeLayout(false);
            panelDelete.PerformLayout();
            panelShowAll.ResumeLayout(false);
            panelShowAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button showCustomer;
        private Button deleteCustomer;
        private Button showAllCustomers;
        private Button createCustomer;
        private Button updateCustomer;
        private Panel panel1;
        private Label label1;
        private TextBox NameTextBox;
        private Label label4;
        private Label label3;
        private TextBox Phone;
        private TextBox Adress;
        private CheckBox checkBox1;
        private Button confirmCreate;
        private Label label2;
        private Panel panelID;
        private TextBox ID;
        private Button confirmAction;
        private TextBox textBox1;
        private Label label5;
        private Panel panelUpdate;
        private TextBox UpName;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox UpAdress;
        private TextBox UpPhone;
        private CheckBox checkBox2;
        private Button UpdateConfirm;
        private Label label6;
        private TextBox UpID;
        private Panel panelDelete;
        private Button DeleteConfirm;
        private TextBox IDdelete;
        private Label label10;
        private Panel panelShowAll;
        private DataGridView dataGridViewCustomers;
        private TextBox filterTextBox;
        private Label labelFilter;
        private Button closeShowAll;
        private Button filterByClub;
    }
}