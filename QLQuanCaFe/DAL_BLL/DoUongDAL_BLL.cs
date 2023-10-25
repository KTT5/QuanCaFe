using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DoUongDAL_BLL
    {
        public DoUongDAL_BLL() { }
        QLCFDataContext qlcf = new QLCFDataContext();
        public List<SanPham> GetSanPhams()
        {
            var sanphams = qlcf.SanPhams.Select(d => d).ToList();
            //(from kh in qlcf.KhachHangs select kh).ToList();
            return sanphams;
          
        }
        public List<SanPham> GetSanPhams1()
        {
            var query = from sp in qlcf.SanPhams
                        join tl in qlcf.TheLoais on sp.MaTheLoai equals tl.MaTheLoai
                        select sp;

            List<SanPham> results = query.ToList();
            return results;

        }
        public List<SanPham> GetSanPhamsTheoMa(int ma)
        {
            var khachhangs = (from kh in qlcf.SanPhams
                              where kh.MaSanPham == ma
                              select kh).ToList();

            return khachhangs;

        }
        public List<SanPham> GetSanPhamsTheoTen(string ma)
        {
            var khachhangs = (from kh in qlcf.SanPhams
                              where kh.TenSanPham == ma
                              select kh).ToList();

            return khachhangs;

        }
        public void ThemSP(string ten, decimal gia, int maloai, byte[] hinh)
        {
            SanPham sp = new SanPham();
            //.MaKhachHang = ma;
            sp.TenSanPham = ten;
            sp.GiaTien = gia;
            sp.MaTheLoai = maloai;
            sp.HinhAnh=hinh;
            qlcf.SanPhams.InsertOnSubmit(sp);
            qlcf.SubmitChanges();
        }
        public void SuaSP(int masp,string ten, decimal gia, int maloai, byte[] hinh)
        {
            SanPham spSua = qlcf.SanPhams.Where(sps => sps.MaSanPham== masp).FirstOrDefault();
            if (spSua != null)
            {
                spSua.TenSanPham = ten;
                spSua.GiaTien = gia;
                spSua.MaTheLoai = maloai;
                spSua.HinhAnh=hinh;
                qlcf.SubmitChanges();

            }
        }
        public void XoaSP(int masp)
        {
            SanPham khXoa = qlcf.SanPhams.Where(kh => kh.MaSanPham == masp).FirstOrDefault();
            if (khXoa != null)
            {
                qlcf.SanPhams.DeleteOnSubmit(khXoa);
                qlcf.SubmitChanges();
            }
        }
    }
}
