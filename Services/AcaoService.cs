using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;
using CInvestimentos.Services.Interface;

namespace CInvestimentos.Services
{
    public class AcaoService : IAcaoService
    {
        private IAcaoRepository _repository;

        public AcaoService(IAcaoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Acao> GetList()
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

        public Acao GetById(int id)
        {
            try
            {
                return _repository.GetById(id); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Acao> Add(Acao acao)
        {
            try
            {
                _repository.Add(acao);
                _repository.SaveChanges();
                return GetById(acao.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Acao> Update(Acao acao)
        {
            try
            {
                _repository.Update(acao);
                _repository.SaveChanges();

                return _repository.GetById(acao.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(int id, Acao acao)
        {
            try
            {
                _repository.Delete(acao);
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