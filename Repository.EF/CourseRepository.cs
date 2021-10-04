using Microsoft.EntityFrameworkCore;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.EF
{
    public class CourseRepository : IRepository<Course>
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ContosoUniversityContext _dbContext { get; set; }

        private DbSet<Course> _objectset;
        private DbSet<Course> ObjectSet
        {
            get
            {
                if (_objectset == null)
                {
                    _objectset = UnitOfWork.Context.Set<Course>();
                }
                return _objectset;
            }
        }

        public CourseRepository(ContosoUniversityContext dbContext)
        {
            UnitOfWork = new EFUnitOfWork();
            _dbContext = dbContext;
        }

        public CourseRepository()
        {
            UnitOfWork = new EFUnitOfWork();
        }
        public CourseRepository(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }
        public void Add(Course entity)
        {
            UnitOfWork.Context.Add(entity);
        }
        public void Update(Course entity)
        {
            ObjectSet.Update(entity);
        }
        public void Delete(Course entity)
        {
            ObjectSet.Remove(entity);
        }

        public Course Find(Expression<Func<Course, bool>> where)
        {
            return ObjectSet.Where(where).FirstOrDefault();
        }
        public IEnumerable<Course> FindAll(Expression<Func<Course, bool>> where)
        {
            return ObjectSet.Where(where);
        }

        public Course Get(long id)
        {
            return ObjectSet.SingleOrDefault(b => b.CourseId == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return ObjectSet.Include(c => c.Department).ToList();
        }
    }
}
