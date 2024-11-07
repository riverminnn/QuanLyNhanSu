CREATE DATABASE QLNS
USE QLNS

Declare @procName varchar(500) 
Declare cur Cursor For Select [name] From sys.objects where type = 'p' 
Open cur 
Fetch Next From cur Into @procName 
While @@fetch_status = 0 
Begin 
 Exec('drop procedure ' + @procName) 
 Fetch Next From cur Into @procName 
End
Close cur 
Deallocate cur

CREATE TABLE tblPhongBan(
	sMaPB varchar(30) PRIMARY KEY,
	sTenPB nvarchar(30),
	sTruongPhong varchar(30),
)

ALTER TABLE tblPhongBan ADD CONSTRAINT FK_sTruongPhong FOREIGN KEY (sTruongPhong) REFERENCES tblNhanVien(sMaNV)

CREATE TABLE tblNhanVien(
	sMaNV varchar(30) PRIMARY KEY,
	sHoTenNV nvarchar(50),
	sMaPB varchar(30),
	sSdt varchar(10),
	dNgaySinh date,
	dNgayVaoLam date,
	fLuongCoBan float,
	fPhuCap float,
	fHsl float,
	CONSTRAINT FK_sMaPB FOREIGN KEY (sMaPB) REFERENCES tblPhongBan(sMaPB),
)

CREATE TABLE tblAccountData(
	sUsername varchar(30) PRIMARY KEY NOT NULL,
	sPassword varchar(16),
	CONSTRAINT FK_sUsername FOREIGN KEY (sUsername) REFERENCES tblNhanVien(sMaNV),
)

SELECT * FROM tblAccountData
SELECT * FROM tblNhanVien
SELECT * FROM tblPhongBan

GO
CREATE OR ALTER PROCEDURE PROC_InsertAccountData
	@sUsername varchar(30),
	@sPassword varchar(16)
AS
BEGIN
	INSERT INTO tblAccountData (sUsername, sPassword)
	VALUES (@sUsername, @sPassword);
END
INSERT INTO tblPhongBan (sMaPB, sTenPB, sTruongPhong)
VALUES ('admin', 'admin', null)
INSERT INTO tblNhanVien (sMaNV, sHoTenNV, sMaPB, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap, fHSL)
VALUES ('admin', 'Yilong Mask', 'admin', '0999999999', '1990-01-01', '2099-01-01', 1, 1, 1.0)
EXEC PROC_InsertAccountData 'admin', '1'

UPDATE tblPhongBan SET sTruongPhong = 'admin' where sMaPB = 'admin'

INSERT INTO tblPhongBan (sMaPB, sTenPB, sTruongPhong)
VALUES
('PB01', 'Phong Ky Thuat', null),
('PB02', 'Phong Tai Chinh', null),
('PB03', 'Phong Ke Toan', null),
('PB04', 'Phong Nhan Su', null),
('PB05', 'Phong Marketing', null),
('PB06', 'Phong Ban Hang', null),
('PB07', 'Phong CNTT', null),
('PB08', 'Phong Nghien Cuu Phat Trien', null),
('PB09', 'Phong Dich Vu Khach Hang', null),
('PB10', 'Phong Phap Ly', null);
INSERT INTO tblPhongBan (sMaPB, sTenPB, sTruongPhong)
VALUES
('PB11', 'Phong Quan Tri', null),
('PB12', 'Phong Phat Trien Kinh Doanh', null),
('PB13', 'Phong Thong Tin', null),
('PB14', 'Phong Thiet Ke', null),
('PB15', 'Phong Doi Ngoai', null),
('PB16', 'Phong Thuc Tap', null),
('PB17', 'Phong Kinh Doanh Quoc Te', null),
('PB18', 'Phong Bao Chi', null),
('PB19', 'Phong An Ninh', null),
('PB20', 'Phong Dieu Hanh', null);

