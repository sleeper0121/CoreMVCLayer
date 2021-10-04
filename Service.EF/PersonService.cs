using Models.EF;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.EF
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepo;
        public PersonService(IRepository<Person> deptRepo)
        {
            this._personRepo = deptRepo;
        }
        public bool Create(Person Person)
        {
            if (Person != null)
            {
                _personRepo.Add(Person);
                _personRepo.UnitOfWork.Commit();
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
                var entity = _personRepo.Find(s => s.Id == id);
                _personRepo.Delete(entity);
                _personRepo.UnitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Person FindById(int id)
        {
            var data = _personRepo.Find(s => s.Id == id);
            return data;
        }

        public List<Person> GetAll()
        {
            var listData = _personRepo.GetAll().ToList();
            return listData;
        }

        public bool Update(Person Person)
        {
            try
            {
                _personRepo.Update(Person);
                _personRepo.UnitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
