using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Services.Interface
{
    public interface IVendaService
    {
        IEnumerable<Venda> GetList();
        Venda GetById(int id);
        Task<Venda> Add(Venda venda);
        Task<Venda> Update(Venda venda);
        bool Delete(int id,Venda venda);
    }
}