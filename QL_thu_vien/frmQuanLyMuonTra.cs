using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
namespace QL_thu_vien
{
    public partial class frmQuanLyMuonTra : Form
    {
        private float thanhToan = 0;
        public frmQuanLyMuonTra()
        {
            
            InitializeComponent();
        }

        private void frmQuanLyMuonTra_Load(object sender, EventArgs e)
        {
            View();
            ViewM();
            ViewT();
        }
        #region->Thẻ
        private void View()
        {
            muonTraBus.Instance.View(dGVMuonTra);
        }
        private void cbDocGia_Click(object sender, EventArgs e)
        {
            muonTraBus.Instance.cbDocGia(cbDocGia);
        }

        private void dGVMuonTra_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVMuonTra.CurrentCell != null)
            {
                int i = dGVMuonTra.CurrentCell.RowIndex;
                txtID.Texts = dGVMuonTra.Rows[i].Cells["id"].Value.ToString();
                cbDocGia.DataSource = dGVMuonTra.DataSource;
                cbDocGia.ValueMember = "readerID";
                cbDocGia.DisplayMember = "readerID";
                dtNgayTao.Value = (DateTime)(DateTime?)(DateTime?)dGVMuonTra.Rows[i].Cells["date"].Value;
            }
            
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            dtNgayTao.Enabled = true;
            cbDocGia.Enabled = true;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            dtNgayTao.Enabled = true;
            cbDocGia.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thông tin bị xóa sẽ không thể khôi phục. Tiếp tục?", "Thẻ mượn", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (canBoThuVienBus.Instance.Xoa(dGVMuonTra))
                {
                    MessageBox.Show("Xóa thành công", "Thẻ mượn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    View();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Thẻ mượn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            dtNgayTao.Enabled = false;
            cbDocGia.Enabled = false;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Texts);
            int maDocGia = int.Parse(cbDocGia.SelectedValue.ToString());
            DateTime date = dtNgayTao.Value;
            if (btnSua.Enabled == false)
            {
                if (muonTraBus.Instance.Them(maDocGia, date))
                {
                    MessageBox.Show("Thêm thành công", "Thẻ mượn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    View();
                    txtID.Enabled = false;
                    dtNgayTao.Enabled = false;
                    cbDocGia.Enabled = false;

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Thẻ mượn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnThem.Enabled == false)
                {
                    if (muonTraBus.Instance.Sua(id, maDocGia, date))
                    {
                        MessageBox.Show("Sửa thành công", "Thẻ mượn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        View();
                        txtID.Enabled = false;
                        dtNgayTao.Enabled = false;
                        cbDocGia.Enabled = false;

                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void search()
        {
            try
            {
                int keyint = int.Parse(txtSearch.Texts);
                muonTraBus.Instance.SearchInt(dGVMuonTra, keyint);
            }
            catch
            {
                try
                {
                    DateTime keyDT = DateTime.ParseExact(txtSearch.Texts, "yyyy/dd/MM", System.Globalization.CultureInfo.InvariantCulture);
                    muonTraBus.Instance.SearchDT(dGVMuonTra, keyDT);
                }
                catch
                {
                    string key = txtSearch.Texts;
                    muonTraBus.Instance.SearchString(dGVMuonTra, key);
                }
            }
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        private void txtSearch_MouseEnter(object sender, EventArgs e)
        {
            search();
        }
        #endregion
        #region->Mượn
        private void inputOff()
        {
            txtIDMuon.Enabled = false;
            cbMaTheMuon.Enabled = false;
            cbMaSach.Enabled = false;
            txtMaCanBoMuon.Enabled = false;
            dtNgayMuon.Enabled = false;
            dtHanTra.Enabled = false;
            txtTinhTrangMuon.Enabled = false;
            txtGhiChuMuon.Enabled = false;
        }
        private void inputOn()
        {
            txtIDMuon.Enabled = true;
            cbMaTheMuon.Enabled = true;
            cbMaSach.Enabled = true;
            txtMaCanBoMuon.Enabled = true;
            dtNgayMuon.Enabled = true;
            dtHanTra.Enabled = true;
            txtTinhTrangMuon.Enabled = true;
            txtGhiChuMuon.Enabled = true;
        }
        private void ViewM()
        {
            muonTraBus.Instance.ViewM(dGVMuon);
        }
        private void dGVMuon_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVMuon.CurrentCell != null)
            {
                int i = dGVMuon.CurrentCell.RowIndex;
                txtIDMuon.Texts = dGVMuon.Rows[i].Cells["idM"].Value.ToString();
                txtMaCanBoMuon.Texts = dGVMuon.Rows[i].Cells["idCb"].Value.ToString();
                txtTinhTrangMuon.Texts = (string)dGVMuon.Rows[i].Cells["statusM"].Value ?? null;
                txtGhiChuMuon.Texts = (string)dGVMuon.Rows[i].Cells["noteM"].Value ?? null;
                cbMaTheMuon.DataSource = dGVMuon.DataSource;
                cbMaTheMuon.ValueMember = "idT";
                cbMaTheMuon.DisplayMember = "idT";
                cbMaSach.DataSource = dGVMuon.DataSource;
                cbMaSach.ValueMember = "idS";
                cbMaSach.DisplayMember = "nameS";
                dtNgayMuon.Value = (DateTime)(DateTime?)dGVMuon.Rows[i].Cells["dateM"].Value;
                dtHanTra.Value = (DateTime)(DateTime?)dGVMuon.Rows[i].Cells["datePT"].Value;
            }
        }

        private void cbMaTheMuon_Click(object sender, EventArgs e)
        {
            muonTraBus.Instance.cbMaTheMuon(cbMaTheMuon);
        }

        private void cbMaSach_Click(object sender, EventArgs e)
        {
            muonTraBus.Instance.cbMaSach(cbMaSach);
        }

        private void btnMThem_Click(object sender, EventArgs e)
        {
            inputOn();
            txtIDMuon.Enabled = false;
            btnMSua.Enabled = false;
            btnMXoa.Enabled = false;
            btnMLuu.Enabled = true;
            btnMHuy.Enabled = true;
        }

        private void btnMSua_Click(object sender, EventArgs e)
        {
            inputOn();
            txtIDMuon.Enabled = false;
            btnMThem.Enabled = false;
            btnMXoa.Enabled = false;
            btnMLuu.Enabled = true;
            btnMHuy.Enabled = true;
        }

        private void btnMXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Toàn bộ thông tin của người được chọn sẽ bị xóa và không thể khôi phục. Tiếp tục?", "Mượn sách", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (muonTraBus.Instance.XoaM(dGVMuon))
                {
                    MessageBox.Show("Xóa thành công", "Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewM();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMHuy_Click(object sender, EventArgs e)
        {
            btnMSua.Enabled = true;
            btnMXoa.Enabled = true;
            btnMThem.Enabled = true;
            btnMLuu.Enabled = false;

            inputOff();
        }

        private void btnMLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDMuon.Texts);
            int maCanBo = int.Parse(txtMaCanBoMuon.Texts);
            string tinhTrang = txtTinhTrangMuon.Texts;
            string ghiChu = txtGhiChuMuon.Texts;
            int maTheMuon = int.Parse(cbMaTheMuon.SelectedValue.ToString());
            int maSach = int.Parse(cbMaSach.SelectedValue.ToString());
            DateTime dateM = dtNgayMuon.Value;
            DateTime datePT = dtHanTra.Value;
            if (btnMSua.Enabled == false)
            {
                if (muonTraBus.Instance.ThemM(maTheMuon, maSach, maCanBo, dateM, datePT, tinhTrang, ghiChu))
                {
                    MessageBox.Show("Thêm thành công", "Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewM();
                    inputOff();
                    btnMSua.Enabled = true;
                    btnMXoa.Enabled = true;
                    btnMLuu.Enabled = false;
                    btnMHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnMThem.Enabled == false)
                {
                    if (muonTraBus.Instance.SuaM(id, maTheMuon, maSach, maCanBo, dateM, datePT, tinhTrang, ghiChu))
                    {
                        MessageBox.Show("Sửa thành công", "Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewM();
                        inputOff();
                        btnMSua.Enabled = true;
                        btnMXoa.Enabled = true;
                        btnMLuu.Enabled = false;
                        btnMHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void searchM()
        {
            try
            {
                int keyint = int.Parse(txtMSearch.Texts);
                muonTraBus.Instance.SearchMInt(dGVMuon, keyint);
            }
            catch
            {
                try
                {
                    DateTime keyDT = DateTime.ParseExact(txtMSearch.Texts, "yyyy/dd/MM", System.Globalization.CultureInfo.InvariantCulture);
                    muonTraBus.Instance.SearchMDT(dGVMuon, keyDT);
                }
                catch
                {
                    string key = txtMSearch.Texts;
                    muonTraBus.Instance.SearchMString(dGVMuon, key);
                }
            }
        }
        private void btnMSearch_Click(object sender, EventArgs e)
        {
            searchM();
        }
        private void txtMSearch_MouseEnter(object sender, EventArgs e)
        {
            searchM();
        }
        #endregion
        #region->Trả
        private void inputTOn()
        {
            txtIDTra.Enabled = false;
            cbMaTheMuonTra.Enabled = true;
            cbMaSachTra.Enabled = true;
            cbCanBoTra.Enabled = true;
            dtNgayTra.Enabled = true;
            txtTinhTrangTra.Enabled = true;
            txtThanhToan.Enabled = true;
            txtGhiChuTra.Enabled = true;
        }
        private void inputTOff()
        {
            txtIDTra.Enabled = false;
            cbMaTheMuonTra.Enabled = false;
            cbMaSachTra.Enabled = false;
            cbCanBoTra.Enabled = false;
            dtNgayTra.Enabled = false;
            txtTinhTrangTra.Enabled = false;
            txtThanhToan.Enabled = false;
            txtGhiChuTra.Enabled = false;
        }
        private void ViewT()
        {
            muonTraBus.Instance.ViewTS(dGVTra);
        }
        private void dGVTra_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVTra.CurrentCell != null)
            {
                int i = dGVTra.CurrentCell.RowIndex;
                txtIDTra.Texts = dGVTra.Rows[i].Cells["idT"].Value.ToString();
                txtTinhTrangTra.Texts = (string)dGVTra.Rows[i].Cells["statusT"].Value ?? null;
                txtThanhToan.Texts = (string)dGVTra.Rows[i].Cells["noteT"].Value ?? null;
                txtGhiChuTra.Texts = (string)dGVTra.Rows[i].Cells["noteT"].Value ?? null;
                cbCanBoTra.DataSource = dGVTra.DataSource;
                cbCanBoTra.ValueMember = "idCb";
                cbCanBoTra.DisplayMember = "idCb";
                cbMaTheMuonTra.DataSource = dGVTra.DataSource;
                cbMaTheMuonTra.ValueMember = "idT";
                cbMaTheMuonTra.DisplayMember = "idT";
                cbMaSachTra.DataSource = dGVTra.DataSource;
                cbMaSachTra.ValueMember = "idS";
                cbMaSachTra.DisplayMember = "nameS";
                try
                {
                    dtNgayTra.Value = (DateTime)(DateTime?)dGVTra.Rows[i].Cells["dateTT"].Value;
                }
                catch
                {
                    dtNgayTra.Value = dtNgayTra.MinDate;
                }
            }

        }

        private void cbMaTheMuonTra_Click(object sender, EventArgs e)
        {
            muonTraBus.Instance.cbMaTheMuon(cbMaTheMuon);
        }

        private void cbCanBoTra_Click(object sender, EventArgs e)
        {
            muonTraBus.Instance.cbDocGia(cbDocGia);
        }

        private void btnTSThem_Click(object sender, EventArgs e)
        {
            inputTOn();
            btnTSSua.Enabled = false;
            btnTSXoa.Enabled = false;
            btnTSLuu.Enabled = true;
            btnTSHuy.Enabled = true;
        }

        private void btnTSSua_Click(object sender, EventArgs e)
        {
            inputTOn();
            txtIDTra.Enabled = false;
            btnTSThem.Enabled = false;
            btnTSXoa.Enabled = false;
            btnTSLuu.Enabled = true;
            btnTSHuy.Enabled = true;
        }

        private void btnTSXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Toàn bộ thông tin của người được chọn sẽ bị xóa và không thể khôi phục. Tiếp tục?", "Trả sách", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (muonTraBus.Instance.XoaTS(dGVTra))
                {
                    MessageBox.Show("Xóa thành công", "Trả sách", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewT();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Trả sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnTSHuy_Click(object sender, EventArgs e)
        {
            btnTSSua.Enabled = true;
            btnTSXoa.Enabled = true;
            btnTSThem.Enabled = true;
            btnTSLuu.Enabled = false;
            inputTOff();
        }

        private void btnTSLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDTra.Text);
            string tinhTrang = txtTinhTrangTra.Text;
            string ghiChu = txtGhiChuTra.Text;
            int maTheMuon = int.Parse(cbMaTheMuonTra.SelectedValue.ToString());
            int maSach = int.Parse(cbMaSachTra.SelectedValue.ToString());
            int maCanBoTra = int.Parse(cbCanBoTra.SelectedValue.ToString());
            if(txtThanhToan.Text != "")
            {
                thanhToan = float.Parse(txtThanhToan.Text);
            }
            DateTime dateT = dtNgayTra.Value;
            if (btnTSSua.Enabled == false)
            {
                if (muonTraBus.Instance.ThemTS(id, maCanBoTra, dateT, tinhTrang, thanhToan, ghiChu))
                {
                    MessageBox.Show("Trả sách thành công","Trả sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewT();
                    btnTSSua.Enabled = true;
                    btnTSXoa.Enabled = true;
                    btnTSLuu.Enabled = false;
                    btnTSHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể trả! Vui lòng kiểm tra lại", "Trả sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnTSThem.Enabled == false)
                {
                    if (muonTraBus.Instance.SuaTS(id, maCanBoTra, dateT, tinhTrang, thanhToan, ghiChu))
                    {
                        MessageBox.Show("Sửa thành công", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewT();
                        btnTSSua.Enabled = true;
                        btnTSXoa.Enabled = true;
                        btnTSLuu.Enabled = false;
                        btnTSHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                }
            }

        private void searchTS()
        {
            try
            {
                int keyint = int.Parse(txtTSSearch.Texts);
                float keyfloat = float.Parse(txtTSSearch.Texts);
                muonTraBus.Instance.SearchTSInt(dGVTra, keyint, keyfloat);
            }
            catch
            {
                try
                {
                    DateTime keyDT = DateTime.ParseExact(txtTSSearch.Texts, "yyyy/dd/MM", System.Globalization.CultureInfo.InvariantCulture);
                    muonTraBus.Instance.SearchTSDT(dGVTra, keyDT);
                }
                catch
                {
                    string key = txtTSSearch.Texts;
                    muonTraBus.Instance.SearchTSString(dGVTra, key);
                }
            }
        }

        private void btnTSSearch_Click(object sender, EventArgs e)
        {
            searchTS();
        }
        private void txtTSSearch_MouseEnter(object sender, EventArgs e)
        {
            searchTS();
        }

        #endregion

        
    }
}
