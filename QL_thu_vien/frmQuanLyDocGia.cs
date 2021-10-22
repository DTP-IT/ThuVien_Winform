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
    public partial class frmQuanLyDocGia : Form
    {
        string gender = "Khác";
        public frmQuanLyDocGia()
        {
            InitializeComponent();
        }
        private void inputOn()
        {
            txtMaThe.Enabled = false;
            txtHoTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            rdKhac.Enabled = true;
            rdNam.Enabled = true;
            rdNu.Enabled = true;
            dTNgaySinh.Enabled = true;
            cbMaKhoa.Enabled = true;
            cbMaLop.Enabled = true;
        }
        private void inputOff()
        {
            txtMaThe.Enabled = false;
            txtHoTen.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtSDT.Enabled = false;
            rdKhac.Enabled = false;
            rdNam.Enabled = false;
            rdNu.Enabled = false;
            dTNgaySinh.Enabled = false;
            cbMaKhoa.Enabled = false;
            cbMaLop.Enabled = false;
        }
        public void View()
        {
           docGiaBus.Instance.View(dGVListReader);

        }
        private void dGVListReader_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVListReader.CurrentCell != null)
            {
                int i = dGVListReader.CurrentCell.RowIndex;
                txtMaThe.Texts = dGVListReader.Rows[i].Cells["id"].Value.ToString();
                cbMaLop.DataSource = dGVListReader.DataSource;
                cbMaLop.ValueMember = "classID";
                cbMaLop.DisplayMember = "className";
                cbMaKhoa.DataSource = dGVListReader.DataSource;
                cbMaKhoa.ValueMember = "facultyID";
                cbMaKhoa.DisplayMember = "facultyName";

                txtHoTen.Texts = (string)dGVListReader.Rows[i].Cells["name"].Value ?? null;
                dTNgaySinh.Value = (DateTime)(DateTime?)(DateTime?)dGVListReader.Rows[i].Cells["dOB"].Value;
                string gender = (string)dGVListReader.Rows[i].Cells["gend"].Value ?? null;
                if (gender == null)
                {
                    rdKhac.Checked = true;

                }
                else
                {
                    if (dGVListReader.Rows[i].Cells["gend"].Value.ToString() == "Nữ")
                    {
                        rdNu.Checked = true;
                    }
                    else
                    {
                        rdNam.Checked = true;
                    }
                }
                txtDiaChi.Texts = (string)dGVListReader.Rows[i].Cells["address"].Value ?? null;
                txtSDT.Texts = (string)dGVListReader.Rows[i].Cells["phone"].Value ?? null;
                txtEmail.Texts = (string)dGVListReader.Rows[i].Cells["email"].Value ?? null;
            }
        }
        private void frmQuanLyDocGia_Load(object sender, EventArgs e)
        {
            View();
            inputOff();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaThe.Enabled = true;
            inputOn();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            inputOn();
            txtMaThe.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thông tin bị xóa sẽ không thể khôi phục. Tiếp tục?", "Độc giả", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (canBoThuVienBus.Instance.Xoa(dGVListReader))
                {
                    MessageBox.Show("Xóa thành công", "Độc giả", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    View();
                }
                else
                {
                    MessageBox.Show("Không thể xóa. Vui lòng thử lại!", "Độc giả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            inputOff();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaThe.Texts);
            string name = txtHoTen.Texts;
            string address = txtDiaChi.Texts;
            string phone = txtSDT.Texts;
            string email = txtEmail.Texts;
            DateTime dob = dTNgaySinh.Value;
            int facultyID = int.Parse(cbMaKhoa.SelectedValue.ToString());
            int classID = int.Parse(cbMaLop.SelectedValue.ToString());
            if (btnSua.Enabled == false)
            {
                if (docGiaBus.Instance.Them(name, facultyID, classID, gender, dob, address, phone, email))
                {
                    MessageBox.Show("Thêm thành công", "Độc giả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    View();
                    inputOff();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không thể thêm thông tin! Vui lòng kiểm tra lại", "Độc giả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (btnThem.Enabled == false)
                {
                    if (docGiaBus.Instance.Sua(id, name, facultyID, classID, gender, dob, address, phone, email))
                    {
                        MessageBox.Show("Sửa thành công", "Độc giả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        View();
                        inputOff();
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa thông tin! Vui lòng kiểm tra lại", "Độc giả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        
        private void cbMaKhoa_Click(object sender, EventArgs e)
        {
            int facultyID = int.Parse(cbMaKhoa.SelectedValue.ToString());
            loadClass(facultyID);
        }

        private void cbMaLop_Click(object sender, EventArgs e)
        {
            int classID = int.Parse(cbMaLop.SelectedValue.ToString());
        }
        private void loadClass(int facultyID)
        {
            docGiaBus.Instance.loadClass(cbMaLop, facultyID);
        }

        private void search()
        {
            
            try
            {
                DateTime keyDT = DateTime.ParseExact(txtSearch.Texts, "yyyy/dd/MM", System.Globalization.CultureInfo.InvariantCulture);
                docGiaBus.Instance.SearchDT(dGVListReader, keyDT);
            }
            catch
            {
                try
                {
                    int keyInt = int.Parse(txtSearch.Texts);
                    docGiaBus.Instance.SearchInt(dGVListReader, keyInt);
                }
                catch
                {
                    string key = txtSearch.Texts;
                    docGiaBus.Instance.SearchString(dGVListReader, key);
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
    }
}
