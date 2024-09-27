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
    public partial class Add_Part : Form
    {
        private Inventory inventory;
        public Add_Part(Inventory inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            machineIDCompanyNameLabel.Text = "Machine ID";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            machineIDCompanyNameLabel.Text = "Company Name";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                textBox7.BackColor = SystemColors.Window;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                textBox6.BackColor = SystemColors.Window;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                textBox2.BackColor = SystemColors.Window;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                textBox4.BackColor = SystemColors.Window;
            }
        }

        private void machineIDCompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (machineIDCompanyNameTextBox.Text != "")
            {
                machineIDCompanyNameTextBox.BackColor = SystemColors.Window;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                textBox5.BackColor = SystemColors.Window;
            }
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
                inventory.AddPart(toAdd);
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
                inventory.AddPart(toAdd);
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
