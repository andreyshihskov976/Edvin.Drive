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
                    doljnosti.AcceptButton = doljnosti.button1;
                    doljnosti.Doljnosti_Closed += должностиToolStripMenuItem_Click;
                    doljnosti.Owner = this;
                    doljnosti.Show();
                }
            }
        }

        private void Delete_String()
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись(-и)?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    if (identify == "doljnosti")
                    {
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Doljnosti, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                        MySqlOperations.Select_DataGridView(MySqlQueries.Select_Doljnosti, dataGridView1);
                        dataGridView1.Columns[0].Visible = false;
                    }
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
