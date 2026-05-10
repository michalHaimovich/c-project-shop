namespace UI_
{
partial class Cashier
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
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            customerId = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(547, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 25);
            label1.TabIndex = 0;
            label1.Text = "קופאי";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(445, 314);
            button1.Name = "button1";
            button1.Size = new Size(262, 118);
            button1.TabIndex = 1;
            button1.Text = "open order";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(690, 128);
            label2.Name = "label2";
            label2.Size = new Size(154, 25);
            label2.TabIndex = 2;
            label2.Text = "enter customer ID";
            // 
            // customerId
            // 
            customerId.Location = new Point(689, 172);
            customerId.Name = "customerId";
            customerId.Size = new Size(150, 31);
            customerId.TabIndex = 3;
            // 
            // Cashier
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(customerId);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Cashier";
            Text = "Cashier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox customerId;
    }
}