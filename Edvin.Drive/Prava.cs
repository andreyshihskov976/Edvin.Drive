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
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Prava, null, MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID, null, comboBox3.Text), maskedTextBox2.Text, Otkr_Categorii());
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string Otkr_Categorii()
        {
            string Otkr_Categorii = string.Empty;
            if (checkBox1.Checked)
                Otkr_Categorii += "AM ";
            if (checkBox2.Checked)
                Otkr_Categorii += "A1 ";
            if (checkBox3.Checked)
                Otkr_Categorii += "A ";
            if (checkBox4.Checked)
                Otkr_Categorii += "B ";
            if (checkBox5.Checked)
                Otkr_Categorii += "C ";
            if (checkBox6.Checked)
                Otkr_Categorii += "D ";
            return Otkr_Categorii.Remove(Otkr_Categorii.Length-1,1);
        }

        public void Check_Otkr_Categorii(string Otkr_Categorii)
        {
            foreach (string Categoriya in Otkr_Categorii.Split(' ')) 
            {
                if (Categoriya == "AM")
                    checkBox1.Checked = true;
                if (Categoriya == "A1")
                    checkBox2.Checked = true;
                if (Categoriya == "A")
                    checkBox3.Checked = true;
                if (Categoriya == "B")
                    checkBox4.Checked = true;
                if (Categoriya == "C")
                    checkBox5.Checked = true;
                if (Categoriya == "D")
                    checkBox6.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text.Length == 9)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Prava, ID, MySqlOperations.Select_Text(MySqlQueries.Select_Clienty_ID, null, comboBox3.Text), maskedTextBox2.Text, Otkr_Categorii());
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
