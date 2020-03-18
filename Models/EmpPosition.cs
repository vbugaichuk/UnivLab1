using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class EmpPosition
    {
        public EmpPosition()
        {
            EmpSubs = new HashSet<EmpSub>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Позиція")]
        public string Position { get; set; }

        public virtual ICollection<EmpSub> EmpSubs { get; set; }
    }
}
