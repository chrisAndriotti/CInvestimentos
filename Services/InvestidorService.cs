using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;
using CInvestimentos.Services.Interface;

namespace CInvestimentos.Services
{
    public class InvestidorService : IInvestidorService
    {
        private IInvestidorRepository _repository;

        public InvestidorService(IInvestidorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Investidor> GetList()
        {
            try
            {
                return _repository.GetListInvestidores();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Investidor GetById(int id)
        {
            try
            {
                return _repository.GetInvestidor(id); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Investidor> Add(Investidor investidor)
        {
            try
            {
                _repository.Add(investidor);
                _repository.SaveChanges();
                return GetById(investidor.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Investidor> Update(Investidor investidor)
        {
            try
            {
                _repository.Update(investidor);
                _repository.SaveChanges();

                return _repository.GetById(investidor.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(int id, Investidor investidor)
        {
            try
            {
                _repository.Delete(investidor);
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