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


        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Passport { get; set; }


        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Range(1900, 2020, ErrorMessage = "Недопустимий рік")]
        public int Year { get; set; }
        public int Id { get; set; }


        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Education { get; set; }


        public virtual ICollection<EmpSub> EmpSubs { get; set; }
    }
}
