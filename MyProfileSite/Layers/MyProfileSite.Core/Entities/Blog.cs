using MyProfileSite.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfileSite.Core.Entities
{
    public class Blog : IEntity
    {
        public Blog()
        {
            BlogsByCategories = new HashSet<BlogsByCategories>();
        }

        public int BlogId { get; set; }
        public string Content { get; set; }
        public int SeoId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string BannerImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsCommentActive { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("SeoId")]
        public Seo Seo { get; set; }
        public ICollection<BlogsByCategories> BlogsByCategories { get; set; }
    }
}
