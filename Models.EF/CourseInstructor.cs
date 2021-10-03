﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Models.EF
{
    public partial class CourseInstructor
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Instructor { get; set; }
    }
}
