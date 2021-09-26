using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;
using CInvestimentos.Services.Interface;

namespace CInvestimentos.Services
{
    public class CompraService : ICompraService
    {
        private ICompraRepository _repository;

        public CompraService(ICompraRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Compra> GetList()
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

        public Compra GetById(int id)
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

        public async Task<Compra> Add(Compra compra)
        {
            try
            {
                _repository.Add(compra);
                _repository.SaveChanges();
                return GetById(compra.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<Compra> Update(Compra compra)
        {
            try
            {
                _repository.Update(compra);
                _repository.SaveChanges();

                return _repository.GetById(compra.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(int id, Compra compra)
        {
            try
            {
                _repository.Delete(compra);
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