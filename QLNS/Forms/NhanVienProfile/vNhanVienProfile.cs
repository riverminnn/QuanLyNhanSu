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
    public partial class vNhanVienProfile : Form
    {
        public static string sMaNV;
        string color_blurple = "#7289DA";
        static string stringConnect = ConfigurationManager.ConnectionStrings["QLNS_SERVER"].ConnectionString;

        public vNhanVienProfile()
        {
            InitializeComponent();
        }
        private void LoadData(string filter = null)
        {
            try
            {
                cNhanVien nhanVienController = new cNhanVien();
                mNhanVien nhanVien= nhanVienController.SelectEmployeeByID(sMaNV);

                txtBox_employeeID.Text = nhanVien.sMaNV;
                txtBox_sTenNV.Text = nhanVien.sHoTenNV;
                txtBox_sMaPB.Text = nhanVien.sMaPB;
                txtBox_employeePN.Text = nhanVien.sSdt;
                txtBox_employeeDefault.Text = nhanVien.fLuongCoBan.ToString();
                datePicker_Birth.Value = nhanVien.dNgaySinh.Value;
                datePicker_StartDate.Value = nhanVien.dNgayVaoLam.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            SetDefault();
            LoadData();
        }
        private void SetDefault()
        {
            btn_Reset.BackColor = ColorTranslator.FromHtml(color_blurple);
        }
    }
}
