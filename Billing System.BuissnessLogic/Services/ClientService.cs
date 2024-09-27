using Billing_System.BuissnessLogic.DTO.Client;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;
using model.models;

namespace Billing_System.BuissnessLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _context;
        public ClientService(IUnitOfWork context)
        {
            _context = context;
        }
        public void Add(ClientToAddDTO client)
        {
            if (client == null)
                throw new Exception("Client Cant Be Null");
            var clientinDb = _context.Clients.GetAll().Where(c => c.Name.ToLower() == client.Name.ToLower()).FirstOrDefault();
            if (clientinDb != null)
                throw new Exception("Client already exists in database");
            _context.Clients.Add(new Client
            {
                Name = client.Name,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address

            });
            _context.Complete();
        }

        public List<ClientToReturnDTO> GetAll()
        {
            var clients = _context.Clients.GetAll();
            var clientstoReturn = new List<ClientToReturnDTO>();
            foreach (var client in clients)
            {
                clientstoReturn.Add(new ClientToReturnDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    PhoneNumber = client.PhoneNumber,
                    Address = client.Address
                });
            }
            return clientstoReturn;
        }
        public ClientToReturnDTO GetById(int id)
        {
            var client = _context.Clients.GetById(id);
            if (client == null)
                throw new Exception($"There is no client in database with Id {id}");
            return new ClientToReturnDTO
            {
                Id = client.Id,
                Name = client.Name,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address
            };
        }
        public void DeleteById(int id)
        {
            var client = _context.Clients.GetById(id);
            if (client == null)
                throw new Exception($"Client you want do delete with id {id} does not exist in database ");
            _context.Clients.Delete(client);
            _context.Complete();
        }
        public void Edit(int id, ClientToAddDTO client)
        {
            if (client == null)
                throw new Exception("Client can't be null");

            var clientInDb = _context.Clients.GetById(id);
            if (clientInDb == null)
                throw new Exception($"No client found with Id {id}");

            clientInDb.Name = client.Name;
            clientInDb.PhoneNumber = client.PhoneNumber;
            clientInDb.Address = client.Address;

            _context.Clients.Update(clientInDb);
            _context.Complete();
        }
    }
}
