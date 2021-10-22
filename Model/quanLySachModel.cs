using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class quanLySachModel
    {
        private static quanLySachModel instance;
        public static quanLySachModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new quanLySachModel();
                return instance;
            }
        }
        private quanLySachModel() { }
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        #region->book
        public object View()
        {
            var book = from b in db.tbl_saches
                         from nxb in db.tbl_NXBs
                         from category in db.tbl_the_loai_saches
                         from storage in db.tbl_kho_saches
                         where b.maKho == storage.maKho
                         where nxb.maNXB == b.maNXB
                         where b.maTheLoai == category.maTheLoai
                         select new
                         {
                             id = b.maSach,
                             name = b.tenSach,
                             nxb = nxb.tenNXB,
                             author = b.tenTacGia,
                             number = b.soLuong,
                             price = b.giaTien,
                             note = b.moTa,
                             category = category.tenTheLoai,
                             storage = storage.tenKho,
                             nxbID = b.maNXB,
                             categoryID = b.maTheLoai,
                             storageID = b.maKho
                         };
            return book;
        }
        public object SearchInt(int keyint, float keyFloat)
        {
            var bookSearch = from book in db.tbl_saches
                               from nxb in db.tbl_NXBs
                               from category in db.tbl_the_loai_saches
                               from storage in db.tbl_kho_saches
                               where book.maKho == storage.maKho
                               where nxb.maNXB == book.maNXB
                               where book.maTheLoai == category.maTheLoai
                               where book.giaTien == keyFloat || book.maSach == keyint || book.soLuong == keyint
                               select new
                               {
                                   id = book.maSach,
                                   name = book.tenSach,
                                   nxb = nxb.tenNXB,
                                   author = book.tenTacGia,
                                   number = book.soLuong,
                                   price = book.giaTien,
                                   note = book.moTa,
                                   category = category.tenTheLoai,
                                   storage = storage.tenKho,
                                   nxbID = book.maNXB,
                                   categoryID = book.maTheLoai,
                                   storageID = book.maKho
                               };
            return bookSearch;
        }
        public object SearchString(string key)
        {
            var bookSearch = from book in db.tbl_saches
                               from nxb in db.tbl_NXBs
                               from category in db.tbl_the_loai_saches
                               from storage in db.tbl_kho_saches
                               where book.maKho == storage.maKho
                               where nxb.maNXB == book.maNXB
                               where book.maTheLoai == category.maTheLoai
                               where SqlMethods.Like(book.tenSach, "%" + key + "%") ||
                               SqlMethods.Like(book.tenTacGia, "%" + key + "%") ||
                               SqlMethods.Like(book.moTa, "%" + key + "%") ||
                               SqlMethods.Like(category.tenTheLoai, "%" + key + "%") ||
                               SqlMethods.Like(storage.tenKho, "%" + key + "%") ||
                               SqlMethods.Like(nxb.tenNXB, "%" + key + "%")
                               select new
                               {
                                   id = book.maSach,
                                   name = book.tenSach,
                                   nxb = nxb.tenNXB,
                                   author = book.tenTacGia,
                                   number = book.soLuong,
                                   price = book.giaTien,
                                   note = book.moTa,
                                   category = category.tenTheLoai,
                                   storage = storage.tenKho,
                                   nxbID = book.maNXB,
                                   categoryID = book.maTheLoai,
                                   storageID = book.maKho
                               };
            return bookSearch;
        }
        public object cbTheLoai()
        {
            var result = from c in db.tbl_the_loai_saches
                         select new
                         {
                             maTheLoai = c.maTheLoai,
                             ten = c.tenTheLoai
                         };
            return result;
        }
        public object cbTenKho()
        {
            var result = from s in db.tbl_kho_saches
                         select new
                         {
                             maKho = s.maKho,
                             ten = s.tenKho
                         };
            return result;
        }
        public object cbNXB()
        {
            var result = from n in db.tbl_NXBs
                         select new
                         {
                             maNXB = n.maNXB,
                             ten = n.tenNXB
                         };
            return result;
        }
        public bool Sua(int id, tbl_sach sach)
        {
            tbl_sach sachModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                sachModel = db.tbl_saches.Where(p => p.maSach == id).SingleOrDefault();
                sachModel.tenSach = sach.tenSach;
                sachModel.maTheLoai = sach.maTheLoai;
                sachModel.tenTacGia = sach.tenTacGia;
                sachModel.soLuong = sach.soLuong;
                sachModel.giaTien = sach.giaTien;
                sachModel.maKho = sach.maKho;
                sachModel.maNXB = sach.maNXB;
                sachModel.moTa = sach.moTa;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        public bool Luu(int maTheLoai, int maKho, int maNXB,string name,string author,int number,float price,string note, tbl_sach sach)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_sach insert = new tbl_sach();
                insert.maTheLoai = maTheLoai;
                insert.maKho = maKho;
                insert.maNXB = maNXB;
                insert.tenSach = name;
                insert.tenTacGia = author;
                insert.soLuong = number;
                insert.giaTien = price;
                insert.moTa = note;

                db.tbl_saches.InsertOnSubmit(insert);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool Xoa(int id, tbl_sach sach)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_sach delete = db.tbl_saches.Where(p => p.maSach == id).SingleOrDefault();
                db.tbl_saches.DeleteOnSubmit(delete);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        #endregion
        #region->Category
        public List<tbl_the_loai_sach> ViewCategory()
        {
            List<tbl_the_loai_sach> category = new List<tbl_the_loai_sach>();
            category = db.tbl_the_loai_saches.Select(c => c).ToList();
            return category;
        }
        public object SearchCategoryInt(int keyint)
        {
            var categorySearch = from c in db.tbl_the_loai_saches
                             where c.maTheLoai == keyint
                             select c;
            return categorySearch;
        }
        public object SearchCategoryString(string key)
        {
            var categorySearch = from c in db.tbl_the_loai_saches
                                 where SqlMethods.Like(c.tenTheLoai, "%" + key + "%") ||
                                 SqlMethods.Like(c.ghiChu, "%" + key + "%")
                                 select c;
            return categorySearch;
        }
        public bool LuuL(string name,  string note, tbl_the_loai_sach LSach)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_the_loai_sach insert = new tbl_the_loai_sach();
                insert.tenTheLoai = name;
                insert.ghiChu = note;

                db.tbl_the_loai_saches.InsertOnSubmit(insert);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool SuaL(int id, tbl_the_loai_sach LSach)
        {
            tbl_the_loai_sach LSachModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                LSachModel = db.tbl_the_loai_saches.Where(p => p.maTheLoai == id).SingleOrDefault();
                LSachModel.tenTheLoai = LSach.tenTheLoai;
                LSachModel.ghiChu = LSach.ghiChu;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        public bool XoaL(int id, tbl_the_loai_sach LSach)
        {
            //tbl_can_bo_thu_vien sachModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_the_loai_sach delete = db.tbl_the_loai_saches.Where(p => p.maTheLoai == id).SingleOrDefault();
                db.tbl_the_loai_saches.DeleteOnSubmit(delete);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        #endregion
        #region->NXB
        public List<tbl_NXB> ViewNXB()
        {
            List<tbl_NXB> nxb = new List<tbl_NXB>();
            nxb = db.tbl_NXBs.Select(n => n).ToList();
            return nxb;
        }
        public object SearchNXBInt(int keyint)
        {
            var nxbSearch = from n in db.tbl_NXBs
                            where n.maNXB == keyint || SqlMethods.Like(n.phone, "%" + keyint + "%")
                            select n;
            return nxbSearch;
        }
        public object SearchNXBString(string key)
        {
            var nxbSearch = from n in db.tbl_NXBs
                            where SqlMethods.Like(n.tenNXB, "%" + key + "%") ||
                                 SqlMethods.Like(n.diaChi, "%" + key + "%") ||
                                 SqlMethods.Like(n.email, "%" + key + "%") ||
                                 SqlMethods.Like(n.phone, "%" + key + "%") ||
                                 SqlMethods.Like(n.ghiChu, "%" + key + "%")
                            select n;
            return nxbSearch;
        }
        public bool LuuN(string name, string phone, string email, string address, string note,tbl_NXB nxb)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_NXB insert = new tbl_NXB();
                insert.tenNXB = name;
                insert.phone = phone;
                insert.email = email;
                insert.diaChi = address;
                insert.ghiChu = note;

                db.tbl_NXBs.InsertOnSubmit(insert);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool SuaN(int id, tbl_NXB nxb)
        {
            tbl_NXB nxbModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                nxbModel = db.tbl_NXBs.Where(p => p.maNXB == id).SingleOrDefault();
                nxbModel.maNXB = nxb.maNXB;
                nxbModel.tenNXB = nxb.tenNXB;
                nxbModel.phone = nxb.phone;
                nxbModel.email = nxb.email;
                nxbModel.diaChi = nxb.diaChi;
                nxbModel.ghiChu = nxb.ghiChu;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        public bool XoaN(int id, tbl_NXB nxb)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_NXB delete = db.tbl_NXBs.Where(p => p.maNXB == id).SingleOrDefault();
                db.tbl_NXBs.DeleteOnSubmit(delete);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        #endregion
        #region->storage
        public List<tbl_kho_sach> ViewStorage()
        {
            List<tbl_kho_sach> storage = new List<tbl_kho_sach>();
            storage = db.tbl_kho_saches.Select(s => s).ToList();
            return storage;
        }
        public object SearchStorageInt(int keyint)
        {
            var storageSearch = from k in db.tbl_kho_saches
                                where k.maKho == keyint
                                select k;
            return storageSearch;
        }
        public object SearchStorageString(string key)
        {
            var storageSearch = from k in db.tbl_kho_saches
                                where SqlMethods.Like(k.tenKho, "%" + key + "%") ||
                                     SqlMethods.Like(k.ghiChu, "%" + key + "%")
                                select k;
            return storageSearch;
        }
        public bool LuuK(string name, string note, tbl_kho_sach KSach)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_kho_sach insert = new tbl_kho_sach();
                insert.tenKho = name;
                insert.ghiChu = note;

                db.tbl_kho_saches.InsertOnSubmit(insert);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool SuaK(int id, tbl_kho_sach KSach)
        {
            tbl_kho_sach KSachModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                KSachModel = db.tbl_kho_saches.Where(p => p.maKho == id).SingleOrDefault();
                KSachModel.tenKho = KSach.tenKho;
                KSachModel.ghiChu = KSach.ghiChu;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        public bool XoaK(int id, tbl_kho_sach KSach)
        {
            //tbl_can_bo_thu_vien sachModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_kho_sach delete = db.tbl_kho_saches.Where(p => p.maKho == id).SingleOrDefault();
                db.tbl_kho_saches.DeleteOnSubmit(delete);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
        #endregion
    }
}
