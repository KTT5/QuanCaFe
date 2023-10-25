using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class TheLoaiDAL_BLL
    {
        public TheLoaiDAL_BLL() { }
        QLCFDataContext qlcf = new QLCFDataContext();
        public List<TheLoai> getTheLoai()
        {
            var khachhangs = qlcf.TheLoais.Select(d => d).ToList();
            //(from kh in qlcf.KhachHangs select kh).ToList();
            return khachhangs;
        }
    }
}
