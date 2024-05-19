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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext) 
        {
           _dbContext = dbContext;
        }
        public int Add(Employee Entity)
        {
            _dbContext.Add(Entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Employee Entitiy)
        {
            _dbContext.Employees.Remove(Entitiy);
            return _dbContext.SaveChanges();
        }
        public int Update(Employee Entity)
        {
            _dbContext.Update(Entity);
            return (_dbContext.SaveChanges());
        }

        public IEnumerable<Employee> GetAll()
            => _dbContext.Employees.Include(E=>E.Department).AsNoTracking().ToList();

        public Employee GetById(int id)
        {
            return _dbContext.Find<Employee>(id);
        }


    }
}
