using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;
using CInvestimentos.Services.Interface;

namespace CInvestimentos.Services
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _repository;

        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Venda> GetList()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Venda GetById(int id)
        {
            try
            {
                return _repository.GetById(id).Result; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Venda> Add(Venda venda)
        {
            try
            {
                _repository.Add(venda);
                _repository.SaveChanges();
                return GetById(venda.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<Venda> Update(Venda venda)
        {
            try
            {
                _repository.Update(venda);
                _repository.SaveChanges();

                return _repository.GetById(venda.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(int id, Venda venda)
        {
            try
            {
                _repository.Delete(venda);
                var a = _repository.SaveChanges();
                return a;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}