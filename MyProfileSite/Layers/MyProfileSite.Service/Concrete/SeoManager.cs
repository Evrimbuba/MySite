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
    public class SeoManager : ISeoService
    {
        private readonly ISeoDal _seoDal;
        private readonly ISeoParameterDal _seoParameterDal;

        public SeoManager(ISeoDal seoDal, ISeoParameterDal seoParameterDal)
        {
            _seoDal = seoDal;
            _seoParameterDal = seoParameterDal;
        }

        public bool Add(Seo seo)
        {
            return _seoDal.AddAsync(seo);
        }

        public bool Add(SeoParameter seoParameter)
        {
            return _seoParameterDal.AddAsync(seoParameter);
        }

        public void AddRangeAsync(IEnumerable<SeoParameter> seoParameters)
        {
            _seoParameterDal.AddRangeAsync(seoParameters);
        }

        public void Delete(Seo seo)
        {
            _seoDal.Delete(seo);
        }

        public void Delete(SeoParameter seoParameter)
        {
            _seoParameterDal.Delete(seoParameter);
        }

        public int DeleteRange(IEnumerable<SeoParameter> seoParameters)
        {
            return _seoParameterDal.DeleteRange(seoParameters);
        }

        public Task<List<Seo>> GetAll()
        {
            return _seoDal.GetAllAsync();
        }

        public Task<List<SeoParameter>> GetAllSeoParameter()
        {
            return _seoParameterDal.GetAllAsync();
        }

        public PagedResult<Seo> GetWithPagination(Expression<Func<Seo, bool>> func, int itemsPerPage = 25, int currentPage = 1)
        {
            var count = _seoDal.Count(func);
            var pageItems = _seoDal.GetAllAsync(filter: func,
                orderby: x => x.SeoId,
                activePage: currentPage - 1,
                recordCount: itemsPerPage, disableTracking: true).Result;
            var result = new PagedResult<Seo>(pageItems, count, itemsPerPage, currentPage);
            return result;
        }

        public PagedResult<SeoParameter> GetWithPagination(Expression<Func<SeoParameter, bool>> func, int itemsPerPage = 25, int currentPage = 1)
        {
            var count = _seoParameterDal.Count(func);
            var pageItems = _seoParameterDal.GetAllAsync(filter: func,
                orderby: x => x.SeoId,
                activePage: currentPage - 1,
                recordCount: itemsPerPage, disableTracking: true).Result;
            var result = new PagedResult<SeoParameter>(pageItems, count, itemsPerPage, currentPage);
            return result;
        }

        public bool Update(Seo seo)
        {
            return _seoDal.Update(seo);
        }

        public bool Update(SeoParameter seoParameter)
        {
            return _seoParameterDal.Update(seoParameter);
        }
    }
}