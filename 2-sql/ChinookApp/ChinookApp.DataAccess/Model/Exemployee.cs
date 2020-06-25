using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class Exemployee
    {
        public Exemployee()
        {
            ExempDetails = new HashSet<ExempDetails>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public int DeptId { get; set; }

        public virtual Exdepartment Dept { get; set; }
        public virtual ICollection<ExempDetails> ExempDetails { get; set; }
    }
}
