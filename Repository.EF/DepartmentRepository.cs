using Microsoft.EntityFrameworkCore;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.EF
{
    public class DepartmentRepository : IRepository<Department>
    {
        //public readonly ContosoUniversityContext _dbContext;

        public IUnitOfWork UnitOfWork { get; set; }
        public ContosoUniversityContext _dbContext { get; set; }

        private DbSet<Department> _objectset;
        private DbSet<Department> ObjectSet
        {
            get
            {
                if (_objectset == null)
                {
                    _objectset = UnitOfWork.Context.Set<Department>();
                }
                return _objectset;
            }
        }

        public DepartmentRepository(ContosoUniversityContext dbContext)
        {
            UnitOfWork = new EFUnitOfWork();
            _dbContext = dbContext;
        }

        public DepartmentRepository()
        {
            UnitOfWork = new EFUnitOfWork();
        }
        public DepartmentRepository(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }
        public void Add(Department entity)
        {
            UnitOfWork.Context.Add(entity);
            //_dbContext.Departments.Add(entity);
            //_dbContext.SaveChanges();
        }
        public void Update(Department entity)
        {
            //_dbContext.Departments.Update(entity);
            //_dbContext.SaveChanges();
            ObjectSet.Update(entity);
        }
        public void Delete(Department entity)
        {
            //_dbContext.Departments.Remove(entity);
            //_dbContext.SaveChanges();
            ObjectSet.Remove(entity);
        }

        public Department Find(Expression<Func<Department, bool>> where)
        {
            //return _dbContext.Departments.Where(where).FirstOrDefault();
            return ObjectSet.Where(where).FirstOrDefault();
        }
        public IEnumerable<Department> FindAll(Expression<Func<Department, bool>> where)
        {
            return ObjectSet.Where(where);
        }

        public Department Get(long id)
        {
            return ObjectSet.SingleOrDefault(b => b.DepartmentId == id);
        }

        public IEnumerable<Department> GetAll()
        {
            return ObjectSet.Include(c => c.Instructor).ToList();
        }
    }
}
