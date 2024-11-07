namespace QuanLyNhanSu.Forms
{
    partial class MenuAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            this.panel_Container = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_maximize = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel_Decoration = new System.Windows.Forms.Panel();
            this.btn_Admin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_PhongBan = new System.Windows.Forms.Button();
            this.btn_Employee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Admin = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.pictureBox_PhongBan = new System.Windows.Forms.PictureBox();
            this.pictureBox_Employee = new System.Windows.Forms.PictureBox();
            this.panel_Container.SuspendLayout();
            this.panel_Decoration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Admin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Container
            // 
            this.panel_Container.AutoSize = true;
            this.panel_Container.BackColor = System.Drawing.Color.White;
            this.panel_Container.Controls.Add(this.pictureBox8);
            this.panel_Container.Controls.Add(this.label3);
            this.panel_Container.Controls.Add(this.pictureBox7);
            this.panel_Container.Controls.Add(this.btn_minimize);
            this.panel_Container.Controls.Add(this.btn_maximize);
            this.panel_Container.Controls.Add(this.btn_exit);
            this.panel_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Container.Location = new System.Drawing.Point(343, 0);
            this.panel_Container.Name = "panel_Container";
            this.panel_Container.Size = new System.Drawing.Size(1459, 993);
            this.panel_Container.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(668, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(657, 362);
            this.label3.TabIndex = 28;
            this.label3.Text = "Welcome back admin";
            // 
            // btn_minimize
            // 
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimize.ForeColor = System.Drawing.Color.Gold;
            this.btn_minimize.Location = new System.Drawing.Point(1348, 4);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(30, 34);
            this.btn_minimize.TabIndex = 27;
            this.btn_minimize.Text = "-";
            this.btn_minimize.UseVisualStyleBackColor = true;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_maximize
            // 
            this.btn_maximize.FlatAppearance.BorderSize = 0;
            this.btn_maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_maximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_maximize.ForeColor = System.Drawing.Color.Lime;
            this.btn_maximize.Location = new System.Drawing.Point(1384, 4);
            this.btn_maximize.Name = "btn_maximize";
            this.btn_maximize.Size = new System.Drawing.Size(30, 34);
            this.btn_maximize.TabIndex = 26;
            this.btn_maximize.Text = "+";
            this.btn_maximize.UseVisualStyleBackColor = true;
            this.btn_maximize.Click += new System.EventHandler(this.btn_maximize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btn_exit.ForeColor = System.Drawing.Color.Red;
            this.btn_exit.Location = new System.Drawing.Point(1420, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(30, 34);
            this.btn_exit.TabIndex = 25;
            this.btn_exit.Text = "x";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel_Decoration
            // 
            this.panel_Decoration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel_Decoration.Controls.Add(this.pictureBox_Admin);
            this.panel_Decoration.Controls.Add(this.Logo);
            this.panel_Decoration.Controls.Add(this.btn_Admin);
            this.panel_Decoration.Controls.Add(this.label1);
            this.panel_Decoration.Controls.Add(this.pictureBox_PhongBan);
            this.panel_Decoration.Controls.Add(this.btn_PhongBan);
            this.panel_Decoration.Controls.Add(this.pictureBox_Employee);
            this.panel_Decoration.Controls.Add(this.btn_Employee);
            this.panel_Decoration.Controls.Add(this.label2);
            this.panel_Decoration.Controls.Add(this.label4);
            this.panel_Decoration.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Decoration.Location = new System.Drawing.Point(0, 0);
            this.panel_Decoration.Name = "panel_Decoration";
            this.panel_Decoration.Size = new System.Drawing.Size(343, 993);
            this.panel_Decoration.TabIndex = 3;
            // 
            // btn_Admin
            // 
            this.btn_Admin.FlatAppearance.BorderSize = 0;
            this.btn_Admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Admin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Admin.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Admin.Location = new System.Drawing.Point(65, 8);
            this.btn_Admin.Name = "btn_Admin";
            this.btn_Admin.Size = new System.Drawing.Size(91, 45);
            this.btn_Admin.TabIndex = 17;
            this.btn_Admin.Text = "Admin";
            this.btn_Admin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Admin.UseVisualStyleBackColor = true;
            this.btn_Admin.Click += new System.EventHandler(this.btn_Admin_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "SpaceY Admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_PhongBan
            // 
            this.btn_PhongBan.FlatAppearance.BorderSize = 0;
            this.btn_PhongBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PhongBan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PhongBan.ForeColor = System.Drawing.Color.White;
            this.btn_PhongBan.Location = new System.Drawing.Point(84, 343);
            this.btn_PhongBan.Name = "btn_PhongBan";
            this.btn_PhongBan.Size = new System.Drawing.Size(240, 73);
            this.btn_PhongBan.TabIndex = 10;
            this.btn_PhongBan.Text = "     Quản lý phòng ban";
            this.btn_PhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PhongBan.UseVisualStyleBackColor = true;
            this.btn_PhongBan.Click += new System.EventHandler(this.btn_PhongBan_Click);
            // 
            // btn_Employee
            // 
            this.btn_Employee.FlatAppearance.BorderSize = 0;
            this.btn_Employee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Employee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Employee.ForeColor = System.Drawing.Color.White;
            this.btn_Employee.Location = new System.Drawing.Point(84, 250);
            this.btn_Employee.Name = "btn_Employee";
            this.btn_Employee.Size = new System.Drawing.Size(240, 73);
            this.btn_Employee.TabIndex = 8;
            this.btn_Employee.Text = "     Quản Lý nhân viên";
            this.btn_Employee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Employee.UseVisualStyleBackColor = true;
            this.btn_Employee.Click += new System.EventHandler(this.btn_Employee_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 956);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Version 0.1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(187, 946);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 48);
            this.label4.TabIndex = 2;
            this.label4.Text = "Be Different Be Better";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::QuanLyNhanSu.Properties.Resources.laptop;
            this.pictureBox8.Location = new System.Drawing.Point(662, 503);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(542, 498);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 29;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::QuanLyNhanSu.Properties.Resources.pngwing_com;
            this.pictureBox7.Location = new System.Drawing.Point(55, 163);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(547, 838);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 18;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox_Admin
            // 
            this.pictureBox_Admin.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Admin.Image = global::QuanLyNhanSu.Properties.Resources.account1;
            this.pictureBox_Admin.Location = new System.Drawing.Point(16, 8);
            this.pictureBox_Admin.Name = "pictureBox_Admin";
            this.pictureBox_Admin.Size = new System.Drawing.Size(49, 45);
            this.pictureBox_Admin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Admin.TabIndex = 30;
            this.pictureBox_Admin.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = global::QuanLyNhanSu.Properties.Resources.Logo1;
            this.Logo.Location = new System.Drawing.Point(63, 59);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(188, 131);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 3;
            this.Logo.TabStop = false;
            // 
            // pictureBox_PhongBan
            // 
            this.pictureBox_PhongBan.Image = global::QuanLyNhanSu.Properties.Resources.boxes;
            this.pictureBox_PhongBan.Location = new System.Drawing.Point(16, 343);
            this.pictureBox_PhongBan.Name = "pictureBox_PhongBan";
            this.pictureBox_PhongBan.Size = new System.Drawing.Size(74, 73);
            this.pictureBox_PhongBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_PhongBan.TabIndex = 9;
            this.pictureBox_PhongBan.TabStop = false;
            // 
            // pictureBox_Employee
            // 
            this.pictureBox_Employee.Image = global::QuanLyNhanSu.Properties.Resources.management;
            this.pictureBox_Employee.Location = new System.Drawing.Point(16, 250);
            this.pictureBox_Employee.Name = "pictureBox_Employee";
            this.pictureBox_Employee.Size = new System.Drawing.Size(74, 73);
            this.pictureBox_Employee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Employee.TabIndex = 7;
            this.pictureBox_Employee.TabStop = false;
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 993);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Container);
            this.Controls.Add(this.panel_Decoration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuAdmin";
            this.Text = "MenuAdmin";
            this.Load += new System.EventHandler(this.MenuAdmin_Load);
            this.panel_Container.ResumeLayout(false);
            this.panel_Decoration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Admin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Employee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Container;
        private System.Windows.Forms.Panel panel_Decoration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_PhongBan;
        private System.Windows.Forms.Button btn_PhongBan;
        private System.Windows.Forms.PictureBox pictureBox_Employee;
        private System.Windows.Forms.Button btn_Employee;
        private System.Windows.Forms.Button btn_Admin;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_maximize;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox_Admin;
    }
}