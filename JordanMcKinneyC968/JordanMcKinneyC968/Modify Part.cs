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
    public partial class Modify_Part : Form
    {
        private Inventory inventory;
        private Part modPart;
        public Modify_Part(Inventory inv, Part modpart)
        {
            inventory = inv;
            modPart = modpart;
            InitializeComponent();

            textBox1.Text = modpart.PartID.ToString();
            textBox7.Text = modpart.Name.ToString();
            textBox6.Text = modpart.InStock.ToString();
            textBox2.Text = modpart.Price.ToString();
            textBox4.Text = modpart.Max.ToString();
            textBox5.Text = modpart.Min.ToString();

            if (modPart is Inhouse inHousePart)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                machineIDCompanyNameTextBox.Text = inHousePart.MachineID.ToString();
            }
            else if (modPart is Outsourced outsourcedPart)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                machineIDCompanyNameTextBox.Text = outsourcedPart.CompanyName.ToString();
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (machineIDCompanyNameTextBox.Text.All(char.IsDigit) && machineIDCompanyNameTextBox.Text.Length > 0) { }
                else
                {
                    MessageBox.Show("Please enter a numeric value for Machine ID");
                    return;
                }
            }
            else
            {
                if (machineIDCompanyNameTextBox.Text.Length > 0) { } else { MessageBox.Show("Please enter a Company Name"); }
            }
            if (textBox4.Text.All(char.IsDigit) && textBox4.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a numeric value for Maximum");
                return;
            }
            if (textBox7.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a Name");
                return;
            }
            if (textBox5.Text.All(char.IsDigit) && textBox5.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a numeric value for Minimum");
                return;
            }
            if (textBox6.Text.All(char.IsDigit) && textBox6.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Please enter a numeric value for Inventory");
                return;
            }
            int.TryParse(textBox5.Text, out int min);
            int.TryParse(textBox4.Text, out int max);
            int.TryParse(textBox6.Text, out int inv);
            int.TryParse(machineIDCompanyNameTextBox.Text, out int machine_id);
            if (min < max) { } else { MessageBox.Show("Please adjust Min so that it is less than Max"); return; }
            if (max > min) { } else { MessageBox.Show("Please adjust Max so that it is greater than Min"); return; }
            if (inv <= max) { } else { MessageBox.Show("Please adjust Inventory so that it is under Between the values of Max & Min. In this case its over Max"); return; }
            if (inv >= min) { } else { MessageBox.Show("Please adjust Inventory so that it is under Between the values of Max & Min. In this case its under Min"); return; }
            if (decimal.TryParse(textBox2.Text, out decimal price)) { } else { MessageBox.Show("Please enter a valid price / cost in decimal format i.e. 4.99"); return; }


            //Add Part in house
            if (radioButton1.Checked)
            {
                Inhouse toAdd = new Inhouse();
                toAdd.MachineID = machine_id;
                toAdd.Min = min;
                toAdd.Max = max;
                toAdd.Price = price;
                toAdd.Name = textBox7.Text;
                toAdd.InStock = inv;
                inventory.UpdatePart(modPart.PartID, toAdd);
            }
            //add part outsourced
            else
            {
                Outsourced toAdd = new Outsourced();
                toAdd.CompanyName = machineIDCompanyNameTextBox.Text;
                toAdd.Min = min;
                toAdd.Max = max;
                toAdd.Price = price;
                toAdd.Name = textBox7.Text;
                toAdd.InStock = inv;
                inventory.UpdatePart(modPart.PartID,toAdd);
            }


            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            machineIDCompanyNameLabel.Text = "Machine ID";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            machineIDCompanyNameLabel.Text = "Company Name";
        }
    }
}
