using Billing_System.BuissnessLogic.DTO.Employee;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;
using model.models;

namespace Billing_System.BuissnessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _context;
        public EmployeeService(IUnitOfWork context)
        {
            _context = context;
        }

        public void Add(EmployeeToAddDTO employee)
        {
            if (employee == null)
                throw new Exception("Employee can't be null");

            var employeeInDb = _context.Employees.GetAll().Where(e => e.Name == employee.Name).FirstOrDefault();
            if (employeeInDb != null)
                throw new Exception("Employee already exists in the database");

            _context.Employees.Add(new Employee
            {
                Name = employee.Name,
                Date = employee.Date,
                StartTime = employee.StartTime,
                EndTime = employee.EndTime
            });
            _context.Complete();
        }

        public List<EmployeeToReturnDTO> GetAll()
        {
            var employees = _context.Employees.GetAll();
            var employeesToReturn = new List<EmployeeToReturnDTO>();
            foreach (var employee in employees)
            {
                employeesToReturn.Add(new EmployeeToReturnDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Date = employee.Date,
                    StartTime = employee.StartTime,
                    EndTime = employee.EndTime
                });
            }
            return employeesToReturn;
        }

        public EmployeeToReturnDTO GetById(int id)
        {
            var employee = _context.Employees.GetById(id);
            if (employee == null)
                throw new Exception($"There is no employee in the database with Id {id}");

            return new EmployeeToReturnDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Date = employee.Date,
                StartTime = employee.StartTime,
                EndTime = employee.EndTime
            };
        }

        public void DeleteById(int id)
        {
            var employee = _context.Employees.GetById(id);
            if (employee == null)
                throw new Exception($"Employee you want to delete with id {id} does not exist in the database");

            _context.Employees.Delete(employee);
            _context.Complete();
        }

        public void Edit(int id, EmployeeToAddDTO employee)
        {
            if (employee == null)
                throw new Exception("Employee can't be null");

            var employeeInDb = _context.Employees.GetById(id);
            if (employeeInDb == null)
                throw new Exception($"No employee found with Id {id}");

            employeeInDb.Name = employee.Name;
            employeeInDb.Date = employee.Date;
            employeeInDb.StartTime = employee.StartTime;
            employeeInDb.EndTime = employee.EndTime;

            _context.Employees.Update(employeeInDb);
            _context.Complete();
        }
    }
}
