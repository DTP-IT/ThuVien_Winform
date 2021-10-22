using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class trangChuModel
    {
        private static trangChuModel instance;
        public static trangChuModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new trangChuModel();
                return instance;
            }
        }
        private trangChuModel() { }
        public int countMember(tbl_can_bo_thu_vien member)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                //int countMember = db.tbl_can_bo_thu_viens.Count(p => p);
                var countMember = from m in db.tbl_can_bo_thu_viens
                                     group m by m.maCanBo into maGr
                                     select new
                                     {
                                         Count = maGr.Count()
                                     };
                return countMember.Count();

            }

        }
            public int countReader(tbl_doc_gia reader )
            {
                using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
                {
                var countReader = from m in db.tbl_doc_gias
                                     group m by m.maThe into maGr
                                     select new
                                     {
                                         Count = maGr.Count()
                                     };
                return countReader.Count();
                  
                }
            }

            public int countBook(tbl_sach book)
            {
                using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
                {
                var countBook = from m in db.tbl_saches
                                  group m by m.maSach into maGr
                                  select new
                                  {
                                      Count = maGr.Count()
                                  };

                return countBook.Count();
                   
                }
            }
        }
}
