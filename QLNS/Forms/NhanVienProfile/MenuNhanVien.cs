using QuanLyNhanSu.Forms.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public partial class MenuNhanVien : Form
    {
        public static string sMaNV;
        string color_blurple = "#7289DA";
        string color_blurple_dark = "#5566a0";
        string color_fullWhite = "#FFFFFF";
        List<Control> controlsToKeep = new List<Control>();
        public MenuNhanVien()
        {
            InitializeComponent();
        }

        private void MenuNhanVien_Load(object sender, EventArgs e)
        {
            setDefault();
            setHoverButton();
        }

        public void setDefault()
        {
            this.CenterToScreen();
            controlsToKeep.Add(btn_exit);
            controlsToKeep.Add(btn_maximize);
            controlsToKeep.Add(btn_minimize);
            panel_Decoration.BackColor = ColorTranslator.FromHtml(color_blurple);
        }

        private void setHoverButton()
        {
            List<Control> controlsToDefault = new List<Control>();
            controlsToDefault.Add(btn_XinNghi);

            controlsToDefault.Add(btn_Profile);

            for (int i = 0; i < controlsToDefault.Count; i++)
            {
                ((Button)controlsToDefault[i]).FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(color_blurple_dark);
                ((Button)controlsToDefault[i]).FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml(color_blurple_dark);
                ((Button)controlsToDefault[i]).FlatAppearance.CheckedBackColor = ColorTranslator.FromHtml(color_blurple_dark);
            }
        }

        private void SetColorButton(Control control, Control icon)
        {
            List<Control> controlsToChange = new List<Control>();
            controlsToChange.Add(control);
            controlsToChange.Add(icon);

            List<Control> controlsToDefault = new List<Control>();
            controlsToDefault.Add(btn_XinNghi);
            controlsToDefault.Add(btn_Profile);
            controlsToDefault.Add(pictureBox_Profile);
            controlsToDefault.Add(pictureBox_XinNghi);

            foreach (Control ctr in controlsToDefault)
            {
                if (controlsToChange.Contains(ctr))
                {
                    if (controlsToChange.Contains(controlsToChange[1]))
                    {
                        ctr.BackColor = ColorTranslator.FromHtml(color_blurple_dark);
                    }
                    ctr.ForeColor = ColorTranslator.FromHtml(color_fullWhite);
                }
                else
                {
                    if (controlsToChange.Contains(controlsToChange[1]))
                    {
                        ctr.BackColor = Color.Transparent;
                    }
                    ctr.ForeColor = Color.White;
                }
            }
        }

        public void OpenChild_panelContainer(Form ChildForm)
        {
            for (int i = panel_Container.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = panel_Container.Controls[i];
                if (!controlsToKeep.Contains(ctrl))
                {
                    panel_Container.Controls.RemoveAt(i);
                }
            }
            this.panel_Container.Controls.Add(ChildForm);
            ChildForm.Parent = panel_Container;
            ChildForm.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btn_XinNghi_Click(object sender, EventArgs e)
        {
            vNhanVienXinNghi vNhanVienXinNghi = new vNhanVienXinNghi()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
            };
            SetColorButton(btn_XinNghi, pictureBox_XinNghi);
            OpenChild_panelContainer(vNhanVienXinNghi);
        }

        private void btn_Profile_Click(object sender, EventArgs e)
        {
            vNhanVienProfile vNhanVienProfile = new vNhanVienProfile()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
            };
            SetColorButton(btn_Profile, pictureBox_Profile);
            vNhanVienProfile.sMaNV = sMaNV;
            OpenChild_panelContainer(vNhanVienProfile);
        }
    }
}
