﻿using RiddhiBooks.DataAccess.Repository.IRepository;
using RiddhiBookStore.DataAccess.Data;
using Microsoft.Extensions.DependencyInjection;


using System;
using System.Collections.Generic;
using System.Text;

namespace RiddhiBooks.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
         readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(db: _db);
            CoverType = new CoverTypeRepository(db: _db);
            Product = new ProductRepository(db: _db);
            SP_Call = new SP_Call(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public ISP_Call SP_Call { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
