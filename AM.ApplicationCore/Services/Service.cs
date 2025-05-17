﻿using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AM.ApplicationCore.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork.Repository<TEntity>();
            this._unitOfWork = unitOfWork;
        }

        public virtual void Add(TEntity entity) => _repository.Add(entity);

        public virtual void Update(TEntity entity) => _repository.Update(entity);

        public virtual void Delete(TEntity entity) => _repository.Delete(entity);

        public virtual void Delete(Expression<Func<TEntity, bool>> where) => _repository.Delete(where);

        public virtual TEntity GetById(params object[] id) => _repository.GetById(id);

        public virtual IEnumerable<TEntity> GetMany() => _repository.GetAll();

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter) => _repository.GetMany(filter);

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where) => _repository.Get(where);

        public void Commit()
        {
            try
            {
                _unitOfWork.Save();
            }
            catch
            {
                throw;
            }
        }

        public virtual IEnumerable<TEntity> GetAll() => _repository.GetAll();
    }
}
