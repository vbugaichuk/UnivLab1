using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class Office
    {
        public Office()
        {
            Subdivisions = new HashSet<Subdivision>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public float Square { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Адреса")]
        public string Address { get; set; }
        public int ItCompanyId { get; set; }

        public virtual City City { get; set; }
        public virtual ItCompany ItCompany { get; set; }
        public virtual ICollection<Subdivision> Subdivisions { get; set; }
    }
}
