using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Bus
{
    public class trangChuBus
    {
        private static trangChuBus instance;
        public static trangChuBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new trangChuBus();
                return instance;
            }
        }
        private trangChuBus() { }

        public int countMember()
        {
            tbl_can_bo_thu_vien member = new tbl_can_bo_thu_vien();;
            return trangChuModel.Instance.countMember(member);
        }
        public int countReader()
        {
            
            tbl_doc_gia reader = new tbl_doc_gia();

            return trangChuModel.Instance.countReader(reader);
        }
        public int countBook()
        {
            tbl_sach book = new tbl_sach();
            return trangChuModel.Instance.countBook(book);
        }
    }
}
