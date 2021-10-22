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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            lblCountMember.Text = trangChuBus.Instance.countMember().ToString();
            lblCountReader.Text = trangChuBus.Instance.countReader().ToString();
            lblCountBook.Text = trangChuBus.Instance.countBook().ToString();
        }
    }
}
