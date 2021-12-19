using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfileSite.Core.Entities
{
    public class Seo
    {
        public int SeoId { get; set; }
        public int SeoTypeId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        [ForeignKey("SeoTypeId")]
        public virtual SeoType SeoType { get; set; }
        public ICollection<SeoParameter> SeoParameters { get; set; }
    }
}