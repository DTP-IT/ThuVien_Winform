using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class loginModel
    {
        private static loginModel instance;
        public static loginModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new loginModel();
                return instance;
            }
        }
        public loginModel() { 
        }

        public bool login(int user, string passwd, tbl_can_bo_thu_vien users)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                int count = db.tbl_can_bo_thu_viens.Count(p => p.maCanBo == user && p.matKhau == passwd);
                if (count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
