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
    public partial class Modify_Product : Form
    {
        private Inventory inventory;
        private Product modifiedProduct;
        private Product productToAdd;
        public Modify_Product(Inventory inventory, Product modProduct)
        {
            InitializeComponent();
            this.inventory = inventory;
            modifiedProduct = modProduct;
            productToAdd = new Product();



            foreach (var part in modifiedProduct.AssociatedParts)
            {
                productToAdd.AddAssociatedPart(part);
            }


            availablePartsView.DataSource = inventory.AllParts;
            addedPartsView.DataSource = productToAdd.AssociatedParts;

            textBox7.Text = modifiedProduct.ProductID.ToString();
            textBox6.Text = modifiedProduct.Name.ToString();
            textBox5.Text = modifiedProduct.InStock.ToString();
            textBox4.Text = modifiedProduct.Price.ToString();
            textBox3.Text = modifiedProduct.Max.ToString();
            textBox2.Text = modifiedProduct.Min.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a Name");
                return;
            }
            if (textBox5.Text.All(char.IsDigit) && textBox5.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a numeric value for Inventory");
                return;
            }
            if (textBox4.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a Price");
                return;
            }
            if (textBox3.Text.All(char.IsDigit) && textBox3.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a value for Max");
                return;
            }
            if (textBox2.Text.All(char.IsDigit) && textBox2.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a value for Min");
                return;
            }
            int.TryParse(textBox2.Text, out int min);
            int.TryParse(textBox3.Text, out int max);
            int.TryParse(textBox5.Text, out int inv);
            if (min < max) { } else { MessageBox.Show("Please adjust Min so that it is less than Max"); return; }
            if (max > min) { } else { MessageBox.Show("Please adjust Max so that it is greater than Min"); return; }
            if (inv <= max) { } else { MessageBox.Show("Please adjust Inventory so that it is under Between the values of Max & Min. In this case its over Max"); return; }
            if (inv >= min) { } else { MessageBox.Show("Please adjust Inventory so that it is under Between the values of Max & Min. In this case its under Min"); return; }
            if (decimal.TryParse(textBox4.Text, out decimal price)) { } else { MessageBox.Show("Please enter a valid price / cost in decimal format i.e. 4.99"); return; }


            productToAdd.Name = textBox6.Text;
            productToAdd.InStock = inv;
            productToAdd.Price = price;
            productToAdd.Max = max;
            productToAdd.Min = min;

            inventory.UpdateProduct(modifiedProduct.ProductID, productToAdd);
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string textToSearch = textBox1.Text.Trim();

                foreach (var part in inventory.AllParts)
                {
                    if (part.Name.Contains(textToSearch))
                    {
                        //found part
                        int index = inventory.AllParts.IndexOf(part);
                        availablePartsView.ClearSelection();
                        availablePartsView.Rows[index].Selected = true;
                        break;
                    }
                }
            }
        }
        private void addProduct_Click(object sender, EventArgs e)
        {
            if (availablePartsView.SelectedRows.Count == 1)
            {
                Part selectedPart = (Part)availablePartsView.SelectedRows[0].DataBoundItem;
                productToAdd.AddAssociatedPart(selectedPart);

            }
            else { MessageBox.Show("Please select a part to add"); }
        }

        private void deletePart_Click(object sender, EventArgs e)
        {
            if (addedPartsView.SelectedRows.Count == 1)
            {
                Part selectedPart = (Part)addedPartsView.SelectedRows[0].DataBoundItem;
                productToAdd.RemoveAssociatedPart(selectedPart.PartID);

            }
            else { MessageBox.Show("Please select a part to remove from the product"); }
        }
    }
}
