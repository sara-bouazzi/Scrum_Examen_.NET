using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AM.ApplicationCore.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(params object[] id);
        IEnumerable<T> GetMany();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
        void Commit();

        // ✅ Correction ici : ne retourne plus object
        IEnumerable<T> GetAll();
    }
}
