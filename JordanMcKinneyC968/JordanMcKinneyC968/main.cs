using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JordanMcKinneyC968
{
    public partial class main : Form
    {
        private Inventory inventory;


        public main()
        {
            InitializeComponent();
            inventory = new Inventory();

            partsGridView.DataSource = inventory.AllParts;
            productsGridView.DataSource = inventory.Products;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void addPartButton_Click(object sender, EventArgs e)
        {
            Add_Part form = new Add_Part(inventory);
            form.Show();
        }

        private void productsSearchButton_Click(object sender, EventArgs e)
        {
            string textToSearch = productsTextBox.Text.Trim();

            foreach (var product in inventory.Products)
            {
                if (product.Name.Contains(textToSearch))
                {
                    int index = inventory.Products.IndexOf(product);
                    productsGridView.ClearSelection();
                    productsGridView.Rows[index].Selected = true;
                    break;
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deletePartButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this part?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int index = partsGridView.SelectedRows[0].Index;
                    Part selectedPart = (Part)partsGridView.SelectedRows[0].DataBoundItem;
                    if (inventory.DeletePart(selectedPart)) { } else { MessageBox.Show("Part is currently being used inside a product"); }
                }

            }
            else { MessageBox.Show("Please select a part row to delete"); }
        }

        private void modifyPartButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count == 1)
            {
                Part selectedPart = (Part)partsGridView.SelectedRows[0].DataBoundItem;
                Modify_Part form = new Modify_Part(inventory, selectedPart);
                form.Show();
            }
            else { MessageBox.Show("Please select a part to modify"); }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string textToSearch = searchTextBox.Text.Trim();

            foreach (var part in inventory.AllParts)
            {
                if(part.Name.Contains(textToSearch))
                {
                    int index = inventory.AllParts.IndexOf(part);
                    partsGridView.ClearSelection();
                    partsGridView.Rows[index].Selected = true;
                    break;
                }
            }
        }

        private void productsDeleteButton_Click(object sender, EventArgs e)
        {
            if (productsGridView.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    if (result == DialogResult.Yes)
                    {
                        int index = productsGridView.SelectedRows[0].Index;
                        Product selectedProduct = (Product)productsGridView.SelectedRows[0].DataBoundItem;
                        inventory.RemoveProduct(selectedProduct.ProductID);
                    }

                }
            }
            else { MessageBox.Show("Please select a product to delete"); }
        }

        private void productsAddButton_Click(object sender, EventArgs e)
        {
            Add_Product form = new Add_Product(inventory);
            form.Show();
        }

        private void productsModifyButton_Click(object sender, EventArgs e)
        {
            if (productsGridView.SelectedRows.Count == 1)
            {
                Product selectedProduct = (Product)productsGridView.SelectedRows[0].DataBoundItem;
                Modify_Product form = new Modify_Product(inventory, selectedProduct);
                form.Show();
            }
            else { MessageBox.Show("Please select a product to modify"); }
        }
    }
}
