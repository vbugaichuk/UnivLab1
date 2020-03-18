using System;
using System.Collections.Generic;

namespace DBIT
{
    public partial class EmpSub
    {
        public int Id { get; set; }
        public float Salary { get; set; }
        public int PositionId { get; set; }
        public int SubdivisionId { get; set; }
        public int EmployerId { get; set; }

        public virtual Employer Employer { get; set; }
        public virtual EmpPosition Position { get; set; }
        public virtual Subdivision Subdivision { get; set; }
    }
}
