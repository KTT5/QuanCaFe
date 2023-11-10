using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class CTTopping
    {
        public CTTopping() { }  
        QLCFDataContext qlcf = new QLCFDataContext();
        public void ThemCTTopping(ChiTietTopping cdtp1)
        {
            ChiTietTopping cttp = new ChiTietTopping();
            cttp.MaDonHang = cdtp1.MaDonHang;
            cttp.MaTopping = cdtp1.MaTopping;
            cttp.SoLuong = cdtp1.SoLuong;
            qlcf.ChiTietToppings.InsertOnSubmit(cttp);
            qlcf.SubmitChanges();
        }
    }
}
