using System;
using System.Collections.Generic;

#nullable disable

namespace Models.EF
{
    public partial class DepartmentEditVM
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public int? InstructorId { get; set; }
    }
}
