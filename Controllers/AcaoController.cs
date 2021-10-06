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
    public class AcaoController : ControllerBase
    {
        private readonly IAcaoService _service;
        public AcaoController(IAcaoService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public ActionResult<IEnumerable<Acao>> List()
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
        public ActionResult<Acao> GetById(int id)
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
        public ActionResult<Acao> Add(Acao acao)
        {
            try
            {
                return Ok(_service.Add(acao).Result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult<Acao> Update(Acao acao)
        {
            try
            {
                return Ok(_service.Update(acao).Result);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("remover")]
        public ActionResult<bool> Delete(int id, Acao acao)
        {
            try
            {
                return Ok(_service.Delete(id,acao));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}