using System;
using System.Windows.Forms;

namespace Edvin.Drive
{
    public partial class Clienty : Form
    {
        MySqlOperations MySqlOperations = null;
        MySqlQueries MySqlQueries = null;
        string ID = null;
        public Clienty(MySqlOperations mySqlOperations, MySqlQueries mySqlQueries, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlQueries = mySqlQueries;
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text.Length == 17 && maskedTextBox3.Text.Length == 9 && maskedTextBox4.Text.Length == 14)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Insert_Clienty, null, textBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox1.Text, textBox4.Text, maskedTextBox3.Text, maskedTextBox4.Text);
                if (MessageBox.Show("Пожалуйста добавьте сведения о водительском удостоверении клиента.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    this.DialogResult = DialogResult.Yes;
                else
                    this.DialogResult = DialogResult.No;
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text.Length == 17 && maskedTextBox3.Text.Length == 9 && maskedTextBox4.Text.Length == 14)
            {
                MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Clienty, ID, textBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox1.Text, textBox4.Text, maskedTextBox3.Text, maskedTextBox4.Text);
                this.Close();
            }
            else
                MessageBox.Show("Проверьте, все ли поля заполнены.", "Предупрждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Clienty_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clienty_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Clienty_Closed;
    }
}
