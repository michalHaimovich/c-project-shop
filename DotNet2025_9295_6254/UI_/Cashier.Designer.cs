namespace UI_
{
    partial class Cashier
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            customerId = new TextBox();
            comboProducts = new ComboBox();
            productIdTextBox = new TextBox();
            quantityUpDown = new NumericUpDown();
            addProductButton = new Button();
            dgvOrder = new DataGridView();
            lblTotal = new Label();
            btnDoOrder = new Button();
            buttonManager = new Button();
            buttonShowSales = new Button();
            panelDetails = new Panel();
            lblDetailName = new Label();
            lblDetailUnit = new Label();
            lblDetailQty = new Label();
            lblDetailFinal = new Label();
            lblDetailSalesCount = new Label();
            ((System.ComponentModel.ISupportInitialize)quantityUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrder).BeginInit();
            panelDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(551, 38);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "קופאי";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(848, 311);
            button1.Name = "button1";
            button1.Size = new Size(210, 94);
            button1.TabIndex = 1;
            button1.Text = "open order";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(848, 222);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 2;
            label2.Text = "enter customer ID";
            // 
            // customerId
            // 
            customerId.Location = new Point(848, 255);
            customerId.Name = "customerId";
            customerId.Size = new Size(121, 27);
            customerId.TabIndex = 3;
            // 
            // comboProducts
            // 
            comboProducts.Location = new Point(227, 114);
            comboProducts.Name = "comboProducts";
            comboProducts.Size = new Size(241, 28);
            comboProducts.TabIndex = 4;
            comboProducts.SelectedIndexChanged += comboProducts_SelectedIndexChanged;
            // 
            // productIdTextBox
            // 
            productIdTextBox.Location = new Point(483, 114);
            productIdTextBox.Name = "productIdTextBox";
            productIdTextBox.Size = new Size(81, 27);
            productIdTextBox.TabIndex = 5;
            // 
            // quantityUpDown
            // 
            quantityUpDown.Location = new Point(571, 114);
            quantityUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantityUpDown.Name = "quantityUpDown";
            quantityUpDown.Size = new Size(48, 27);
            quantityUpDown.TabIndex = 6;
            quantityUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            quantityUpDown.ValueChanged += quantityUpDown_ValueChanged;
            // 
            // addProductButton
            // 
            addProductButton.Location = new Point(657, 115);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(96, 25);
            addProductButton.TabIndex = 7;
            addProductButton.Text = "Add";
            addProductButton.UseVisualStyleBackColor = true;
            addProductButton.Click += addProductButton_Click;
            // 
            // dgvOrder
            // 
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrder.Location = new Point(215, 173);
            dgvOrder.Name = "dgvOrder";
            dgvOrder.ReadOnly = true;
            dgvOrder.RowHeadersWidth = 51;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrder.Size = new Size(560, 320);
            dgvOrder.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(219, 518);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(160, 24);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total: 0";
            // 
            // btnDoOrder
            // 
            btnDoOrder.Location = new Point(395, 518);
            btnDoOrder.Name = "btnDoOrder";
            btnDoOrder.Size = new Size(96, 24);
            btnDoOrder.TabIndex = 10;
            btnDoOrder.Text = "Do Order";
            btnDoOrder.UseVisualStyleBackColor = true;
            btnDoOrder.Click += btnDoOrder_Click;
            // 
            // buttonManager
            // 
            buttonManager.Location = new Point(984, 642);
            buttonManager.Name = "buttonManager";
            buttonManager.Size = new Size(120, 30);
            buttonManager.TabIndex = 11;
            buttonManager.Text = "Manager";
            buttonManager.UseVisualStyleBackColor = true;
            buttonManager.Click += buttonManager_Click;
            // 
            // buttonShowSales
            // 
            buttonShowSales.Location = new Point(1004, 84);
            buttonShowSales.Name = "buttonShowSales";
            buttonShowSales.Size = new Size(100, 25);
            buttonShowSales.TabIndex = 13;
            buttonShowSales.Text = "מבצעים";
            buttonShowSales.UseVisualStyleBackColor = true;
            buttonShowSales.Click += buttonShowSales_Click;
            // 
            // panelDetails
            // 
            panelDetails.BorderStyle = BorderStyle.FixedSingle;
            panelDetails.Controls.Add(lblDetailName);
            panelDetails.Controls.Add(lblDetailUnit);
            panelDetails.Controls.Add(lblDetailQty);
            panelDetails.Controls.Add(lblDetailFinal);
            panelDetails.Controls.Add(lblDetailSalesCount);
            panelDetails.Location = new Point(820, 173);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(260, 200);
            panelDetails.TabIndex = 11;
            // 
            // lblDetailName
            // 
            lblDetailName.Location = new Point(10, 10);
            lblDetailName.Name = "lblDetailName";
            lblDetailName.Size = new Size(240, 20);
            lblDetailName.TabIndex = 0;
            lblDetailName.Text = "Name:";
            // 
            // lblDetailUnit
            // 
            lblDetailUnit.Location = new Point(10, 40);
            lblDetailUnit.Name = "lblDetailUnit";
            lblDetailUnit.Size = new Size(240, 20);
            lblDetailUnit.TabIndex = 1;
            lblDetailUnit.Text = "Unit price:";
            lblDetailUnit.Click += lblDetailUnit_Click;
            // 
            // lblDetailQty
            // 
            lblDetailQty.Location = new Point(10, 70);   
            lblDetailQty.Name = "lblDetailQty";
            lblDetailQty.Size = new Size(240, 20);
            lblDetailQty.TabIndex = 2;
            lblDetailQty.Text = "Quantity:"; 
            // 
            // lblDetailFinal
            // 
            lblDetailFinal.Location = new Point(10, 100);
            lblDetailFinal.Name = "lblDetailFinal";
            lblDetailFinal.Size = new Size(240, 20);
            lblDetailFinal.TabIndex = 3;
            lblDetailFinal.Text = "Final price:";
            // 
            // lblDetailSalesCount
            // 
            lblDetailSalesCount.Location = new Point(10, 130);
            lblDetailSalesCount.Name = "lblDetailSalesCount";
            lblDetailSalesCount.Size = new Size(240, 20);
            lblDetailSalesCount.TabIndex = 4;
            lblDetailSalesCount.Text = "Active sales: 0";
            // 
            // Cashier
            // 
            ClientSize = new Size(1116, 684);
            Controls.Add(customerId);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboProducts);
            Controls.Add(productIdTextBox);
            Controls.Add(quantityUpDown);
            Controls.Add(addProductButton);
            Controls.Add(dgvOrder);
            Controls.Add(lblTotal);
            Controls.Add(btnDoOrder);
            Controls.Add(panelDetails);
            Controls.Add(buttonManager);
            Controls.Add(buttonShowSales);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Cashier";
            Text = "Cashier";
            Load += Cashier_Load;
            ((System.ComponentModel.ISupportInitialize)quantityUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrder).EndInit();
            panelDetails.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox customerId;
        private System.Windows.Forms.ComboBox comboProducts;
        private System.Windows.Forms.TextBox productIdTextBox;
        private System.Windows.Forms.NumericUpDown quantityUpDown;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnDoOrder;
        private System.Windows.Forms.Button buttonManager;
        private System.Windows.Forms.Button buttonShowSales;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblDetailUnit;
        private System.Windows.Forms.Label lblDetailQty;
        private System.Windows.Forms.Label lblDetailFinal;
        private System.Windows.Forms.Label lblDetailSalesCount;
    }
}