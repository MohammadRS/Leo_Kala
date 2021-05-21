using _01_LampshadeQuery.Contracts.Inventory;
using InventoryManagement.Infrastructure.EFCore.Context;
using ShopManagement.Infrastructure.EFCore.Context;
using System.Linq;

namespace _01_LampshadeQuery.Query
{
    public class InventoryQuery : IInventoryQuery
    {
        private readonly LeoContext _shopContext;
        private readonly InventoryContext _inventoryContext;

        public InventoryQuery(InventoryContext inventoryContext, LeoContext shopContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public StockStatus CheckStock(IsInStock command)
        {
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == command.ProductId);
            if(inventory == null || inventory.CalculateCurrentCount() < command.Count)
            {
                var product = _shopContext.Products.Select(x => new { x.Id, x.Name })
                    .FirstOrDefault(x => x.Id == command.ProductId);
                return new StockStatus
                {
                    IsStock = false,
                    ProductName = product?.Name
                };
            }

            return new StockStatus
            {
                IsStock = true
            };
        }
    }
}
