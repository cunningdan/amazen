using System.Collections.Generic;
using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
    public class WishlistRepository
    {
        private readonly IDbConnection _db;
        private readonly string populateCreator = "SELECT wishlist.*, profile.* FROM wishlists wishlist INNER JOIN profiles profile ON wishlist.creatorId = profile.id ";
        public WishlistRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Wishlist> GetByProfile(string creatorId)
        {
            string sql = "SELECT * FROM wishlists WHERE creatorId = @CreatorId";
            return _db.Query<Wishlist>(sql, new { creatorId });
        }
        public Wishlist GetById(int id)
        {
            string sql = "SELECT * FROM wishlists WHERE id = @Id;";
            return _db.QueryFirstOrDefault(sql, new { id });
        }
        public int Create(Wishlist newWishlist)
        {
            string sql = @"
            INSERT INTO wishlists
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newWishlist );
        }
    }
}