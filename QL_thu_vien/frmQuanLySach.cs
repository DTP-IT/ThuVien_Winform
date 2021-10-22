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
    public partial class frmQuanLySach : Form
    {
        public frmQuanLySach()
        {
            InitializeComponent();
        }
        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            ViewBook();
            ViewCategory();
            ViewStorage();
            ViewNXB();
        }

        #region->Book
        private void inputOn()
        {
            txtRMaSach.Enabled = false;
            txtRTenSach.Enabled = true;
            txtTacGia.Enabled = true;
            txtRSoLuong.Enabled = true;
            txtRGiaTien.Enabled = true;
            txtRMoTa.Enabled = true;
            cbTheLoai.Enabled = true;
            cbTenKho.Enabled = true;
            cbNXB.Enabled = true;
        }
        private void inputOff()
        {
            txtRMaSach.Enabled = false;
            txtRTenSach.Enabled = false;
            txtTacGia.Enabled = false;
            txtRSoLuong.Enabled = false;
            txtRGiaTien.Enabled = false;
            txtRMoTa.Enabled = false;
            cbTheLoai.Enabled = false;
            cbTenKho.Enabled = false;
            cbNXB.Enabled = false;
        }
        private void ViewBook()
        {
            quanLySachBus.Instance.View(dGVBook);
        }
        private void btnBThem_Click(object sender, EventArgs e)
        {
            inputOn();

            btnBSua.Enabled = false;
            btnBXoa.Enabled = false;
            btnBLuu.Enabled = true;
            btnBHuy.Enabled = true;
        }

        private void btnBSua_Click(object sender, EventArgs e)
        {
            inputOn();
            btnBThem.Enabled = false;
            btnBXoa.Enabled = false;
            btnBLuu.Enabled = true;
            btnBHuy.Enabled = true;
        }

        private void btnBXoa_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Thông tin bị xóa sẽ không thể khôi phục. Tiếp tục?", "Sách", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (quanLySachBus.Instance.Xoa(dGVBook))
                {
                    MessageBox.Show("Xóa thành công", "Sách", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewBook();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBHuy_Click(object sender, EventArgs e)
        {
            btnBSua.Enabled = true;
            btnBXoa.Enabled = true;
            btnBThem.Enabled = true;
            btnBLuu.Enabled = false;

            inputOff();
        }

        private void btnBLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtRMaSach.Texts);
            string name = txtRTenSach.Texts;
            string author = txtTacGia.Texts;
            int number = int.Parse(txtRSoLuong.Texts);
            float price = float.Parse(txtRGiaTien.Texts);
            string note = txtRMoTa.Texts;
            int maTheLoai = int.Parse(cbTheLoai.SelectedValue.ToString());
            int maKho = int.Parse(cbTenKho.SelectedValue.ToString());
            int maNXB = int.Parse(cbNXB.SelectedValue.ToString());
            if (btnBSua.Enabled == false)
            {
                if (quanLySachBus.Instance.Them(name, maTheLoai, author, number, price, maKho, maNXB, note))
                {
                    MessageBox.Show("Thêm thành công", "Sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewBook();
                    inputOff();
                    btnBSua.Enabled = true;
                    btnBXoa.Enabled = true;
                    btnBLuu.Enabled = false;
                    btnBHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnBThem.Enabled == false)
                {
                    if (quanLySachBus.Instance.Sua(id, name, maTheLoai, author, number, price, maKho, maNXB, note))
                    {
                        MessageBox.Show("Sửa thành công", "Sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewBook();
                        inputOff();
                        btnBSua.Enabled = true;
                        btnBXoa.Enabled = true;
                        btnBLuu.Enabled = false;
                        btnBHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        

        private void cbTheLoai_Click(object sender, EventArgs e)
        {
            quanLySachBus.Instance.cbTheLoai(cbTheLoai);  
        }

        private void cbTenKho_Click(object sender, EventArgs e)
        {
            quanLySachBus.Instance.cbTenKho(cbTenKho);
        }

        private void cbNXB_Click(object sender, EventArgs e)
        {
            quanLySachBus.Instance.cbNXB(cbNXB);
        }
        private void searchB()
        {
            try
            {
                int keyint = int.Parse(txtSearch.Texts);
                float keyFloat = float.Parse(txtSearch.Texts);
                quanLySachBus.Instance.SearchInt(dGVBook, keyint, keyFloat);
            }
            catch
            {
                string key = txtSearch.Texts;
                quanLySachBus.Instance.SearchString(dGVBook, key);

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchB();
        }
        private void txtSearch_MouseEnter(object sender, EventArgs e)
        {
            searchB();
        }
        #endregion

        #region->Category
        private void ViewCategory()
        {
            quanLySachBus.Instance.ViewCategory(dGVLoaiSach);
        }
        private void dGVLoaiSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVLoaiSach.CurrentCell != null)
            {
                int i = dGVLoaiSach.CurrentCell.RowIndex;
                txtMaLoaiSach.Texts = dGVLoaiSach.Rows[i].Cells["categoryID"].Value.ToString();

                txtTenLoaiSach.Texts = (string)dGVLoaiSach.Rows[i].Cells["categoryName"].Value ?? null;
                txtGhiChuLoaiSach.Texts = (string)dGVLoaiSach.Rows[i].Cells["caNote"].Value ?? null;
            }
        }

        private void btnLThem_Click(object sender, EventArgs e)
        {
            txtTenLoaiSach.Enabled = true;
            txtMaLoaiSach.Enabled = false;
            txtGhiChuLoaiSach.Enabled = true;
            btnLSua.Enabled = false;
            btnLXoa.Enabled = false;
            btnLLuu.Enabled = true;
            btnLHuy.Enabled = true;
        }

        private void btnLSua_Click(object sender, EventArgs e)
        {
            txtTenLoaiSach.Enabled = true;
            txtMaLoaiSach.Enabled = false;
            txtGhiChuLoaiSach.Enabled = true;
            btnLThem.Enabled = false;
            btnLXoa.Enabled = false;
            btnLLuu.Enabled = true;
            btnLHuy.Enabled = true;
        }

        private void btnLXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thông tin bị xóa sẽ không thể khôi phục. Tiếp tục?", "Loại sách", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (quanLySachBus.Instance.XoaL(dGVLoaiSach))
                {
                    MessageBox.Show("Xóa thành công", "Thẻ mượn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewCategory();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Loại sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLHuy_Click(object sender, EventArgs e)
        {
            btnLSua.Enabled = true;
            btnLXoa.Enabled = true;
            btnLThem.Enabled = true;
            btnLLuu.Enabled = false;
            txtTenLoaiSach.Enabled = false;
            txtMaLoaiSach.Enabled = false;
            txtGhiChuLoaiSach.Enabled = false;
        }

        private void btnLLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaLoaiSach.Texts);
            string name = txtTenLoaiSach.Texts;
            string note = txtGhiChuLoaiSach.Texts;
            if (btnLSua.Enabled == false)
            {
                if (quanLySachBus.Instance.ThemL(name, note))
                {
                    MessageBox.Show("Thêm thành công", "Loại sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewCategory();
                    txtTenLoaiSach.Enabled = false;
                    txtMaLoaiSach.Enabled = false;
                    txtGhiChuLoaiSach.Enabled = false;

                    btnLSua.Enabled = true;
                    btnLXoa.Enabled = true;
                    btnLLuu.Enabled = false;
                    btnLHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Loại sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnLThem.Enabled == false)
                {
                    if (quanLySachBus.Instance.SuaL(id, name, note))
                    {
                        MessageBox.Show("Sửa thành công", "Loại sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewCategory();
                        txtTenLoaiSach.Enabled = false;
                        txtMaLoaiSach.Enabled = false;
                        txtGhiChuLoaiSach.Enabled = false;

                        btnLThem.Enabled = true;
                        btnLXoa.Enabled = true;
                        btnLLuu.Enabled = false;
                        btnLHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Loại sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void searchL()
        {
            try
            {
                int keyint = int.Parse(txtLSearch.Texts);

                quanLySachBus.Instance.SearchCategoryInt(dGVLoaiSach, keyint);
            }
            catch
            {
                string key = txtLSearch.Texts;

                quanLySachBus.Instance.SearchCategoryString(dGVLoaiSach, key);

            }
        }
        private void btnLSearch_Click(object sender, EventArgs e)
        {
            searchL();
        }
        private void txtLSearch_MouseEnter(object sender, EventArgs e)
        {
            searchL();
        }
        #endregion
        #region->NXB
        private void inputNXBOn()
        {
            txtIDNXB.Enabled = false;
            txtnameNXB.Enabled = true;
            txtPhoneNXB.Enabled = true;
            txtEmailNXB.Enabled = true;
            txtAddressNXB.Enabled = true;
            txtNoteNXB.Enabled = true;
        }
        private void inputNXBOff()
        {
            txtIDNXB.Enabled = false;
            txtnameNXB.Enabled = false;
            txtPhoneNXB.Enabled = false;
            txtEmailNXB.Enabled = false;
            txtAddressNXB.Enabled = false;
            txtNoteNXB.Enabled = false;
        }
        private void ViewNXB()
        {
            quanLySachBus.Instance.ViewNXB(dGVNXB);
        }
        private void dGVNXB_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVNXB.CurrentCell != null)
            {
                int i = dGVNXB.CurrentCell.RowIndex;
                txtIDNXB.Texts = dGVNXB.Rows[i].Cells["id"].Value.ToString();
                txtnameNXB.Texts = (string)dGVNXB.Rows[i].Cells["name"].Value ?? null;
                txtPhoneNXB.Texts = (string)dGVNXB.Rows[i].Cells["phone"].Value ?? null;
                txtEmailNXB.Texts = (string)dGVNXB.Rows[i].Cells["email"].Value ?? null;
                txtAddressNXB.Texts = (string)dGVNXB.Rows[i].Cells["address"].Value ?? null;
                txtNoteNXB.Texts = (string)dGVNXB.Rows[i].Cells["note"].Value ?? null;
            }
        }

        private void btnNThem_Click(object sender, EventArgs e)
        {
            inputNXBOn();
            btnNSua.Enabled = false;
            btnNXoa.Enabled = false;
            btnNLuu.Enabled = true;
            btnNHuy.Enabled = true;
        }

        private void btnNSua_Click(object sender, EventArgs e)
        {
            inputNXBOn();
            btnNThem.Enabled = false;
            btnNXoa.Enabled = false;
            btnNLuu.Enabled = true;
            btnNHuy.Enabled = true;
        }

        private void btnNXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thông tin bị xóa sẽ không thể khôi phục. Tiếp tục?", "Nhà xuất bản", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (quanLySachBus.Instance.XoaN(dGVNXB))
                {
                    MessageBox.Show("Xóa thành công", "Nhà xuất bản", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewNXB();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Nhà xuất bản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNHuy_Click(object sender, EventArgs e)
        {
            btnNSua.Enabled = true;
            btnNXoa.Enabled = true;
            btnNThem.Enabled = true;
            btnNLuu.Enabled = false;
            inputNXBOff();
        }

        private void btnNLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDNXB.Texts);
            string name = txtnameNXB.Texts;
            string phone = txtPhoneNXB.Texts;
            string email = txtEmailNXB.Texts;
            string address = txtAddressNXB.Texts;
            string note = txtNoteNXB.Texts;
            if (btnNSua.Enabled == false)
            {
                if (quanLySachBus.Instance.ThemN(name, phone, email, address, note))
                {
                    MessageBox.Show("Thêm thành công", "Nhà xuất bản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewNXB();
                    inputNXBOff();
                    btnNSua.Enabled = true;
                    btnNXoa.Enabled = true;
                    btnNLuu.Enabled = false;
                    btnNHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Nhà xuất bản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnNThem.Enabled == false)
                {
                    if (quanLySachBus.Instance.SuaN(id, name, phone, email, address, note))
                    {
                        MessageBox.Show("Sửa thành công", "Nhà xuất bản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewNXB();
                        inputNXBOff();
                        btnNThem.Enabled = true;
                        btnNXoa.Enabled = true;
                        btnNLuu.Enabled = false;
                        btnNHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Nhà xuất bản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void searchN()
        {
            try
            {
                int keyint = int.Parse(txtNSearch.Texts);

                quanLySachBus.Instance.SearchNXBInt(dGVNXB, keyint);
            }
            catch
            {
                string key = txtNSearch.Texts;

                quanLySachBus.Instance.SearchNXBString(dGVNXB, key);
            }
        }
        private void btnNSearch_Click(object sender, EventArgs e)
        {
            searchN();
        }
        private void txtNSearch_MouseEnter(object sender, EventArgs e)
        {
            searchN();
        }
        #endregion

        #region->Storage
        private void ViewStorage()
        {
            quanLySachBus.Instance.ViewStorage(dGVKho);
        }
        private void dGVKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVKho.CurrentCell != null)
            {
                int i = dGVKho.CurrentCell.RowIndex;
                txtMaKho.Texts = dGVKho.Rows[i].Cells["storageID"].Value.ToString();
                txtTenKho.Texts = (string)dGVKho.Rows[i].Cells["storageName"].Value ?? null;
                txtKhoGhiChu.Texts = (string)dGVKho.Rows[i].Cells["storageNote"].Value ?? null;
            }
        }

        private void btnKThem_Click(object sender, EventArgs e)
        {
            txtMaKho.Enabled = false;
            txtTenKho.Enabled = true;
            txtKhoGhiChu.Enabled = true;
            btnKSua.Enabled = false;
            btnKXoa.Enabled = false;
            btnKLuu.Enabled = true;
            btnKHuy.Enabled = true;
        }

        private void btnKSua_Click(object sender, EventArgs e)
        {
            txtMaKho.Enabled = false;
            txtTenKho.Enabled = true;
            txtKhoGhiChu.Enabled = true;

            btnKThem.Enabled = false;
            btnKXoa.Enabled = false;
            btnKLuu.Enabled = true;
            btnKHuy.Enabled = true;
        }

        private void btnKXoa_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Thông tin bị xóa sẽ không thể khôi phục. Tiếp tục?", "Kho sách", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (quanLySachBus.Instance.XoaK(dGVKho))
                {
                    MessageBox.Show("Xóa thành công", "Kho sách", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ViewStorage();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Kho sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKHuy_Click(object sender, EventArgs e)
        {
            btnKSua.Enabled = true;
            btnKXoa.Enabled = true;
            btnKThem.Enabled = true;
            btnKLuu.Enabled = false;

            txtMaKho.Enabled = false;
            txtTenKho.Enabled = false;
            txtKhoGhiChu.Enabled = false;
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaKho.Texts);
            string name = txtTenKho.Texts;
            string note = txtKhoGhiChu.Texts;
            if (btnKSua.Enabled == false)
            {
                if (quanLySachBus.Instance.ThemK(name, note))
                {
                    MessageBox.Show("Thêm thành công", "Kho sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewStorage();

                    txtMaKho.Enabled = false;
                    txtTenKho.Enabled = false;
                    txtKhoGhiChu.Enabled = false;

                    btnKSua.Enabled = true;
                    btnKXoa.Enabled = true;
                    btnKLuu.Enabled = false;
                    btnKHuy.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Kho sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnKThem.Enabled == false)
                {
                    if (quanLySachBus.Instance.SuaK(id, name, note))
                    {
                        MessageBox.Show("Sửa thành công", "Kho sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewStorage();

                        txtMaKho.Enabled = false;
                        txtTenKho.Enabled = false;
                        txtKhoGhiChu.Enabled = false;

                        btnKThem.Enabled = true;
                        btnKXoa.Enabled = true;
                        btnKLuu.Enabled = false;
                        btnKHuy.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Kho sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void searchK()
        {
            try
            {
                int keyint = int.Parse(txtKSearch.Texts);
                quanLySachBus.Instance.SearchStorageInt(dGVKho, keyint);
            }
            catch
            {
                string key = txtKSearch.Texts;
                quanLySachBus.Instance.SearchStorageString(dGVKho, key);

            }
        }
        private void btnKSearch_Click(object sender, EventArgs e)
        {
            searchK();
        }
        private void txtKSearch_MouseEnter(object sender, EventArgs e)
        {
            searchK();
        }



        #endregion

        
    }
}
