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
    public partial class Acts : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = null;

        public Acts(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Dogovory_ComboBox, comboBox2);
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Sotrudniki_ComboBox, comboBox3);
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Avtopark_ComboBox, comboBox4);
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string output = string.Empty;
                if (comboBox1.SelectedItem == comboBox1.Items[0])
                    output = MySqlOperations.Select_Text(MySqlQueries.Select_Exists_ActSdachi, comboBox2.Text.Split(' ')[1]);
                else if (comboBox1.SelectedItem == comboBox1.Items[1])
                    output = MySqlOperations.Select_Text(MySqlQueries.Select_Exists_ActPriema, comboBox2.Text.Split(' ')[1]);
                if (output == "0")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Acts, null, comboBox1.Text,
                        DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString(),
                        MySqlOperations.Select_Text(MySqlQueries.Select_Dogovory_ID, null, comboBox2.Text),
                        MySqlOperations.Select_Text(MySqlQueries.Select_Sotrudniki_ID, null, comboBox3.Text),
                        MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox4.Text),
                        textBox1.Text);
                    this.Close();
                }
                else
                    MessageBox.Show("Для выбранного вами договора уже составлен " + comboBox1.Text.ToLower() + '.', "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (textBox1.Text != "")
            {
                string output = string.Empty;
                if (comboBox1.SelectedItem == comboBox1.Items[0])
                    output = MySqlOperations.Select_Text(MySqlQueries.Select_Exists_ActSdachi, comboBox2.Text.Split(' ')[1]);
                else if (comboBox1.SelectedItem == comboBox1.Items[1])
                    output = MySqlOperations.Select_Text(MySqlQueries.Select_Exists_ActPriema, comboBox2.Text.Split(' ')[1]);
                if (output == "0")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Acts, ID, comboBox1.Text,
                    MySqlOperations.Select_Text(MySqlQueries.Select_Dogovory_ID, null, comboBox2.Text),
                    MySqlOperations.Select_Text(MySqlQueries.Select_Sotrudniki_ID, null, comboBox3.Text),
                    MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox4.Text),
                    textBox1.Text);
                    this.Close();
                }
                else
                    MessageBox.Show("Для выбранного вами договора уже составлен " + comboBox1.Text.ToLower() + '.', "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Acts_FormClosed(object sender, FormClosedEventArgs e)
        {
            Acts_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Acts_Closed;

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MySqlOperations.Search_In_ComboBox(MySqlOperations.Select_Text(MySqlQueries.Select_Avto_Dogovora, null, comboBox2.Text), comboBox4);
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == comboBox1.Items[0])
                MySqlOperations.Select_ComboBox(MySqlQueries.Select_Deistv_Dogovory_ComboBox, comboBox2);
            else if (comboBox1.SelectedItem == comboBox1.Items[1])
                MySqlOperations.Select_ComboBox(MySqlQueries.Select_Nedeistv_Dogovory_ComboBox, comboBox2);
            if (comboBox2.Items.Count < 1 && comboBox1.SelectedItem == comboBox1.Items[0])
            {
                MessageBox.Show("На данный момент нет действительных договоров.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else if (comboBox2.Items.Count < 1 && comboBox1.SelectedItem == comboBox1.Items[1])
            {
                MessageBox.Show("На данный момент нет не действительных договоров.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}
