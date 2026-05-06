using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BlApi;

namespace UI_
{
    public partial class Customers : Form
    {
        IBl bl = Factory.Get();

        public Customers()
        {
            InitializeComponent();
            panel1.Visible = false;
            panelID.Visible = false;
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Phone.Text) || string.IsNullOrEmpty(Adress.Text)  || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("נא למלא את כל השדות");
            }
            else
            {
                try
                {
                    bl.IClient.Create(new BO.Client {Id = int.Parse(textBox1.Text), Name = Name.Text, Phone = Phone.Text, Address = Adress.Text, IsClubMember = checkBox1.Checked });
                    MessageBox.Show("לקוח חדש נוצר בהצלחה!");
                    panel1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"אירעה שגיאה בעת יצירת הלקוח: {ex.Message}");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelID.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text))
            {

            }
            else
            {
                try
                {
                    int id = int.Parse(ID.Text);
                    var client = bl.IClient.Get(id);
                    MessageBox.Show($"פרטי הלקוח:\n\nשם: {client.Name}\nטלפון: {client.Phone}\nכתובת: {client.Address}\nחבר מועדון: {(client.IsClubMember ? "כן" : "לא")}");
                    panelID.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"אירעה שגיאה בעת קבלת פרטי הלקוח: {ex.Message}");
                }
            }
        }
    }
}
