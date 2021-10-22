using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class homeModel
    {
        private static homeModel instance;
        public static homeModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new homeModel();
                return instance;
            }
        }
        private homeModel() { }

        //public bool Sua(int id, tbl_can_bo_thu_vien nhanVien)
        //{
        //    tbl_can_bo_thu_vien nhanVienModel;
        //    using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
        //    {
        //        nhanVienModel = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
        //        nhanVienModel.maCanBo = nhanVien.maCanBo;
        //        nhanVienModel.tenCanBo = nhanVien.tenCanBo;
        //        nhanVienModel.gioiTinh = nhanVien.gioiTinh;
        //        nhanVienModel.namSinh = nhanVien.namSinh;
        //        nhanVienModel.diaChi = nhanVien.diaChi;
        //        nhanVienModel.phone = nhanVien.phone;
        //        nhanVienModel.email = nhanVien.email;
        //        nhanVienModel.quenHan = nhanVien.quenHan;
        //        nhanVienModel.matKhau = nhanVien.matKhau;
        //        try
        //        {
        //            db.SubmitChanges();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }

        //    }
        //    return false;
        //}
        //public bool Luu(string name, string gender, DateTime doB, string address, string phone, string email, string power, tbl_can_bo_thu_vien nhanVien)
        //{
        //    using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
        //    {
        //        tbl_can_bo_thu_vien insert = new tbl_can_bo_thu_vien();
        //        insert.tenCanBo = name;
        //        insert.gioiTinh = gender;
        //        insert.namSinh = doB;
        //        insert.diaChi = address;
        //        insert.phone = phone;
        //        insert.email = email;
        //        insert.quenHan = power;

        //        db.tbl_can_bo_thu_viens.InsertOnSubmit(insert);
        //        try
        //        {
        //            db.SubmitChanges();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}
        //public bool Xoa(int id, tbl_can_bo_thu_vien nhanVien)
        //{
        //    tbl_can_bo_thu_vien nhanVienModel;
        //    using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
        //    {
        //        tbl_can_bo_thu_vien delete = db.tbl_can_bo_thu_viens.Where(p => p.maCanBo == id).SingleOrDefault();
        //        db.tbl_can_bo_thu_viens.DeleteOnSubmit(delete);
        //        try
        //        {
        //            db.SubmitChanges();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }

        //    }
        //    return false;
        //}
    }
}
