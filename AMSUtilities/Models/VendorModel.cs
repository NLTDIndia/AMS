using System;
using System.ComponentModel.DataAnnotations;

namespace AMSUtilities.Models
{
    public class VendorModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Vendor Name required")]
        [StringLength(400)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address required")]
        [StringLength(4000)]
        public string Address { get; set; }

        [Required(ErrorMessage = "EmailID required")]
        [StringLength(400)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Number required")]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Contact Number.")]
        [StringLength(10)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Contact Person required")]
        [Display(Name = "Contact Person")]
        [StringLength(400)]
        public string ContactPerson { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage = "CreatedBy required")]
        public int CreatedBy { get; set; }
    }
}