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
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service;
        public CompraController(ICompraService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public ActionResult<IEnumerable<Compra>> List()
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
        public ActionResult<Compra> GetById(int id)
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
        public ActionResult<Compra> Add(Compra compra)
        {
            try
            {
                return Ok(_service.Add(compra));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult<Compra> Update(Compra compra)
        {
            try
            {
                return Ok(_service.Update(compra));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("remover")]
        public ActionResult<bool> Delete(int id, Compra compra)
        {
            try
            {
                return Ok(_service.Delete(id,compra));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}