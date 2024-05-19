using BLL.Interfaces;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Department Entity)
        {
            _dbContext.Add(Entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department Entity)
        {
            _dbContext.Departments.Remove(Entity);
            return _dbContext.SaveChanges();
        }


        public int Update(Department Entity)
        {
            _dbContext.Departments.Update(Entity);
            return _dbContext.SaveChanges() ;
        }


        public Department GetById(int id)
        {
            //var department = _dbContext.Departments.Local.Where(D => D.Id == id).FirstOrDefault();
            //if (department is null)
            //    department = _dbContext.Departments.Local.Where(D => D.Id == id).FirstOrDefault();
            //return department;

            //return _dbContext.Departments.Find(id);
            return _dbContext.Find<Department>(id);

        }

        public IEnumerable<Department> GetAll()
            => _dbContext.Departments.AsNoTracking().ToList();
    }
}
