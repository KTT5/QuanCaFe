using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class ToppingDAL_BLL
    {
        public ToppingDAL_BLL() { }
        QLCFDataContext qlcf = new QLCFDataContext();
        
        public List<Topping> getToppping()
        {
            var khachhangs = qlcf.Toppings.Select(d => d).ToList();
            //(from kh in qlcf.KhachHangs select kh).ToList();
            return khachhangs;
        }
        public List<Topping> getToppingTheoMa(int makh)
        {
            var khachhangs = (from kh in qlcf.Toppings
                              where kh.MaTopping == makh
                              select kh).ToList();

            return khachhangs;
        }
    }
}