INSERT INTO tblNhanVien (sMaNV, sHoTenNV, sMaPB, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap, fHSL)
VALUES 
('NV01', 'Nguyen Tran A', 'PB01', '0123456789', '1990-01-01', '2099-01-01', 1000, 200, 1.0),
('NV02', 'Nguyen Van A', 'PB02', '0123456788', '1990-01-01', '2099-01-01', 1000, 200, 1.0),
('NV03', 'Nguyen Thi A', 'PB03', '0123456787', '1990-01-01', '2099-01-01', 1000, 200, 1.0),
('NV04', 'Le Minh B', 'PB04', '0123456786', '1988-04-15', '2023-05-10', 1200, 250, 1.1),
('NV05', 'Tran Van C', 'PB05', '0123456785', '1992-08-22', '2022-03-01', 1300, 220, 1.2),
('NV06', 'Pham Thi D', 'PB06', '0123456784', '1985-06-30', '2021-07-20', 1100, 300, 1.0),
('NV07', 'Nguyen Van E', 'PB07', '0123456783', '1993-09-12', '2023-02-15', 1150, 270, 1.1),
('NV08', 'Do Thi F', 'PB08', '0123456782', '1990-11-03', '2020-11-01', 1250, 240, 1.3),
('NV09', 'Bui Van G', 'PB09', '0123456781', '1987-01-17', '2022-06-30', 1180, 260, 1.2),
('NV10', 'Hoang Thi H', 'PB10', '0123456780', '1995-03-27', '2021-10-10', 1350, 210, 1.4);
INSERT INTO tblNhanVien (sMaNV, sHoTenNV, sMaPB, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap, fHSL)
VALUES 
('NV11', 'Nguyen Huu I', 'PB01', '0123456779', '1989-05-10', '2023-01-15', 1250, 230, 1.2),
('NV12', 'Le Thi J', 'PB02', '0123456778', '1991-02-18', '2021-09-20', 1300, 210, 1.1),
('NV13', 'Pham Van K', 'PB03', '0123456777', '1983-12-24', '2022-08-05', 1400, 250, 1.3),
('NV14', 'Truong Thi L', 'PB04', '0123456776', '1994-07-09', '2023-04-12', 1150, 220, 1.0),
('NV15', 'Hoang Van M', 'PB05', '0123456775', '1990-03-30', '2020-06-18', 1200, 240, 1.1),
('NV16', 'Vu Thi N', 'PB06', '0123456774', '1987-11-02', '2022-10-25', 1275, 260, 1.2),
('NV17', 'Tran Van O', 'PB07', '0123456773', '1992-08-21', '2021-01-01', 1180, 250, 1.1),
('NV18', 'Nguyen Thi P', 'PB08', '0123456772', '1985-06-17', '2023-07-14', 1350, 240, 1.3),
('NV19', 'Bui Van Q', 'PB09', '0123456771', '1996-09-25', '2022-03-19', 1250, 270, 1.2),
('NV20', 'Ngo Thi R', 'PB10', '0123456770', '1993-04-05', '2020-12-11', 1300, 210, 1.4);
INSERT INTO tblNhanVien (sMaNV, sHoTenNV, sMaPB, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap, fHSL)
VALUES 
('NV21', 'Tran Huu S', 'PB01', '0123456769', '1990-05-14', '2023-05-15', 1200, 220, 1.1),
('NV22', 'Le Van T', 'PB02', '0123456768', '1986-10-20', '2021-02-18', 1250, 230, 1.2),
('NV23', 'Nguyen Thi U', 'PB03', '0123456767', '1994-03-22', '2022-07-25', 1300, 240, 1.1),
('NV24', 'Pham Van V', 'PB04', '0123456766', '1991-01-16', '2020-09-12', 1150, 210, 1.0),
('NV25', 'Bui Thi W', 'PB05', '0123456765', '1993-12-18', '2023-03-08', 1400, 260, 1.3),
('NV26', 'Do Van X', 'PB06', '0123456764', '1988-08-29', '2021-11-20', 1175, 240, 1.1),
('NV27', 'Hoang Van Y', 'PB07', '0123456763', '1989-07-07', '2022-04-10', 1250, 250, 1.2),
('NV28', 'Nguyen Thi Z', 'PB08', '0123456762', '1995-06-15', '2020-05-19', 1350, 230, 1.3),
('NV29', 'Le Van AA', 'PB09', '0123456761', '1987-09-30', '2023-02-22', 1300, 220, 1.2),
('NV30', 'Vu Thi BB', 'PB10', '0123456760', '1992-11-11', '2021-08-17', 1400, 250, 1.4);
INSERT INTO tblNhanVien (sMaNV, sHoTenNV, sMaPB, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap, fHSL)
VALUES 
('NV31', 'Nguyen Van CC', 'PB01', '0123456759', '1985-02-13', '2022-05-01', 1250, 220, 1.2),
('NV32', 'Tran Thi DD', 'PB02', '0123456758', '1990-10-05', '2021-03-16', 1300, 210, 1.1),
('NV33', 'Le Van EE', 'PB03', '0123456757', '1984-06-19', '2020-01-23', 1275, 240, 1.2),
('NV34', 'Pham Thi FF', 'PB04', '0123456756', '1993-08-11', '2023-06-04', 1200, 230, 1.0),
('NV35', 'Do Van GG', 'PB05', '0123456755', '1991-11-09', '2022-10-20', 1350, 260, 1.3),
('NV36', 'Bui Thi HH', 'PB06', '0123456754', '1989-05-17', '2021-09-30', 1150, 240, 1.1),
('NV37', 'Nguyen Van II', 'PB07', '0123456753', '1995-03-29', '2020-12-15', 1280, 250, 1.2),
('NV38', 'Vu Thi JJ', 'PB08', '0123456752', '1986-12-03', '2023-01-27', 1325, 220, 1.3),
('NV39', 'Le Thi KK', 'PB09', '0123456751', '1992-04-06', '2022-08-09', 1300, 270, 1.2),
('NV40', 'Pham Van LL', 'PB10', '0123456750', '1988-07-14', '2021-05-18', 1375, 210, 1.4);
INSERT INTO tblNhanVien (sMaNV, sHoTenNV, sMaPB, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap, fHSL)
VALUES 
('NV41', 'Hoang Van MM', 'PB01', '0123456749', '1991-01-23', '2020-06-30', 1240, 210, 1.1),
('NV42', 'Nguyen Thi NN', 'PB02', '0123456748', '1987-09-12', '2021-07-20', 1290, 220, 1.2),
('NV43', 'Tran Van OO', 'PB03', '0123456747', '1993-03-08', '2023-05-01', 1350, 240, 1.3),
('NV44', 'Bui Thi PP', 'PB04', '0123456746', '1995-10-15', '2022-11-19', 1180, 230, 1.0),
('NV45', 'Vu Van QQ', 'PB05', '0123456745', '1988-06-06', '2020-03-05', 1250, 250, 1.2),
('NV46', 'Do Thi RR', 'PB06', '0123456744', '1989-11-21', '2021-08-15', 1300, 260, 1.1),
('NV47', 'Pham Van SS', 'PB07', '0123456743', '1990-04-17', '2022-04-22', 1320, 220, 1.3),
('NV48', 'Le Thi TT', 'PB08', '0123456742', '1992-05-30', '2023-02-10', 1280, 240, 1.2),
('NV49', 'Tran Van UU', 'PB09', '0123456741', '1994-02-14', '2021-09-25', 1350, 270, 1.3),
('NV50', 'Nguyen Thi VV', 'PB10', '0123456740', '1991-07-28', '2022-12-05', 1380, 210, 1.4);

