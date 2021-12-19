using MyProfileSite.Core.Entities;
using MyProfileSite.Data.Abstract;
using MyProfileSite.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProfileSite.Service.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryDal.GetAllAsync();
        }

        public async Task<List<Category>> GetAllWithAdvertCount()
        {
            return await _categoryDal.GetAllAsync(select: x => new Category { Name = x.Name, CategoryId = x.CategoryId },orderby: x => new Guid());
        }

        public async Task<Category> GetByLink(List<string> links)
        {
            return await _categoryDal.Get(filter: x => links.Contains(x.Link));
        }
    }
}