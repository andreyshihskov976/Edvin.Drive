using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace Edvin.Drive
{
    public class MySqlOperations
    {
        public MySqlConnection mySqlConnection = new MySqlConnection("server=localhost; user=root; database=prokat_avto; port=3306; password=; charset=utf8;");
        public MySqlQueries MySqlQueries = null;

        MySqlDataReader sqlDataReader = null;

        MySqlDataAdapter dataAdapter = null;

        DataSet dataSet = null;

        MySqlCommand sqlCommand = null;

        public MySqlOperations(MySqlQueries sqlQueries)
        {
            this.MySqlQueries = sqlQueries;
        }
        //Подключение (Закрытие подключения) к Базе Данных
        public void OpenConnection()
        {
            mySqlConnection.Open();
        }
        public void CloseConnection()
        {
            mySqlConnection.Close();
        }
        //Подключение (Закрытие подключения) к Базе Данных

        //Универсальные методы
        public void Select_DataGridView(string query, DataGridView dataGridView, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null)
        {
            try
            {
                dataGridView.DataSource = null;
                dataSet = new DataSet();
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                dataAdapter = new MySqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataSet);
                dataGridView.DataSource = dataSet.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Select_ComboBox(string query, ComboBox comboBox)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox.Items.Add(Convert.ToString(sqlDataReader[0]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                if (comboBox.Items.Count != 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        public void Search_In_ComboBox(string s, ComboBox comboBox)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString().Contains(s))
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        //public string Select_ID_From_ComboBox(string query, string Value)
        //{
        //    string ID = null;
        //    try
        //    {
        //        sqlCommand = new MySqlCommand(query, mySqlConnection);
        //        sqlCommand.Parameters.AddWithValue("Value1", Value);
        //        sqlDataReader = sqlCommand.ExecuteReader();
        //        while (sqlDataReader.Read())
        //        {
        //            ID = Convert.ToString(sqlDataReader[0]);
        //            break;
        //        }
        //        return ID;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //    finally
        //    {
        //        if (sqlDataReader != null)
        //            sqlDataReader.Close();
        //    }
        //}

        public string Select_Text(string query, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null, string Value4 = null, string Value5 = null, string Value6 = null, string Value7 = null, string Value8 = null)
        {
            string output = string.Empty;
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                sqlCommand.Parameters.AddWithValue("Value4", Value4);
                sqlCommand.Parameters.AddWithValue("Value5", Value5);
                sqlCommand.Parameters.AddWithValue("Value6", Value6);
                sqlCommand.Parameters.AddWithValue("Value7", Value7);
                sqlCommand.Parameters.AddWithValue("Value8", Value8);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    output = Convert.ToString(sqlDataReader[0]);
                    break;
                }
                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
            }
        }

        public void Insert_Update_Delete(string query, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null, string Value4 = null, string Value5 = null, string Value6 = null, string Value7 = null, string Value8 = null)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                sqlCommand.Parameters.AddWithValue("Value4", Value4);
                sqlCommand.Parameters.AddWithValue("Value5", Value5);
                sqlCommand.Parameters.AddWithValue("Value6", Value6);
                sqlCommand.Parameters.AddWithValue("Value7", Value7);
                sqlCommand.Parameters.AddWithValue("Value8", Value8);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Search(ToolStripTextBox textBox, DataGridView dataGridView)
        {
            if (textBox.Text != "")
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    dataGridView.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                            if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox.Text))
                            {
                                dataGridView.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            else dataGridView.ClearSelection();
        }
        public void Print_Dogovor(MySqlQueries mySqlQueries, DataGridView dataGridView, DateTimePicker dateTimePicker, SaveFileDialog saveFileDialog, string ID)
        {
            ExcelApplication ExcelApp = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            string output = null;
            string fileName = null;
            //Select_Text(mySqlQueries.Select_Doljnost_by_ID, ref output, ID);
            saveFileDialog.Title = "Сохранить график работы как";
            saveFileDialog.FileName = "График работы для " + output;
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Отчетность\\";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                //Select_Text(mySqlQueries.Exists_Grafik_Raboty_Print, ref output, ID, dateTimePicker.Value.Year.ToString() + "-1-1", dateTimePicker.Value.AddYears(1).Year.ToString() + "-1-0");
                if (output == "1")
                {
                    //Select_DataGridView(mySqlQueries.Print_Grafik, dataGridView, ID, dateTimePicker.Value.Year.ToString() + "-1-1", dateTimePicker.Value.AddYears(1).Year.ToString() + "-1-0");
                    if (dataGridView.Rows.Count >= 13)
                    {
                        try
                        {
                            //Select_Text(mySqlQueries.Select_Doljnost_by_ID, ref output, ID);
                            //ExcelApp = new ExcelApplication();
                            //workbooks = ExcelApp.Workbooks;
                            //workbook = workbooks.Open(Application.StartupPath + "\\Blanks\\Grafik.xlsx");
                            //ExcelApp.Cells[1, 22] = dateTimePicker.Value.Year.ToString();
                            //ExcelApp.Cells[2, 13] = output;
                            //ExcelApp.Cells[26, 11] = dateTimePicker.Value.Year.ToString();
                            ////Select_Text(mySqlQueries.Select_Kol_Rab_Dney_Grafik, ref output, ID, dateTimePicker.Value.Year.ToString() + "-1-1", dateTimePicker.Value.AddYears(1).Year.ToString() + "-1-0");
                            //ExcelApp.Cells[27, 5] = output;
                            //Select_Text(mySqlQueries.Select_Kol_PredPrazdn_Dney_Grafik, ref output, ID, dateTimePicker.Value.Year.ToString() + "-1-1", dateTimePicker.Value.AddYears(1).Year.ToString() + "-1-0");
                            //ExcelApp.Cells[27, 20] = output;
                            //Select_Text(mySqlQueries.Select_Kol_Poln_Dney_Grafik, ref output, ID, dateTimePicker.Value.Year.ToString() + "-1-1", dateTimePicker.Value.AddYears(1).Year.ToString() + "-1-0");
                            //ExcelApp.Cells[27, 11] = output;
                            //Select_Text(mySqlQueries.Select_Itogo_Rab_Chasov_Grafik, ref output, ID, dateTimePicker.Value.Year.ToString() + "-1-1", dateTimePicker.Value.AddYears(1).Year.ToString() + "-1-0");
                            //ExcelApp.Cells[28, 5] = decimal.Parse(output);
                            //int ExCol = 2;
                            //int ExRow = 7;
                            //for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                            //{
                            //    if (ExRow == 10 || ExRow == 14 || ExRow == 18)
                            //        ExRow++;
                            //    ExCol = 2;
                            //    for (int j = 1; j < dataGridView.Columns.Count; j++)
                            //    {
                            //        ExcelApp.Cells[ExRow, ExCol] = dataGridView.Rows[i].Cells[j].Value.ToString();
                            //        ExCol++;
                            //    }
                            //    ExRow++;
                            //}
                            //workbook.SaveAs(fileName);
                            //ExcelApp.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(workbook);
                            Marshal.ReleaseComObject(workbooks);
                            Marshal.ReleaseComObject(ExcelApp);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Не хватает записей графика работы" + '\n' + "для данной должности на выбранный вами год." + '\n' + "Пожалуйста дополните график работы для данной должности." + '\n' + "Необходимо заполнить график на 12 месяцев для выбранного вами года.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    //MessageBox.Show("Отсутствует график работы" + '\n' + "для данной должности на выбранный вами год." + '\n' + "Пожалуйста заполните график работы для данной должности.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}