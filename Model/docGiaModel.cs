using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class docGiaModel
    {
        private static docGiaModel instance;
        public static docGiaModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new docGiaModel();
                return instance;
            }
        }
        private docGiaModel() { }

        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        public object View() 
        {
           var reader = from r in db.tbl_doc_gias
                        from c in db.tbl_lops
                        from f in db.tbl_khoas
                        where r.maKhoa == f.maKhoa
                        where r.maLop == c.maLop
                        select new
                        {
                            id = r.maThe,
                            classID = r.maLop,
                            className = c.tenLop,
                            facultyID = r.maKhoa,
                            facultyName = f.tenKhoa,
                            name = r.hoTen,
                            dOB = r.ngaySinh,
                            gender = r.gioiTinh,
                            address = r.diaChi,
                            phone = r.phone,
                            email = r.email
                        };
            return reader;
        }
        public object SearchInt(int keyInt)
        {
            var readerSearch = from r in db.tbl_doc_gias
                               from c in db.tbl_lops
                               from f in db.tbl_khoas
                               where r.maKhoa == f.maKhoa
                               where r.maLop == c.maLop
                               where r.maThe == keyInt ||
                               SqlMethods.Like(r.phone, "%" + keyInt + "%")
                               select new
                               {
                                   id = r.maThe,
                                   classID = r.maLop,
                                   className = c.tenLop,
                                   facultyID = r.maKhoa,
                                   facultyName = f.tenKhoa,
                                   name = r.hoTen,
                                   dOB = r.ngaySinh,
                                   gender = r.gioiTinh,
                                   address = r.diaChi,
                                   phone = r.phone,
                                   email = r.email
                               };
            return readerSearch;
        }
        public object SearchString(string key)
        {
            var readerSearch = from r in db.tbl_doc_gias
                               from c in db.tbl_lops
                               from f in db.tbl_khoas
                               where r.maKhoa == f.maKhoa
                               where r.maLop == c.maLop
                               where SqlMethods.Like(r.hoTen, "%" + key + "%") ||
                               SqlMethods.Like(r.gioiTinh, "%" + key + "%") ||
                               SqlMethods.Like(r.phone, "%" + key + "%") ||
                               SqlMethods.Like(r.email, "%" + key + "%") ||
                               SqlMethods.Like(r.diaChi, "%" + key + "%") ||
                               SqlMethods.Like(f.tenKhoa, "%" + key + "%") ||
                               SqlMethods.Like(c.tenLop, "%" + key + "%")
                               select new
                               {
                                   id = r.maThe,
                                   classID = r.maLop,
                                   className = c.tenLop,
                                   facultyID = r.maKhoa,
                                   facultyName = f.tenKhoa,
                                   name = r.hoTen,
                                   dOB = r.ngaySinh,
                                   gender = r.gioiTinh,
                                   address = r.diaChi,
                                   phone = r.phone,
                                   email = r.email
                               };
            return readerSearch;
        }
        public object SearchDT(DateTime keyDT)
        {
            var readerSearch = from r in db.tbl_doc_gias
                               from c in db.tbl_lops
                               from f in db.tbl_khoas
                               where r.maKhoa == f.maKhoa
                               where r.maLop == c.maLop
                               where r.ngaySinh == keyDT
                               select new
                               {
                                   id = r.maThe,
                                   classID = r.maLop,
                                   className = c.tenLop,
                                   facultyID = r.maKhoa,
                                   facultyName = f.tenKhoa,
                                   name = r.hoTen,
                                   dOB = r.ngaySinh,
                                   gender = r.gioiTinh,
                                   address = r.diaChi,
                                   phone = r.phone,
                                   email = r.email
                               };
            return readerSearch;
        }
        public object loadClass(int facultyID)
        {
            var result = from c in db.tbl_lops
                         where c.maKhoa == facultyID
                         select new
                         {
                             maLop = c.maLop,
                             tenLop = c.tenLop
                         };
            return result;
        }
        public bool Sua(int id, tbl_doc_gia docGiaBus)
        {
            tbl_doc_gia docGiaModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                docGiaModel = db.tbl_doc_gias.Where(p => p.maThe == id).SingleOrDefault();
                docGiaModel.maKhoa = docGiaBus.maKhoa;
                docGiaModel.maLop = docGiaBus.maLop;
                docGiaModel.hoTen = docGiaBus.hoTen;
                docGiaModel.ngaySinh = docGiaBus.ngaySinh;
                docGiaModel.gioiTinh = docGiaBus.gioiTinh;
                docGiaModel.diaChi = docGiaBus.diaChi;
                docGiaModel.phone = docGiaBus.phone;
                docGiaModel.email = docGiaBus.email;
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
        public bool Luu(int faculty, int classID, string name,  DateTime doB, string gender, string address, string phone, string email, tbl_doc_gia docGia)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_doc_gia insert = new tbl_doc_gia();
                insert.maKhoa = faculty;
                insert.maLop = classID;
                insert.hoTen = name;
                insert.ngaySinh = doB;
                insert.gioiTinh = gender;
                insert.diaChi = address;
                insert.phone = phone;
                insert.email = email;

                db.tbl_doc_gias.InsertOnSubmit(insert);
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
        public bool Xoa(int id, tbl_doc_gia docGia)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_doc_gia delete = db.tbl_doc_gias.Where(p => p.maThe == id).SingleOrDefault();
                db.tbl_doc_gias.DeleteOnSubmit(delete);
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
    }
}
