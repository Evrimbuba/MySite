using MyProfileSite.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfileSite.Core.Entities
{
    public class SeoParameter : IEntity
    {
        public int SeoParameterId { get; set; }
        public string ParameterKey { get; set; }
        public string ParameterValue { get; set; }
        public int SeoId { get; set; }

        [ForeignKey("SeoId")]
        public virtual Seo Seo { get; set; }
    }
}