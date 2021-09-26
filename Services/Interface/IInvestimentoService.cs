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
        Task<Investimento> Add(Investimento investimento);
        Task<Investimento> Update(Investimento investimento);
        bool Delete(int id,Investimento investimento);
    }
}