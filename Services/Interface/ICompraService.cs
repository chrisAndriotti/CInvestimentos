using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;

namespace CInvestimentos.Services.Interface
{
    public interface ICompraService
    {
        IEnumerable<Compra> GetList();
        Compra GetById(int id);
        Task<Compra> Add(Compra compra);
        Task<Compra> Update(Compra compra);
        bool Delete(int id, Compra compra);
    }
}