using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class muonTraModel
    {
        private static muonTraModel instance;
        public static muonTraModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new muonTraModel();
                return instance;
            }
        }
        private muonTraModel() { }
        QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
        #region->Thẻ
        public object View()
        {
            var card = from m in db.tbl_muon_tras
                       from r in db.tbl_doc_gias
                       where m.maThe == r.maThe
                       select new
                       {
                           id = m.ID,
                           readerID = m.maThe,
                           readerName = r.hoTen,
                           date = m.ngayTao
                       };
            return card;
        }
        public object SearchInt(int keyint)
        {
            var cardSearch = from m in db.tbl_muon_tras
                               from r in db.tbl_doc_gias
                               where m.maThe == r.maThe
                               where m.ID == keyint || m.maThe == keyint
                               select new
                               {
                                   id = m.ID,
                                   readerID = m.maThe,
                                   readerName = r.hoTen,
                                   date = m.ngayTao
                               };
            return cardSearch;
        }
        public object SearchString(string key)
        {
            var cardSearch = from m in db.tbl_muon_tras
                             from r in db.tbl_doc_gias
                             where m.maThe == r.maThe
                             where SqlMethods.Like(r.hoTen, "%" + key + "%")
                             select new
                             {
                                 id = m.ID,
                                 readerID = m.maThe,
                                 readerName = r.hoTen,
                                 date = m.ngayTao
                             };
            return cardSearch;
        }
        public object SearchDT(DateTime keyDT)
        {
            var cardSearch = from m in db.tbl_muon_tras
                               from r in db.tbl_doc_gias
                               where m.maThe == r.maThe
                               where m.ngayTao == keyDT
                               select new
                               {
                                   id = m.ID,
                                   readerID = m.maThe,
                                   readerName = r.hoTen,
                                   date = m.ngayTao
                               };
            return cardSearch;
        }
        public bool Luu(int maDocGia, DateTime date, tbl_muon_tra muonTra)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_muon_tra insert = new tbl_muon_tra();
                insert.maThe = maDocGia;
                insert.ngayTao = date;

                db.tbl_muon_tras.InsertOnSubmit(insert);
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
        public bool Sua(int id, tbl_muon_tra muonTra)
        {
            tbl_muon_tra muonTraModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                muonTraModel = db.tbl_muon_tras.Where(p => p.ID == id).SingleOrDefault();
                muonTraModel.maThe = muonTra.maThe;
                muonTraModel.ngayTao = muonTra.ngayTao;
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
        public bool Xoa(int id, tbl_muon_tra muonTra)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_muon_tra delete = db.tbl_muon_tras.Where(p => p.ID == id).SingleOrDefault();
                db.tbl_muon_tras.DeleteOnSubmit(delete);
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
        #region->Mượn
        public object ViewM()
        {
            var borrow = from c in db.tbl_chi_tiet_muon_tras
                         from m in db.tbl_muon_tras
                         from r in db.tbl_doc_gias
                         from b in db.tbl_saches
                         from cb in db.tbl_can_bo_thu_viens
                         where c.muon_tra_id == m.ID
                         where m.maThe == r.maThe
                         where c.maSach == b.maSach
                         where c.maCanBoMuon == cb.maCanBo
                         select new
                         {
                             id = c.id,
                             idT = c.muon_tra_id,
                             idS = c.maSach,
                             nameDg = r.hoTen,
                             nameS = b.tenSach,
                             idCb = c.maCanBoMuon,
                             nameCb = cb.tenCanBo,
                             dateM = c.ngayMuon,
                             datePT = c.ngayPhaiTra,
                             statusM = c.tinhTrangMuon,
                             noteM = c.ghiChu
                         };
            return borrow;
        }
        public object SearchMInt(int keyint)
        {
            var brSearch = from c in db.tbl_chi_tiet_muon_tras
                             from m in db.tbl_muon_tras
                             from r in db.tbl_doc_gias
                             from b in db.tbl_saches
                             from cb in db.tbl_can_bo_thu_viens
                             where c.muon_tra_id == m.ID
                             where m.maThe == r.maThe
                             where c.maSach == b.maSach
                             where c.maCanBoMuon == cb.maCanBo
                             where c.id == keyint || c.muon_tra_id == keyint || c.maSach == keyint || c.maCanBoMuon == keyint
                             select new
                             {
                                 id = c.id,
                                 idT = c.muon_tra_id,
                                 idS = c.maSach,
                                 nameDg = r.hoTen,
                                 nameS = b.tenSach,
                                 idCb = c.maCanBoMuon,
                                 nameCb = cb.tenCanBo,
                                 dateM = c.ngayMuon,
                                 datePT = c.ngayPhaiTra,
                                 statusM = c.tinhTrangMuon,
                                 noteM = c.ghiChu
                             };
            return brSearch;
        }
        public object SearchMString(string key)
        {
            var brSearch = from c in db.tbl_chi_tiet_muon_tras
                             from m in db.tbl_muon_tras
                             from r in db.tbl_doc_gias
                             from b in db.tbl_saches
                             from cb in db.tbl_can_bo_thu_viens
                             where c.muon_tra_id == m.ID
                             where m.maThe == r.maThe
                             where c.maSach == b.maSach
                             where c.maCanBoMuon == cb.maCanBo
                             where SqlMethods.Like(r.hoTen, "%" + key + "%") ||
                             SqlMethods.Like(b.tenSach, "%" + key + "%") ||
                             SqlMethods.Like(cb.tenCanBo, "%" + key + "%") ||
                             SqlMethods.Like(c.tinhTrangMuon, "%" + key + "%") ||
                             SqlMethods.Like(c.ghiChu, "%" + key + "%")
                             select new
                             {
                                 id = c.id,
                                 idT = c.muon_tra_id,
                                 idS = c.maSach,
                                 nameDg = r.hoTen,
                                 nameS = b.tenSach,
                                 idCb = c.maCanBoMuon,
                                 nameCb = cb.tenCanBo,
                                 dateM = c.ngayMuon,
                                 datePT = c.ngayPhaiTra,
                                 statusM = c.tinhTrangMuon,
                                 noteM = c.ghiChu
                             };
            return brSearch;
        }
        public object SearchMDT(DateTime keyDT)
        {
            var brSearch = from c in db.tbl_chi_tiet_muon_tras
                             from m in db.tbl_muon_tras
                             from r in db.tbl_doc_gias
                             from b in db.tbl_saches
                             from cb in db.tbl_can_bo_thu_viens
                             where c.muon_tra_id == m.ID
                             where m.maThe == r.maThe
                             where c.maSach == b.maSach
                             where c.maCanBoMuon == cb.maCanBo
                             where c.ngayMuon == keyDT || c.ngayPhaiTra == keyDT
                             select new
                             {
                                 id = c.id,
                                 idT = c.muon_tra_id,
                                 idS = c.maSach,
                                 nameDg = r.hoTen,
                                 nameS = b.tenSach,
                                 idCb = c.maCanBoMuon,
                                 nameCb = cb.tenCanBo,
                                 dateM = c.ngayMuon,
                                 datePT = c.ngayPhaiTra,
                                 statusM = c.tinhTrangMuon,
                                 noteM = c.ghiChu
                             };
            return brSearch;
        }
        public object cbMaTheMuon()
        {
            var result = from m in db.tbl_muon_tras
                         select new
                         {
                             id = m.ID
                         };
            return result;
        }
        public object cbMaSach()
        {
            var result = from s in db.tbl_saches
                         select new
                         {
                             id = s.maSach,
                             ten = s.tenSach
                         };
           
            return result;
        }
        public bool LuuM(int maTheMuon, int maSach, int maCanBo, DateTime dateM, DateTime datePT, string tinhTrang, string ghiChu, tbl_chi_tiet_muon_tra muon) {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_chi_tiet_muon_tra insert = new tbl_chi_tiet_muon_tra();
                insert.muon_tra_id = maTheMuon;
                insert.maSach = maSach;
                insert.maCanBoMuon = maCanBo;
                insert.ngayMuon = dateM;
                insert.ngayPhaiTra = datePT;
                insert.tinhTrangMuon = tinhTrang;
                insert.ghiChu = ghiChu;

                db.tbl_chi_tiet_muon_tras.InsertOnSubmit(insert);
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
        public bool SuaM(int id, tbl_chi_tiet_muon_tra muon)
        {
            tbl_chi_tiet_muon_tra muonModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                muonModel = db.tbl_chi_tiet_muon_tras.Where(p => p.id == id).SingleOrDefault();
                muonModel.muon_tra_id = muon.muon_tra_id;
                muonModel.maSach = muon.maSach;
                muonModel.maCanBoMuon = muon.maCanBoMuon;
                muonModel.ngayMuon = muon.ngayMuon;
                muonModel.ngayPhaiTra = muon.ngayPhaiTra;
                muonModel.tinhTrangMuon = muon.tinhTrangMuon;
                muonModel.ghiChu = muon.ghiChu;
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
        public bool XoaM(int id, tbl_chi_tiet_muon_tra muon)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_chi_tiet_muon_tra delete = db.tbl_chi_tiet_muon_tras.Where(p => p.id == id).SingleOrDefault();
                db.tbl_chi_tiet_muon_tras.DeleteOnSubmit(delete);
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
        #region->Trả
        public object ViewTS()
        {
            var returnBook = from c in db.tbl_chi_tiet_muon_tras
                       from m in db.tbl_muon_tras
                       from r in db.tbl_doc_gias
                       from b in db.tbl_saches
                       from cb in db.tbl_can_bo_thu_viens
                       where c.muon_tra_id == m.ID
                       where m.maThe == r.maThe
                       where c.maSach == b.maSach
                       where c.maCanBoMuon == cb.maCanBo
                       select new
                       {
                           id = c.id,
                           idT = c.muon_tra_id,
                           idS = c.maSach,
                           nameDg = r.hoTen,
                           nameS = b.tenSach,
                           idCb = c.maCanBoTra,
                           nameCb = cb.tenCanBo,
                           datePT = c.ngayPhaiTra,
                           dateT = c.ngayTra,
                           statusT = c.tinhTrangTra,
                           price = c.thanhToan,
                           noteT = c.ghiChu
                       };
            return returnBook;
        }
        public object SearchTSInt(int keyint, float keyfloat)
        {
            var reSearch = from c in db.tbl_chi_tiet_muon_tras
                             from m in db.tbl_muon_tras
                             from r in db.tbl_doc_gias
                             from b in db.tbl_saches
                             from cb in db.tbl_can_bo_thu_viens
                             where c.muon_tra_id == m.ID
                             where m.maThe == r.maThe
                             where c.maSach == b.maSach
                             where c.maCanBoMuon == cb.maCanBo
                             where c.id == keyint || c.muon_tra_id == keyint || c.maSach == keyint || c.maCanBoTra == keyint || c.thanhToan == keyfloat
                             select new
                             {
                                 id = c.id,
                                 idT = c.muon_tra_id,
                                 idS = c.maSach,
                                 nameDg = r.hoTen,
                                 nameS = b.tenSach,
                                 idCb = c.maCanBoTra,
                                 nameCb = cb.tenCanBo,
                                 datePT = c.ngayPhaiTra,
                                 dateT = c.ngayTra,
                                 statusT = c.tinhTrangTra,
                                 price = c.thanhToan,
                                 noteT = c.ghiChu
                             };
            return reSearch;
        }
        public object SearchTSString(string key)
        {
            var reSearch = from c in db.tbl_chi_tiet_muon_tras
                           from m in db.tbl_muon_tras
                           from r in db.tbl_doc_gias
                           from b in db.tbl_saches
                           from cb in db.tbl_can_bo_thu_viens
                           where c.muon_tra_id == m.ID
                           where m.maThe == r.maThe
                           where c.maSach == b.maSach
                           where c.maCanBoMuon == cb.maCanBo
                           where SqlMethods.Like(r.hoTen, "%" + key + "%") ||
                           SqlMethods.Like(b.tenSach, "%" + key + "%") ||
                           SqlMethods.Like(cb.tenCanBo, "%" + key + "%") ||
                           SqlMethods.Like(c.tinhTrangTra, "%" + key + "%") ||
                           SqlMethods.Like(c.ghiChu, "%" + key + "%")
                           select new
                           {
                               id = c.id,
                               idT = c.muon_tra_id,
                               idS = c.maSach,
                               nameDg = r.hoTen,
                               nameS = b.tenSach,
                               idCb = c.maCanBoTra,
                               nameCb = cb.tenCanBo,
                               datePT = c.ngayPhaiTra,
                               dateT = c.ngayTra,
                               statusT = c.tinhTrangTra,
                               price = c.thanhToan,
                               noteT = c.ghiChu
                           };
            return reSearch;
        }
        public object SearchTSDT(DateTime keyDT)
        {
            var reSearch = from c in db.tbl_chi_tiet_muon_tras
                             from m in db.tbl_muon_tras
                             from r in db.tbl_doc_gias
                             from b in db.tbl_saches
                             from cb in db.tbl_can_bo_thu_viens
                             where c.muon_tra_id == m.ID
                             where m.maThe == r.maThe
                             where c.maSach == b.maSach
                             where c.maCanBoMuon == cb.maCanBo
                             where c.ngayPhaiTra == keyDT || c.ngayTra == keyDT
                             select new
                             {
                                 id = c.id,
                                 idT = c.muon_tra_id,
                                 idS = c.maSach,
                                 nameDg = r.hoTen,
                                 nameS = b.tenSach,
                                 idCb = c.maCanBoTra,
                                 nameCb = cb.tenCanBo,
                                 datePT = c.ngayPhaiTra,
                                 dateT = c.ngayTra,
                                 statusT = c.tinhTrangTra,
                                 price = c.thanhToan,
                                 noteT = c.ghiChu
                             };
            return reSearch;
        }
        public object cbDocGia()
        {
            var result = from r in db.tbl_doc_gias
                         select new
                         {
                             id = r.maThe,
                             name = r.hoTen
                         };
            return result;
        }
        public bool LuuTS(int id, tbl_chi_tiet_muon_tra tra)
        {
            tbl_chi_tiet_muon_tra traModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                traModel = db.tbl_chi_tiet_muon_tras.Where(p => p.id == id).SingleOrDefault();
                traModel.maCanBoTra = tra.maCanBoTra;
                traModel.ngayTra = tra.ngayTra;
                traModel.tinhTrangTra = tra.tinhTrangTra;
                traModel.thanhToan = tra.thanhToan;
                traModel.ghiChu = tra.ghiChu;
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
        public bool SuaTS(int id, tbl_chi_tiet_muon_tra tra)
        {
            tbl_chi_tiet_muon_tra traModel;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                traModel = db.tbl_chi_tiet_muon_tras.Where(p => p.id == id).SingleOrDefault();
                traModel.maCanBoTra = tra.maCanBoTra;
                traModel.ngayTra = tra.ngayTra;
                traModel.tinhTrangTra = tra.tinhTrangTra;
                traModel.thanhToan = tra.thanhToan;
                traModel.ghiChu = tra.ghiChu;
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
        public bool XoaTS(int id, tbl_chi_tiet_muon_tra tra)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                tbl_chi_tiet_muon_tra delete = db.tbl_chi_tiet_muon_tras.Where(p => p.id == id).SingleOrDefault();
                db.tbl_chi_tiet_muon_tras.DeleteOnSubmit(delete);
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
