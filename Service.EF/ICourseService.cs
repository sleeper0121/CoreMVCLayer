using Models.EF;
using System;
using System.Collections.Generic;

namespace Service.EF
{
    public interface ICourseService : IBaseService<Course>
    {
        bool BatchEdit(IList<CourseUpdateVM> list);
    }
}
