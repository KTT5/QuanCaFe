using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class KhachHangDAL_BLL
    {
        public KhachHangDAL_BLL() { }
        QLCFDataContext qlcf = new QLCFDataContext();
        
        public List<KhachHang> getKhachHang()
        {
            var khachhangs = (from kh in qlcf.KhachHangs select kh).ToList();
            return khachhangs;
        }
        public List<KhachHang> getKhachHangTheoMa(int makh)
        {
            var khachhangs = (from kh in qlcf.KhachHangs
                              where kh.MaKhachHang == makh
                              select kh).ToList();

            return khachhangs;
        }
    }
}
