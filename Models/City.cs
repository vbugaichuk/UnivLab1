using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class City
    {
        public City()
        {
            Offices = new HashSet<Office>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Місто")]
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
    }
}
