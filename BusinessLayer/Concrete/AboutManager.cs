using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAddBl(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDeleteBl(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdateBl(About about)
        {
            _aboutDal.Update(about);
        }

        public About GetbyId(int id)
        {
            return _aboutDal.Get(x=>x.AboutId==id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }
    }


}
