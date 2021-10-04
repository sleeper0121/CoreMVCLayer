using Models.EF;
using Omu.ValueInjecter;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.EF
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _CourseRepo;
        public CourseService(IRepository<Course> CourseRepo)
        {
            this._CourseRepo = CourseRepo;
        }
        public bool Create(Course Course)
        {
            if (Course != null)
            {
                _CourseRepo.Add(Course);
                _CourseRepo.UnitOfWork.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _CourseRepo.Find(s => s.CourseId == id);
                _CourseRepo.Delete(entity);
                _CourseRepo.UnitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Course FindById(int id)
        {
            var data = _CourseRepo.Find(s => s.CourseId == id);
            return data;
        }

        public List<Course> GetAll()
        {
            var listData = _CourseRepo.GetAll().ToList();
            return listData;
        }

        public bool Update(Course Course)
        {
            try
            {
                _CourseRepo.Update(Course);
                _CourseRepo.UnitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool BatchEdit(IList<CourseUpdateVM> list)
        {
            try
            {
                foreach (var course in list)
                {
                    var ori = this.FindById(course.CourseId);
                    ori.InjectFrom(course);
                }
                _CourseRepo.UnitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          
        }
    }


}
