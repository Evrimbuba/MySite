using MyProfileSite.Core.Entities;
using MyProfileSite.Core.Repositories.EntityFramework;
using MyProfileSite.Data.Abstract;

namespace MyProfileSite.Data.Concrete.EntityFramework
{
    public class EfBlogsByCategoriesDal : EfEntityRepositoryBase<BlogsByCategories,ProfileSiteContext>, IBlogsByCategoriesDal
    {
    }
}