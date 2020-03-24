using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using WindowState = System.Windows.Forms.FormWindowState;

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
            if (toolStripTextBox1.Text != "")
                MySqlOperations.Search(toolStripTextBox1, dataGridView1);
            else
            {
                dataGridView1.ClearSelection();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    dataGridView1.Rows[i].Visible = true;
            }
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

        private void актыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Acts, dataGridView1);
            identify = "acts";
            dataGridView1.Columns[0].Visible = false;
        }

        private void действительныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory_Deistv, dataGridView1);
            identify = "dogovory";
            dataGridView1.Columns[0].Visible = false;
        }

        private void неДействительныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory_Nedeistv, dataGridView1);
            identify = "dogovory";
            dataGridView1.Columns[0].Visible = false;
        }

        private void актыПриСдачеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Acts_Sdachi, dataGridView1);
            identify = "acts";
            dataGridView1.Columns[0].Visible = false;
        }

        private void актыПриПриемеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Acts_Priema, dataGridView1);
            identify = "acts";
            dataGridView1.Columns[0].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlOperations.OpenConnection();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory, dataGridView1);
                identify = "dogovory";
                dataGridView1.Columns[0].Visible = false;
                if (MySqlOperations.Select_Text(MySqlQueries.Select_Exists_Nedeistv_Dogovory) == "1")
                {
                    ArrayList list = new ArrayList();
                    MySqlOperations.Select_List(MySqlQueries.Select_List_Nedeistv_Dogovory, ref list);
                    int Count = 0;
                    foreach (var s in list)
                    {
                        if (MessageBox.Show("Договор " + s.ToString() + " прекращает своё действие. Желаете его закрыть и оформить акт осмотра авто?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Identify_Dogovory, s.ToString().Split(' ')[1]);
                            MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Identify_Avtopark, s.ToString().Split(' ')[1]);
                            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory, dataGridView1);
                            dataGridView1.Columns[0].Visible = false;
                            Acts acts = new Acts(MySqlOperations, MySqlQueries);
                            acts.button1.Visible = true;
                            acts.button3.Visible = false;
                            acts.AcceptButton = acts.button1;
                            acts.comboBox1.SelectedItem = acts.comboBox1.Items[1];
                            MySqlOperations.Search_In_ComboBox(s.ToString(), acts.comboBox2);
                            acts.comboBox1.Enabled = false;
                            acts.comboBox2.Enabled = false;
                            acts.comboBox3.Enabled = false;
                            acts.comboBox4.Enabled = false;
                            acts.Acts_Closed += актыToolStripMenuItem_Click;
                            acts.Owner = this;
                            acts.Show();
                            Count++;
                        }
                        else
                        {
                            MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_K_Date_Dogovory, s.ToString().Split(' ')[1]);
                            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory, dataGridView1);
                            identify = "dogovory";
                            dataGridView1.Columns[0].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не обнаружена база данных или сервер не активен." + '\n' + "Обратитесь к системному администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
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

        public void Filter()
        {
            if (identify == "doljnosti")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Doljnosti_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
            else if (identify == "price")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Price_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
            else if (identify == "avtopark")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Avtopark_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
            else if (identify == "sotrudniki")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
            else if (identify == "clienty")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Clienty_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
            else if (identify == "prava")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Prava_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
            else if (identify == "dogovory")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
            else if (identify == "acts")
            {
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Acts_Filter, dataGridView1, null, "%" + toolStripTextBox1.Text + "%");
                dataGridView1.Columns[0].Visible = false;
            }
        }

        public async void Insert_String()
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
                await MySqlOperations.GetTaskFromEvent(clienty, "FormClosed");
                if (clienty.DialogResult == DialogResult.Yes)
                {
                    Prava prava = new Prava(MySqlOperations, MySqlQueries);
                    prava.button1.Visible = true;
                    prava.button3.Visible = false;
                    prava.AcceptButton = prava.button1;
                    prava.comboBox3.Items.Clear();
                    MySqlOperations.Select_ComboBox(MySqlQueries.Select_Clienty_ComboBoxIsNull, prava.comboBox3);
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), prava.comboBox3);
                    if (prava.comboBox3.Items.Count > 0)
                    {
                        prava.Prava_Closed += клиентыToolStripMenuItem_Click;
                        prava.Owner = this;
                        prava.Show();
                    }
                }
            }
            else if (identify == "prava")
            {
                Prava prava = new Prava(MySqlOperations, MySqlQueries);
                prava.button1.Visible = true;
                prava.button3.Visible = false;
                prava.AcceptButton = prava.button1;
                prava.comboBox3.Items.Clear();
                MySqlOperations.Select_ComboBox(MySqlQueries.Select_Clienty_ComboBoxIsNull, prava.comboBox3);
                if (prava.comboBox3.Items.Count > 0)
                {
                    prava.Prava_Closed += водПраваToolStripMenuItem_Click;
                    prava.Owner = this;
                    prava.Show();
                }
                else
                {
                    MessageBox.Show("Для всех записей клиентов уже существуют записи в данной таблице.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    prava.Dispose();
                }
            }
            else if (identify == "dogovory")
            {
                Dogovory dogovory = new Dogovory(MySqlOperations, MySqlQueries);
                dogovory.button1.Visible = true;
                dogovory.button3.Visible = false;
                dogovory.AcceptButton = dogovory.button1;
                dogovory.dateTimePicker1.Value = DateTime.Now;
                dogovory.dateTimePicker1.MinDate = dogovory.dateTimePicker1.Value;
                dogovory.dateTimePicker1.MaxDate = dogovory.dateTimePicker1.Value;
                dogovory.Dogovory_Closed += договорыToolStripMenuItem_Click;
                dogovory.Owner = this;
                dogovory.Show();
                await MySqlOperations.GetTaskFromEvent(dogovory, "FormClosed");
                if (dogovory.DialogResult == DialogResult.Yes)
                {
                    Acts acts = new Acts(MySqlOperations, MySqlQueries);
                    acts.button1.Visible = true;
                    acts.button3.Visible = false;
                    acts.AcceptButton = acts.button1;
                    acts.comboBox1.SelectedItem = acts.comboBox1.Items[0];
                    MySqlOperations.Search_In_ComboBox(MySqlOperations.Select_Text(MySqlQueries.Select_Dogovor,
                        MySqlOperations.Select_Text(MySqlQueries.Select_Last_Insert_Dogovor)), acts.comboBox2);
                    acts.comboBox1.Enabled = false;
                    acts.comboBox2.Enabled = false;
                    acts.comboBox3.Enabled = false;
                    acts.comboBox4.Enabled = false;
                    acts.Acts_Closed += актыToolStripMenuItem_Click;
                    acts.Owner = this;
                    acts.Show();
                }
            }
            else if (identify == "acts")
            {
                Acts acts = new Acts(MySqlOperations, MySqlQueries);
                acts.button1.Visible = true;
                acts.button3.Visible = false;
                acts.AcceptButton = acts.button1;
                acts.Acts_Closed += актыToolStripMenuItem_Click;
                acts.Owner = this;
                acts.Show();
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
                    avtopark.numericUpDown1.Value = decimal.Parse(dataGridView1.SelectedRows[i].Cells[7].Value.ToString());
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
                else if (identify == "prava")
                {
                    Prava prava = new Prava(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    prava.button3.Visible = true;
                    prava.button1.Visible = false;
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), prava.comboBox3);
                    prava.comboBox3.Enabled = false;
                    prava.maskedTextBox2.Text = dataGridView1.SelectedRows[i].Cells[2].Value.ToString();
                    prava.Check_Otkr_Categorii(dataGridView1.SelectedRows[i].Cells[3].Value.ToString());
                    prava.AcceptButton = prava.button3;
                    prava.Prava_Closed += водПраваToolStripMenuItem_Click;
                    prava.Owner = this;
                    prava.Show();
                }
                else if (identify == "dogovory")
                {
                    if (dataGridView1.SelectedRows[i].Cells[8].Value.ToString() != "Не действительный")
                    {
                        Dogovory dogovory = new Dogovory(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                        dogovory.button3.Visible = true;
                        dogovory.button1.Visible = false;
                        MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[2].Value.ToString(), dogovory.comboBox1);
                        MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), dogovory.comboBox2);
                        MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), dogovory.comboBox3);
                        dogovory.comboBox1.Enabled = false;
                        dogovory.comboBox2.Enabled = false;
                        dogovory.comboBox3.Enabled = false;
                        dogovory.dateTimePicker1.Enabled = false;
                        dogovory.dateTimePicker1.Value = DateTime.Parse(dataGridView1.SelectedRows[i].Cells[5].Value.ToString());
                        dogovory.dateTimePicker1.MinDate = dogovory.dateTimePicker1.Value;
                        dogovory.dateTimePicker1.MaxDate = dogovory.dateTimePicker1.Value;
                        dogovory.dateTimePicker2.Value = DateTime.Parse(dataGridView1.SelectedRows[i].Cells[6].Value.ToString());
                        dogovory.Summa();
                        dogovory.AcceptButton = dogovory.button3;
                        dogovory.Dogovory_Closed += договорыToolStripMenuItem_Click;
                        dogovory.Owner = this;
                        dogovory.Show();
                    }
                    else
                        MessageBox.Show("Данный договор не действительный. Редактирование невозможно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (identify == "acts")
                {
                    Acts acts = new Acts(MySqlOperations, MySqlQueries, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    acts.button3.Visible = true;
                    acts.button1.Visible = false;
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), acts.comboBox1);
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), acts.comboBox2);
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), acts.comboBox3);
                    acts.comboBox1.Enabled = false;
                    acts.comboBox2.Enabled = false;
                    acts.comboBox3.Enabled = false;
                    acts.textBox1.Text = MySqlOperations.Select_Text(MySqlQueries.Select_Comments_Act, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    acts.AcceptButton = acts.button3;
                    acts.Acts_Closed += актыToolStripMenuItem_Click;
                    acts.Owner = this;
                    acts.Show();
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
                else if (identify == "prava")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Prava, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Prava, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "dogovory")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Dogovory, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Identify_Avtopark, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "acts")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Acts, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Acts, dataGridView1);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите отредактировать запись?", "Вопрос", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Update_String();
            }
            else if (result == DialogResult.No)
            {
                if (identify == "clienty")
                {
                    if (MySqlOperations.Select_Text(MySqlQueries.Select_Prava_Exists, dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) != "1")
                    {
                        if (MessageBox.Show("Желаете добавить водительские права данного клиента?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Prava prava = new Prava(MySqlOperations, MySqlQueries);
                            prava.button1.Visible = true;
                            prava.button3.Visible = false;
                            prava.AcceptButton = prava.button1;
                            prava.comboBox3.Items.Clear();
                            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Clienty_ComboBoxIsNull, prava.comboBox3);
                            MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), prava.comboBox3);
                            if (prava.comboBox3.Items.Count > 0)
                            {
                                prava.Prava_Closed += клиентыToolStripMenuItem_Click;
                                prava.Owner = this;
                                prava.Show();
                            }
                        } 
                    }
                    else
                        MessageBox.Show("Для данного клиента уже существует запись о его вод. удостоверении.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (identify == "dogovory")
                {
                    if (MessageBox.Show("Хотите закрыть данный договор?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Identify_Dogovory, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        MySqlOperations.Insert_Update_Delete(MySqlQueries.Update_Identify_Avtopark, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        if (MySqlOperations.Select_Text(MySqlQueries.Select_Exists_ActPriema, dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) == "0")
                        {
                            if (MessageBox.Show("Хотите составить акт осмотра?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Acts acts = new Acts(MySqlOperations, MySqlQueries);
                                acts.button1.Visible = true;
                                acts.button3.Visible = false;
                                acts.AcceptButton = acts.button1;
                                acts.comboBox1.SelectedItem = acts.comboBox1.Items[1];
                                MySqlOperations.Search_In_ComboBox(MySqlOperations.Select_Text(MySqlQueries.Select_Dogovor,
                                    dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), acts.comboBox2);
                                acts.comboBox1.Enabled = false;
                                acts.comboBox2.Enabled = false;
                                acts.comboBox3.Enabled = false;
                                acts.comboBox4.Enabled = false;
                                if (MessageBox.Show("Хотите перейти в журнал актов после операции?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    acts.Acts_Closed += актыToolStripMenuItem_Click;
                                else
                                    acts.Acts_Closed += договорыToolStripMenuItem_Click;
                                acts.Owner = this;
                                acts.Show();
                            }
                        }
                        else
                        {
                            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory, dataGridView1);
                            dataGridView1.Columns[0].Visible = false;
                        }
                    }
                }
            }
        }

        private void фильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                if (identify == "doljnosti")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Doljnosti, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "price")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Price, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "avtopark")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Avtopark, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "sotrudniki")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sotrudniki, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "clienty")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Clienty, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "prava")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Prava, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "dogovory")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Dogovory, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
                else if (identify == "acts")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Acts, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                }
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (identify == "dogovory")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Print_Dogovor(saveFileDialog1, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
            }
            else if(identify == "acts")
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    MySqlOperations.Print_Acts(saveFileDialog1, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
            }
        }

        private void MainWin_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                toolStripTextBox1.Width += 200;
                toolStripTextBox1.Height = 23;
                dataGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            }
            else if (this.WindowState == WindowState.Normal)
            {
                toolStripTextBox1.Width -= 200;
                toolStripTextBox1.Height = 23;
                dataGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
            }
        }

        private void заНеделюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dataTable = MySqlOperations.Select_DataTable(MySqlQueries.Select_Statistics_Week, null, null);
            Statistics statistics = new Statistics();
            statistics.Text = "Статистика " + заНеделюToolStripMenuItem.Text.ToLower();
            statistics.chart1.Series[0].Name = "Количество аренд";
            statistics.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                statistics.chart1.Series[0].Points.AddXY(dataTable.Rows[i][0].ToString(), int.Parse(dataTable.Rows[i][1].ToString()));
            }
            statistics.Show();
        }

        private void заМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dataTable = MySqlOperations.Select_DataTable(MySqlQueries.Select_Statistics_Month, null, null);
            Statistics statistics = new Statistics();
            statistics.Text = "Статистика " + заНеделюToolStripMenuItem.Text.ToLower();
            statistics.chart1.Series[0].Name = "Количество аренд";
            statistics.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                statistics.chart1.Series[0].Points.AddXY(dataTable.Rows[i][0].ToString(), int.Parse(dataTable.Rows[i][1].ToString()));
            }
            statistics.Show();
        }

        private void заГодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dataTable = MySqlOperations.Select_DataTable(MySqlQueries.Select_Statistics_Year, null, null);
            Statistics statistics = new Statistics();
            statistics.Text = "Статистика " + заНеделюToolStripMenuItem.Text.ToLower();
            statistics.chart1.Series[0].Name = "Количество аренд";
            statistics.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                statistics.chart1.Series[0].Points.AddXY(dataTable.Rows[i][0].ToString(), int.Parse(dataTable.Rows[i][1].ToString()));
            }
            statistics.Show();
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($@"Программа Edvin.Drive разработана по индивидуальному заданию на курсовой проект Базы Данных и СУБД.
Программа позволяет осуществлять функции добавления, удаления, редактирования записей таблиц. Предусмотрен вывод на печать следующих докуметов: Договор на аренду, Акты осмотра при сдачи (приеме) в(из) аренду(-ы).
Также программа имеет функцию построения статистических графиков за выбранных период. Предусмотренны проверки нежелательных действий пользователя, а также триггеры для таблиц базы данных.
Программу разработал учащийся группы ПО-41 Шишков Андрей Алексеевич.");
        }
    }
}
