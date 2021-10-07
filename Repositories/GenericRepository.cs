using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CInvestimentos.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly Context _context;
        
        public GenericRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return  _context.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            var result = _context.Set<TEntity>()
                        .FirstOrDefaultAsync(e => e.Id == id).Result;
            if(result == null)
            {
                return null;
            }

            return result;
            
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

         public async Task<bool> SaveChangesAsync()
        {
            return ( await _context.SaveChangesAsync(true) > 0);
        }
        public List<Investidor> GetListInvestidores()
        {
            IQueryable<Investidor> query = _context.Investidor;
            query = query.Include(i => i.Investimentos).ThenInclude(a => a.Acao);
            
            return query.ToList();
        }


        public Investidor GetInvestidor(int id)
        {
            IQueryable<Investidor> query = _context.Investidor;
            query = query.Include(i => i.Investimentos).ThenInclude(a => a.Acao);
            query = query.AsNoTracking().Where(investidor => investidor.Id == id);
            
            return query.FirstOrDefault();
        }

        public List<Investimento> GetListInvestimentos()
        {
            IQueryable<Investimento> query = _context.Investimentos;
            query = query.Include(i => i.Acao);
            query = query.AsNoTracking().OrderBy(i => i.Id);
            
            return query.ToList();
        }

        public Investimento GetInvestimento(int id)
        {
            IQueryable<Investimento> query = _context.Investimentos;

            query = query.Include(a => a.Acao);
            query = query.Include(i => i.Investidor);

            query = query.Where(investimento => investimento.Id == id);
            
            return query.FirstOrDefault();
        }

        // public Investimento InvestimentoPorInvestidor(int idInvestidor)
        // {
            
            
        // }
    }
}