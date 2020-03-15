using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edvin.Drive
{
    public partial class Avtopark : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = null;

        public Avtopark(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Price_ComboBox, comboBox3);
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "B")
            {
                maskedTextBox1.Mask = "0000LL-0";
            }
            else if (comboBox2.SelectedItem.ToString() == "C" || comboBox2.SelectedItem.ToString() == "D")
            {
                maskedTextBox1.Mask = "LL0000-0";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && maskedTextBox1.Text.Length == 8 && maskedTextBox2.Text.Length == 17)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Avtopark, null, comboBox1.Text, textBox1.Text, comboBox2.Text, MySqlOperations.Select_Text(MySqlQueries.Select_Price_ID,null,comboBox3.Text),maskedTextBox1.Text,maskedTextBox2.Text);
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && maskedTextBox1.Text.Length == 8 && maskedTextBox2.Text.Length == 17)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Avtopark, ID, comboBox1.Text, textBox1.Text, comboBox2.Text, MySqlOperations.Select_Text(MySqlQueries.Select_Price_ID, null, comboBox3.Text), maskedTextBox1.Text, maskedTextBox2.Text);
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Avtopark_FormClosed(object sender, FormClosedEventArgs e)
        {
            Avtopark_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Avtopark_Closed;
    }
}
