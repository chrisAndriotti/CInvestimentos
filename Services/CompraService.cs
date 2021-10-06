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
        private ICompraRepository _compraRepository;
        private IInvestidorRepository _investidorRepository;
        private IAcaoRepository _acaoRepository;
        private ITransacaoRepository _transacaoRepository;
        private IInvestimentoRepository _investimentoRepository;
        private IInvestimentoService _investimentoService;
        private ITransacaoService _transacaoService;

        public CompraService(ICompraRepository compraRepository, IInvestidorRepository investidorRepository,
                             IAcaoRepository acaoRepository, ITransacaoRepository transacaoRepository,
                             IInvestimentoRepository investimentoRepository, IInvestimentoService investimentoService,
                             ITransacaoService transacaoService)
        {
            _compraRepository = compraRepository;
            _investidorRepository = investidorRepository;
            _acaoRepository = acaoRepository;
            _transacaoRepository = transacaoRepository;
            _investimentoRepository = investimentoRepository;
            _investimentoService = investimentoService;
            _transacaoService = transacaoService;
        }

        public IEnumerable<Compra> GetList()
        {
            try
            {
                return _compraRepository.GetAll();
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
                return _compraRepository.GetById(id); 
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
                var acao = _acaoRepository.GetById(compra.AcaoId);
                var investidor = _investidorRepository.GetById(compra.InvestidorId);

                if(investidor != null && acao != null)
                {
                    compra.Total = acao.Valor * compra.Quantidade;

                    Transacao transacao = new Transacao();
                    transacao.InvestidorId = investidor.Id;
                    transacao.TipoTransacao = ETransacoes.Compra;
                    transacao.Valor = compra.Total;
                        
                    var flag = false;
                    if(investidor.Investimentos != null)
                    {
                        foreach(var investimento in investidor.Investimentos)
                        {
                            if(investimento.Acao.Id == acao.Id)
                            {
                                investimento.ValorTotal += compra.Total;
                                investimento.Ativo = true;

                                flag = true;

                                break;
                            }
                        }
                    }
                    if(flag == false)
                    {
                        Investimento compraItem = new Investimento();
                        compraItem.Acao = acao;
                        compraItem.Ativo = true;
                        compraItem.ValorTotal = compra.Total;
                        compraItem.Investidor = investidor;

                        if(investidor.SaldoEmConta >= compra.Total)
                        {
                            await _investimentoService.Add(compraItem);
                            investidor.Investimentos.Add(compraItem);
                        }

                        
                    }

                    await _transacaoService.Add(transacao);

                    _investidorRepository.Update(investidor);
                    _investidorRepository.SaveChanges();   
                    
                    // _transacaoRepository.Add(transacao);
                    // _transacaoRepository.SaveChanges();
                }

                _compraRepository.Add(compra);
                _compraRepository.SaveChanges();

                return GetById(compra.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Compra> Update(Compra compra)
        {
            try
            {
                _compraRepository.Update(compra);
                _compraRepository.SaveChanges();

                return _compraRepository.GetById(compra.Id);
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
                _compraRepository.Delete(compra);
                var a = _compraRepository.SaveChanges();
                return a;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}