using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListById(int id);
        void ContentAddBl(Content content);

        Content GetbyId(int id);
        void ContentDeleteBl(Content content);
        void ContentUpdateBl(Content content);
    }
}
