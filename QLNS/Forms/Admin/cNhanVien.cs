using QuanLyNhanSu.Reports;
using System;
using System.Collections.Generic;
using System.Configuration; // Thêm namespace này để sử dụng ConfigurationManager
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms.Admin
{
    internal class cNhanVien
    {
        static string connectionString;
        public cNhanVien()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QLNS_SERVER"].ConnectionString;
        }

        // Phương thức để lấy danh sách nhân viên từ cơ sở dữ liệu
        public List<mNhanVien> GetAllNhanVien()
        {
            List<mNhanVien> nhanVienList = new List<mNhanVien>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "PROC_SelectAllFromNhanVien"; // Truy vấn lấy tất cả nhân viên
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        mNhanVien nhanVien = new mNhanVien
                        {
                            sMaNV = reader["sMaNV"].ToString(),
                            sMaPB = reader["sMaPB"].ToString(),
                            sHoTenNV = reader["sHoTenNV"].ToString(),
                            sSdt = reader["sSDT"].ToString(),
                            dNgaySinh = reader["dNgaySinh"] as DateTime?,
                            dNgayVaoLam = reader["dNgayVaoLam"] as DateTime?,
                            fLuongCoBan = reader["fLuongCoBan"] != DBNull.Value ? Convert.ToSingle(reader["fLuongCoBan"]) : (float?)null,
                            fPhuCap = reader["fPhuCap"] != DBNull.Value ? Convert.ToSingle(reader["fPhuCap"]) : (float?)null,
                            fHsl = reader["fHSL"] != DBNull.Value ? Convert.ToSingle(reader["fHSL"]) : (float?)null,
                        };
                        nhanVienList.Add(nhanVien);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return nhanVienList;
        }


        public bool AddEmployee(mNhanVien nhanVien)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "PROC_InsertNhanVien";
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số cho thủ tục
                        command.Parameters.AddWithValue("@sMaNV", nhanVien.sMaNV);
                        command.Parameters.AddWithValue("@sMaPB", nhanVien.sMaPB);
                        command.Parameters.AddWithValue("@sHoTenNV", nhanVien.sHoTenNV);
                        command.Parameters.AddWithValue("@sSDT", nhanVien.sSdt);
                        command.Parameters.AddWithValue("@dNgaySinh", nhanVien.dNgaySinh);
                        command.Parameters.AddWithValue("@dNgayVaoLam", nhanVien.dNgayVaoLam);
                        command.Parameters.AddWithValue("@fLuongCoBan", nhanVien.fLuongCoBan);
                        command.Parameters.AddWithValue("@fPhuCap", nhanVien.fPhuCap);
                        command.Parameters.AddWithValue("@fHSL", nhanVien.fHsl);

                        connection.Open();
                        command.ExecuteNonQuery(); // Thực hiện chèn dữ liệu

                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính
                {
                    MessageBox.Show("This employee ID already exists. Please enter a unique employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        public bool DeleteEmployee(string maNV)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("PROC_DeleteNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sMaNV", maNV);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0; // Trả về true nếu xóa thành công
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Ràng buộc khóa ngoại bị vi phạm
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

        public bool UpdateEmployee(mNhanVien nhanVien)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("PROC_UpdateNhanVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sMaNV", nhanVien.sMaNV);
                        command.Parameters.AddWithValue("@sMaPB", nhanVien.sMaPB);
                        command.Parameters.AddWithValue("@sHoTenNV", nhanVien.sHoTenNV);
                        command.Parameters.AddWithValue("@sSDT", nhanVien.sSdt);
                        command.Parameters.AddWithValue("@dNgaySinh", nhanVien.dNgaySinh);
                        command.Parameters.AddWithValue("@dNgayVaoLam", nhanVien.dNgayVaoLam);
                        command.Parameters.AddWithValue("@fLuongCoBan", nhanVien.fLuongCoBan);
                        command.Parameters.AddWithValue("@fPhuCap", nhanVien.fPhuCap);
                        command.Parameters.AddWithValue("@fHSL", nhanVien.fHsl);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public DataTable SearchEmployee (string filter = null)
        {
            DataTable tblNhanVien = new DataTable();

            List<mNhanVien> nhanVienList = new List<mNhanVien>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "PROC_SelectAllFromNhanVien";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tblNhanVien);
                        DataView dvTblNhanVien = new DataView();
                        dvTblNhanVien = tblNhanVien.DefaultView;
                        if (!String.IsNullOrEmpty(filter))
                        {
                            dvTblNhanVien.RowFilter = filter;
                        }
                        tblNhanVien = dvTblNhanVien.ToTable();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return tblNhanVien;
            }
        }
        public mNhanVien SelectEmployeeByID (string sMaNV)
        {
            mNhanVien mNhanVien = null;  // Set to null initially to handle cases where no record is found

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "PROC_SelectNhanVienByID";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@sMaNV", sMaNV);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())  // Check if there are rows to read
                    {
                        mNhanVien = new mNhanVien
                        {
                            sMaNV = reader["sMaNV"].ToString(),
                            sMaPB = reader["sMaPB"].ToString(),
                            sHoTenNV = reader["sHoTenNV"].ToString(),
                            sSdt = reader["sSDT"].ToString(),
                            dNgaySinh = reader["dNgaySinh"] as DateTime?,
                            dNgayVaoLam = reader["dNgayVaoLam"] as DateTime?,
                            fLuongCoBan = reader["fLuongCoBan"] != DBNull.Value ? Convert.ToSingle(reader["fLuongCoBan"]) : (float?)null,
                            fPhuCap = reader["fPhuCap"] != DBNull.Value ? Convert.ToSingle(reader["fPhuCap"]) : (float?)null,
                            fHsl = reader["fHSL"] != DBNull.Value ? Convert.ToSingle(reader["fHSL"]) : (float?)null,
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return mNhanVien;
        }

    }
}
