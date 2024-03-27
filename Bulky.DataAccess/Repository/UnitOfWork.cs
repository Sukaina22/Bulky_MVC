﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            Category = new CategoryRepository(db);
            Product = new ProductRepository(db);
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
