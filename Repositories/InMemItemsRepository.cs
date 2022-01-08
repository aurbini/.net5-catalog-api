using System.Collections.Generic;
using Catalog.Entities;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Catalog.Repositories 
{

    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Item 1", Price = 10, CreatedDate = DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Item 2", Price = 20, CreatedDate = DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Item 2", Price = 20, CreatedDate = DateTimeOffset.Now }

        };
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id) => items.Where(i => i.Id == id).SingleOrDefault();

        public void CreateItem(Item item){
            items.Add(item);
        }

        public void UpdateItem(Item item){
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);

            items[index] = item; 
        }

        public void DeleteItem(Guid id ){
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}