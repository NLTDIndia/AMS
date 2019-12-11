using System.ComponentModel.DataAnnotations;

namespace AMSUtilities.Models
{
    public class AssetCategoryModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
    }
}