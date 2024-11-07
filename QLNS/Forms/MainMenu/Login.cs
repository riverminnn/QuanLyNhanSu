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
    public partial class Login : Form
    {
        string color_blurple = "#7289DA";
        string color_blurple_dark = "#5566a0";
        string color_fullWhite = "#FFFFFF";
        private MainMenu mainMenuForm;
        static string stringConnect = ConfigurationManager.ConnectionStrings["QLNS_SERVER"].ConnectionString;
        bool isLogin = true;

        public Login(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainMenuForm = mainMenu;
            this.KeyPreview = true;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            setDefault();
        }

        public void setDefault()
        {
            this.CenterToScreen();
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.BackColor = ColorTranslator.FromHtml(color_blurple);
            wrong_info.ForeColor = Color.Transparent;
        }


        private void panel_username_Paint(object sender, PaintEventArgs e)
        {
            if (panel_username.BorderStyle == BorderStyle.FixedSingle)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Black, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              panel_username.ClientSize.Width - thickness,
                                                              panel_username.ClientSize.Height - thickness));
                }
            }
        }

        private void panel_password_Paint(object sender, PaintEventArgs e)
        {
            if (panel_password.BorderStyle == BorderStyle.FixedSingle)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Black, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              panel_password.ClientSize.Width - thickness,
                                                              panel_password.ClientSize.Height - thickness));
                }
            }
        }

        private void btn_Login_MouseLeave(object sender, EventArgs e)
        {
            btn_Login.BackColor = ColorTranslator.FromHtml(color_blurple);
        }

        private void btn_Login_MouseEnter(object sender, EventArgs e)
        {
            btn_Login.BackColor = ColorTranslator.FromHtml(color_blurple_dark);
        }
        private void LoginCheck()
        {
            try
            {
                isLogin = false;
                string procSelect = "PROC_SelectAllFromAccountData";
                using (SqlConnection connection = new SqlConnection(stringConnect))
                {
                    connection.ConnectionString = stringConnect;
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = procSelect;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.SelectCommand = command;
                            using (DataTable tblAccountData = new DataTable())
                            {
                                adapter.Fill(tblAccountData);
                                foreach (DataRow row in tblAccountData.Rows)
                                {
                                    if (txtBox_username.Text == row["sUsername"].ToString())
                                    {
                                        if (txtBox_password.Text == row["sPassword"].ToString())
                                        {
                                            isLogin = true;
                                            wrong_info.ForeColor = Color.Transparent;
                                            if (row["sUsername"].ToString() == "admin")
                                            {
                                                MenuAdmin menuAdmin = new MenuAdmin();
                                                menuAdmin.Show();
                                                mainMenuForm.Hide();
                                            }
                                            else
                                            {
                                                MenuNhanVien MenuNhanVien = new MenuNhanVien();
                                                MenuNhanVien.sMaNV = txtBox_username.Text;
                                                MenuNhanVien.Show();
                                                mainMenuForm.Hide();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (!isLogin)
                {
                    wrong_info.ForeColor = Color.IndianRed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginCheck();
                e.SuppressKeyPress = true;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            if (mainMenuForm.WindowState == FormWindowState.Normal)
            {
                mainMenuForm.WindowState = FormWindowState.Maximized;
            } else
            {
                mainMenuForm.WindowState = FormWindowState.Normal;
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            mainMenuForm.WindowState = FormWindowState.Minimized;
        }
    }
}
