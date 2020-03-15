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
    public partial class Doljnosti : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = null;
        public Doljnosti(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Doljnosti, null, textBox1.Text);
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
            if (textBox1.Text != "")
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Doljnosti, ID, textBox1.Text);
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Doljnosti_FormClosed(object sender, FormClosedEventArgs e)
        {
            Doljnosti_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Doljnosti_Closed;
    }
}
