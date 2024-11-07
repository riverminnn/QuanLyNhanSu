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
    public partial class vNhanVien : Form
    {
        string color_blurple = "#7289DA";
        static string stringConnect = ConfigurationManager.ConnectionStrings["QLNS_SERVER"].ConnectionString;

        public vNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            SetDefault();
            LoadDataToDGV1();
        }

        private void LoadDataToDGV1(string filter = null)
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

        private void btn_Insert_Click(object sender, EventArgs e)// moi
        {
            try
            {
                // Thu thập dữ liệu từ các ô nhập liệu trên form
                string sMaNV = txtBox_employeeID.Text,
                    sMaPB = txtBox_sMaPB.Text,
                    sHoTen = txtBox_employeeName.Text,
                    sSdt = txtBox_employeePN.Text;
                DateTime dNgaySinh = datePicker_Birth.Value;
                DateTime dNgayVaoLam = datePicker_StartDate.Value;

                float luongCB, phuCap, hsl;
                if (!float.TryParse(txtBox_employeeDefault.Text, out luongCB) ||
                    !float.TryParse(txtBox_employeeCoefficent.Text, out hsl) ||
                    !float.TryParse(txtBox_employeeAllowance.Text, out phuCap))
                {
                    MessageBox.Show("Please enter valid numeric values for fLuongCoBan, fHsl, and fPhuCap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng NhanVien và gán các thuộc tính
                mNhanVien nhanVien = new mNhanVien
                {
                    sMaNV = sMaNV,
                    sMaPB = sMaPB,
                    sHoTenNV = sHoTen,
                    sSdt = sSdt,
                    dNgaySinh = dNgaySinh,
                    dNgayVaoLam = dNgayVaoLam,
                    fLuongCoBan = luongCB,
                    fPhuCap = phuCap,
                    fHsl = hsl
                };

                // Gọi controller để chèn nhân viên vào cơ sở dữ liệu
                cNhanVien controller = new cNhanVien();
                bool isInserted = controller.AddEmployee(nhanVien);

                if (isInserted)
                {
                    MessageBox.Show("Successfully added");
                    LoadDataToDGV1(); // Cập nhật lại DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e) //moi
        {
            string sMaNV = txtBox_employeeID.Text;

            if (string.IsNullOrEmpty(sMaNV))
            {
                MessageBox.Show("Please enter an employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this employee " + sMaNV + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                cNhanVien controller = new cNhanVien();
                bool isDeleted = controller.DeleteEmployee(sMaNV);

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
            // Tạo đối tượng NhanVien
            mNhanVien nhanVien = new mNhanVien
            {
                sMaNV = txtBox_employeeID.Text,
                sMaPB = txtBox_sMaPB.Text,
                sHoTenNV = txtBox_employeeName.Text,
                sSdt = txtBox_employeePN.Text,
                dNgaySinh = datePicker_Birth.Value.Date,
                dNgayVaoLam = datePicker_StartDate.Value.Date
            };

            if (string.IsNullOrEmpty(nhanVien.sMaNV))
            {
                MessageBox.Show("Please enter an employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra giá trị số cho các trường lương, phụ cấp và hệ số lương
            if (!float.TryParse(txtBox_employeeDefault.Text, out float luongCB))
            {
                MessageBox.Show("Please enter a valid numeric value for fLuongCoBan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nhanVien.fLuongCoBan = luongCB;

            if (!float.TryParse(txtBox_employeeCoefficent.Text, out float hsl))
            {
                MessageBox.Show("Please enter a valid numeric value for fHsl.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nhanVien.fHsl = hsl;

            if (!float.TryParse(txtBox_employeeAllowance.Text, out float phuCap))
            {
                MessageBox.Show("Please enter a valid numeric value for fPhuCap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nhanVien.fPhuCap = phuCap;

            // Gọi phương thức cập nhật
            cNhanVien controller = new cNhanVien();
            bool isUpdated = controller.UpdateEmployee(nhanVien);

            // Kiểm tra kết quả cập nhật
            if (isUpdated)
            {
                MessageBox.Show("Successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToDGV1(); // Cập nhật lại DataGridView sau khi sửa
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
            string employeeID = txtBox_employeeID.Text;
            string sMaPB = txtBox_sMaPB.Text;
            string filter = "";
            string sMaNV = txtBox_employeeID.Text;
            string sHoTenNV = txtBox_employeeName.Text;
            string sSDT = txtBox_employeePN.Text;
            float fLuongCB = 0.0f;
            float fPhuCap = 0.0f;
            float fHSL = 0.0f;

            if (!String.IsNullOrEmpty(sMaNV))
            {
                filter += string.Format("sMaNV LIKE '%{0}%'", sMaNV);
            }

            if (!String.IsNullOrEmpty(sMaPB))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("sMaPB LIKE '%{0}%'", sMaPB);
            }

            if (!String.IsNullOrEmpty(sHoTenNV))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("sHoTenNV LIKE '%{0}%'", sHoTenNV);
            }

            if (!String.IsNullOrEmpty(sSDT))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("sSDT LIKE '%{0}%'", sSDT);
            }

            if (float.TryParse(txtBox_employeeDefault.Text, out fLuongCB))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("fLuongCoBan = {0}", fLuongCB);
            }

            if (float.TryParse(txtBox_employeeAllowance.Text, out fPhuCap))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("fPhuCap = {0}", fPhuCap);
            }

            if (float.TryParse(txtBox_employeeCoefficent.Text, out fHSL))
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("fHSL = {0}", fHSL);
            }

            // Gọi phương thức SearchEmployee từ controller
            cNhanVien controller = new cNhanVien();
            DataTable result = controller.SearchEmployee(filter);

            // Hiển thị kết quả trong DataGridView
            dgv_tblNhanVien.DataSource = result;
        }

        private void dgv_tblNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_tblNhanVien.Rows[e.RowIndex];
                txtBox_employeeID.Text = row.Cells["sMaNV"].Value.ToString();
                txtBox_sMaPB.Text = row.Cells["sMaPB"].Value.ToString();
                txtBox_employeeName.Text = row.Cells["sHoTenNV"].Value.ToString();
                txtBox_employeePN.Text = row.Cells["sSDT"].Value.ToString();
                datePicker_Birth.Value = Convert.ToDateTime(row.Cells["dNgaySinh"].Value);
                datePicker_StartDate.Value = Convert.ToDateTime(row.Cells["dNgayVaoLam"].Value);
                txtBox_employeeDefault.Text = row.Cells["fLuongCoBan"].Value.ToString();
                txtBox_employeeAllowance.Text = row.Cells["fPhuCap"].Value.ToString();
                txtBox_employeeCoefficent.Text = row.Cells["fHSL"].Value.ToString();
            }
        }


        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Clear textboxes and any other content
            txtBox_employeeID.Text = "";
            txtBox_sMaPB.Text = "";
            txtBox_employeeName.Text = "";
            txtBox_employeePN.Text = "";
            txtBox_employeeDefault.Text = "";
            txtBox_employeeCoefficent.Text = "";
            txtBox_employeeAllowance.Text = "";
            datePicker_Birth.Value = DateTime.Today;
            datePicker_StartDate.Value = DateTime.Today;

            // Reload data
            LoadDataToDGV1("");
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            string filterReport = "NOT(ISNULL({PROC_SelectAllFromNhanVien.sMaNV}))";
            string tableName = "PROC_SelectAllFromNhanVien";
            string reportName = "NhanVien";
            string reportWriter = "Admin";

            if (!string.IsNullOrEmpty(txtBox_employeeID.Text))
            {
                filterReport += string.Format(" AND {0} LIKE '*{1}*'", "{PROC_SelectAllFromNhanVien.sMaNV}", txtBox_employeeID.Text);
            }

            ReportManagement Printer = new ReportManagement();
            Printer.Show();
            Printer.ShowReport(filterReport, tableName, reportName, reportWriter);
        }

        private void btn_XuatBangLuong_Click(object sender, EventArgs e)
        {
            string filterReport = "NOT(ISNULL({PROC_SelectAllFromNhanVien.sMaNV}))";
            string tableName = "PROC_SelectAllFromNhanVien";
            string reportName = "BangLuong";
            string reportWriter = "Admin";

            if (!string.IsNullOrEmpty(txtBox_employeeID.Text))
            {
                filterReport += string.Format(" AND {0} LIKE '*{1}*'", "{PROC_SelectAllFromNhanVien.sMaNV}", txtBox_employeeID.Text);
            }

            ReportManagement Printer = new ReportManagement();
            Printer.Show();
            Printer.ShowReport(filterReport, tableName, reportName, reportWriter);
        }
    }
}
