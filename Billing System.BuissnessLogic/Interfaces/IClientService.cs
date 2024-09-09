using Billing_System.BuissnessLogic.DTO.Client;

namespace Billing_System.BuissnessLogic.Interfaces
{
    public interface IClientService
    {
        void Add(ClientToAddDTO client);
        List<ClientToReturnDTO> GetAll();
        ClientToReturnDTO GetById(int id);
        void DeleteById(int id);
    }
}
