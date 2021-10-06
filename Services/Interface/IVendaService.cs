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
        Task<bool> Add(Venda venda);
        Task<bool> Update(Venda venda);
        Task<bool> Delete(Venda venda);
    }
}