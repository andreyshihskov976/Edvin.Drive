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
    }
}
