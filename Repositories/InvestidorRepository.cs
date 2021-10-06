using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;

namespace CInvestimentos.Repositories
{
    public class InvestidorRepository : GenericRepository<Investidor>, IInvestidorRepository
    {

        // private readonly Context _context;
        public InvestidorRepository(Context context) : base(context)
        {
        }

        // public List<Investidor> GetList()
        // {
        //     IQueryable<Investidor> query = _context.Investidores;
        //     query = query.Include(i => i.Investimentos);
        //     query = query.AsNoTracking().OrderBy(i => i.Id);

        //     return query.ToList();
        // }
    }
}