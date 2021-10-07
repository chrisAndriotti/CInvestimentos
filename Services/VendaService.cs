using System.ComponentModel.DataAnnotations;
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
        private IVendaRepository _vendaRepository;
        private IInvestidorRepository _investidorRepository;
        private IAcaoRepository _acaoRepository;
        private ITransacaoRepository _transacaoRepository;
        private IInvestimentoRepository _investimentoRepository;
        private ITransacaoService _transacaoService;
        private readonly IInvestimentoService _investimentoService;

        public VendaService(IVendaRepository vendaRepository, IInvestidorRepository investidorRepository,
                             IAcaoRepository acaoRepository, ITransacaoRepository transacaoRepository,
                             IInvestimentoRepository investimentoRepository, ITransacaoService transacaoService,
                             IInvestimentoService investimentoService) 
        {
            _vendaRepository = vendaRepository;
            _investidorRepository = investidorRepository;
            _acaoRepository = acaoRepository;
            _transacaoRepository = transacaoRepository;
            _investimentoRepository = investimentoRepository;
            _transacaoService = transacaoService;
            _investimentoService = investimentoService;
        }

        public IEnumerable<Venda> GetList()
        {
            try
            {
                return _vendaRepository.GetAll();
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
                return _vendaRepository.GetById(id); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Add(Venda venda)
        {
            try
            {
                Investimento investimento = _investimentoService.GetById(venda.InvestimentoId);

                var acao = investimento.Acao;
                var investidor = investimento.Investidor;

                var quantidadeExistente = investimento.ValorTotal / acao.Valor;

                if(venda.Quantidade <= quantidadeExistente)
                {
                    var valorVenda = acao.Valor * venda.Quantidade;

                    investimento.ValorTotal -= valorVenda;
                    venda.Total = valorVenda;

                    if(investimento.ValorTotal <= 0)
                    {
                        investimento.Ativo = false;
                    }

                    var update = _investimentoService.Update(investimento);

                    Transacao deposito = new Transacao();
                    deposito.InvestidorId = investimento.Investidor.Id;
                    deposito.TipoTransacao = ETransacoes.Venda;
                    deposito.Valor = valorVenda;
                   
                    if(update)
                    {
                        await _transacaoService.Add(deposito);

                        _vendaRepository.Add(venda);
                        _vendaRepository.SaveChanges();

                        return true;
                    }
                }

                return false;

                // if(venda.Quantidade <= quantidade && investidor != null)
                // {
                //     investimento.ValorTotal = valor/quantidade;
                //     investimento.Ativo = investimento.ValorTotal <= 0 ? investimento.Ativo = false : investimento.Ativo = true;
                //     investimento.Acao = investimento.Acao;

                //     await _investimentoService.Update(investimento);
                //     _investimentoRepository.SaveChanges();

                //     Transacao deposito = new Transacao
                //     {
                //         InvestidorId = venda.InvestidorId,
                //         Valor =+ valor / quantidade,
                //         TipoTransacao = ETransacoes.Venda 
                //     };

                //     await _transacaoService.Add(deposito);
                    
                // }

              


                // if(investidor != null && acao != null)

                // {
                //     if(investidor.Investimentos != null)
                //     {
                //         foreach(var investimento in investidor.Investimentos)
                //         {
                //             if(investimento.Acao.Id == acao.Id && investimento.Ativo == true)
                //             {
                //                 var quantidade = investimento.ValorTotal/investimento.Acao.Valor;
                //                 var valor = investimento.ValorTotal-investimento.Acao.Valor;

                //                 venda.Total = acao.Valor * venda.Quantidade;

                //                 if(venda.Quantidade == quantidade)
                //                 {
                //                     investimento.Ativo = false;
                //                 }

                //                 Investimento itemInvestimento = new Investimento
                //                 {
                //                     Id = investimento.Id,
                //                     Acao = acao,
                //                     ValorTotal = valor,
                //                     Ativo = true,
                //                     Investidor = investidor

                //                 };

                //                 _investimentoRepository.SaveChanges();
                //                 _investidorRepository.SaveChanges();
                //                 _acaoRepository.SaveChanges();

                //                 investimentoExt = itemInvestimento;

                //                 Transacao transacao = new Transacao
                //                 {
                //                     InvestidorId = investidor.Id,
                //                     TipoTransacao = ETransacoes.Venda,
                //                     Valor = venda.Total
                //                 };

                //                 await _transacaoService.Add(transacao);
                                
                //             }
                //         }
                //     }
                // }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Update(Venda venda)
        {
            try
            {
                var entity = GetById(venda.Id);

                _vendaRepository.Update(entity);
                return await _vendaRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Delete(Venda venda)
        {
            try
            {
                var entity = GetById(venda.Id);
                
                _vendaRepository.Delete(entity);
                return await _vendaRepository.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}