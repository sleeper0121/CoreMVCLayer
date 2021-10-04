using Microsoft.EntityFrameworkCore;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.EF
{
    public class PersonRepository : IRepository<Person>
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ContosoUniversityContext _dbContext { get; set; }

        private DbSet<Person> _objectset;
        private DbSet<Person> ObjectSet
        {
            get
            {
                if (_objectset == null)
                {
                    _objectset = UnitOfWork.Context.Set<Person>();
                }
                return _objectset;
            }
        }

        public PersonRepository(ContosoUniversityContext dbContext)
        {
            UnitOfWork = new EFUnitOfWork();
            _dbContext = dbContext;
        }

        public PersonRepository()
        {
            UnitOfWork = new EFUnitOfWork();
        }
        public PersonRepository(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }
        public void Add(Person entity)
        {
            UnitOfWork.Context.Add(entity);
        }
        public void Update(Person entity)
        {
            ObjectSet.Update(entity);
        }
        public void Delete(Person entity)
        {
            ObjectSet.Remove(entity);
        }

        public Person Find(Expression<Func<Person, bool>> where)
        {
            return ObjectSet.Where(where).FirstOrDefault();
        }
        public IEnumerable<Person> FindAll(Expression<Func<Person, bool>> where)
        {
            return ObjectSet.Where(where);
        }

        public Person Get(long id)
        {
            return ObjectSet.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return ObjectSet.ToList();
        }
    }
}
