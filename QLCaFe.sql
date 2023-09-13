create database QLCafe
use QLCafe

--table
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY,
    TenKhachHang NVARCHAR(255),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20)
);

CREATE TABLE TheLoai (
    MaTheLoai INT PRIMARY KEY,
    TenTheLoai NVARCHAR(255)
);

CREATE TABLE Topping(
	MaTopping INT PRIMARY KEY,
	Ten NVARCHAR(255),
	Gia INT
);

CREATE TABLE SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY(1,1),
    TenSanPham NVARCHAR(255),
    GiaTien DECIMAL(10, 2),
	MaTheLoai int,
	FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai)
);

CREATE TABLE DonHang (
    MaDonHang INT PRIMARY KEY IDENTITY(1,1),
    MaKhachHang INT,
    NgayDatHang DATE,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

CREATE TABLE ChiTietDonHang (
    MaChiTietDonHang INT PRIMARY KEY IDENTITY(1,1),
    MaDonHang INT,
    MaSanPham INT,
    SoLuong INT,
	MaTopping INT,
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
	FOREIGN KEY (MaTopping) REFERENCES Topping(MaTopping),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    TenNhanVien NVARCHAR(255),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(255),
	Luong INT,
	QuyenTruyCap NVARCHAR(225)
);
---INSERT

INSERT INTO TheLoai (MaTheLoai,TenTheLoai) VALUES (1,N'Trà Sữa');
INSERT INTO TheLoai (MaTheLoai,TenTheLoai) VALUES (2,N'Hồng Trà');
INSERT INTO TheLoai (MaTheLoai,TenTheLoai) VALUES (3,N'Cà Phê');
INSERT INTO TheLoai (MaTheLoai,TenTheLoai) VALUES (4,N'Nước Đóng Chai');
INSERT INTO TheLoai (MaTheLoai,TenTheLoai) VALUES (5,N'Món Ăn');

INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Trà Sữa Matcha', 20000, 1);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Trà Sữa Thái Xanh', 18000.0, 1);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Trà Sữa Thái Đỏ', 18000, 1);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Trà Sữa Truyền Thống', 25000, 1);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Hồng Trà', 10000, 2);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Hồng Trà Chang', 10000, 2);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Hồng Trà Tắc', 12000, 2);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Cafe Đen', 15000, 3);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Cafe Sữa', 18000, 3);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Bạc Xĩu', 18000, 3);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Sting', 15000, 4);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Cocacola', 15000, 4);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Trà Olong', 12000, 4);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Pessi', 15000, 4);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Mì Gói', 10000, 5);
INSERT INTO SanPham (TenSanPham, GiaTien, MaTheLoai) VALUES (N'Pudding', 5000, 5);

INSERT INTO Topping (MaTopping,Ten,Gia) VALUES (1,N'Topping Khoai Môn',5000);
INSERT INTO Topping (MaTopping,Ten,Gia) VALUES (2,N'Topping Socola',5000);
INSERT INTO Topping (MaTopping,Ten,Gia) VALUES (3,N'Topping trân châu đen',5000);
INSERT INTO Topping (MaTopping,Ten,Gia) VALUES (4,N'Topping Thạch',5000);

INSERT INTO NhanVien (MaNhanVien,TenNhanVien,DiaChi,SoDienThoai,Email,Luong,QuyenTruyCap)
VALUES (1,N'Nguyen Van A',N'Tây Ninh','01234567','nguyenvana@gmail.com',3000000,'Thu Chi');