using Models.EF;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.EF
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _deptRepo;
        public DepartmentService(IRepository<Department> deptRepo)
        {
            this._deptRepo = deptRepo;
        }
        //public DepartmentService()
        //{
        //    this._deptRepo = RepositoryHelper.GetDepartmentRepository();
        //}
        public bool Create(Department department)
        {
            if (department != null)
            {
                _deptRepo.Add(department);
                _deptRepo.UnitOfWork.Commit();
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
                var entity = _deptRepo.Find(s => s.DepartmentId == id);
                entity.IsDeleted = true;
                _deptRepo.UnitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Department FindById(int id)
        {
            var data = _deptRepo.Find(s => s.DepartmentId == id);
            return data;
        }

        public List<Department> GetAll()
        {
            var listData = _deptRepo.GetAll().Where(p=>p.IsDeleted != true).ToList();
            return listData;
        }

        public bool Update(Department department)
        {
            try
            {
                _deptRepo.Update(department);
                _deptRepo.UnitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
