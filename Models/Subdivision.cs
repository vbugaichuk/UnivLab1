using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class Subdivision
    {
        public Subdivision()
        {
            EmpSubs = new HashSet<EmpSub>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Підрозділ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Офіс")]
        public int OfficeId { get; set; }

        public virtual Office Office { get; set; }
        public virtual ICollection<EmpSub> EmpSubs { get; set; }
    }
}
