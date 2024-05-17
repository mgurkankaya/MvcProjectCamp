using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void HeadingAddBl(Heading heading);
        Heading GetbyId(int id);
        void HeadingDeleteBl(Heading heading);
        void HeadingUpdateBl(Heading heading);
    }
}
