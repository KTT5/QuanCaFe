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
    }
}
