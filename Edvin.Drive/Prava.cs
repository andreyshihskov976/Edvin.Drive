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
    public partial class Prava : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = null;

        public Prava(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Clienty_ComboBox, comboBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text.Length == 9)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Avtopark, null, MySqlOperations.Select_Text(MySqlQueries.Select_Price_ID, null, comboBox3.Text), maskedTextBox1.Text, maskedTextBox2.Text);
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
            if (maskedTextBox2.Text.Length == 9)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Avtopark, ID, comboBox1.Text, textBox1.Text, comboBox2.Text, MySqlOperations.Select_Text(MySqlQueries.Select_Price_ID, null, comboBox3.Text), maskedTextBox1.Text, maskedTextBox2.Text);
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Prava_FormClosed(object sender, FormClosedEventArgs e)
        {
            Prava_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Prava_Closed;
    }
}
