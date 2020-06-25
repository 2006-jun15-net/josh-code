using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class Exdepartment
    {
        public Exdepartment()
        {
            Exemployee = new HashSet<Exemployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Exemployee> Exemployee { get; set; }
    }
}
