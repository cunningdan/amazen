using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class ItemService
    {
        private readonly ItemRepository _repo;
        public ItemService(ItemRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Item> GetAll()
        {
            return _repo.GetAll();
        }
        public Item Create(Item newItem)
        {
            newItem.Id = _repo.Create(newItem);
            return newItem;
        }
    }
}