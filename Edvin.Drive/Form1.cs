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
    public partial class Form1 : Form
    {
        MySqlQueries mySqlQueries = null;
        MySqlOperations mySqlOperations = null;
        string identify = string.Empty;

        public Form1()
        {
            InitializeComponent();
            mySqlQueries = new MySqlQueries();
            mySqlOperations = new MySqlOperations(mySqlQueries);
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Search(toolStripTextBox1, dataGridView1);
        }

        private void договорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Select_DataGridView(mySqlQueries.Select_Dogovory, dataGridView1);
            identify = "dogovory";
            dataGridView1.Columns[0].Visible = false;
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Select_DataGridView(mySqlQueries.Select_Clienty, dataGridView1);
            identify = "clienty";
            dataGridView1.Columns[0].Visible = false;
        }

        private void водПраваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Select_DataGridView(mySqlQueries.Select_Prava, dataGridView1);
            identify = "prava";
            dataGridView1.Columns[0].Visible = false;
        }

        private void автопаркToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Select_DataGridView(mySqlQueries.Select_Avtopark, dataGridView1);
            identify = "avtopark";
            dataGridView1.Columns[0].Visible = false;
        }

        private void прайслистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Select_DataGridView(mySqlQueries.Select_Price, dataGridView1);
            identify = "price";
            dataGridView1.Columns[0].Visible = false;
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Select_DataGridView(mySqlQueries.Select_Doljnosti, dataGridView1);
            identify = "doljnosti";
            dataGridView1.Columns[0].Visible = false;
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.Select_DataGridView(mySqlQueries.Select_Sotrudniki, dataGridView1);
            identify = "sotrudniki";
            dataGridView1.Columns[0].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mySqlOperations.OpenConnection();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mySqlOperations.CloseConnection();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySqlOperations.CloseConnection();
            Application.Exit();
        }
    }
}
