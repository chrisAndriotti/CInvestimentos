using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Repositories.Interfaces;
using CInvestimentos.Services.Interface;

namespace CInvestimentos.Services
{
    public class TransacaoService : ITransacaoService
    {
        private ITransacaoRepository _transacaoRepository;
        private IInvestidorRepository _investidorRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository,IInvestidorRepository investidorRepository)
        {
            _transacaoRepository = transacaoRepository;
            _investidorRepository = investidorRepository;
        }

        public IEnumerable<Transacao> GetList()
        {
            try
            {
                return _transacaoRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Transacao GetById(int id)
        {
            try
            {
                return _transacaoRepository.GetById(id); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Transacao> Add(Transacao transacao)
        {
            try
            {
                var investidor =_investidorRepository.GetById(transacao.InvestidorId);

                if(investidor != null)
                {
                    if(transacao.TipoTransacao == ETransacoes.Saque || transacao.TipoTransacao == ETransacoes.Compra)
                    {
                        if(investidor.SaldoEmConta >= transacao.Valor)
                        {
                            investidor.SaldoEmConta -= transacao.Valor;
                        }
                    }
                    else if(transacao.TipoTransacao == ETransacoes.Deposito || transacao.TipoTransacao == ETransacoes.Venda)
                    {
                        investidor.SaldoEmConta += transacao.Valor;
                    }
                }

                _transacaoRepository.Add(transacao);
                _transacaoRepository.SaveChanges();

                _investidorRepository.Update(investidor);
                await _investidorRepository.SaveChangesAsync();

                return  GetById(transacao.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Transacao> Update(Transacao transacao)
        {
            try
            {
                _transacaoRepository.Update(transacao);
                _transacaoRepository.SaveChanges();

                return _transacaoRepository.GetById(transacao.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(int id, Transacao transacao)
        {
            try
            {
                _transacaoRepository.Delete(transacao);
                var a = _transacaoRepository.SaveChanges();
                return a;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}