using System;
using System.Collections.Generic;
using System.Configuration; // Thêm namespace này để sử dụng ConfigurationManager
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms.Admin
{
    internal class cPhongBan
    {
        static string connectionString;
        public cPhongBan()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QLNS_SERVER"].ConnectionString;
        }
        public List<mPhongBan> GetAllPhongBan()
        {
            List<mPhongBan> phongBanList = new List<mPhongBan>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "PROC_SelectAllFromPhongBan";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        mPhongBan phongBan = new mPhongBan
                        {
                            sMaPB = reader["sMaPB"].ToString(),
                            sTenPB = reader["sTenPB"].ToString(),
                            sTruongPhong = reader["sTruongPhong"].ToString(),
                        };
                        phongBanList.Add(phongBan);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return phongBanList;
        }
        public bool InsertPhongBan(mPhongBan phongBan, bool checkTruongPhong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "PROC_InsertPhongBan";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sMaPB", phongBan.sMaPB);
                        command.Parameters.AddWithValue("@sTenPB", phongBan.sTenPB);
                        if (checkTruongPhong) {
                            command.Parameters.AddWithValue("@sTruongPhong", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@sTruongPhong", phongBan.sTruongPhong);
                        }
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Please enter a unique ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        public bool DeletePhongBan(string sMaPB)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("PROC_DeletePhongBan", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sMaPB", sMaPB);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Error: This record cannot be deleted because it is referenced by other records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdatePhongBan(mPhongBan phongBan, bool checkTruongPhong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("PROC_UpdatePhongBan", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sMaPB", phongBan.sMaPB);
                        command.Parameters.AddWithValue("@sTenPB", phongBan.sTenPB);
                        if (checkTruongPhong)
                        {
                            command.Parameters.AddWithValue("@sTruongPhong", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@sTruongPhong", phongBan.sTruongPhong);
                        }
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public DataTable SearchPhongBan(string filter = null)
        {
            DataTable tblPhongBan = new DataTable();

            List<mPhongBan> phongBanList = new List<mPhongBan>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "PROC_SelectAllFromPhongBan";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tblPhongBan);
                        DataView dvtblPhongBan = new DataView();
                        dvtblPhongBan = tblPhongBan.DefaultView;
                        if (!String.IsNullOrEmpty(filter))
                        {
                            dvtblPhongBan.RowFilter = filter;
                        }
                        tblPhongBan = dvtblPhongBan.ToTable();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return tblPhongBan;
            }
        }
    }
}
