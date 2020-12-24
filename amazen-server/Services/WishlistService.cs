using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class WishlistService
    {
        private WishlistRepository _repo;
        public WishlistService(WishlistRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Wishlist> GetByProfile(string creatorId)
        {
            return _repo.GetByProfile(creatorId);
        }
        public Wishlist GetById(int id)
        {
            Wishlist foundWishlist = _repo.GetById(id);
            if (foundWishlist == null)
            {
                throw new Exception("no wishlist found");
            }
            return foundWishlist;
        }
        public Wishlist Create(Wishlist newWishlist)
        {
            newWishlist.Id = _repo.Create(newWishlist);
            return newWishlist;
        }
    }
}