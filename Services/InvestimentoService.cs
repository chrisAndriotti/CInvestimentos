using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;
using CInvestimentos.Services.Interface;

namespace CInvestimentos.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private IInvestimentoRepository _repository;

        public InvestimentoService(IInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Investimento> GetList()
        {
            try
            {
                return _repository.GetListInvestimentos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Investimento GetById(int id)
        {
            try
            {
                return _repository.GetInvestimento(id); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Investimento> Add(Investimento investimento)
        {
            try
            {
                _repository.Add(investimento);
                await _repository.SaveChangesAsync();
                return GetById(investimento.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<bool> Update(Investimento investimento)
        {
            try
            {
                var entity = _repository.GetById(investimento.Id);
                _repository.Update(entity);

            
                return _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(int id, Investimento investimento)
        {
            try
            {
                _repository.Delete(investimento);
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