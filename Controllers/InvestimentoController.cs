using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CInvestimentos.Models;
using CInvestimentos.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CInvestimentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoService _service;
        public InvestimentoController(IInvestimentoService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public ActionResult<IEnumerable<Investimento>> List()
        {
            try
            {
                return Ok(_service.GetList());
            }
            catch (Exception)
            {
                throw;
            } 
        }

        [HttpGet("buscar/{id}")]
        public ActionResult<Investimento> GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("criar")]
        public ActionResult<Investimento> Add(Investimento investimento)
        {
            try
            {
                return Ok(_service.Add(investimento));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult<Investimento> Update(Investimento investimento)
        {
            try
            {
                return Ok(_service.Update(investimento));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("remover")]
        public ActionResult<bool> Delete(int id, Investimento investimento)
        {
            try
            {
                return Ok(_service.Delete(id,investimento));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}