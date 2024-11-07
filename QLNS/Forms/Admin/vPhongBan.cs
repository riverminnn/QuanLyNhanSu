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
    public partial class vPhongBan : Form
    {
        string color_blurple = "#7289DA";
        static string stringConnect = "Data Source=DESKTOP-ON61FFC;Initial Catalog=QLNS;Integrated Security=True;";
        public vPhongBan()
        {
            InitializeComponent();
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            SetDefault();
            LoadDataToDGV1();
        }

        private void LoadDataToDGV1(string filter = null)
        {
            try
            {
                cPhongBan phongBanController = new cPhongBan();
                List<mPhongBan> phongBanList = phongBanController.GetAllPhongBan();
                dgv_tblPhongBan.AutoGenerateColumns = false;
                dgv_tblPhongBan.Columns.Clear();
                var columns = new (string Name, string Header, string PropertyName)[]
                {
                    ("sMaPB", "Mã phòng ban", "sMaPB"),
                    ("sTenPB", "Tên phòng ban", "sTenPB"),
                    ("sTruongPhong", "Trưởng Phòng", "sTruongPhong"),
                };
                foreach (var col in columns)
                {
                    AddColumn(dgv_tblPhongBan, col.Name, col.Header, col.PropertyName);
                }

                dgv_tblPhongBan.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgv_tblPhongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_tblPhongBan.DataSource = phongBanList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        void AddColumn(DataGridView dgv, string name, string header, string propertyName)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = propertyName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };
            dgv.Columns.Add(column);
        }

        private void SetDefault()
        {
            btn_Reset.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Insert.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Delete.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Update.BackColor = ColorTranslator.FromHtml(color_blurple);
            btn_Search.BackColor = ColorTranslator.FromHtml(color_blurple);
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string sMaPB = txtBox_sMaPB.Text,
                    sTenPB = txtBox_sTenPB.Text,
                    sTruongPhong = txtBox_sTruongPhong.Text;
                mPhongBan phongban = new mPhongBan
                {
                    sMaPB = sMaPB,
                    sTenPB = sTenPB,
                    sTruongPhong = sTruongPhong
                };

                if (checkTruongPhong.Checked == false)
                {
                    cPhongBan controller = new cPhongBan();
                    bool isInserted = controller.InsertPhongBan(phongban, checkTruongPhong.Checked);

                    if (isInserted)
                    {
                        MessageBox.Show("Successfully added");
                        LoadDataToDGV1();
                    }
                }
                else
                {
                    cPhongBan controller = new cPhongBan();
                    bool isInserted = controller.InsertPhongBan(phongban, checkTruongPhong.Checked);

                    if (isInserted)
                    {
                        MessageBox.Show("Successfully added");
                        LoadDataToDGV1();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string sMaPB = txtBox_sMaPB.Text;

            if (string.IsNullOrEmpty(sMaPB))
            {
                MessageBox.Show("Please enter an ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this PB " + sMaPB + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                cPhongBan controller = new cPhongBan();
                bool isDeleted = controller.DeletePhongBan(sMaPB);

                if (isDeleted)
                {
                    MessageBox.Show("Successfully deleted");
                    LoadDataToDGV1();
                }
                else
                {
                    MessageBox.Show("Error: Unable to delete the record.");
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string sMaPB = txtBox_sMaPB.Text,
                    sTenPB = txtBox_sTenPB.Text,
                    sTruongPhong = txtBox_sTruongPhong.Text;
            bool checkTruongPhong = false;
            if (txtBox_sTruongPhong.Text == "")
            {
                checkTruongPhong = true;
            }
            else
            {
                checkTruongPhong = false;
            }
            mPhongBan phongban = new mPhongBan
            {
                sMaPB = sMaPB,
                sTenPB = sTenPB,
                sTruongPhong = sTruongPhong
            };

            if (string.IsNullOrEmpty(phongban.sMaPB))
            {
                MessageBox.Show("Please enter an ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            cPhongBan controller = new cPhongBan();
            bool isUpdated = controller.UpdatePhongBan(phongban, checkTruongPhong);
            if (isUpdated)
            {
                MessageBox.Show("Successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToDGV1();
                return;
            }
            else
            {
                MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDataToDGV1();
            }
        }




        private void btn_Search_Click(object sender, EventArgs e)
        {
            string sMaPB = txtBox_sMaPB.Text;
            string sTenPB = txtBox_sTenPB.Text;
            string sTruongPhong = txtBox_sTruongPhong.Text;
            string filter = "";

            if (!String.IsNullOrEmpty(sMaPB))
            {
                filter += string.Format("sMaPB LIKE '%{0}%'", sMaPB);
            }
            if (!String.IsNullOrEmpty(sTenPB))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("sTenPB LIKE '%{0}%'", sTenPB);
            }
            if (!String.IsNullOrEmpty(sTruongPhong))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("sTruongPhong LIKE '%{0}%'", sTruongPhong);
            }
            cPhongBan controller = new cPhongBan();
            DataTable result = controller.SearchPhongBan(filter);
            dgv_tblPhongBan.DataSource = result;
        }

        private void dgv_tblPhongBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_tblPhongBan.Rows[e.RowIndex];
                txtBox_sTruongPhong.Text = row.Cells["sTruongPhong"].Value.ToString();
                txtBox_sMaPB.Text = row.Cells["sMaPB"].Value.ToString();
                txtBox_sTenPB.Text = row.Cells["sTenPB"].Value.ToString();
            }
        }


        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Clear textboxes and any other content
            txtBox_sTruongPhong.Text = "";
            txtBox_sMaPB.Text = "";
            txtBox_sTenPB.Text = "";
            // Reload data
            LoadDataToDGV1("");
        }

        private void LoadDataToDGV2(string filter = null)
        {
            try
            {
                cNhanVien nhanVienController = new cNhanVien();
                List<mNhanVien> nhanVienList = nhanVienController.GetAllNhanVien();
                dgv_tblNhanVien.AutoGenerateColumns = false;
                dgv_tblNhanVien.Columns.Clear();

                // List of column definitions
                var columns = new (string Name, string Header, string PropertyName)[]
                {
                    ("sMaNV", "Mã nhân viên", "sMaNV"),
                    ("sMaPB", "Mã phòng ban", "sMaPB"),
                    ("sHoTenNV", "Họ tên", "sHoTenNV"),
                    ("sSDT", "SĐT", "sSDT"),
                    ("dNgaySinh", "Ngày sinh", "dNgaySinh"),
                    ("dNgayVaoLam", "Ngày vào làm", "dNgayVaoLam"),
                    ("fLuongCoBan", "Lương CB", "fLuongCoBan"),
                    ("fPhuCap", "Phụ cấp", "fPhuCap"),
                    ("fHSL", "Hệ số lương", "fHSL")
                };

                // Add columns using the helper method
                foreach (var col in columns)
                {
                    AddColumn(dgv_tblNhanVien, col.Name, col.Header, col.PropertyName);
                }

                // Set global styles
                dgv_tblNhanVien.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgv_tblNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Bind data source
                dgv_tblNhanVien.DataSource = nhanVienList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btn_XemNhanVien_Click(object sender, EventArgs e)
        {
            string sMaPB = txtBox_sMaPB.Text;
            string filter = "";
            if (!String.IsNullOrEmpty(sMaPB))
            {
                filter += string.Format("sMaPB LIKE '%{0}%'", sMaPB);
            }
            cNhanVien controller = new cNhanVien();
            DataTable result = controller.SearchEmployee(filter);

            dgv_tblNhanVien.DataSource = result;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            string filterReport = "NOT(ISNULL({PROC_SelectAllFromPhongBan.sMaPB}))";
            string tableName = "PROC_SelectAllFromPhongBan";
            string reportName = "PhongBan";
            string reportWriter = "Admin";

            if (!string.IsNullOrEmpty(txtBox_sMaPB.Text))
            {
                filterReport += string.Format(" AND {0} LIKE '*{1}*'", "{PROC_SelectAllFromPhongBan.sMaPB}", txtBox_sMaPB.Text);
            }

            ReportManagement Printer = new ReportManagement();
            Printer.Show();
            Printer.ShowReport(filterReport, tableName, reportName, reportWriter);
        }
    }
}
