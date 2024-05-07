using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentdal;

        public ContentManager(IContentDal contentdal)
        {
            _contentdal = contentdal;
        }

        public void ContentAddBl(Content content)
        {
            _contentdal.Insert(content);
        }

        public void ContentDeleteBl(Content content)
        {
            _contentdal.Delete(content);
        }

        public void ContentUpdateBl(Content content)
        {
            _contentdal.Update(content);
        }

        public Content GetbyId(int id)
        {
            return _contentdal.Get(x=>x.ContentId==id);
        }

        public List<Content> GetList()
        {
            return _contentdal.List();
        }

        public List<Content> GetListById(int id)
        {
            return _contentdal.List(x=>x.HeadingId==id);
        }
    }
}
