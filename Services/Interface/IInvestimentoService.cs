using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Services.Interface
{
    public interface IInvestimentoService
    {
        IEnumerable<Investimento> GetList();
        Investimento GetById(int id);
        Task<Investimento> Add(Investimento investimentos);
        bool Update(Investimento investimentos);
        bool Delete(int id,Investimento investimentos);
    }
}