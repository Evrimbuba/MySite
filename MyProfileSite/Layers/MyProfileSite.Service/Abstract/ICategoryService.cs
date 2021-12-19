using MyProfileSite.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProfileSite.Service.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<List<Category>> GetAllWithAdvertCount();
        Task<Category> GetByLink(List<string> links);
    }
}