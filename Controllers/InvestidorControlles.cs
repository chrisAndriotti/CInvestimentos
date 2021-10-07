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

        /// <summary>
        /// Buscar Investidores
        /// </summary>  
        [HttpGet("lista")]
        public ActionResult<IEnumerable<Investidor>> List()
        {
    
            return Ok(_service.GetList());
 
        }

        [HttpGet("buscar/{id}")]
        public ActionResult<Investidor> GetById(int id)
        {
            return Ok(_service.GetById(id));   
        }

        [HttpPost("criar")]
        public ActionResult<Investidor> Add(Investidor investidor)
        {
 
            if(ModelState.IsValid)
            {
                return Ok(_service.Add(investidor).Result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("atualizar")]
        public ActionResult<Investidor> Update(Investidor investidor)
        {
            if(ModelState.IsValid)
            {
                return Ok(_service.Update(investidor));
            }
            else
            {
                return BadRequest(ModelState);
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