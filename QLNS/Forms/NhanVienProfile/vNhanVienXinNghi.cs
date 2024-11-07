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
    public partial class vNhanVienXinNghi : Form
    {
        string color_blurple = "#7289DA";
        static string stringConnect = ConfigurationManager.ConnectionStrings["QLNS_SERVER"].ConnectionString;

        public vNhanVienXinNghi()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            SetDefault();
        }
        private void SetDefault()
        {
            btn_Reset.BackColor = ColorTranslator.FromHtml(color_blurple);
        }
    }
}
