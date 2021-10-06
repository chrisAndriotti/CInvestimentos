using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Repositories.Interfaces
{
    public interface IInvestidorRepository : IGenericRepository<Investidor>
    {
        // List<Investidor> GetList();
    }
}