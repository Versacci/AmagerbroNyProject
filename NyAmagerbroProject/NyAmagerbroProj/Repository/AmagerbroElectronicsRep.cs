using NyAmagerbroProj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NyAmagerbroProj.Repository
{
    public class AmagerbroElectronicsRep<T> : IAmagerbroElectronicsRep<T> where T : class
    {
        private AmagerbroDbContext db;
        private DbSet<T> dbSet;

        public AmagerbroElectronicsRep()
        {
            db = new AmagerbroDbContext();
            dbSet = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            T getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}