using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_System.BuissnessLogic.DTO.Employee;

namespace Billing_System.BuissnessLogic.Interfaces
{
    public interface IEmployeeService
    {
        void Add(EmployeeToAddDTO employee);
        List<EmployeeToReturnDTO> GetAll();
        //IEnumerable<EmployeeToReturnDTO> GetAll();
        EmployeeToReturnDTO GetById(int id);
        void DeleteById(int id);
        void Edit(int id, EmployeeToAddDTO employee);
    }
}
