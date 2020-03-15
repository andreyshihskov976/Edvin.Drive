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
                string am = "Нет";
                string a1 = "Нет";
                string a = "Нет";
                string b = "Нет";
                string c = "Нет";
                string d = "Нет";
                BoolToString(ref am, ref a1, ref a, ref b, ref c, ref d);
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Prava, null, MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID, null, comboBox3.Text), maskedTextBox2.Text, am, a1, a, b, c, d);
                    this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BoolToString(ref string am, ref string a1, ref string a, ref string b, ref string c, ref string d)
        {
            if (checkBox1.Checked)
                am = "Есть";
            if (checkBox2.Checked)
                a1 = "Есть";
            if (checkBox3.Checked)
                a = "Есть";
            if (checkBox4.Checked)
                b = "Есть";
            if (checkBox5.Checked)
                c = "Есть";
            if (checkBox6.Checked)
                d = "Есть";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text.Length == 9)
            {
                string am = "Нет";
                string a1 = "Нет";
                string a = "Нет";
                string b = "Нет";
                string c = "Нет";
                string d = "Нет";
                BoolToString(ref am, ref a1, ref a, ref b, ref c, ref d);
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Prava, ID, MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID, null, comboBox3.Text), maskedTextBox2.Text, am, a1, a, b, c, d);
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
