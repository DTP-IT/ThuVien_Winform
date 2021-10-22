using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus;
namespace QL_thu_vien
{
    public partial class frmLogin : Form
    {
        public int userName;
        public frmLogin()
        {
            InitializeComponent();
            lblError.Hide();
        }


        private void cBtnLogin_Click(object sender, EventArgs e)
        {
            if (cTxtUser.Texts == "")
            {
                
                lblError.Text = "Vui lòng nhập tài khoản";
                lblError.Show();
                picError.Visible = true;
            }
            else
            {
                if (cTxtPasswd.Texts == "")
                {
                    lblError.Text = "Vui lòng nhập mật khẩu";
                    lblError.Show();
                    picError.Visible = true;
                }
                else
                {
                    int user = int.Parse(cTxtUser.Texts);
                    string pass = cTxtPasswd.Texts;
                    if (loginBus.Instance.login(user, pass))
                    {
                        userName = int.Parse(cTxtUser.Texts);
                        frmHome f = new frmHome();
                        f.userName = userName;
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        picError.Visible = true;
                        lblError.Text = "Tài khoản hoặc mật khẩu không chính xác!";
                        lblError.Show();
                    }
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
