using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Services.Interface
{
    public interface ITransacaoService
    {
        IEnumerable<Transacao> GetList();
        Transacao GetById(int id);
        Task<Transacao> Add(Transacao transacao);
        Task<Transacao> Update(Transacao transacao);
        bool Delete(int id, Transacao transacao);
    }
}