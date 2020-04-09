using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBIT
{
    public partial class EmpSub
    {
        public int Id { get; set; }

        [Display(Name = "Заробітна плата")]
        [Required(ErrorMessage ="Поле не повинно бути порожнім")]
        public float Salary { get; set; }

        [Display(Name = "Позиція")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int PositionId { get; set; }

        [Display(Name = "Підрозділ")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int SubdivisionId { get; set; }


        [Display(Name = "Працівник")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int EmployerId { get; set; }



        public virtual Employer Employer { get; set; }
        public virtual EmpPosition Position { get; set; }
        public virtual Subdivision Subdivision { get; set; }
    }
}
