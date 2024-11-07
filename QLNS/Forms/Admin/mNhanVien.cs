    using System;

    namespace QuanLyNhanSu.Forms.Admin
    {
        internal class mNhanVien
        {
            public string sMaNV { get; set; }          // Mã nhân viên
            public string sMaPB { get; set; }          // Mã phòng ban
            public string sHoTenNV { get; set; }       // Họ tên nhân viên
            public string sSdt { get; set; }           // Số điện thoại
            public DateTime? dNgaySinh { get; set; }   // Ngày sinh
            public DateTime? dNgayVaoLam { get; set; } // Ngày vào làm
            public float? fLuongCoBan { get; set; }       // Lương cơ bản
            public float? fPhuCap { get; set; }        // Phụ cấp
            public float? fHsl { get; set; }           // Hệ số lương
        }
    }
