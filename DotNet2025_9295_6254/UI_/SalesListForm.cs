using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;

namespace UI_
{
    public partial class SalesListForm : Form
    {
        public SalesListForm()
        {
            InitializeComponent();
        }

        public void SetSales(System.Collections.Generic.IEnumerable<BO.SaleInProduct> sales, string productName)
        {
            var list = sales.Select(s => new { Product = productName, Amount = s.Amount_to_sale, Price = s.Price_per_one, SaleId = s.SaleId }).ToList();
            dgvSales.DataSource = null;
            dgvSales.DataSource = list;
            // hide SaleId column (kept for reference)
            if (dgvSales.Columns.Contains("SaleId"))
                dgvSales.Columns["SaleId"].Visible = false;
        }
    }
}
