using MyProfileSite.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfileSite.Core.Entities
{
    public class Category : IEntity
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string MainCategoryId { get; set; }
        public string CategoryLogoImage { get; set; }
        public string CssClassName { get; set; }

        [ForeignKey("MainCategoryId")]
        public Category MainCategory { get; set; }
    }
}