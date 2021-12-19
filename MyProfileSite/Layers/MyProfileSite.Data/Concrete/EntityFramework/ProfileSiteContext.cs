using Microsoft.EntityFrameworkCore;
using MyProfileSite.Core.Entities;
using MyProfileSite.Core.Repositories.EntityFramework.Contexts;

namespace MyProfileSite.Data.Concrete.EntityFramework
{
    public class ProfileSiteContext : CoreDbContext
    {
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogsByCategories> BlogsByCategories { get; set; }
        public virtual DbSet<Category> EuAdvertContacts { get; set; }
        public virtual DbSet<SeoParameter> SeoParameters { get; set; }
        public virtual DbSet<Seo> Seos { get; set; }
        public virtual DbSet<SeoType> SeoTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //   modelBuilder.ApplyConfiguration(new EuAdminsMap());
        //}
    }
}