﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

 

        public void CategoryAddBl(Category category)
        {
           _categorydal.Insert(category);
        }

        public void CategoryDeleteBl(Category category)
        {
            
            _categorydal.Delete(category);
        }

        public void CategoryUpdateBl(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetbyId(int id)
        {
            return _categorydal.Get(x=>x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }
    }
}
