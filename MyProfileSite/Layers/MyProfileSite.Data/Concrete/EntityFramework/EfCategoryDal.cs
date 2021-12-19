using MyProfileSite.Core.Entities;
using MyProfileSite.Core.Repositories.EntityFramework;
using MyProfileSite.Data.Abstract;

namespace MyProfileSite.Data.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ProfileSiteContext>, ICategoryDal
    {
    }
}