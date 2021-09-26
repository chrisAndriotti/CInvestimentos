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
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _service;
        public TransacaoController(ITransacaoService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public ActionResult<IEnumerable<Transacao>> List()
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
        public ActionResult<Transacao> GetById(int id)
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
        public ActionResult<Transacao> Add(Transacao transacao)
        {
            try
            {
                return Ok(_service.Add(transacao));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult<Transacao> Update(Transacao transacao)
        {
            try
            {
                return Ok(_service.Update(transacao));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("remover")]
        public ActionResult<bool> Delete(int id, Transacao transacao)
        {
            try
            {
                return Ok(_service.Delete(id,transacao));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}