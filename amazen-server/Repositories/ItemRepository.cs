using System.Collections.Generic;
using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
    public class ItemRepository
    {
        private readonly IDbConnection _db;
        public ItemRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Item> GetAll()
        {
            string sql = "SELECT * FROM items";
            return _db.Query<Item>(sql);
        }
        public int Create(Item newItem)
        {
            string sql = @"
            INSERT INTO items
            (name, price, color, description)
            VALUES
            (@Name, @Price, @Color, @Description);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newItem);
        }
    }
}