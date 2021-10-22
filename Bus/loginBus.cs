using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
namespace Bus
{
    public class loginBus
    {
        private static loginBus instance;
        public static loginBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new loginBus();
                return instance;
            }
        }
        private loginBus() { }

       
        public bool login(int user, string passwd)
        {
            tbl_can_bo_thu_vien userBus = new tbl_can_bo_thu_vien();
            userBus.maCanBo = user;
            userBus.matKhau = passwd;
            return loginModel.Instance.login(user, passwd, userBus);
        }
     
    }
}
