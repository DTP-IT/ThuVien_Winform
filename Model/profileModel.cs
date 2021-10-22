using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class profileModel
    {
        private static profileModel instance;
        public static profileModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new profileModel();
                return instance;
            }
        }
        private profileModel() { }

        public string profile(int userName)
        {
            QuanLyThuVienDataContext db = new QuanLyThuVienDataContext();
            var adname = from member in db.tbl_can_bo_thu_viens
                         where member.maCanBo == userName
                         select member;
            foreach (var member in adname)
            {
                return member.tenCanBo.ToString();
            }
            return null;
        }
    }
}
