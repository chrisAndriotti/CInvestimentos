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
    public class InvestidorController : ControllerBase
    {
        private readonly IInvestidorService _service;
        public InvestidorController(IInvestidorService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public ActionResult<IEnumerable<Investidor>> List()
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
        public ActionResult<Investidor> GetById(int id)
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
        public ActionResult<Investidor> Add(Investidor investidor)
        {
            try
            {
                return Ok(_service.Add(investidor).Result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult<Investidor> Update(Investidor investidor)
        {
            try
            {
                return Ok(_service.Update(investidor));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("remover")]
        public ActionResult<bool> Delete(int id, Investidor investidor)
        {
            try
            {
                return Ok(_service.Delete(id,investidor));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}