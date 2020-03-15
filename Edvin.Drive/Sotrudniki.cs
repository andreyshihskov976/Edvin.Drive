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
    public partial class Sotrudniki : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = null;
        public Sotrudniki(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Doljnosti_ComboBox, comboBox1);           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text.Length == 17)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Sotrudniki, null, textBox1.Text,textBox2.Text,textBox3.Text,MySqlOperations.Select_Text(MySqlQueries.Select_Doljnosti_ID,null,comboBox1.Text),maskedTextBox1.Text);
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text.Length == 17)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Sotrudniki, ID, textBox1.Text, textBox2.Text, textBox3.Text, MySqlOperations.Select_Text(MySqlQueries.Select_Doljnosti_ID, null, comboBox1.Text), maskedTextBox1.Text);
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Sotrudniki_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sotrudniki_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Sotrudniki_Closed;
    }
}
