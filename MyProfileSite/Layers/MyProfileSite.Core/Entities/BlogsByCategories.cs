using MyProfileSite.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfileSite.Core.Entities
{
    public class BlogsByCategories : IEntity
    {
        public int BlogsByCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int BlogId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
    }
}