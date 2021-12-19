using MyProfileSite.Core.Entities;
using MyProfileSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProfileSite.Service.Abstract
{
    public interface ISeoService
	{
		Task<List<Seo>> GetAll();
		bool Add(Seo seo);
		bool Update(Seo seo);
		void Delete(Seo seo);
		PagedResult<Seo> GetWithPagination(Expression<Func<Seo, bool>> func, int itemsPerPage = 25,
			int currentPage = 1);

		Task<List<SeoParameter>> GetAllSeoParameter();
		bool Add(SeoParameter seoParameter);
		void AddRangeAsync(IEnumerable<SeoParameter> seoParameter);
		bool Update(SeoParameter seoParameter);
		void Delete(SeoParameter seoParameter);
		int DeleteRange(IEnumerable<SeoParameter> seoParameters);
		PagedResult<SeoParameter> GetWithPagination(Expression<Func<SeoParameter, bool>> func, int itemsPerPage = 25,
			int currentPage = 1);
	}
}