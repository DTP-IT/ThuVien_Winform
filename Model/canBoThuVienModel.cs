using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    public class canBoThuVienModel
    {
        private static canBoThuVienModel instance;
        public static canBoThuVienModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new canBoThuVienModel();
                return instance;
            }
        }
        private canBoThuVienModel() { }
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        #region->Can bo
        public object View()
        {
            var member = from m in db.tbl_can_bo_thu_viens
                         select new
                         {
                             id = m.maCanBo,
                             name = m.tenCanBo,
                             gioiTinh = m.gioiTinh,
                             ngaySinh = m.namSinh,
                             diaChi = m.diaChi,
                             sdt = m.phone,
                             email = m.email,
                         };
            return member;
        }
        public object SearchInt(int keyint)
        {
            var memberSearch = from m in db.tbl_can_bo_thu_viens
                              where m.maCanBo == keyint || SqlMethods.Like(m.phone, "%" + keyint + "%")
                              select new
                              {
                                  id = m.maCanBo,
                                  name = m.tenCanBo,
                                  gioiTinh = m.gioiTinh,
                                  ngaySinh = m.namSinh,
                                  diaChi = m.diaChi,
                                  sdt = m.phone,
                                  email = m.email,
                              };
            return memberSearch;
        }
        public object SearchString(string key)
        {
            var memberSearch = from m in db.tbl_can_bo_thu_viens
                              where SqlMethods.Like(m.tenCanBo, "%" + key + "%") ||
                              SqlMethods.Like(m.gioiTinh, "%" + key + "%") ||
                              SqlMethods.Like(m.diaChi, "%" + key + "%") ||
                              SqlMethods.Like(m.phone, "%" + key + "%") ||
                              SqlMethods.Like(m.email, "%" + key + "%")
                              select new
                              {
                                  id = m.maCanBo,
                                  name = m.tenCanBo,
                                  gioiTinh = m.gioiTinh,
                                  ngaySinh = m.namSinh,
                                  diaChi = m.diaChi,
                                  sdt = m.phone,
                                  email = m.email,
                              };
            return memberSearch;
        }
        public object SearchDT(DateTime keyDT)
        {
            var memberSearch = from m in db.tbl_can_bo_thu_viens
                              where m.namSinh == keyDT
                              select new
                              {
                                  id = m.maCanBo,
                                  name = m.tenCanBo,
                                  gioiTinh = m.gioiTinh,
                                  ngaySinh = m.namSinh,
                                  diaChi = m.diaChi,
                                  sdt = m.phone,
                                  email = m.email,
                              };
            return memberSearch;
        }
        public bool Sua(int id, tbl_can_bo_thu_vien nhanVien)
        {
            tbl_can_bo_thu_vien nhanVienModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                nhanVienModel = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
                nhanVienModel.tenCanBo = nhanVien.tenCanBo;
                nhanVienModel.gioiTinh = nhanVien.gioiTinh;
                nhanVienModel.namSinh = nhanVien.namSinh;
                nhanVienModel.diaChi = nhanVien.diaChi;
                nhanVienModel.phone = nhanVien.phone;
                nhanVienModel.email = nhanVien.email;
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
        public bool Luu(string name, string gender, DateTime doB, string address,  string phone, string email, tbl_can_bo_thu_vien nhanVien)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_can_bo_thu_vien insert = new tbl_can_bo_thu_vien();
                insert.tenCanBo = name;
                insert.gioiTinh = gender;
                insert.namSinh = doB;
                insert.diaChi = address;
                insert.phone = phone;
                insert.email = email;

                db.tbl_can_bo_thu_viens.InsertOnSubmit(insert);
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
        public bool Xoa(int id, tbl_can_bo_thu_vien nhanVien)
        {
            tbl_can_bo_thu_vien nhanVienModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_can_bo_thu_vien delete = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
                db.tbl_can_bo_thu_viens.DeleteOnSubmit(delete);
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
        #region->Tai khoan
        public object ViewAccount()
        {
            var account = from m in db.tbl_can_bo_thu_viens
                          select new
                          {
                              id = m.maCanBo,
                              name = m.tenCanBo,
                              email = m.email,
                              matKhau = m.matKhau
                          };
            return account;
        }
        public object SearchAccountInt(int keyint)
        {
            var accountSearch = from m in db.tbl_can_bo_thu_viens
                                where m.maCanBo == keyint
                                select new
                                {
                                    id = m.maCanBo,
                                    name = m.tenCanBo,
                                    email = m.email,
                                    matKhau = m.matKhau
                                };
            return accountSearch;
        }
        public object SearchAccountString(string key)
        {
            var accountSearch = from m in db.tbl_can_bo_thu_viens
                                where SqlMethods.Like(m.tenCanBo, "%" + key + "%") ||
                                SqlMethods.Like(m.email, "%" + key + "%") ||
                                SqlMethods.Like(m.matKhau, "%" + key + "%")
                                select new
                                {
                                    id = m.maCanBo,
                                    name = m.tenCanBo,
                                    email = m.email,
                                    matKhau = m.matKhau
                                };
            return accountSearch;
        }
        public bool LuuAcount(string name, string email, string passwd, tbl_can_bo_thu_vien account)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_can_bo_thu_vien insert = new tbl_can_bo_thu_vien();
                insert.tenCanBo = name;
                insert.email = email;
                insert.matKhau = passwd;

                db.tbl_can_bo_thu_viens.InsertOnSubmit(insert);
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
        public bool SuaAccount(int id, tbl_can_bo_thu_vien account)
        {
            tbl_can_bo_thu_vien accountModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                accountModel = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
                accountModel.maCanBo = account.maCanBo;
                accountModel.tenCanBo = account.tenCanBo;
                accountModel.email = account.email;
                accountModel.matKhau = account.matKhau;
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
        public bool XoaAccount(int id, tbl_can_bo_thu_vien account)
        {
            tbl_can_bo_thu_vien accountModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_can_bo_thu_vien delete = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
                db.tbl_can_bo_thu_viens.DeleteOnSubmit(delete);
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
        #region->quyen
        public object ViewPower()
        {
            var power = from m in db.tbl_can_bo_thu_viens
                        select new
                        {
                            id = m.maCanBo,
                            name = m.tenCanBo,
                            email = m.email,
                            chucVu = m.quenHan
                        };
            return power;
        }
        public object SearchPowerInt(int keyint)
        {
            var powerSearch = from m in db.tbl_can_bo_thu_viens
                              where m.maCanBo == keyint
                              select new
                              {
                                  id = m.maCanBo,
                                  name = m.tenCanBo,
                                  email = m.email,
                                  chucVu = m.quenHan
                              };
            return powerSearch;
        }
        public object SearchPowerString(string key)
        {
            var powerSearch = from m in db.tbl_can_bo_thu_viens
                              where SqlMethods.Like(m.tenCanBo, "%" + key + "%") ||
                              SqlMethods.Like(m.email, "%" + key + "%") ||
                              SqlMethods.Like(m.quenHan, "%" + key + "%")
                              select new
                              {
                                  id = m.maCanBo,
                                  name = m.tenCanBo,
                                  email = m.email,
                                  chucVu = m.quenHan
                              };
            return powerSearch;
        }
        public bool LuuPower(string name, string email, string lever, tbl_can_bo_thu_vien power)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_can_bo_thu_vien insert = new tbl_can_bo_thu_vien();
                insert.tenCanBo = name;
                insert.email = email;
                insert.quenHan = lever;

                db.tbl_can_bo_thu_viens.InsertOnSubmit(insert);
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
        public bool SuaPower(int id, tbl_can_bo_thu_vien power)
        {
            tbl_can_bo_thu_vien powerModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                powerModel = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
                powerModel.maCanBo = power.maCanBo;
                powerModel.tenCanBo = power.tenCanBo;
                powerModel.email = power.email;
                powerModel.quenHan = power.matKhau;
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
        public bool XoaPower(int id, tbl_can_bo_thu_vien power)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_can_bo_thu_vien delete = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
                db.tbl_can_bo_thu_viens.DeleteOnSubmit(delete);
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
