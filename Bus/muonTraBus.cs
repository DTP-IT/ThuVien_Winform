using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Bus
{
    public class muonTraBus
    {
        private static muonTraBus instance;
        public static muonTraBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new muonTraBus();
                return instance;
            }
        }
        private muonTraBus() { }
        #region->Thẻ
        public void View(DataGridView data)
        {
            data.DataSource = muonTraModel.Instance.View();
        }
        public void SearchInt(DataGridView data, int keyInt)
        {
            data.DataSource = muonTraModel.Instance.SearchInt(keyInt);
        }
        public void SearchString(DataGridView data, string key)
        {
            data.DataSource = muonTraModel.Instance.SearchString(key);
        }
        public void SearchDT(DataGridView data, DateTime keyDT)
        {
            data.DataSource = muonTraModel.Instance.SearchDT(keyDT);
        }
        public void cbDocGia(ComboBox combo)
        {
            combo.DataSource = muonTraModel.Instance.cbDocGia();
            combo.ValueMember = "id";
            combo.DisplayMember = "id";
        }
        public bool Them(int maDocGia, DateTime date)
        {
            tbl_muon_tra muonTraBus = new tbl_muon_tra();
            muonTraBus.maThe = maDocGia;
            muonTraBus.ngayTao = date;
            return muonTraModel.Instance.Luu(maDocGia, date, muonTraBus);
        }
        public bool Sua(int id, int maDocGia, DateTime date)
        {
            tbl_muon_tra muonTraBus = new tbl_muon_tra();
            muonTraBus.maThe = maDocGia;
            muonTraBus.ngayTao = date;

            return muonTraModel.Instance.Sua(id, muonTraBus);
        }
        public bool Xoa(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["id"].Value;

            tbl_muon_tra muonTraBus = new tbl_muon_tra();
            muonTraBus.ID = id;

            return muonTraModel.Instance.Xoa(id, muonTraBus);
        }
        #endregion
        #region->Mượn
        public void ViewM(DataGridView data)
        {
            data.DataSource = muonTraModel.Instance.ViewM();
        }
        public void SearchMInt(DataGridView data, int keyInt)
        {
            data.DataSource = muonTraModel.Instance.SearchMInt(keyInt);
        }
        public void SearchMString(DataGridView data, string key)
        {
            data.DataSource = muonTraModel.Instance.SearchMString(key);
        }
        public void SearchMDT(DataGridView data, DateTime keyDT)
        {
            data.DataSource = muonTraModel.Instance.SearchMDT(keyDT);
        }
        public void cbMaTheMuon(ComboBox combo)
        {
            combo.DataSource = muonTraModel.Instance.cbMaTheMuon();
            combo.ValueMember = "id";
            combo.DisplayMember = "id";
        }
        public void cbMaSach(ComboBox combo)
        {
            combo.DataSource = muonTraModel.Instance.cbMaSach();
            combo.ValueMember = "id";
            combo.DisplayMember = "ten";
        }
        public bool ThemM(int maTheMuon, int maSach, int maCanBo, DateTime dateM, DateTime datePT, string tinhTrang, string ghiChu)
        {
            tbl_chi_tiet_muon_tra muonBus = new tbl_chi_tiet_muon_tra();
            muonBus.maCanBoMuon = maCanBo;
            muonBus.maSach = maSach;
            muonBus.muon_tra_id = maTheMuon;
            muonBus.ngayMuon = dateM;
            muonBus.ngayPhaiTra = datePT;
            muonBus.tinhTrangMuon = tinhTrang;
            muonBus.ghiChu = ghiChu;
            return muonTraModel.Instance.LuuM(maTheMuon, maSach, maCanBo, dateM, datePT, tinhTrang, ghiChu, muonBus);
        }
        public bool SuaM(int id, int maTheMuon, int maSach, int maCanBo, DateTime dateM, DateTime datePT, string tinhTrang, string ghiChu)
        {
            tbl_chi_tiet_muon_tra muonBus = new tbl_chi_tiet_muon_tra();
            muonBus.maCanBoMuon = maCanBo;
            muonBus.maSach = maSach;
            muonBus.muon_tra_id = maTheMuon;
            muonBus.ngayMuon = dateM;
            muonBus.ngayPhaiTra = datePT;
            muonBus.tinhTrangMuon = tinhTrang;
            muonBus.ghiChu = ghiChu;

            return muonTraModel.Instance.SuaM(id, muonBus);
        }
        public bool XoaM(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["idM"].Value;

            tbl_chi_tiet_muon_tra muonBus = new tbl_chi_tiet_muon_tra();
            muonBus.id = id;

            return muonTraModel.Instance.XoaM(id, muonBus);
        }
        #endregion
        #region->Trả
        public void ViewTS(DataGridView data)
        {
            data.DataSource = muonTraModel.Instance.ViewTS();
        }
        public void SearchTSInt(DataGridView data, int keyInt, float keyfloat)
        {
            data.DataSource = muonTraModel.Instance.SearchTSInt(keyInt, keyfloat);
        }
        public void SearchTSString(DataGridView data, string key)
        {
            data.DataSource = muonTraModel.Instance.SearchTSString(key);
        }
        public void SearchTSDT(DataGridView data, DateTime keyDT)
        {
            data.DataSource = muonTraModel.Instance.SearchDT(keyDT);
        }
        public bool ThemTS(int id, int maCanBoTra, DateTime dateT, string tinhTrang, float thanhToan, string ghiChu)
        {
            
            tbl_chi_tiet_muon_tra traBus = new tbl_chi_tiet_muon_tra();
            traBus.maCanBoTra = maCanBoTra;
            traBus.ngayTra = dateT;
            traBus.tinhTrangTra = tinhTrang;
            traBus.thanhToan = thanhToan;
            traBus.ghiChu = ghiChu;

            return muonTraModel.Instance.LuuTS(id, traBus);
        }
        public bool SuaTS(int id, int maCanBoTra,DateTime dateT, string tinhTrang,float thanhToan, string ghiChu)
        {
            tbl_chi_tiet_muon_tra traBus = new tbl_chi_tiet_muon_tra();
            traBus.maCanBoTra = maCanBoTra;
            traBus.ngayTra = dateT;
            traBus.tinhTrangTra = tinhTrang;
            traBus.thanhToan = thanhToan;
            traBus.ghiChu = ghiChu;

            return muonTraModel.Instance.SuaTS(id, traBus);
        }
        public bool XoaTS(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["idT"].Value;

            tbl_chi_tiet_muon_tra traBus = new tbl_chi_tiet_muon_tra();
            traBus.id = id;

            return muonTraModel.Instance.XoaTS(id, traBus);
        }
        #endregion
    }
}
