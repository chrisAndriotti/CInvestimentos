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
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;
        public VendaController(IVendaService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public IActionResult List()
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
        public IActionResult GetById(int id)
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
        public async Task<IActionResult> Add(Venda venda)
        {
            try
            {
                return Ok(await _service.Add(venda).ConfigureAwait(false));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Update(Venda venda)
        {
            try
            {
                return Ok(await _service.Update(venda).ConfigureAwait(false));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("remover")]
        public async Task<ActionResult> Delete(Venda venda)
        {
            try
            {
                return Ok(await _service.Delete(venda).ConfigureAwait(false));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}