using MyProfileSite.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MyProfileSite.Core.Entities
{
    public class SeoType : IEntity
    {
        public int SeoTypeId { get; set; }
        [Display(Name = "Area Adı")]
        public string AreaName { get; set; }
        [Display(Name = "Controller Adı")]
        [Required(ErrorMessage = "Controller Adı zorunlu alan.")]
        public string ControllerName { get; set; }
        [Display(Name = "Action Adı")]
        [Required(ErrorMessage = "Action Adı zorunlu alan.")]
        public string ActionName { get; set; }
        [Display(Name = "Link Tipi Adı")]
        [Required(ErrorMessage = "Link Tipi Adı zorunlu alan.")]
        public string SeoTypeName { get; set; }
    }
}