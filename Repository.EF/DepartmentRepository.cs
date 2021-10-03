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
        public readonly ContosoUniversityContext _dbContext;

        public DepartmentRepository(ContosoUniversityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Department Find(Expression<Func<Department, bool>> where)
        {
            return _dbContext.Departments.Where(where).FirstOrDefault();
        }
        public IEnumerable<Department> FindAll(Expression<Func<Department, bool>> where)
        {
            return _dbContext.Departments.Where(where);
        }

        public Department Get(long id)
        {
            return _dbContext.Departments.SingleOrDefault(b => b.DepartmentId == id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.Include(c => c.Instructor).ToList();
        }
    }
}
