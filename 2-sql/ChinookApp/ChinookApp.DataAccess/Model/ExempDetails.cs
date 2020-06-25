using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class ExempDetails
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Exemployee Employee { get; set; }
    }
}
