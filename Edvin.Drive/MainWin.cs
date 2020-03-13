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
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string identify = string.Empty;

        public Form1()
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
                doljnosti.ShowDialog();
            }
            //if (identify == "raschetniki")
            //{
            //    Raschetniki raschetniki = new Raschetniki(MySqlOperations, MySqlQueries);
            //    raschetniki.Raschetniki_Closed += РасчетныеСчетаToolStripMenuItem_Click;
            //    raschetniki.Owner = this;
            //    raschetniki.button1.Visible = true;
            //    raschetniki.button3.Visible = false;
            //    raschetniki.AcceptButton = raschetniki.button1;
            //    raschetniki.Show();
            //}
            //else if (identify == "otdely")
            //{
            //    Otdely otdely = new Otdely(MySqlOperations, MySqlQueries);
            //    otdely.Otdely_Closed += ОтделыToolStripMenuItem_Click;
            //    otdely.Owner = this;
            //    otdely.button1.Visible = true;
            //    otdely.button3.Visible = false;
            //    otdely.AcceptButton = otdely.button1;
            //    otdely.Show();
            //}
            //else if (identify == "sotrudniki")
            //{
            //    Sotrudniki sotrudniki = new Sotrudniki(MySqlOperations, MySqlQueries);
            //    sotrudniki.Sotrudniki_Closed += СотрудникиToolStripMenuItem1_Click;
            //    sotrudniki.Owner = this;
            //    if (sotrudniki.comboBox1.Items.Count == 0 && Role[3] != '0')
            //        Sotrudniki_After_Otdely(sotrudniki);
            //    if (sotrudniki.comboBox2.Items.Count == 0 && Role[0] != '0')
            //        Sotrudniki_After_Doljnosti(sotrudniki);
            //    if (sotrudniki.comboBox3.Items.Count == 0 && Role[2] != '0')
            //        Sotrudniki_After_Oklad(sotrudniki);
            //    if (sotrudniki.comboBox4.Items.Count == 0 && Role[4] != '0')
            //        Sotrudniki_After_RS(sotrudniki);
            //    sotrudniki.button1.Visible = true;
            //    sotrudniki.button3.Visible = false;
            //    sotrudniki.AcceptButton = sotrudniki.button1;
            //    sotrudniki.Show();
            //}
            //else if (identify == "oklad")
            //{
            //    Oklad oklad = new Oklad(MySqlOperations, MySqlQueries);
            //    oklad.Oklad_Closed += ОкладToolStripMenuItem_Click;
            //    oklad.Owner = this;
            //    oklad.button1.Visible = true;
            //    oklad.button3.Visible = false;
            //    oklad.AcceptButton = oklad.button1;
            //    oklad.Show();
            //}
            //else if (identify == "vyplaty")
            //{
            //    Vyplaty vyplaty = new Vyplaty(MySqlOperations, MySqlQueries);
            //    vyplaty.Vyplaty_Closed += ВыплатыЗарплатыToolStripMenuItem_Click;
            //    vyplaty.Owner = this;
            //    vyplaty.Show();
            //}
        }

        public void Update_String()
        {

        }

        private void Delete_String()
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись(-и)?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    //if (identify == "raschetniki")
                    //{
                    //    MySqlOperations.Delete(MySqlQueries.Delete_Rasch_Scheta, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    //    identify = "raschetniki";
                    //    DataGrid_Load(MySqlQueries.Select_Rasch_Scheta);
                    //    this.Text = "Расчетные счета";
                    //}
                    //else if (identify == "otdely")
                    //{

                    //    MySqlOperations.Delete(MySqlQueries.Delete_Otdely, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    //    identify = "otdely";
                    //    DataGrid_Load(MySqlQueries.Select_Otdely);
                    //    this.Text = "Отделы";
                    //}
                    //else if (identify == "sotrudniki")
                    //{
                    //    MySqlOperations.Delete(MySqlQueries.Delete_Sotrudniki, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    //    identify = "sotrudniki";
                    //    DataGrid_Load(MySqlQueries.Select_Sotrudniki);
                    //    this.Text = "Сотрудники";
                    //}
                    //else if (identify == "oklad")
                    //{
                    //    MySqlOperations.Delete(MySqlQueries.Delete_Oklad, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    //    identify = "oklad";
                    //    DataGrid_Load(MySqlQueries.Select_Oklad);
                    //    this.Text = "Оклад";
                    //}
                    //else if (identify == "doljnosti")
                    //{
                    //    MySqlOperations.Delete(MySqlQueries.Delete_Doljnosti, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    //    identify = "doljnosti";
                    //    DataGrid_Load(MySqlQueries.Select_Doljnosti);
                    //    this.Text = "Должности";
                    //}
                    //else if (identify == "vyplaty")
                    //{
                    //    MySqlOperations.Delete(MySqlQueries.Delete_Vyplaty, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    //    identify = "vyplaty";
                    //    DataGrid_Load(MySqlQueries.Select_Vyplaty);
                    //    this.Text = "Выплаты зарплаты";
                    //}
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
