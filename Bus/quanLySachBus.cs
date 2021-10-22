using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Bus
{
    public class quanLySachBus
    {
        private static quanLySachBus instance;
        public static quanLySachBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new quanLySachBus();
                return instance;
            }
        }
        private quanLySachBus() { }
        #region->Book
        public void View(DataGridView data)
        {
            data.DataSource = quanLySachModel.Instance.View();
        }
        public void SearchInt(DataGridView data, int keyInt, float keyFloat)
        {
            data.DataSource = quanLySachModel.Instance.SearchInt(keyInt, keyFloat);
        }
        public void SearchString(DataGridView data, string key)
        {
            data.DataSource = quanLySachModel.Instance.SearchString(key);
        }
        public void cbTheLoai(ComboBox combo)
        {
            combo.DataSource = quanLySachModel.Instance.cbTheLoai();
            combo.ValueMember = "maTheLoai";
            combo.DisplayMember = "ten";
        }
        public void cbTenKho(ComboBox combo)
        {
            combo.DataSource = quanLySachModel.Instance.cbTenKho();
            combo.ValueMember = "maKho";
            combo.DisplayMember = "ten";
        }
        public void cbNXB(ComboBox combo)
        {
            combo.DataSource = quanLySachModel.Instance.cbNXB();
            combo.ValueMember = "maNXB";
            combo.DisplayMember = "ten";
        }
        public bool Sua(int id, string name, int maTheLoai, string author, int number, float price, int maKho, int maNXB, string note)
        {
            tbl_sach sachBus = new tbl_sach();
            sachBus.maSach = id;
            sachBus.tenSach = name;
            sachBus.maTheLoai = maTheLoai;
            sachBus.tenTacGia = author;
            sachBus.soLuong = number;
            sachBus.giaTien = price;
            sachBus.maKho = maKho;
            sachBus.maNXB = maNXB;
            sachBus.moTa = note;

            return quanLySachModel.Instance.Sua(id, sachBus);
        }
        public bool Them(string name, int maTheLoai, string author, int number, float price, int maKho, int maNXB, string note)
        {
            tbl_sach sachBus = new tbl_sach();
            sachBus.tenSach = name;
            sachBus.maTheLoai = maTheLoai;
            sachBus.tenTacGia = author;
            sachBus.soLuong = number;
            sachBus.giaTien = price;
            sachBus.maKho = maKho;
            sachBus.maNXB = maNXB;
            sachBus.moTa = note;
            return quanLySachModel.Instance.Luu(maTheLoai, maKho, maNXB, name, author, number, price, note, sachBus);
        }
        public bool Xoa(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["idB"].Value;

            tbl_sach sachBus = new tbl_sach();
            sachBus.maSach = id;

            return quanLySachModel.Instance.Xoa(id, sachBus);
        }
        #endregion
        #region->category
        public void ViewCategory(DataGridView data)
        {
            data.DataSource = quanLySachModel.Instance.ViewCategory();
        }
        public void SearchCategoryInt(DataGridView data, int keyInt)
        {
            data.DataSource = quanLySachModel.Instance.SearchCategoryInt(keyInt);
        }
        public void SearchCategoryString(DataGridView data, string key)
        {
            data.DataSource = quanLySachModel.Instance.SearchCategoryString(key);
        }
        public bool ThemL(string name, string note)
        {
            tbl_the_loai_sach LSachBus = new tbl_the_loai_sach();
            LSachBus.tenTheLoai = name;
            LSachBus.ghiChu = note;
            return quanLySachModel.Instance.LuuL(name,  note, LSachBus);
        }
        public bool SuaL(int id, string name, string note)
        {
            
            tbl_the_loai_sach LSachBus = new tbl_the_loai_sach();
            LSachBus.maTheLoai = id;
            LSachBus.tenTheLoai = name;
            LSachBus.ghiChu = note;

            return quanLySachModel.Instance.SuaL(id, LSachBus);
        }
        public bool XoaL(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["categoryID"].Value;

            tbl_the_loai_sach LSachBus = new tbl_the_loai_sach();
            LSachBus.maTheLoai = id;

            return quanLySachModel.Instance.XoaL(id, LSachBus);
        }
        #endregion
        #region->NXB
        public void ViewNXB(DataGridView data)
        {
            data.DataSource = quanLySachModel.Instance.ViewNXB();
        }
        public void SearchNXBInt(DataGridView data, int keyInt)
        {
            data.DataSource = quanLySachModel.Instance.SearchNXBInt(keyInt);
        }
        public void SearchNXBString(DataGridView data, string key)
        {
            data.DataSource = quanLySachModel.Instance.SearchNXBString(key);
        }
        public bool ThemN(string name, string phone, string email, string address, string note)
        {
           
            tbl_NXB nxbBus = new tbl_NXB();
            nxbBus.tenNXB = name;
            nxbBus.phone = phone;
            nxbBus.email = email;
            nxbBus.diaChi = note;
            nxbBus.ghiChu = note;
            return quanLySachModel.Instance.LuuN(name, phone, email, address, note, nxbBus);
        }
        public bool SuaN(int id, string name, string phone, string email, string address, string note)
        {
            tbl_NXB nxbBus = new tbl_NXB();
            nxbBus.maNXB = id;
            nxbBus.tenNXB = name;
            nxbBus.phone = phone;
            nxbBus.email = email;
            nxbBus.diaChi = note;
            nxbBus.ghiChu = note;

            return quanLySachModel.Instance.SuaN(id, nxbBus);
        }
        public bool XoaN(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["id"].Value;

            tbl_NXB nxbBus = new tbl_NXB();
            nxbBus.maNXB = id;

            return quanLySachModel.Instance.XoaN(id, nxbBus);
        }
        #endregion
        #region->storage
        public void ViewStorage(DataGridView data)
        {
            data.DataSource = quanLySachModel.Instance.ViewStorage();
        }
        public void SearchStorageInt(DataGridView data, int keyInt)
        {
            data.DataSource = quanLySachModel.Instance.SearchStorageInt(keyInt);
        }
        public void SearchStorageString(DataGridView data, string key)
        {
            data.DataSource = quanLySachModel.Instance.SearchStorageString(key);
        }
        public bool ThemK(string name, string note)
        {
           
            tbl_kho_sach KSachBus = new tbl_kho_sach();
            KSachBus.tenKho = name;
            KSachBus.ghiChu = note;
            return quanLySachModel.Instance.LuuK(name, note, KSachBus);
        }
        public bool SuaK(int id, string name, string note)
        {
            
            tbl_kho_sach KSachBus = new tbl_kho_sach();
            KSachBus.maKho = id;
            KSachBus.tenKho = name;
            KSachBus.ghiChu = note;

            return quanLySachModel.Instance.SuaK(id, KSachBus);
        }
        public bool XoaK(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["storageID"].Value;

            tbl_kho_sach KSachBus = new tbl_kho_sach();
            KSachBus.maKho = id;

            return quanLySachModel.Instance.XoaK(id, KSachBus);
        }
        #endregion
    }
}
