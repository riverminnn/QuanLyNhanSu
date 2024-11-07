using QuanLyNhanSu.Forms.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace QuanLyNhanSu.Forms

{
    public partial class FormAccountData : Form
    {
        string color_blurple = "#7289DA";
        string color_blurple_dark = "#5566a0";
        string color_fullWhite = "#FFFFFF";
        static string stringConnect = ConfigurationManager.ConnectionStrings["QLNS_SERVER"].ConnectionString;
        public FormAccountData()
        {
            InitializeComponent();
        }
        private void vAccountData_Load(object sender, EventArgs e)
        {
            SetDefault();
            LoadDataToDGV();
        }
        private void SetDefault()
        {
            btn_Reset.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Insert.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Delete.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Update.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Search.BackColor = ColorTranslator.FromHtml(color_blurple);
        }
        private void LoadDataToDGV(string filter = "")
        {
            string PROC_SelectAllFromAccountData = "PROC_SelectAllFromAccountData";
            using (SqlConnection sqlConnection = new SqlConnection(stringConnect))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = PROC_SelectAllFromAccountData;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        using (DataTable tblAccountData = new DataTable())
                        {
                            tblAccountData.Clear();
                            sqlDataAdapter.SelectCommand = cmd;
                            sqlDataAdapter.Fill(tblAccountData);
                            DataView dvTblAccountData = new DataView();
                            dvTblAccountData = tblAccountData.DefaultView;
                            if (!String.IsNullOrEmpty(filter))
                            {
                                dvTblAccountData.RowFilter = filter;
                            }
                            dgv_tblAccountData.DataSource = dvTblAccountData;
                            dgv_tblAccountData.DefaultCellStyle.Font = new Font("Arial", 12);
                            dgv_tblAccountData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            dgv_tblAccountData.Columns["sUsername"].DisplayIndex = 0;
                            dgv_tblAccountData.Columns["sPassword"].DisplayIndex = 1;

                            dgv_tblAccountData.Columns["sUsername"].HeaderText = "Username";
                            dgv_tblAccountData.Columns["sPassword"].HeaderText = "Password";
                        }
                    }
                }
            }
        }


        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtBox_username.Text;
                string password = txtBox_password.Text;

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection sqlConnection = new SqlConnection(stringConnect))
                {
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = "PROC_SelectAllFromAccountData";
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            using (DataTable tblAccountData = new DataTable("tblAccountData"))
                            {
                                adapter.Fill(tblAccountData);

                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(tblAccountData);

                                    DataRow newRow = tblAccountData.NewRow();
                                    newRow["sUsername"] = username;
                                    newRow["sPassword"] = password;
                                    tblAccountData.Rows.Add(newRow);

                                    // Insert
                                    sqlCommand.CommandText = "PROC_InsertAccountData";
                                    sqlCommand.CommandType = CommandType.StoredProcedure;
                                    sqlCommand.Parameters.Clear();
                                    sqlCommand.Parameters.AddWithValue("@sUsername", username);
                                    sqlCommand.Parameters.AddWithValue("@sPassword", password);

                                    adapter.InsertCommand = sqlCommand;
                                    adapter.Update(dataSet, "tblAccountData");

                                    MessageBox.Show("Successfully added");
                                    LoadDataToDGV();
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // SQL Server violation of PRIMARY KEY error code
                {
                    MessageBox.Show("This username already exists. Please enter a unique username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string sUsername = txtBox_username.Text;
            try
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to delete this " + sUsername + "???", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(stringConnect))
                    {
                        using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                        {
                            sqlCommand.CommandText = "SELECT * FROM tblAccountData";
                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                using (DataTable tblAccountData = new DataTable("tblAccountData"))
                                {
                                    adapter.Fill(tblAccountData);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(tblAccountData);
                                        tblAccountData.PrimaryKey = new DataColumn[] { tblAccountData.Columns["sUsername"] };
                                        DataRow row = tblAccountData.Rows.Find(sUsername);
                                        row.Delete();

                                        sqlCommand.CommandText = "PROC_DeleteAccountData";
                                        sqlCommand.CommandType = CommandType.StoredProcedure;
                                        sqlCommand.Parameters.Clear();

                                        sqlCommand.Parameters.AddWithValue("@sUsername", sUsername);

                                        adapter.DeleteCommand = sqlCommand;
                                        adapter.Update(dataSet, "tblAccountData");

                                        MessageBox.Show("Succesfully Deleted");
                                        LoadDataToDGV();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx && sqlEx.Number == 547)
                {
                    MessageBox.Show("Error: This record cannot be deleted because it is referenced by other records.");
                }
                else if (ex is NullReferenceException)
                {
                    MessageBox.Show("Error: The key maybe not found or you haven't fill required records");
                }
                else if (ex is InvalidOperationException)
                {
                    MessageBox.Show("Error: The specified record could not be found in the database.");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtBox_username.Text,
                    password = txtBox_password.Text;

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection sqlConnection = new SqlConnection(stringConnect))
                {
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = "PROC_SelectAllFromAccountData";
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            using (DataTable tblAccountData = new DataTable("tblAccountData"))
                            {
                                adapter.Fill(tblAccountData);

                                using (DataSet dataSet = new DataSet())
                                {
                                    dataSet.Tables.Add(tblAccountData);

                                    DataRow rowToUpdate = tblAccountData.Select($"sUsername='{username}'").FirstOrDefault();

                                    if (rowToUpdate == null)
                                    {
                                        MessageBox.Show("Username does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    rowToUpdate["sPassword"] = password;

                                    //Update
                                    sqlCommand.CommandText = "PROC_UpdateAccountData";
                                    sqlCommand.CommandType = CommandType.StoredProcedure;
                                    sqlCommand.Parameters.Clear();
                                    sqlCommand.Parameters.AddWithValue("@sUsername", username);
                                    sqlCommand.Parameters.AddWithValue("@sPassword", password);

                                    adapter.UpdateCommand = sqlCommand;
                                    adapter.Update(dataSet, "tblAccountData");

                                    MessageBox.Show("Successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadDataToDGV();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx && sqlEx.Number == 547)
                {
                    MessageBox.Show("Error: This record cannot be updated because it is referenced by other records.");
                }
                else if (ex is NullReferenceException)
                {
                    MessageBox.Show("Error: Please fill in all required fields.");
                }
                else if (ex is InvalidOperationException)
                {
                    MessageBox.Show("Error: The specified record could not be found in the database.");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btn_Search_Click(object sender, EventArgs e)
        {
            string filter = "";
            string sUsername = txtBox_username.Text;
            string sPassword = txtBox_password.Text;

            if (!String.IsNullOrEmpty(sUsername))
            {
                filter += string.Format("sUsername LIKE '%{0}%'", sUsername);
            }

            if (!String.IsNullOrEmpty(sPassword))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("sPassword LIKE '%{0}%'", sPassword);
            }

            LoadDataToDGV(filter);
        }


        private void dgv_tblAccountData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_tblAccountData.Rows[e.RowIndex];
                txtBox_username.Text = row.Cells["sUsername"].Value.ToString();
                txtBox_password.Text = row.Cells["sPassword"].Value.ToString();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Clear textboxes and any other content
            txtBox_username.Text = "";
            txtBox_password.Text = "";
            // Reload data
            LoadDataToDGV("");
        }
    }
}
