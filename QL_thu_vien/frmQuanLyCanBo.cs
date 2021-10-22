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
    public partial class frmQuanLyCanBo : Form
    {
        string gender ="Khác";
        public frmQuanLyCanBo()
        {
            InitializeComponent();
            
        }
        private void frmQuanLyCanBo_Load(object sender, EventArgs e)
        {
            View();
            ViewAcount();
            ViewPower();
            
        }

       #region->Can bo
        private void View()
        {
            txtMaCanBo.Enabled = false;
            txtTenCanBo.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            rdKhac.Enabled = false;
            rdNam.Enabled = false;
            rdNu.Enabled = false;
            dTNgaySinh.Enabled = false; 
            canBoThuVienBus.Instance.ViewBus(dGVListMember);
        }
        private void tabCanBo_Click(object sender, EventArgs e)
        {
            View();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thông tin bị xóa sẽ không thể khôi phục. Tiếp tục?", "Nhân viên", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (canBoThuVienBus.Instance.Xoa(dGVListMember))
                {
                    MessageBox.Show("Xóa thành công", "Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    frmQuanLyCanBo_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!","Nhân viên",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaCanBo.Texts);
            string tenCanBo = txtTenCanBo.Texts;
            DateTime dob = dTNgaySinh.Value;
            string diaChi = txtDiaChi.Texts;
            string sdt = txtSDT.Texts;
            string email = txtEmail.Texts;
            if (btnSua.Enabled == false)
            {
                if (canBoThuVienBus.Instance.Them(tenCanBo, gender, dob, diaChi, sdt, email))
                {
                    MessageBox.Show("Thêm thành công","Nhân viên", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    View();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại","Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnThem.Enabled == false)
                {
                    if (canBoThuVienBus.Instance.Sua(id, tenCanBo, gender, dob, diaChi, sdt, email))
                    {
                        MessageBox.Show("Sửa thành công","Nhân viên",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //View();
                        btnThem.Enabled = true;
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
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaCanBo.Enabled = false;
            txtTenCanBo.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            rdKhac.Enabled = true;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            dTNgaySinh.Enabled = true;
            btnSua.Enabled  = false;
            btnXoa.Enabled  = false;
            btnLuu.Enabled  = true;
            btnHuy.Enabled  = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaCanBo.Enabled = false;
            txtTenCanBo.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            rdKhac.Enabled = true;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            dTNgaySinh.Enabled = true;
            btnThem.Enabled         = false;
            btnXoa.Enabled          = false;
            btnLuu.Enabled          = true;
            btnHuy.Enabled          = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnSua.Enabled  = true;
            btnXoa.Enabled  = true;
            btnThem.Enabled = true;
            btnLuu.Enabled  = false;
        }
        private void dGVListMember_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVListMember.CurrentCell != null)
            {
                int i = dGVListMember.CurrentCell.RowIndex;
                txtMaCanBo.Texts = dGVListMember.Rows[i].Cells["id"].Value.ToString();
                txtTenCanBo.Texts = (string)dGVListMember.Rows[i].Cells["name"].Value ?? null;
                string gender = (string)dGVListMember.Rows[i].Cells["gend"].Value ?? null;
                switch (gender)
                {
                    case "Nam": rdNam.Checked = true; break;
                    case "Nữ": rdNu.Checked = true; break;
                    default: rdKhac.Checked = true; break;
                }
                dTNgaySinh.Value = (DateTime)(DateTime?)(DateTime?)dGVListMember.Rows[i].Cells["dOB"].Value;
                txtDiaChi.Texts = (string)dGVListMember.Rows[i].Cells["address"].Value ?? null;
                txtSDT.Texts = (string)dGVListMember.Rows[i].Cells["phone"].Value ?? null;
                txtEmail.Texts = (string)dGVListMember.Rows[i].Cells["email"].Value ?? null;
            }
            
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNam.Checked)
            {
                gender = "Nam";
            }
        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNu.Checked)
            {
                gender = "Nữ";
            }
        }
        private void rdKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKhac.Checked)
            {
                gender = "Khác";
            }
        }
        private void search()
        {
            try
            {
                int keyint = int.Parse(txtSearch.Texts);
                canBoThuVienBus.Instance.SearchInt(dGVListMember, keyint);
            }
            catch
            {
                try
                {
                    DateTime keyDT = DateTime.ParseExact(txtSearch.Texts, "yyyy/dd/MM", System.Globalization.CultureInfo.InvariantCulture);
                    canBoThuVienBus.Instance.SearchDT(dGVListMember, keyDT);
                }
                catch
                {
                    string key = txtSearch.Texts;
                    canBoThuVienBus.Instance.SearchString(dGVListMember, key);
                }
                
            }
        }
        private void txtSearch_MouseEnter(object sender, EventArgs e)
        {
            search();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        #endregion
        #region->Tai khoan
        private void ViewAcount()
        {
            
            txtTMaCanBo.Enabled = false;
            txtTenCanBo.Enabled = false;
            txtTEmail.Enabled = false;
            txtTMatKhau.Enabled = false;
            
            canBoThuVienBus.Instance.ViewAccountBus(dGVTaiKhoan);
        }
        private void tPTaiKhoan_Click(object sender, EventArgs e)
        {
            ViewAcount(); 
            tab2BtnHuy.Enabled          = false;
            tab2BtnLuu.Enabled          = false;
        }

        private void tab2BtnSua_Click(object sender, EventArgs e)
        {
            txtTMaCanBo.Enabled = false;
            txtTenCanBo.Enabled = true;
            txtTEmail.Enabled = true;
            txtTMatKhau.Enabled = true;
            tab2BtnThem.Enabled         = false;
            tab2BtnXoa.Enabled          = false;
            tab2BtnLuu.Enabled          = true;
            tab2BtnHuy.Enabled          = true;
        }

        private void tab2BtnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Toàn bộ thông tin của người được chọn sẽ bị xóa và không thể khôi phục. Tiếp tục?", "Tài khoản", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (canBoThuVienBus.Instance.XoaAccount(dGVTaiKhoan))
                {
                    MessageBox.Show("Xóa thành công", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewAcount();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!","Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tab2BtnHuy_Click(object sender, EventArgs e)
        {
            tab2BtnSua.Enabled  = true;
            tab2BtnXoa.Enabled  = true;
            tab2BtnThem.Enabled = true;
            tab2BtnLuu.Enabled  = false;
        }

        private void tab2BtnLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtTMaCanBo.Texts);
            string tenCanBo = txtTTenNhanVien.Texts;
            string email = txtTEmail.Texts;
            string matkhau = txtTMatKhau.Texts;
            if (tab2BtnSua.Enabled == false)
            {
                
                if (canBoThuVienBus.Instance.ThemAccount(tenCanBo, email, matkhau))
                {
                    MessageBox.Show("Thêm thành công", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewAcount();
                    tab2BtnLuu.Enabled = false;
                    tab2BtnThem.Enabled = true;
                    tab2BtnSua.Enabled = true;
                    tab2BtnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (tab2BtnThem.Enabled == false)
                {
                    if (canBoThuVienBus.Instance.SuaAcount(id, tenCanBo, email, matkhau))
                    {
                        MessageBox.Show("Sửa thành công", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewAcount();
                        tab2BtnLuu.Enabled = false;
                        tab2BtnThem.Enabled = true;
                        tab2BtnSua.Enabled = true;
                        tab2BtnXoa.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tab2BtnThem_Click(object sender, EventArgs e)
        {
            txtTMaCanBo.Enabled = false;
            txtTenCanBo.Enabled = true;
            txtTEmail.Enabled = true;
            txtTMatKhau.Enabled = true;
            tab2BtnSua.Enabled          = false;
            tab2BtnXoa.Enabled          = false;
            tab2BtnLuu.Enabled          = true;
            tab2BtnHuy.Enabled          = true;
        }
        private void dGVTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVTaiKhoan.CurrentCell !=null)
            {
                int i = dGVTaiKhoan.CurrentCell.RowIndex;
                txtTMaCanBo.Texts = dGVTaiKhoan.Rows[i].Cells["tKID"].Value.ToString();
                txtTTenNhanVien.Texts = (string)dGVTaiKhoan.Rows[i].Cells["tKName"].Value ?? null;
                txtTEmail.Texts = (string)dGVTaiKhoan.Rows[i].Cells["tKEmail"].Value ?? null;
                txtTMatKhau.Texts = (string)dGVTaiKhoan.Rows[i].Cells["tkPasswd"].Value ?? null;
            }
            
        }
        private void searchAccount()
        {
            try
            {
                int keyint = int.Parse(txtTSearch.Texts);
                canBoThuVienBus.Instance.SearchAccountInt(dGVTaiKhoan, keyint);
            }
            catch
            {
                string key = txtTSearch.Texts;
                canBoThuVienBus.Instance.SearchAccountString(dGVTaiKhoan, key);
            }
            
        }
        private void btrnTSearch_Click(object sender, EventArgs e)
        {
            searchAccount();
        }
        private void txtTSearch_MouseEnter(object sender, EventArgs e)
        {
            searchAccount();
        }
        #endregion
        #region-> Phan quyen
        private void ViewPower()
        {
            txtQMaNhanVien.Enabled = false;
            txtQTenNhanVien.Enabled = false;
            txtQEmail.Enabled = false;
            txtQuyen.Enabled = false;
            canBoThuVienBus.Instance.ViewPowerBus(dGVQuyen);
        }
        private void tPQuyenHan_Click(object sender, EventArgs e)
        {
            ViewPower();
            tab3BtnHuy.Enabled          = false;
            tab3BtnLuu.Enabled          = false;
        }

        private void tab3BtnThem_Click(object sender, EventArgs e)
        {

            txtQMaNhanVien.Enabled = false;
            txtQTenNhanVien.Enabled = true;
            txtQEmail.Enabled = true;
            txtQuyen.Enabled = true;
            tab3BtnSua.Enabled          = false;
            tab3BtnXoa.Enabled          = false;
            tab3BtnLuu.Enabled          = true;
            tab3BtnHuy.Enabled          = true;
        }

        private void tab3BtnSua_Click(object sender, EventArgs e)
        {
            txtQMaNhanVien.Enabled = false;
            txtQTenNhanVien.Enabled = true;
            txtQEmail.Enabled = true;
            txtQuyen.Enabled = true;
            txtQMaNhanVien.Enabled      = false;
            tab3BtnThem.Enabled         = false;
            tab3BtnXoa.Enabled          = false;
            tab3BtnLuu.Enabled          = true;
            tab3BtnHuy.Enabled          = true;
        }

        private void tab3BtnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Toàn bộ thông tin của người được chọn sẽ bị xóa và không thể khôi phục. Tiếp tục?", "Phân quyền", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (canBoThuVienBus.Instance.XoaPower(dGVQuyen))
                {
                    MessageBox.Show("Xóa thành công", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewPower();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tab3BtnHuy_Click(object sender, EventArgs e)
        {
            tab3BtnSua.Enabled  = true;
            tab3BtnXoa.Enabled  = true;
            tab3BtnThem.Enabled = true;
            tab3BtnLuu.Enabled  = false;
        }

        private void tab3BtnLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtQMaNhanVien.Texts);
            string tenCanBo = txtQTenNhanVien.Texts;
            string email = txtQEmail.Texts;
            string quyen = txtQuyen.Texts;
            if (tab3BtnSua.Enabled == false)
            {
                if (canBoThuVienBus.Instance.ThemPower(tenCanBo, email, quyen))
                {
                    MessageBox.Show("Thêm thành công", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewPower();
                    tab3BtnLuu.Enabled = false;
                    tab3BtnThem.Enabled = true;
                    tab3BtnSua.Enabled = true;
                    tab3BtnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (tab3BtnThem.Enabled == false)
                {
                    if (canBoThuVienBus.Instance.SuaPower(id, tenCanBo, email, quyen))
                    {
                        MessageBox.Show("Sửa thành công", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewPower();
                        tab3BtnLuu.Enabled = false;
                        tab3BtnThem.Enabled = true;
                        tab3BtnSua.Enabled = true;
                        tab3BtnXoa.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dGVQuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVQuyen.CurrentCell !=null)
            {
                int i = dGVQuyen.CurrentCell.RowIndex;
                txtQMaNhanVien.Texts = dGVQuyen.Rows[i].Cells["qHID"].Value.ToString();
                txtQTenNhanVien.Texts = (string)dGVQuyen.Rows[i].Cells["qHName"].Value ?? null;
                txtQEmail.Texts = (string)dGVQuyen.Rows[i].Cells["qHEmail"].Value ?? null;
                txtQuyen.Texts = (string)(dGVQuyen.Rows[i].Cells["qHPower"].Value ?? null);
            }
            
        }
        
        private void searchQ()
        {
            try
            {
                int keyint = int.Parse(txtQSearch.Texts);
                canBoThuVienBus.Instance.SearchPowerInt(dGVQuyen, keyint);
            }
            catch
            {
                string key = txtQSearch.Texts;
                canBoThuVienBus.Instance.SearchPowerString(dGVQuyen, key);
            }
            
        }
        private void btnQSearch_Click(object sender, EventArgs e)
        {
            searchQ();
        }
        private void txtQSearch_MouseEnter(object sender, EventArgs e)
        {
            searchQ();
        }
        #endregion


    }
}
