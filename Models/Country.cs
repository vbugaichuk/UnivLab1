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
        [StringLength(50, MinimumLength =3, ErrorMessage ="Довжина рядка повина бути від 3 до 50 символів")]
        [Display(Name = "Країна")]
        public string Name { get; set; }


        [Display(Name = "Інформація про країну")]

        public virtual ICollection<City> Cities { get; set; }
    }
}
