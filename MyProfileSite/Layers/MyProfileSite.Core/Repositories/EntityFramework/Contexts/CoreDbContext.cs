using Ganss.XSS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace MyProfileSite.Core.Repositories.EntityFramework.Contexts
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (Core.IsLocal)
            {
                configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

            }
            optionsBuilder.UseSqlServer(configurationRoot["ConnectionString"]);
            if (Core.IsLocal)
            {
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                var changedEntities = ChangeTracker
                        .Entries()
                        .Where(_ => _.State == EntityState.Added ||
                                    _.State == EntityState.Modified);
                IHtmlSanitizer htmlSanitizer = new HtmlSanitizer();

                foreach (var e in changedEntities)
                {
                    var z = e.Properties.Where(x => x.CurrentValue != null && x.Metadata.ClrType == typeof(string));
                    foreach (var item in z)
                    {
                        string val = htmlSanitizer.Sanitize(item.CurrentValue.ToString());
                        if (val.Length < item.Metadata.GetMaxLength())
                            item.CurrentValue = val;
                        else
                            item.CurrentValue = val.Substring(0, item.Metadata.GetMaxLength().Value);
                    }
                }
            }
            catch (Exception ex)
            {
                var hata = ex;
                return 0;
            }
            return base.SaveChanges();
        }
    }
}
