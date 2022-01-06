using System.Collections.Generic;
using Catalog.Entities;
using System;
using System.Linq;

namespace Catalog.Repositories 
{
    public class InMemItemsRepository 
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Item 1", Price = 10, CreatedDate = DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Item 2", Price = 20, CreatedDate = DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Item 2", Price = 20, CreatedDate = DateTimeOffset.Now }

        };
        public IEnumerable<Item> GetItems(){
            return items;
        }
        public Item GetItem(Guid id) => items.Where(i => i.Id == id).SingleOrDefault();
    }
}