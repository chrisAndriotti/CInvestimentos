using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;

namespace CInvestimentos.Repositories
{
    public class InvestidorRepository : GenericRepository<Investidor>, IInvestidorRepository
    {
        public InvestidorRepository(Context context) : base(context)
        {
        }
    }
}