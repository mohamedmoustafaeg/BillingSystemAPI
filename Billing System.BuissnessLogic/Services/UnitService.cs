using Billing_System.BuissnessLogic.DTO.Unit;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;

namespace Billing_System.BuissnessLogic.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _context;

        public UnitService(IUnitOfWork context)
        {
            _context = context;
        }

        public void Add(UnitToAddDTO unitDto)
        {
            if (unitDto == null)
                throw new ArgumentNullException(nameof(unitDto), "Unit data can't be null");

            // Check if the unit already exists
            var existingUnit = _context.Units.GetAll().FirstOrDefault(u => u.Name == unitDto.Name);
            if (existingUnit != null)
                throw new InvalidOperationException("Unit already exists in the database");

            // Create new Unit with just the Name
            var unit = new model.models.Unit
            {
                Name = unitDto.Name
            };

            // Add the new unit to the database
            _context.Units.Add(unit);
            _context.Complete();
        }
        public void Edit(int id, UnitToAddDTO unitDto)
        {
            if (unitDto == null)
                throw new ArgumentNullException(nameof(unitDto), "Unit data can't be null");

            // Fetch the existing unit by ID
            var existingUnit = _context.Units.GetById(id);
            if (existingUnit == null)
                throw new InvalidOperationException("Unit not found");

            // Update the unit's properties
            existingUnit.Name = unitDto.Name;
            _context.Units.Update(existingUnit);
            // Save changes
            _context.Complete();
        }
        public UnitToReturnDTO GetById(int id)
        {
            var unit = _context.Units.GetById(id);
            if (unit == null)
                throw new InvalidOperationException("Unit not found");

            // Return the unit as DTO
            return new UnitToReturnDTO
            {
                Id = unit.Id,
                Name = unit.Name
            };
        }
        public List<UnitToReturnDTO> GetAll()
        {
            var units = _context.Units.GetAll();

            // Convert to DTOs
            var unitDtos = units.Select(u => new UnitToReturnDTO
            {
                Id = u.Id,
                Name = u.Name
            }).ToList();

            return unitDtos;
        }
        public void DeleteById(int id)
        {
            var unit = _context.Units.GetById(id);
            if (unit == null)
                throw new InvalidOperationException("Unit not found");

            // Remove the unit
            _context.Units.Delete(unit);
            _context.Complete();
        }


    }

}
