using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        List<Investidor> GetListInvestidores();
        List<Investimento> GetListInvestimentos();
        Investidor GetInvestidor(int id);
        Investimento GetInvestimento(int id);
    }
}