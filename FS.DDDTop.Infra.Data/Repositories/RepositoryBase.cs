using FS.DDDTop.Domain.Interfaces;
using FS.DDDTop.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.DDDTop.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly EFContext _db;

        public RepositoryBase(EFContext db)
        {
            _db = db;
        }

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges(); //fere UOW, precisa melhorar
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges(); //fere UOW, precisa melhorar
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges(); //fere UOW, precisa melhorar
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
