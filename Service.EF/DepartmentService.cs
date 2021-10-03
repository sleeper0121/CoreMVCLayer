﻿using Models.EF;
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

        public bool Create(Department department)
        {
            if (department != null)
            {
                _deptRepo.Add(department);
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
                _deptRepo.Delete(entity);
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
            var listData = _deptRepo.GetAll().ToList();
            return listData;
        }

        public bool Update(Department department)
        {
            try
            {
                _deptRepo.Update(department);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
