using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class Product
    {
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Продукт")]
        public string Name { get; set; }
        public int Year { get; set; }
        public int Budget { get; set; }
        public int ItCompanyId { get; set; }
        public int Id { get; set; }

        public virtual ItCompany ItCompany { get; set; }
    }
}
