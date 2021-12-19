using MyProfileSite.Core.Entities;
using MyProfileSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProfileSite.Service.Abstract
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAll();
        bool Add(Blog euBlog);
        Task<Blog> GetBlogById(int id);
        PagedResult<Blog> GetWithPagination(Expression<Func<Blog, bool>> func, int itemsPerPage = 25,
            int currentPage = 1);
    }
}