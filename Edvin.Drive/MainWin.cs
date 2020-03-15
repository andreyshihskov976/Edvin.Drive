using System;
using System.Windows.Forms;

namespace Edvin.Drive
{
    public partial class MainWin : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string identify = string.Empty;

        public MainWin()
        {
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Search(toolStripTextBox1, dataGridView1);
        }

        private void договорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory, dataGridView1);
            identify = "dogovory";
            dataGridView1.Columns[0].Visible = false;
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Clienty, dataGridView1);
            identify = "clienty";
            dataGridView1.Columns[0].Visible = false;
        }

        private void водПраваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Prava, dataGridView1);
            identify = "prava";
            dataGridView1.Columns[0].Visible = false;
        }

        private void автопаркToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Avtopark, dataGridView1);
            identify = "avtopark";
            dataGridView1.Columns[0].Visible = false;
        }

        private void прайслистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Price, dataGridView1);
            identify = "price";
            dataGridView1.Columns[0].Visible = false;
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Doljnosti, dataGridView1);
            identify = "doljnosti";
            dataGridView1.Columns[0].Visible = false;
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki, dataGridView1);
            identify = "sotrudniki";
            dataGridView1.Columns[0].Visible = false;
        }

        private void актыСдачиАвтоВАрендуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Act_Sdachi, dataGridView1);
            identify = "act_sdachi";
            dataGridView1.Columns[0].Visible = false;
        }

        private void актыПриемкиАвтоПослеАрендыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Act_Priemki, dataGridView1);
            identify = "act_priemki";
            dataGridView1.Columns[0].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySqlOperations.CloseConnection();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.CloseConnection();
            Application.Exit();
        }

        public void Insert_String()
        {
            if (identify == "doljnosti")
            {
                Doljnosti doljnosti = new Doljnosti(MySqlOperations, MySqlQueries);
                doljnosti.button1.Visible = true;
                doljnosti.button3.Visible = false;
                doljnosti.AcceptButton = doljnosti.button1;
                doljnosti.Doljnosti_Closed += должностиToolStripMenuItem_Click;
                doljnosti.Owner = this;
                doljnosti.Show();
            }
            else if (identify == "price")
            {
                Price price = new Price(MySqlOperations, MySqlQueries);
                price.button1.Visible = true;
                price.button3.Visible = false;
                price.AcceptButton = price.button1;
                price.Price_Closed += прайслистToolStripMenuItem_Click;
                price.Owner = this;
                price.Show();
            }
            else if (identify == "avtopark")
            {
                Avtopark avtopark = new Avtopark(MySqlOperations, MySqlQueries);
                avtopark.button1.Visible = true;
                avtopark.button3.Visible = false;
                avtopark.AcceptButton = avtopark.button1;
                avtopark.Avtopark_Closed += автопаркToolStripMenuItem_Click;
                avtopark.Owner = this;
                avtopark.Show();
            }
            else if (identify == "sotrudniki")
            {
                Sotrudniki sotrudniki = new Sotrudniki(MySqlOperations, MySqlQueries);
                sotrudniki.button1.Visible = true;
                sotrudniki.button3.Visible = false;
                sotrudniki.AcceptButton = sotrudniki.button1;
                sotrudniki.Sotrudniki_Closed += сотрудникиToolStripMenuItem_Click;
                sotrudniki.Owner = this;
                sotrudniki.Show();
            }
            else if (identify == "clienty")
            {
                Clienty clienty = new Clienty(MySqlOperations, MySqlQueries);
                clienty.button1.Visible = true;
                clienty.button3.Visible = false;
                clienty.AcceptButton = clienty.button1;
                clienty.Clienty_Closed += клиентыToolStripMenuItem_Click;
                clienty.Owner = this;
                clienty.Show();
            }
        }

        public void Update_String()
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                if (identify == "doljnosti")
                {
                    Doljnosti doljnosti = new Doljnosti(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    doljnosti.button3.Visible = true;
                    doljnosti.button1.Visible = false;
                    doljnosti.textBox1.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString();
                    doljnosti.AcceptButton = doljnosti.button3;
                    doljnosti.Doljnosti_Closed += должностиToolStripMenuItem_Click;
                    doljnosti.Owner = this;
                    doljnosti.Show();
                }
                else if (identify == "price")
                {
                    Price price = new Price(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    price.button3.Visible = true;
                    price.button1.Visible = false;
                    price.textBox1.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString();
                    price.numericUpDown1.Value = decimal.Parse(dataGridView1.SelectedRows[i].Cells[2].Value.ToString());
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), price.comboBox1);
                    price.AcceptButton = price.button3;
                    price.Price_Closed += прайслистToolStripMenuItem_Click;
                    price.Owner = this;
                    price.Show();
                }
                else if (identify == "avtopark")
                {
                    Avtopark avtopark = new Avtopark(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    avtopark.button3.Visible = true;
                    avtopark.button1.Visible = false;
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), avtopark.comboBox1);
                    avtopark.textBox1.Text = dataGridView1.SelectedRows[i].Cells[2].Value.ToString();
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), avtopark.comboBox2);
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), avtopark.comboBox3);
                    avtopark.maskedTextBox1.Text = dataGridView1.SelectedRows[i].Cells[5].Value.ToString();
                    avtopark.maskedTextBox2.Text = dataGridView1.SelectedRows[i].Cells[6].Value.ToString();
                    avtopark.AcceptButton = avtopark.button3;
                    avtopark.Avtopark_Closed += автопаркToolStripMenuItem_Click;
                    avtopark.Owner = this;
                    avtopark.Show();
                }
                else if (identify == "sotrudniki")
                {
                    Sotrudniki sotrudniki = new Sotrudniki(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    sotrudniki.button3.Visible = true;
                    sotrudniki.button1.Visible = false;
                    sotrudniki.textBox1.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString().Split(' ')[0];
                    sotrudniki.textBox2.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString().Split(' ')[1];
                    sotrudniki.textBox3.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString().Split(' ')[2];
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[2].Value.ToString(), sotrudniki.comboBox1);
                    sotrudniki.maskedTextBox1.Text = dataGridView1.SelectedRows[i].Cells[3].Value.ToString();
                    sotrudniki.AcceptButton = sotrudniki.button3;
                    sotrudniki.Sotrudniki_Closed += сотрудникиToolStripMenuItem_Click;
                    sotrudniki.Owner = this;
                    sotrudniki.Show();
                }
                else if (identify == "clienty")
                {
                    Clienty clienty = new Clienty(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    clienty.button3.Visible = true;
                    clienty.button1.Visible = false;
                    clienty.textBox1.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString().Split(' ')[0];
                    clienty.textBox2.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString().Split(' ')[1];
                    clienty.textBox3.Text = dataGridView1.SelectedRows[i].Cells[1].Value.ToString().Split(' ')[2];
                    clienty.maskedTextBox1.Text = dataGridView1.SelectedRows[i].Cells[2].Value.ToString();
                    clienty.textBox4.Text = dataGridView1.SelectedRows[i].Cells[3].Value.ToString();
                    clienty.maskedTextBox3.Text = dataGridView1.SelectedRows[i].Cells[4].Value.ToString();
                    clienty.maskedTextBox4.Text = dataGridView1.SelectedRows[i].Cells[5].Value.ToString();
                    clienty.AcceptButton = clienty.button3;
                    clienty.Clienty_Closed += клиентыToolStripMenuItem_Click;
                    clienty.Owner = this;
                    clienty.Show();
                }
            }
        }

        private void Delete_String()
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись(-и)?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (identify == "doljnosti")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Doljnosti, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Doljnosti, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "price")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Price, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Price, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "avtopark")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Avtopark, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Avtopark, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "sotrudniki")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Sotrudniki, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "clienty")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Clienty, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Clienty, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
            }
        }

        private void выделитьвсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void вставкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert_String();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_String();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_String();
        }
    }
}
