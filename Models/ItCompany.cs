using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class ItCompany
    {
        public ItCompany()
        {
            Offices = new HashSet<Office>();
            Products = new HashSet<Product>();
        }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Range(1900, 2020, ErrorMessage = "Недопустимий рік")]
        [Display(Name = "Рік")]
        public int Year { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Office> Offices { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
