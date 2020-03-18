using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class Employer
    {
        public Employer()
        {
            EmpSubs = new HashSet<EmpSub>();
        }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Працівник")]
        public string Name { get; set; }
        public string Passport { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
        public string Education { get; set; }

        public virtual ICollection<EmpSub> EmpSubs { get; set; }
    }
}
