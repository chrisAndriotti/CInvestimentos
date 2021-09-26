using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Services.Interface
{
    public interface IInvestidorService
    {
        IEnumerable<Investidor> GetList();
        Investidor GetById(int id);
        Task<Investidor> Add(Investidor investidor);
        Task<Investidor> Update(Investidor investidor);
        bool Delete(int id, Investidor investidor);
    }
}