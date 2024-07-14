using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart> , IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       
        
        public void Update(ShoppingCart obj)
        {
            _db.ShoppingCarts.Update(obj);
        }

        public void UpdateIdentityInsert(bool turnOn) 
        {
            string status = turnOn ? "ON" : "OFF";
            _db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT ShoppingCarts {status}");
            _db.SaveChanges();
        }
    }
}