GO
CREATE PROCEDURE PROC_SelectNhanVienByID
@sMaNV varchar(15)
AS
BEGIN
	SELECT * FROM tblNhanVien WHERE sMaNV = @sMaNV
END

GO
CREATE PROCEDURE PROC_SelectPhongBanByID
@sMaPB varchar(15)
AS
BEGIN
	SELECT * FROM tblNhanVien WHERE sMaPB = @sMaPB
END

GO
CREATE PROCEDURE PROC_SelectAllFromNhanVien
AS
BEGIN
	SELECT * FROM tblNhanVien;
END

GO
CREATE PROCEDURE PROC_SelectAllFromAccountData
AS
BEGIN
	SELECT * FROM tblAccountData;
END

GO
CREATE PROCEDURE PROC_DeleteAccountData
	@sUsername varchar(15)
AS
BEGIN
	DELETE FROM tblAccountData WHERE sUsername = @sUsername;
END

GO
CREATE PROCEDURE PROC_UpdateAccountData
	@sUsername varchar(15),
	@sPassword varchar(16)
AS
BEGIN
	UPDATE tblAccountData
	SET sPassword = @sPassword
	WHERE sUsername = @sUsername;
END

GO
CREATE PROCEDURE PROC_DeleteNhanVien
	@sMaNV varchar(30)
