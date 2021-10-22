using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Bus
{
    public class docGiaBus
    {
        private static docGiaBus instance;
        public static docGiaBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new docGiaBus();
                return instance;
            }
        }
        private docGiaBus() { }
        public void View(DataGridView data)
        {
            data.DataSource = docGiaModel.Instance.View();
        }
        public void SearchInt(DataGridView data, int keyInt)
        {
            data.DataSource = docGiaModel.Instance.SearchInt(keyInt);
        }
        public void SearchString(DataGridView data, string key)
        {
            data.DataSource = docGiaModel.Instance.SearchString(key);
        }
        public void SearchDT(DataGridView data, DateTime keyDT)
        {
            data.DataSource = docGiaModel.Instance.SearchDT(keyDT);
        }
        public void loadClass(ComboBox combo, int facultyID)
        {
            combo.DataSource = docGiaModel.Instance.loadClass(facultyID);
            combo.ValueMember = "maLop";
            combo.DisplayMember = "tenLop";
        }
        public bool Sua(int id, string name, int facultyID, int classID, string gender, DateTime doB, string address, string phone, string email)
        {
            tbl_doc_gia docGiaBus = new tbl_doc_gia();
            docGiaBus.maThe = id;
            docGiaBus.maKhoa = facultyID;
            docGiaBus.maLop = classID;
            docGiaBus.hoTen = name;
            docGiaBus.ngaySinh = doB;
            docGiaBus.gioiTinh = gender;
            docGiaBus.diaChi = address;
            docGiaBus.phone = phone;
            docGiaBus.email = email;

            return docGiaModel.Instance.Sua(id, docGiaBus);
        }
        public bool Them(string name, int facultyID, int classID, string gender, DateTime doB, string address, string phone, string email)
        {
            tbl_doc_gia docGiaBus = new tbl_doc_gia();
            docGiaBus.maKhoa = facultyID;
            docGiaBus.maLop = classID;
            docGiaBus.hoTen = name;
            docGiaBus.ngaySinh = doB;
            docGiaBus.gioiTinh = gender;
            docGiaBus.diaChi = address;
            docGiaBus.phone = phone;
            docGiaBus.email = email;
            return docGiaModel.Instance.Luu(facultyID, classID, name,  doB, gender, address, phone, email, docGiaBus);
        }
        public bool Xoa(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            int id = (int)row.Cells["id"].Value;

            tbl_doc_gia docGiaBus = new tbl_doc_gia();
            docGiaBus.maThe = id;

            return docGiaModel.Instance.Xoa(id, docGiaBus);
        }
    }
}
