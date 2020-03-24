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
    public partial class Dogovory : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = null;
        public Dogovory(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Sotrudniki_ComboBox, comboBox1);
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Avtopark_ComboBox, comboBox3);
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Clienty_ComboBox, comboBox2);
            //dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MySqlOperations.Select_Text(MySqlQueries.Select_Identify_Avto, MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox3.Text)) != "Занята")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Dogovory, null,
                        MySqlOperations.Select_Text(MySqlQueries.Select_Sotrudniki_ID, null, comboBox1.Text),
                        MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID, null, comboBox2.Text),
                        dateTimePicker1.Value.Year.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString(),
                        dateTimePicker2.Value.Year.ToString() + "-" + dateTimePicker2.Value.Month.ToString() + "-" + dateTimePicker2.Value.Day.ToString(),
                        textBox1.Text.Replace(',', '.'), MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox3.Text),
                        DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString());
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Identify_Avtopark1, MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox3.Text));
                    if (MessageBox.Show("Хотите оформить акт осмотра?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        this.DialogResult = DialogResult.Yes;
                    else
                        this.DialogResult = DialogResult.No;
                    this.Close();
                }
                else
                    MessageBox.Show("На данный момент выбранный автомобиль занят.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Dogovory, ID, 
                    MySqlOperations.Select_Text(MySqlQueries.Select_Sotrudniki_ID, null, comboBox1.Text), 
                    MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID, null, comboBox2.Text), 
                    dateTimePicker1.Value.Year.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString(), 
                    dateTimePicker2.Value.Year.ToString() + "-" + dateTimePicker2.Value.Month.ToString() + "-" + dateTimePicker2.Value.Day.ToString(), 
                    textBox1.Text.Replace(',', '.'), MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox3.Text));
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Identify_Avtopark1, MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox3.Text));
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Dogovory_FormClosed(object sender, FormClosedEventArgs e) => Dogovory_Closed(this, EventArgs.Empty);
        public event EventHandler Dogovory_Closed;

        private void button4_Click(object sender, EventArgs e) => Summa();

        public void Summa() => textBox1.Text = (decimal.Parse(MySqlOperations.Select_Text(MySqlQueries.Select_Stoimost, MySqlOperations.Select_Text(MySqlQueries.Select_Avtopark_ID, null, comboBox3.Text))) * decimal.Parse((dateTimePicker2.Value.Date - dateTimePicker1.Value.Date).TotalDays.ToString())).ToString();

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) => Summa();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
                dateTimePicker2.MinDate = dateTimePicker2.Value;
            }
            catch (Exception) { }
        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) => Summa();

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MySqlOperations.Select_Text(MySqlQueries.Select_Prava_Exists, MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID,null,comboBox2.Text)) != "0") 
            {
                string output = string.Empty;
                foreach (string Categoriya in MySqlOperations.Select_Text(MySqlQueries.Select_Prava_Clienty, MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID, null, comboBox2.Text)).Split(' '))
                {
                    output += "'" + Categoriya + "',";
                }
                MySqlOperations.Select_ComboBox(MySqlQueries.Select_Avtopark_ComboBox1 + output.Remove(output.Length - 1, 1) + ");", comboBox3);
                if (comboBox3.Items.Count < 1)
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                    MessageBox.Show("На данный момент нет свободных автомобилей для данного клиента.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                } 
            }
            else
            {
                button1.Enabled = false;
                button3.Enabled = false;
                MessageBox.Show("Для данного клиента не заполнены сведения о вод. удостоверении."+'\n'+"Пожалуйста заполните внесите сведения, прежде чем заключать договор.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