AS
BEGIN
	DELETE FROM tblNhanVien WHERE sMaNV = @sMaNV;
END

GO
CREATE PROCEDURE PROC_InsertNhanVien
	@sMaNV varchar(30),
	@sHoTenNV nvarchar(50),
	@sMaPB varchar(30),
	@sSDT varchar(10),
	@dNgaySinh date,
	@dNgayVaoLam date,
	@fLuongCoBan float,
	@fPhuCap float,
	@fHSL float
AS
BEGIN
	INSERT INTO tblNhanVien (sMaNV, sHoTenNV, sMaPB, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap, fHSL)
	VALUES (@sMaNV, @sHoTenNV, @sMaPB, @sSDT, @dNgaySinh, @dNgayVaoLam, @fLuongCoBan, @fPhuCap, @fHSL);
END

GO
CREATE PROCEDURE PROC_UpdateNhanVien
	@sMaNV varchar(30),
	@sHoTenNV nvarchar(50),
	@sMaPB varchar(30),
	@sSDT varchar(10),
	@dNgaySinh date,
	@dNgayVaoLam date,
	@fLuongCoBan float,
	@fPhuCap float,
	@fHSL float
AS
BEGIN
	UPDATE tblNhanVien
	SET sHoTenNV = @sHoTenNV,
		sMaPB = @sMaPB,
		sSDT = @sSDT,
		dNgaySinh = @dNgaySinh,
		dNgayVaoLam = @dNgayVaoLam,
		fLuongCoBan = @fLuongCoBan,
		fPhuCap = @fPhuCap,
		fHSL = @fHSL
	WHERE sMaNV = @sMaNV;
END

GO
CREATE PROCEDURE PROC_SelectAllFromPhongBan
AS
BEGIN
    SELECT * FROM tblPhongBan;
END
GO

CREATE PROCEDURE PROC_DeletePhongBan
    @sMaPB varchar(30)
AS
BEGIN
    DELETE FROM tblPhongBan WHERE sMaPB = @sMaPB;
END
GO

CREATE PROCEDURE PROC_InsertPhongBan
    @sMaPB varchar(30),
    @sTenPB nvarchar(30),
    @sTruongPhong varchar(30)
AS
BEGIN
    INSERT INTO tblPhongBan (sMaPB, sTenPB, sTruongPhong)
    VALUES (@sMaPB, @sTenPB, @sTruongPhong);
END
GO

CREATE PROCEDURE PROC_UpdatePhongBan
    @sMaPB varchar(30),
    @sTenPB nvarchar(30),
    @sTruongPhong varchar(30)
AS
BEGIN
    UPDATE tblPhongBan
    SET sTenPB = @sTenPB,
        sTruongPhong = @sTruongPhong
    WHERE sMaPB = @sMaPB;
END
GO


