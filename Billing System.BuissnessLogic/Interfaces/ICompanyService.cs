using Billing_System.BuissnessLogic.DTO;

namespace Billing_System.BuissnessLogic.Interfaces
{
    public interface ICompanyService
    {
        void Add(CompanyToAddDTO company);
        List<CompanyToReturnDTO> GetAll();
        void DeletebyId(int id);
        void Edit(int id, CompanyToAddDTO company);
    }
}
