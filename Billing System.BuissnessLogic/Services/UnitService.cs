using System;
using System.Collections.Generic;
using System.Linq;
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

            
            var existingUnit = _context.Units.GetAll().FirstOrDefault(u => u.Name == unitDto.Name);
            if (existingUnit != null)
                throw new InvalidOperationException("Unit already exists in the database");

            
            var validItemIds = _context.Items.GetAll().Select(i => i.Id).ToList();
            var invalidItemIds = unitDto.ItemIds.Except(validItemIds).ToList();
            if (invalidItemIds.Any())
                throw new ArgumentException($"Item(s) with ID(s) {string.Join(", ", invalidItemIds)} do not exist");

            
            var unit = new model.models.Unit
            {
                Name = unitDto.Name,
                Description = unitDto.Description,
                CompanyId = unitDto.CompanyId,
                Items = unitDto.ItemIds.Select(id => new model.models.Item { Id = id }).ToList() 
            };
            _context.Units.Add(unit);
            _context.Complete();
        }

        public List<UnitToReturnDTO> GetAll()
        {
            var units = _context.Units.GetAll().ToList();
            var unitToReturn = units.Select(unit => new UnitToReturnDTO
            {
                Id = unit.Id,
                Name = unit.Name,
                Description = unit.Description,
                CompanyName = unit.Company.Name,
                ItemIds = unit.Items.Select(i => i.Id).ToList() 
            }).ToList();
            return unitToReturn;
        }

        public UnitToReturnDTO GetById(int id)
        {
            var unit = _context.Units.GetById(id);
            if (unit == null)
                throw new KeyNotFoundException($"Unit with Id {id} not found");

            return new UnitToReturnDTO
            {
                Id = unit.Id,
                Name = unit.Name,
                Description = unit.Description,
                CompanyName = unit.Company.Name,
                ItemIds = unit.Items.Select(i => i.Id).ToList()
            };
        }

        public void DeleteById(int id)
        {
            var unit = _context.Units.GetById(id);
            if (unit == null)
                throw new KeyNotFoundException($"Unit with Id {id} not found");

            _context.Units.Delete(unit);
            _context.Complete();
        }

        public void Edit(int id, UnitToAddDTO unitDto)
        {
            if (unitDto == null)
                throw new ArgumentNullException(nameof(unitDto), "Unit data can't be null");

            var existingUnit = _context.Units.GetById(id);
            if (existingUnit == null)
                throw new KeyNotFoundException($"Unit with Id {id} not found");

            existingUnit.Name = unitDto.Name;
            existingUnit.Description = unitDto.Description;
            existingUnit.CompanyId = unitDto.CompanyId;

            
            var validItemIds = _context.Items.GetAll().Select(i => i.Id).ToList();
            var invalidItemIds = unitDto.ItemIds.Except(validItemIds).ToList();
            if (invalidItemIds.Any())
                throw new ArgumentException($"Item(s) with ID(s) {string.Join(", ", invalidItemIds)} do not exist");

            existingUnit.Items = unitDto.ItemIds.Select(id => new model.models.Item { Id = id }).ToList(); 

            _context.Units.Update(existingUnit);
            _context.Complete();
        }
    }
}
