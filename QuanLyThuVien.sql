USE [master]
GO
/****** Object:  Database [QuanLyThuVien]    Script Date: 9/28/2021 9:15:46 PM ******/
CREATE DATABASE [QuanLyThuVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyThuVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyThuVien.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyThuVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyThuVien_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyThuVien] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyThuVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyThuVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyThuVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyThuVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyThuVien] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyThuVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyThuVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyThuVien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyThuVien] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyThuVien] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyThuVien] SET QUERY_STORE = OFF
GO
USE [QuanLyThuVien]
GO
/****** Object:  Table [dbo].[tbl_can_bo_thu_vien]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_can_bo_thu_vien](
	[maCanBo] [int] IDENTITY(1,1) NOT NULL,
	[tenCanBo] [nvarchar](50) NULL,
	[gioiTinh] [nvarchar](5) NULL,
	[namSinh] [date] NULL,
	[diaChi] [nvarchar](200) NULL,
	[phone] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[quenHan] [varchar](20) NULL,
	[matKhau] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_can_bo_thu-vien] PRIMARY KEY CLUSTERED 
(
	[maCanBo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_chi_tiet_muon_tra]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_chi_tiet_muon_tra](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[muon_tra_id] [int] NOT NULL,
	[maSach] [int] NOT NULL,
	[maCanBoMuon] [int] NULL,
	[maCanBoTra] [int] NULL,
	[ngayMuon] [date] NULL,
	[ngayPhaiTra] [date] NULL,
	[tinhTrangMuon] [nvarchar](100) NULL,
	[ngayTra] [date] NULL,
	[tinhTrangTra] [text] NULL,
	[thanhToan] [float] NULL,
	[ghiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_tbl_chi_tiet_muon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_doc_gia]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_doc_gia](
	[maThe] [int] IDENTITY(1,1) NOT NULL,
	[maKhoa] [int] NULL,
	[maLop] [int] NULL,
	[hoTen] [nchar](50) NULL,
	[ngaySinh] [date] NULL,
	[gioiTinh] [nvarchar](5) NULL,
	[diaChi] [nvarchar](200) NULL,
	[phone] [char](10) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_doc_gia] PRIMARY KEY CLUSTERED 
(
	[maThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_kho_sach]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_kho_sach](
	[maKho] [int] IDENTITY(1,1) NOT NULL,
	[tenKho] [nvarchar](50) NULL,
	[ghiChu] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_kho_sach] PRIMARY KEY CLUSTERED 
(
	[maKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_khoa]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_khoa](
	[maKhoa] [int] IDENTITY(1,1) NOT NULL,
	[tenKhoa] [nvarchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
	[SDT] [char](10) NULL,
	[email] [varchar](30) NULL,
	[truongKhoa] [nvarchar](30) NULL,
 CONSTRAINT [PK_tbl_khoa] PRIMARY KEY CLUSTERED 
(
	[maKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_lop]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_lop](
	[maLop] [int] IDENTITY(1,1) NOT NULL,
	[maKhoa] [int] NOT NULL,
	[tenLop] [nvarchar](50) NULL,
	[chuNhiem] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_lop] PRIMARY KEY CLUSTERED 
(
	[maLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_muon_tra]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_muon_tra](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[maThe] [int] NULL,
	[ngayTao] [datetime] NULL,
 CONSTRAINT [PK_tbl_muon_tra] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_NXB]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NXB](
	[maNXB] [int] IDENTITY(1,1) NOT NULL,
	[tenNXB] [nvarchar](50) NULL,
	[phone] [char](10) NULL,
	[email] [varchar](50) NULL,
	[diaChi] [nvarchar](100) NULL,
	[ghiChu] [ntext] NULL,
 CONSTRAINT [PK_tbl_NXB] PRIMARY KEY CLUSTERED 
(
	[maNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sach]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sach](
	[maSach] [int] IDENTITY(1,1) NOT NULL,
	[maTheLoai] [int] NULL,
	[maKho] [int] NULL,
	[maNXB] [int] NULL,
	[tenSach] [nvarchar](100) NULL,
	[tenTacGia] [nvarchar](50) NULL,
	[soLuong] [int] NULL,
	[giaTien] [real] NULL,
	[moTa] [ntext] NULL,
 CONSTRAINT [PK_tbl_sach] PRIMARY KEY CLUSTERED 
(
	[maSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_the_loai_sach]    Script Date: 9/28/2021 9:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_the_loai_sach](
	[maTheLoai] [int] IDENTITY(1,1) NOT NULL,
	[tenTheLoai] [nvarchar](50) NULL,
	[ghiChu] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_the_loai_sach] PRIMARY KEY CLUSTERED 
(
	[maTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_can_bo_thu_vien] ON 

INSERT [dbo].[tbl_can_bo_thu_vien] ([maCanBo], [tenCanBo], [gioiTinh], [namSinh], [diaChi], [phone], [email], [quenHan], [matKhau]) VALUES (1, N'Đỗ Tuấn Phong', N'Khác', CAST(N'2000-03-25' AS Date), N'Hà Tây', N'033331762', N'1811061189@gmail.com', N'admin', N'1')
INSERT [dbo].[tbl_can_bo_thu_vien] ([maCanBo], [tenCanBo], [gioiTinh], [namSinh], [diaChi], [phone], [email], [quenHan], [matKhau]) VALUES (3, N'ahii', N'Khác', CAST(N'1989-09-15' AS Date), N'Hà Nam', N'036987451', N'abc@gmail.com', N'member', N'123')
INSERT [dbo].[tbl_can_bo_thu_vien] ([maCanBo], [tenCanBo], [gioiTinh], [namSinh], [diaChi], [phone], [email], [quenHan], [matKhau]) VALUES (15, N'ABC', N'Nam', CAST(N'2000-03-25' AS Date), N'Hà Nội', N'032455', N'1811061189@gmail.com', N'', N'123')
INSERT [dbo].[tbl_can_bo_thu_vien] ([maCanBo], [tenCanBo], [gioiTinh], [namSinh], [diaChi], [phone], [email], [quenHan], [matKhau]) VALUES (17, N'EGH', N'Nữ', CAST(N'2000-03-25' AS Date), N'Hà Nội', N'033331762', N'1811061189@gmail.com', N'meber
member', NULL)
INSERT [dbo].[tbl_can_bo_thu_vien] ([maCanBo], [tenCanBo], [gioiTinh], [namSinh], [diaChi], [phone], [email], [quenHan], [matKhau]) VALUES (20, N'bbb', N'Khác', CAST(N'2000-03-25' AS Date), N'Hà Nội', N'033331762', N'1811061189@gmail.com', N'meber
member', N'1')
INSERT [dbo].[tbl_can_bo_thu_vien] ([maCanBo], [tenCanBo], [gioiTinh], [namSinh], [diaChi], [phone], [email], [quenHan], [matKhau]) VALUES (25, N'asd', N'Nữ', CAST(N'2000-03-25' AS Date), N'Hà Tây', N'033331762', N'1811061189@gmail.com', N'admin', NULL)
INSERT [dbo].[tbl_can_bo_thu_vien] ([maCanBo], [tenCanBo], [gioiTinh], [namSinh], [diaChi], [phone], [email], [quenHan], [matKhau]) VALUES (28, N'Ngô Thị Hà', NULL, NULL, NULL, NULL, N'', NULL, N'1')
SET IDENTITY_INSERT [dbo].[tbl_can_bo_thu_vien] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_chi_tiet_muon_tra] ON 

INSERT [dbo].[tbl_chi_tiet_muon_tra] ([id], [muon_tra_id], [maSach], [maCanBoMuon], [maCanBoTra], [ngayMuon], [ngayPhaiTra], [tinhTrangMuon], [ngayTra], [tinhTrangTra], [thanhToan], [ghiChu]) VALUES (7, 2, 14, 1, 15, CAST(N'2021-05-20' AS Date), CAST(N'2021-05-26' AS Date), N'ok', CAST(N'2021-05-20' AS Date), N'Bình thu?ng', 0, N'')
INSERT [dbo].[tbl_chi_tiet_muon_tra] ([id], [muon_tra_id], [maSach], [maCanBoMuon], [maCanBoTra], [ngayMuon], [ngayPhaiTra], [tinhTrangMuon], [ngayTra], [tinhTrangTra], [thanhToan], [ghiChu]) VALUES (9, 1, 11, 1, 15, CAST(N'2021-05-05' AS Date), CAST(N'2021-06-04' AS Date), N'ok', CAST(N'1753-01-31' AS Date), N'T?t', 0, N'ok')
INSERT [dbo].[tbl_chi_tiet_muon_tra] ([id], [muon_tra_id], [maSach], [maCanBoMuon], [maCanBoTra], [ngayMuon], [ngayPhaiTra], [tinhTrangMuon], [ngayTra], [tinhTrangTra], [thanhToan], [ghiChu]) VALUES (11, 6, 17, 1, NULL, CAST(N'2021-08-10' AS Date), CAST(N'2021-08-26' AS Date), N'bình thường', NULL, NULL, NULL, N'')
INSERT [dbo].[tbl_chi_tiet_muon_tra] ([id], [muon_tra_id], [maSach], [maCanBoMuon], [maCanBoTra], [ngayMuon], [ngayPhaiTra], [tinhTrangMuon], [ngayTra], [tinhTrangTra], [thanhToan], [ghiChu]) VALUES (12, 7, 11, 1, NULL, CAST(N'2021-05-10' AS Date), CAST(N'2021-06-05' AS Date), N'Tốt', NULL, NULL, NULL, N'')
INSERT [dbo].[tbl_chi_tiet_muon_tra] ([id], [muon_tra_id], [maSach], [maCanBoMuon], [maCanBoTra], [ngayMuon], [ngayPhaiTra], [tinhTrangMuon], [ngayTra], [tinhTrangTra], [thanhToan], [ghiChu]) VALUES (13, 2, 14, 1, NULL, CAST(N'2021-05-20' AS Date), CAST(N'2021-05-26' AS Date), N'ok', NULL, NULL, NULL, N'')
SET IDENTITY_INSERT [dbo].[tbl_chi_tiet_muon_tra] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_doc_gia] ON 

INSERT [dbo].[tbl_doc_gia] ([maThe], [maKhoa], [maLop], [hoTen], [ngaySinh], [gioiTinh], [diaChi], [phone], [email]) VALUES (1, 1, 1, N'Đỗ Tuấn Phong                                     ', CAST(N'2000-06-12' AS Date), N'Nam', N'HN', N'0321456987', N'abc@gmail.com')
INSERT [dbo].[tbl_doc_gia] ([maThe], [maKhoa], [maLop], [hoTen], [ngaySinh], [gioiTinh], [diaChi], [phone], [email]) VALUES (2, 2, 2, N'CBA                                               ', CAST(N'2000-10-25' AS Date), N'Nữ', N'HN', N'024345    ', N'')
INSERT [dbo].[tbl_doc_gia] ([maThe], [maKhoa], [maLop], [hoTen], [ngaySinh], [gioiTinh], [diaChi], [phone], [email]) VALUES (4, 1, 1, N'ABC                                               ', CAST(N'2000-06-12' AS Date), N'Nam', N'HN', N'0321456987', N'abc@gmail.com')
INSERT [dbo].[tbl_doc_gia] ([maThe], [maKhoa], [maLop], [hoTen], [ngaySinh], [gioiTinh], [diaChi], [phone], [email]) VALUES (5, 1, 3, N'a a a                                             ', CAST(N'2000-06-08' AS Date), N'Nữ', N'Việt Nam', N'0321456987', N'abc@gmail.com')
INSERT [dbo].[tbl_doc_gia] ([maThe], [maKhoa], [maLop], [hoTen], [ngaySinh], [gioiTinh], [diaChi], [phone], [email]) VALUES (8, 2, 6, N'Alo alo                                           ', CAST(N'2000-10-04' AS Date), N'Nữ', N'HN', N'024345    ', N'')
SET IDENTITY_INSERT [dbo].[tbl_doc_gia] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_kho_sach] ON 

INSERT [dbo].[tbl_kho_sach] ([maKho], [tenKho], [ghiChu]) VALUES (7, N'abc', NULL)
INSERT [dbo].[tbl_kho_sach] ([maKho], [tenKho], [ghiChu]) VALUES (8, N'Công nghệ thông tin', N'')
INSERT [dbo].[tbl_kho_sach] ([maKho], [tenKho], [ghiChu]) VALUES (9, N'Kế toán', N'')
INSERT [dbo].[tbl_kho_sach] ([maKho], [tenKho], [ghiChu]) VALUES (11, N'Tài nguyên', N'')
INSERT [dbo].[tbl_kho_sach] ([maKho], [tenKho], [ghiChu]) VALUES (12, N'DL', N'')
SET IDENTITY_INSERT [dbo].[tbl_kho_sach] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_khoa] ON 

INSERT [dbo].[tbl_khoa] ([maKhoa], [tenKhoa], [diaChi], [SDT], [email], [truongKhoa]) VALUES (1, N'Công nghiệ thông tin', N'a', N'0123456789', N'CNTT@gmail.com', NULL)
INSERT [dbo].[tbl_khoa] ([maKhoa], [tenKhoa], [diaChi], [SDT], [email], [truongKhoa]) VALUES (2, N'KE', N'w', N'42345     ', N'fd', NULL)
SET IDENTITY_INSERT [dbo].[tbl_khoa] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_lop] ON 

INSERT [dbo].[tbl_lop] ([maLop], [maKhoa], [tenLop], [chuNhiem]) VALUES (1, 1, N'DH8C7', NULL)
INSERT [dbo].[tbl_lop] ([maLop], [maKhoa], [tenLop], [chuNhiem]) VALUES (2, 2, N'DH8KE1', NULL)
INSERT [dbo].[tbl_lop] ([maLop], [maKhoa], [tenLop], [chuNhiem]) VALUES (3, 1, N'DH8C6', NULL)
INSERT [dbo].[tbl_lop] ([maLop], [maKhoa], [tenLop], [chuNhiem]) VALUES (6, 2, N'DH8KE2', NULL)
SET IDENTITY_INSERT [dbo].[tbl_lop] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_muon_tra] ON 

INSERT [dbo].[tbl_muon_tra] ([ID], [maThe], [ngayTao]) VALUES (1, 1, CAST(N'2021-05-14T09:35:27.630' AS DateTime))
INSERT [dbo].[tbl_muon_tra] ([ID], [maThe], [ngayTao]) VALUES (2, 1, CAST(N'2021-05-14T09:35:55.230' AS DateTime))
INSERT [dbo].[tbl_muon_tra] ([ID], [maThe], [ngayTao]) VALUES (4, 2, CAST(N'2021-05-26T09:35:27.000' AS DateTime))
INSERT [dbo].[tbl_muon_tra] ([ID], [maThe], [ngayTao]) VALUES (5, 8, CAST(N'2021-07-29T09:35:27.000' AS DateTime))
INSERT [dbo].[tbl_muon_tra] ([ID], [maThe], [ngayTao]) VALUES (6, 5, CAST(N'2021-07-21T09:35:27.000' AS DateTime))
INSERT [dbo].[tbl_muon_tra] ([ID], [maThe], [ngayTao]) VALUES (7, 2, CAST(N'2021-08-12T09:35:27.000' AS DateTime))
INSERT [dbo].[tbl_muon_tra] ([ID], [maThe], [ngayTao]) VALUES (8, 4, CAST(N'2021-05-26T09:35:27.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_muon_tra] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_NXB] ON 

INSERT [dbo].[tbl_NXB] ([maNXB], [tenNXB], [phone], [email], [diaChi], [ghiChu]) VALUES (1, N'Đại học quốc gia', N'0326598741', N'DHQG@gmail.com', N'', N'')
INSERT [dbo].[tbl_NXB] ([maNXB], [tenNXB], [phone], [email], [diaChi], [ghiChu]) VALUES (2, N'Bộ GD-DT', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_NXB] ([maNXB], [tenNXB], [phone], [email], [diaChi], [ghiChu]) VALUES (3, N'Đạ học TN&MT', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_NXB] ([maNXB], [tenNXB], [phone], [email], [diaChi], [ghiChu]) VALUES (4, N'Đại học sư phạm', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_NXB] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_sach] ON 

INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (10, 2, 7, 1, N'Thời trang', N'DGDG', 35, 4534534, N'')
INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (11, 3, 8, 3, N'Đồ án', N' sf', 56, 456546, N'')
INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (12, 1, 9, 4, N'Công nghệ Java', N'DHSP', 34, 65, N'')
INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (13, 2, 7, 2, N'y45', N'gg', 35, 4534534, N'')
INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (14, 2, 7, 1, N'Tạp chí kinh tế', N'gg', 23, 4534534, N'')
INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (17, 2, 7, 2, N'Công nghệ .Net', N'gg', 35, 4534534, N'')
INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (20, 2, 9, 3, N'Phân tích thiết kế', N'gg', 4, 8567, N'')
INSERT [dbo].[tbl_sach] ([maSach], [maTheLoai], [maKho], [maNXB], [tenSach], [tenTacGia], [soLuong], [giaTien], [moTa]) VALUES (21, 3, 8, 2, N'LA tốt nghiệp', N'adas', 35, 4534534, N'')
SET IDENTITY_INSERT [dbo].[tbl_sach] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_the_loai_sach] ON 

INSERT [dbo].[tbl_the_loai_sach] ([maTheLoai], [tenTheLoai], [ghiChu]) VALUES (1, N'Giáo trình', NULL)
INSERT [dbo].[tbl_the_loai_sach] ([maTheLoai], [tenTheLoai], [ghiChu]) VALUES (2, N'Tạp chí', NULL)
INSERT [dbo].[tbl_the_loai_sach] ([maTheLoai], [tenTheLoai], [ghiChu]) VALUES (3, N'Luận án', NULL)
INSERT [dbo].[tbl_the_loai_sach] ([maTheLoai], [tenTheLoai], [ghiChu]) VALUES (4, N'Báo cáo bài tập', N'')
INSERT [dbo].[tbl_the_loai_sach] ([maTheLoai], [tenTheLoai], [ghiChu]) VALUES (5, N'Sách tham khảo', NULL)
INSERT [dbo].[tbl_the_loai_sach] ([maTheLoai], [tenTheLoai], [ghiChu]) VALUES (6, N'Đồ án', N'')
SET IDENTITY_INSERT [dbo].[tbl_the_loai_sach] OFF
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra] ADD  CONSTRAINT [DF_tbl_chi_tiet_muon_ngayMuon]  DEFAULT (getdate()) FOR [ngayMuon]
GO
ALTER TABLE [dbo].[tbl_muon_tra] ADD  CONSTRAINT [DF_tbl_muon_tra_ngayTao]  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra]  WITH CHECK ADD  CONSTRAINT [FK_tbl_chi_tiet_muon_tbl_muon_tra] FOREIGN KEY([maCanBoMuon])
REFERENCES [dbo].[tbl_muon_tra] ([ID])
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra] CHECK CONSTRAINT [FK_tbl_chi_tiet_muon_tbl_muon_tra]
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra]  WITH CHECK ADD  CONSTRAINT [FK_tbl_chi_tiet_muon_tbl_sach] FOREIGN KEY([maSach])
REFERENCES [dbo].[tbl_sach] ([maSach])
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra] CHECK CONSTRAINT [FK_tbl_chi_tiet_muon_tbl_sach]
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra]  WITH CHECK ADD  CONSTRAINT [FK_tbl_chi_tiet_muon_tra_tbl_can_bo_thu_vien] FOREIGN KEY([maCanBoMuon])
REFERENCES [dbo].[tbl_can_bo_thu_vien] ([maCanBo])
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra] CHECK CONSTRAINT [FK_tbl_chi_tiet_muon_tra_tbl_can_bo_thu_vien]
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra]  WITH CHECK ADD  CONSTRAINT [FK_tbl_chi_tiet_muon_tra_tbl_can_bo_thu_vien1] FOREIGN KEY([maCanBoTra])
REFERENCES [dbo].[tbl_can_bo_thu_vien] ([maCanBo])
GO
ALTER TABLE [dbo].[tbl_chi_tiet_muon_tra] CHECK CONSTRAINT [FK_tbl_chi_tiet_muon_tra_tbl_can_bo_thu_vien1]
GO
ALTER TABLE [dbo].[tbl_doc_gia]  WITH CHECK ADD  CONSTRAINT [FK_tbl_doc_gia_tbl_khoa] FOREIGN KEY([maKhoa])
REFERENCES [dbo].[tbl_khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[tbl_doc_gia] CHECK CONSTRAINT [FK_tbl_doc_gia_tbl_khoa]
GO
ALTER TABLE [dbo].[tbl_doc_gia]  WITH CHECK ADD  CONSTRAINT [FK_tbl_doc_gia_tbl_lop] FOREIGN KEY([maLop])
REFERENCES [dbo].[tbl_lop] ([maLop])
GO
ALTER TABLE [dbo].[tbl_doc_gia] CHECK CONSTRAINT [FK_tbl_doc_gia_tbl_lop]
GO
ALTER TABLE [dbo].[tbl_lop]  WITH CHECK ADD  CONSTRAINT [FK_tbl_lop_tbl_khoa] FOREIGN KEY([maKhoa])
REFERENCES [dbo].[tbl_khoa] ([maKhoa])
GO
ALTER TABLE [dbo].[tbl_lop] CHECK CONSTRAINT [FK_tbl_lop_tbl_khoa]
GO
ALTER TABLE [dbo].[tbl_muon_tra]  WITH CHECK ADD  CONSTRAINT [FK_tbl_muon_tra_tbl_doc_gia] FOREIGN KEY([maThe])
REFERENCES [dbo].[tbl_doc_gia] ([maThe])
GO
ALTER TABLE [dbo].[tbl_muon_tra] CHECK CONSTRAINT [FK_tbl_muon_tra_tbl_doc_gia]
GO
ALTER TABLE [dbo].[tbl_sach]  WITH CHECK ADD  CONSTRAINT [FK_tbl_sach_tbl_kho_sach] FOREIGN KEY([maKho])
REFERENCES [dbo].[tbl_kho_sach] ([maKho])
GO
ALTER TABLE [dbo].[tbl_sach] CHECK CONSTRAINT [FK_tbl_sach_tbl_kho_sach]
GO
ALTER TABLE [dbo].[tbl_sach]  WITH CHECK ADD  CONSTRAINT [FK_tbl_sach_tbl_NXB] FOREIGN KEY([maNXB])
REFERENCES [dbo].[tbl_NXB] ([maNXB])
GO
ALTER TABLE [dbo].[tbl_sach] CHECK CONSTRAINT [FK_tbl_sach_tbl_NXB]
GO
ALTER TABLE [dbo].[tbl_sach]  WITH CHECK ADD  CONSTRAINT [FK_tbl_sach_tbl_the_loai_sach] FOREIGN KEY([maTheLoai])
REFERENCES [dbo].[tbl_the_loai_sach] ([maTheLoai])
GO
ALTER TABLE [dbo].[tbl_sach] CHECK CONSTRAINT [FK_tbl_sach_tbl_the_loai_sach]
GO
USE [master]
GO
ALTER DATABASE [QuanLyThuVien] SET  READ_WRITE 
GO
