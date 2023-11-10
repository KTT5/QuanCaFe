using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDonDAL_BLL
    {
        public HoaDonDAL_BLL()
        {

        }
        QLCFDataContext qlcf = new QLCFDataContext();
        public void ThemHoaDon(DonHang dh1)
        {
            DonHang dh = new DonHang();
            dh.MaKhachHang = dh1.MaKhachHang;
            dh.MaNhanVien=dh1.MaNhanVien;
            dh.NgayDatHang= dh1.NgayDatHang;
            dh.TongTien=dh1.TongTien;
            qlcf.DonHangs.InsertOnSubmit(dh);
            qlcf.SubmitChanges();
        }
        public int LayMaDH()
        {
            int maxMaDonHang = qlcf.DonHangs.Max(dh => dh.MaDonHang);
            return maxMaDonHang;
        }
    }
}
