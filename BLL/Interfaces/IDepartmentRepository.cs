using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        // here we make add, update and delete with int to return number of recored that has been affected
        int Add (Department Entity);
        int Update (Department Entity);
        int Delete (Department Entity);
    }
}
