using MyProfileSite.Core.Entities;
using MyProfileSite.Data.Abstract;
using MyProfileSite.Service.Abstract;
using MyProfileSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProfileSite.Service.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IBlogsByCategoriesDal _blogsByCategoriesDal;

        public BlogManager(IBlogDal blogDal, IBlogsByCategoriesDal blogsByCategoriesDal)
        {
            _blogDal = blogDal;
            _blogsByCategoriesDal = blogsByCategoriesDal;
        }

        public bool Add(Blog blog)
        {
            return _blogDal.AddAsync(blog);
        }

        public async Task<List<Blog>> GetAll()
        {
            return await _blogDal.GetAllAsync(filter: x => x.IsActive);
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _blogDal.Get(filter: x => x.BlogId == id && x.IsActive,
                select: x => new Blog
                {
                    BlogId = x.BlogId,
                    Title = x.Title,
                    BannerImage = x.BannerImage,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    IsCommentActive = x.IsCommentActive,
                    Seo = x.Seo,
                    Summary = x.Summary,
                    SeoId = x.SeoId,
                    BlogsByCategories = (ICollection<BlogsByCategories>)x.BlogsByCategories
                }
            );
        }

        public PagedResult<Blog> GetWithPagination(Expression<Func<Blog, bool>> func, int itemsPerPage = 25,
            int currentPage = 1)
        {
            var count = _blogDal.Count(func);
            var pageItems = _blogDal.GetAllAsync(filter: func,
                orderby: x => x.BlogId,
                activePage: currentPage - 1,
                recordCount: itemsPerPage, disableTracking: true).Result;
            var result = new PagedResult<Blog>(pageItems, count, itemsPerPage, currentPage);
            return result;
        }
    }
}