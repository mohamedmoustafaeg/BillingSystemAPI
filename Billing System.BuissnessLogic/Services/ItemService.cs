using Billing_System.BuissnessLogic.DTO.Client;
using Billing_System.BuissnessLogic.DTO.Item;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using model.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System.BuissnessLogic.Services
{
    public class Itemervices:IItemService
    {
        public readonly IUnitOfWork context;
        public Itemervices(IUnitOfWork _context)
        {
            context = _context;
        }
        public void Add(ItemToAddDto item)
        {
            if (item == null)
                throw new Exception("item Cant Be Null");
            var iteminDb = context.Items.GetAll().Where(c => c.Name == item.Name).FirstOrDefault();
            if (iteminDb != null)
                throw new Exception("Items already exists in database");
            context.Items.Add(new Item
            {
                Name = item.Name,
                Note = item.Note,
                SellingPrice = item.SellingPrice,
                BuyingPrice = item.BuyingPrice,
                AvailableQyantity = item.AvailableQyantity,
                TypeId = item.TypeId,
                UnitId = item.UnitId,
                CompanyId = item.CompanyId

            });
            context.Complete();
        }
        public List<ItemToReturnDto> GetAll()
        { 
        var items = context.Items.GetAll();
        var itemstoreturn = new List<ItemToReturnDto>();
            foreach (var item in items)
            {
                itemstoreturn.Add(new ItemToReturnDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Note = item.Note,
                    SellingPrice = item.SellingPrice,
                    BuyingPrice = item.BuyingPrice,
                    AvailableQyantity = item.AvailableQyantity,
                    TypeId = item.TypeId,
                    UnitId = item.TypeId,
                    CompanyId = item.TypeId
                }
                    );
            }
            return itemstoreturn;
        }
        public ItemToReturnDto GetById(int id)
        {
            var item = context.Items.GetById(id);
            var itemtoreturn = new ItemToReturnDto
            {
                Id = item.Id,
                Name = item.Name,
                Note = item.Note,
                SellingPrice = item.SellingPrice,
                BuyingPrice = item.BuyingPrice,
                AvailableQyantity = item.AvailableQyantity,
                TypeId = item.TypeId,
                UnitId = item.UnitId,
                CompanyId = item.CompanyId
            };
            return itemtoreturn;
        }
    }
}
