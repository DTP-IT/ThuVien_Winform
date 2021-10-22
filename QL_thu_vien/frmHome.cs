using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
namespace QL_thu_vien
{
    public partial class frmHome : Form
    {
        public int userName;
        public frmHome()
        {
            InitializeComponent();
            this.palContent.Controls.Clear();
            frmTrangChu frm_DashBoard = new frmTrangChu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm_DashBoard.FormBorderStyle = FormBorderStyle.None;
            this.palContent.Controls.Add(frm_DashBoard);
            frm_DashBoard.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            profileBus.Instance.profile(userName, lblUserName) ; 
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            this.Text = "Sách";
            this.palContent.Controls.Clear();
            frmQuanLySach frm_Book = new frmQuanLySach() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true};
            frm_Book.FormBorderStyle = FormBorderStyle.None;
            this.palContent.Controls.Add(frm_Book);
            frm_Book.Show();
        }

        private void btnQuanLyDocGia_Click(object sender, EventArgs e)
        {
            this.Text = "Độc giả";
            this.palContent.Controls.Clear();
            frmQuanLyDocGia frm_Reader = new frmQuanLyDocGia() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm_Reader.FormBorderStyle = FormBorderStyle.None;
            this.palContent.Controls.Add(frm_Reader);
            frm_Reader.Show();
        }

        private void btnQuanLyMuonTra_Click(object sender, EventArgs e)
        {
            this.Text = "Mượn trả";
            this.palContent.Controls.Clear();
            frmQuanLyMuonTra frm_Bo_Re = new frmQuanLyMuonTra() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm_Bo_Re.FormBorderStyle = FormBorderStyle.None;
            this.palContent.Controls.Add(frm_Bo_Re);
            frm_Bo_Re.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Nhân viên";
            this.palContent.Controls.Clear();
            frmQuanLyCanBo frm_Member = new frmQuanLyCanBo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm_Member.FormBorderStyle = FormBorderStyle.None;
            this.palContent.Controls.Add(frm_Member);
            frm_Member.Show();
            
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            this.Text = "Trang chủ";
            this.palContent.Controls.Clear();
            frmTrangChu frm_DashBoard = new frmTrangChu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true};
            frm_DashBoard.FormBorderStyle = FormBorderStyle.None;
            this.palContent.Controls.Add(frm_DashBoard);
            frm_DashBoard.Show();
           
        }
    }
}
