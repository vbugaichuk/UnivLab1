using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="Поле не повинно бути порожнім")]
        [Display(Name = "Країна")]
        public string Name { get; set; }
        [Display(Name = "Інформація про країну")]

        public virtual ICollection<City> Cities { get; set; }
    }
}
