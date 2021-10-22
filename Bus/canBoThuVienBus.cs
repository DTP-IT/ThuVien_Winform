using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Bus
{
    public class canBoThuVienBus
    {
        private static canBoThuVienBus instance;
        public static canBoThuVienBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new canBoThuVienBus();
                return instance;
            }
        }
        private canBoThuVienBus() { }
        #region->Can bo
        public void ViewBus(DataGridView data)
        {
            data.DataSource = canBoThuVienModel.Instance.View();
        }
        public void SearchInt(DataGridView data, int keyInt)
        {
            data.DataSource = canBoThuVienModel.Instance.SearchInt(keyInt);
        }
        public void SearchString(DataGridView data, string key)
        {
            data.DataSource = canBoThuVienModel.Instance.SearchString(key);
        }
        public void SearchDT(DataGridView data, DateTime keyDT)
        {
            data.DataSource = canBoThuVienModel.Instance.SearchDT(keyDT);
        }

        public bool Sua(int id,string name, string gender, DateTime doB, string address, string phone, string email)
        {
            
            tbl_can_bo_thu_vien nhanVienBus = new tbl_can_bo_thu_vien();
            nhanVienBus.maCanBo = id;
            nhanVienBus.tenCanBo = name;
            nhanVienBus.gioiTinh = gender;
            nhanVienBus.namSinh = doB;
            nhanVienBus.diaChi = address;
            nhanVienBus.phone = phone;
            nhanVienBus.email = email;

            return canBoThuVienModel.Instance.Sua(id, nhanVienBus);
        }
        public bool Them(string name, string gender, DateTime doB, string address, string phone, string email)
        {
            
            tbl_can_bo_thu_vien nhanVienBus = new tbl_can_bo_thu_vien();
            nhanVienBus.tenCanBo = name;
            nhanVienBus.gioiTinh = gender;
            nhanVienBus.namSinh = doB;
            nhanVienBus.diaChi = address;
            nhanVienBus.phone = phone;
            nhanVienBus.email = email;
            return canBoThuVienModel.Instance.Luu(name, gender, doB, address, phone, email, nhanVienBus);
        }
        public bool Xoa(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["id"].Value;
            
            tbl_can_bo_thu_vien nhanVienBus = new tbl_can_bo_thu_vien();
            nhanVienBus.maCanBo = id;

            return canBoThuVienModel.Instance.Xoa(id, nhanVienBus);
        }
        #endregion
        #region->Tai khoan
        public void ViewAccountBus(DataGridView data)
        {
            data.DataSource = canBoThuVienModel.Instance.ViewAccount();
        }
        public void SearchAccountInt(DataGridView data, int keyInt)
        {
            data.DataSource = canBoThuVienModel.Instance.SearchAccountInt(keyInt);
        }
        public void SearchAccountString(DataGridView data, string key)
        {
            data.DataSource = canBoThuVienModel.Instance.SearchAccountString(key);
        }
        public bool ThemAccount(string name, string email, string passwd)
        {
            tbl_can_bo_thu_vien accoutnBus = new tbl_can_bo_thu_vien();
            accoutnBus.tenCanBo = name;
            accoutnBus.email = email;
            accoutnBus.quenHan = passwd;
            return canBoThuVienModel.Instance.LuuAcount(name, email, passwd, accoutnBus);
        }
        public bool SuaAcount(int id, string name, string email, string passwd)
        {
            tbl_can_bo_thu_vien accountBus = new tbl_can_bo_thu_vien();
            accountBus.maCanBo = id;
            accountBus.tenCanBo = name;
            accountBus.email = email;
            accountBus.matKhau = passwd;

            return canBoThuVienModel.Instance.SuaAccount(id, accountBus);
        }
        public bool XoaAccount(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["tKID"].Value;

            tbl_can_bo_thu_vien accountBus = new tbl_can_bo_thu_vien();
            accountBus.maCanBo = id;

            return canBoThuVienModel.Instance.XoaAccount(id, accountBus);
        }
        #endregion
        #region->Quyen
        public void ViewPowerBus(DataGridView data)
        {
            data.DataSource = canBoThuVienModel.Instance.ViewPower();
        }
        public void SearchPowerInt(DataGridView data, int keyInt)
        {
            data.DataSource = canBoThuVienModel.Instance.SearchPowerInt(keyInt);
        }
        public void SearchPowerString(DataGridView data, string key)
        {
            data.DataSource = canBoThuVienModel.Instance.SearchPowerString(key);
        }
        public bool ThemPower(string name, string email, string power)
        {
            tbl_can_bo_thu_vien powerBus = new tbl_can_bo_thu_vien();
            powerBus.tenCanBo = name;
            powerBus.email = email;
            powerBus.quenHan = power;
            return canBoThuVienModel.Instance.LuuPower(name, email, power, powerBus);
        }
        public bool SuaPower(int id, string name, string email,string level)
        {
            tbl_can_bo_thu_vien powertBus = new tbl_can_bo_thu_vien();
            powertBus.maCanBo = id;
            powertBus.tenCanBo = name;
            powertBus.email = email;
            powertBus.quenHan = level;

            return canBoThuVienModel.Instance.SuaPower(id, powertBus);
        }
        public bool XoaPower(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["qHID"].Value;

            tbl_can_bo_thu_vien powerBus = new tbl_can_bo_thu_vien();
            powerBus.maCanBo = id;

            return canBoThuVienModel.Instance.XoaPower(id, powerBus);
        }
        #endregion
    }
}
