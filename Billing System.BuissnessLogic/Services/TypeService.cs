using Billing_System.BuissnessLogic.DTO.Type;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;

namespace Billing_System.BuissnessLogic.Services
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _context;
        public TypeService(IUnitOfWork context)
        {
            _context = context;
        }
        public void Add(TypeToAddDTO type)
        {
            if (type == null)
                throw new Exception("Type Can't Be Null");
            var typeinDb = _context.Types.GetAll().Where(t => t.Name == type.Name).FirstOrDefault();
            if (typeinDb != null)
                throw new Exception("Type already exists in database");
            var company = _context.Companies.GetById(type.companyId);
            if (company == null)
                throw new Exception($"Company with id {type.companyId} does not exist in database");
            _context.Types.Add(new model.models.Type
            {
                Name = type.Name,
                Note = type.Note,
                CompanyId = type.companyId
            });
            _context.Complete();
        }


        public List<TypeToReturnDTO> GetAll()
        {
            var types = _context.Types.GetAll();
            var typestoReturn = new List<TypeToReturnDTO>();
            foreach (var type in types)
            {
                typestoReturn.Add(new TypeToReturnDTO
                {
                    Id = type.Id,
                    Name = type.Name,
                    Note = type.Note,
                    CompanyName = type.Company.Name
                });
            }
            return typestoReturn;
        }
        public TypeToReturnDTO GetById(int id)
        {
            var type = _context.Types.GetById(id);
            if (type == null)
                throw new Exception($"There is no type in database with Id {id}");
            return new TypeToReturnDTO
            {
                Id = type.Id,
                Name = type.Name,
                Note = type.Note,
                CompanyName = type.Company.Name
            };
        }
        public void DeleteById(int id)
        {
            var type = _context.Types.GetById(id);
            if (type == null)
                throw new Exception($"type you want do delete with id {id} does not exist in database ");
            _context.Types.Delete(type);
            _context.Complete();
        }
        public void Edit(int id, TypeToAddDTO type)
        {
            if (type == null)
                throw new Exception("type can't be null");

            var typeInDb = _context.Types.GetById(id);
            if (typeInDb == null)
                throw new Exception($"No type found with Id {id}");

            typeInDb.Name = type.Name;
            typeInDb.Note = type.Note;
            typeInDb.CompanyId = type.companyId;
            _context.Types.Update(typeInDb);
            _context.Complete();
        }


    }
}
