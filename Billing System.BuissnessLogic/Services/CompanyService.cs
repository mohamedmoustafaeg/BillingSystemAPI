using Billing_System.BuissnessLogic.DTO.Company;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;
using model.models;

namespace Billing_System.BuissnessLogic.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _context;
        public CompanyService(IUnitOfWork context)
        {
            _context = context;
        }

        public void Add(CompanyToAddDTO company)
        {
            if (company == null)
                throw new Exception("Error Company Is Null");
            var companyInDB = _context.Companies.GetAll().Where(c => c.Name == company.Name).FirstOrDefault();
            if (companyInDB != null)
                throw new Exception("Company name Already Exists in Database");
            Company companyToAdd = new Company()
            {
                Name = company.Name,
                Note = company.Note
            };
            _context.Companies.Add(companyToAdd);
            _context.Complete();
        }

        public void DeletebyId(int id)
        {
            var company = _context.Companies.GetById(id);
            if (company == null)
            {
                throw new Exception($"This id Does not exist in database {id}");
            }
            _context.Companies.Delete(company);
            _context.Complete();
        }

        public List<CompanyToReturnDTO> GetAll()
        {
            var companies = _context.Companies.GetAll();
            var companiesToReturn = new List<CompanyToReturnDTO>();
            foreach (var company in companies)
            {

                companiesToReturn.Add(new CompanyToReturnDTO()
                {

                    Id = company.Id,
                    Name = company.Name,
                    Note = company.Note
                });

            }
            return companiesToReturn;
        }
        public void Edit(int id, CompanyToAddDTO company)
        {
            if (company == null)
                throw new Exception("Error: Company is null");

            var companyInDB = _context.Companies.GetById(id);
            if (companyInDB == null)
                throw new Exception($"Company with ID {id} does not exist");

            var companyWithSameName = _context.Companies.GetAll()
                .Where(c => c.Name == company.Name && c.Id != id)
                .FirstOrDefault();

            if (companyWithSameName != null)
                throw new Exception("Another company with the same name already exists");

            companyInDB.Name = company.Name;
            companyInDB.Note = company.Note;

            _context.Companies.Update(companyInDB);
            _context.Complete();
        }
        public CompanyToReturnDTO GetById(int id)
        {

            var company = _context.Companies.GetById(id);
            return new CompanyToReturnDTO
            {
                Id = company.Id,
                Name = company.Name,
                Note = company.Note
            };
        }
    }
}
