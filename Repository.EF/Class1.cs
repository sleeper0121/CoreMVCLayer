using Microsoft.EntityFrameworkCore;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF
{
	public interface IUnitOfWork
	{
		DbContext Context { get; set; }
		void Commit();
	}

	public class EFUnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public EFUnitOfWork()
		{
			Context = new ContosoUniversityContext();
		}

		public void Commit()
		{
			Context.SaveChanges();
		}
	}

	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}

		public static DepartmentRepository GetDepartmentRepository()
		{
			var repository = new DepartmentRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static DepartmentRepository GetDepartmentRepository(IUnitOfWork unitOfWork)
		{
			var repository = new DepartmentRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}
	}
}
