namespace QuanLyNhanSu.Forms
{
    partial class vPhongBan
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
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_tblPhongBan = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBox_sTenPB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.panel_0 = new System.Windows.Forms.Panel();
            this.txtBox_sTruongPhong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.txtBox_sMaPB = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_tblNhanVien = new System.Windows.Forms.DataGridView();
            this.checkTruongPhong = new System.Windows.Forms.CheckBox();
            this.btn_XemNhanVien = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPhongBan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("Google Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.Color.White;
            this.btn_Reset.Location = new System.Drawing.Point(29, 911);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(98, 39);
            this.btn_Reset.TabIndex = 47;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(360, 55);
            this.label6.TabIndex = 46;
            this.label6.Text = "Quản Lý Phòng Ban";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_tblPhongBan
            // 
            this.dgv_tblPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tblPhongBan.Location = new System.Drawing.Point(31, 429);
            this.dgv_tblPhongBan.Name = "dgv_tblPhongBan";
            this.dgv_tblPhongBan.Size = new System.Drawing.Size(417, 475);
            this.dgv_tblPhongBan.TabIndex = 45;
            this.dgv_tblPhongBan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tblPhongBan_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtBox_sTenPB);
            this.panel1.Location = new System.Drawing.Point(31, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 39);
            this.panel1.TabIndex = 36;
            // 
            // txtBox_sTenPB
            // 
            this.txtBox_sTenPB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_sTenPB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_sTenPB.Location = new System.Drawing.Point(3, 6);
            this.txtBox_sTenPB.Name = "txtBox_sTenPB";
            this.txtBox_sTenPB.Size = new System.Drawing.Size(194, 22);
            this.txtBox_sTenPB.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(29, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 37);
            this.label1.TabIndex = 34;
            this.label1.Text = "Tên Phòng Ban";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(209, 152);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(145, 54);
            this.btn_Search.TabIndex = 38;
            this.btn_Search.Text = "Tìm kiếm";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Location = new System.Drawing.Point(33, 152);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(145, 54);
            this.btn_Update.TabIndex = 37;
            this.btn_Update.Text = "Sửa";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(209, 67);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(145, 54);
            this.btn_Delete.TabIndex = 35;
            this.btn_Delete.Text = "Xoá";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Insert
            // 
            this.btn_Insert.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Insert.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Insert.ForeColor = System.Drawing.Color.White;
            this.btn_Insert.Location = new System.Drawing.Point(33, 67);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(145, 54);
            this.btn_Insert.TabIndex = 33;
            this.btn_Insert.Text = "Thêm";
            this.btn_Insert.UseVisualStyleBackColor = false;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // panel_0
            // 
            this.panel_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_0.Controls.Add(this.txtBox_sTruongPhong);
            this.panel_0.Location = new System.Drawing.Point(31, 275);
            this.panel_0.Name = "panel_0";
            this.panel_0.Size = new System.Drawing.Size(198, 39);
            this.panel_0.TabIndex = 32;
            // 
            // txtBox_sTruongPhong
            // 
            this.txtBox_sTruongPhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_sTruongPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_sTruongPhong.Location = new System.Drawing.Point(3, 6);
            this.txtBox_sTruongPhong.Name = "txtBox_sTruongPhong";
            this.txtBox_sTruongPhong.Size = new System.Drawing.Size(185, 22);
            this.txtBox_sTruongPhong.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(29, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 37);
            this.label5.TabIndex = 31;
            this.label5.Text = "Trưởng Phòng";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btn_print.Location = new System.Drawing.Point(288, 330);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(66, 36);
            this.btn_print.TabIndex = 82;
            this.btn_print.Text = "Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::QuanLyNhanSu.Properties.Resources.printer__1_;
            this.pictureBox10.Location = new System.Drawing.Point(250, 330);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 33);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 81;
            this.pictureBox10.TabStop = false;
            // 
            // txtBox_sMaPB
            // 
            this.txtBox_sMaPB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_sMaPB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_sMaPB.Location = new System.Drawing.Point(3, 6);
            this.txtBox_sMaPB.Name = "txtBox_sMaPB";
            this.txtBox_sMaPB.Size = new System.Drawing.Size(185, 22);
            this.txtBox_sMaPB.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtBox_sMaPB);
            this.panel6.Location = new System.Drawing.Point(250, 275);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(198, 39);
            this.panel6.TabIndex = 84;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(248, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 37);
            this.label10.TabIndex = 83;
            this.label10.Text = "Mã Phòng Ban";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_tblNhanVien
            // 
            this.dgv_tblNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tblNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tblNhanVien.Location = new System.Drawing.Point(520, 48);
            this.dgv_tblNhanVien.Name = "dgv_tblNhanVien";
            this.dgv_tblNhanVien.Size = new System.Drawing.Size(860, 925);
            this.dgv_tblNhanVien.TabIndex = 85;
            // 
            // checkTruongPhong
            // 
            this.checkTruongPhong.AutoSize = true;
            this.checkTruongPhong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTruongPhong.ForeColor = System.Drawing.Color.Gray;
            this.checkTruongPhong.Location = new System.Drawing.Point(31, 319);
            this.checkTruongPhong.Name = "checkTruongPhong";
            this.checkTruongPhong.Size = new System.Drawing.Size(161, 21);
            this.checkTruongPhong.TabIndex = 86;
            this.checkTruongPhong.Text = "Chưa có trưởng phòng";
            this.checkTruongPhong.UseVisualStyleBackColor = true;
            // 
            // btn_XemNhanVien
            // 
            this.btn_XemNhanVien.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_XemNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XemNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XemNhanVien.ForeColor = System.Drawing.Color.White;
            this.btn_XemNhanVien.Location = new System.Drawing.Point(250, 372);
            this.btn_XemNhanVien.Name = "btn_XemNhanVien";
            this.btn_XemNhanVien.Size = new System.Drawing.Size(198, 39);
            this.btn_XemNhanVien.TabIndex = 87;
            this.btn_XemNhanVien.Text = "Xem Nhân Viên";
            this.btn_XemNhanVien.UseVisualStyleBackColor = false;
            this.btn_XemNhanVien.Click += new System.EventHandler(this.btn_XemNhanVien_Click);
            // 
            // vPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1457, 1000);
            this.ControlBox = false;
            this.Controls.Add(this.btn_XemNhanVien);
            this.Controls.Add(this.checkTruongPhong);
            this.Controls.Add(this.dgv_tblNhanVien);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_tblPhongBan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.panel_0);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "vPhongBan";
            this.Text = "FormNhanVien";
            this.Load += new System.EventHandler(this.FormPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblPhongBan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_0.ResumeLayout(false);
            this.panel_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tblNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_tblPhongBan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBox_sTenPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.Panel panel_0;
        private System.Windows.Forms.TextBox txtBox_sTruongPhong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox txtBox_sMaPB;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_tblNhanVien;
        private System.Windows.Forms.CheckBox checkTruongPhong;
        private System.Windows.Forms.Button btn_XemNhanVien;
    }
}