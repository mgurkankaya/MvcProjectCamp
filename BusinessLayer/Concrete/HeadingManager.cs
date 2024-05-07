﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetbyId(int id)
        {
            return _headingDal.Get(x=>x.HeadingId==id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public void HeadingAddBl(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDeleteBl(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdateBl(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
