using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FProductsCrud : Form
    {
        public FProductsCrud()
        {
            InitializeComponent();
        }
        public void ViewUpdate()
        {
            dataGridView2.DataSource = ServerProducts.LoadProducts();
        }
        private void FProductsCrud_Load(object sender, EventArgs e)
        {
            ViewUpdate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.ReadOnly = checkBox1.Checked == true ? false : true;
            dataGridView2.AllowUserToAddRows = checkBox1.Checked == true ? true : false;
            dataGridView2.AllowUserToDeleteRows = checkBox1.Checked == true ? true : false;
            addButton.Enabled = checkBox1.Checked == true ? true : false;
            removeButton.Enabled = checkBox1.Checked == true ? true : false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell = null;
            List<int> unmatchingRowsIndexes = dataGridView2.Rows.Cast<DataGridViewRow>()
            .Where(r => !r.Cells["productName"].FormattedValue.ToString().Contains(textBox2.Text))
            .Select(r => r.Index).ToList();
            List<int> matchingRowsIndexes = dataGridView2.Rows.Cast<DataGridViewRow>()
            .Where(r => r.Cells["productName"].FormattedValue.ToString().Contains(textBox2.Text))
            .Select(r => r.Index).ToList();
            unmatchingRowsIndexes.ForEach(i => dataGridView2.Rows[i].Visible = false);
            matchingRowsIndexes.ForEach(i => dataGridView2.Rows[i].Visible = true);       
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ServerProducts.UpdateProductProperty(sender as DataGridView, e.RowIndex, e.ColumnIndex))
            {
                MessageBox.Show("Operation completed successfully");
                ViewUpdate();
            }
            else
                MessageBox.Show("Error!");

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FAddProduct f = new FAddProduct(this);
            f.Visible = true;
            Enabled = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            List<int> selectedProductsIds = new List<int>(dataGridView2.SelectedCells.Cast<DataGridViewCell>()
                .Where(cell => cell.OwningColumn.HeaderText.Equals("productId"))
                .Select(cell => Convert.ToInt32(cell.Value)).ToList().Distinct());
            ServerProducts.RemoveProducts(selectedProductsIds);
            ViewUpdate();
        }
    }
}
