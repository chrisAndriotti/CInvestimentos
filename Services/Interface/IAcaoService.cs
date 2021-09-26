using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Services.Interface
{
    public interface IAcaoService
    {
        IEnumerable<Acao> GetList();
        Acao GetById(int id);
        Task<Acao> Add(Acao acao);
        Task<Acao> Update(Acao acao);
        bool Delete(int id, Acao acao);
    }
}