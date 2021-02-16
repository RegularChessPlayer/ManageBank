using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Domain.Input;
using AtlanticoBank.Domain.Output;
using AtlanticoBank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlanticoBank.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        ICaixaService _caixaService;

        public BankController(ICaixaService caixaService)
        {
            _caixaService = caixaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caixa>>> GetCaixaAsync()
        {
            var caixas = await _caixaService.ListCaixaAsync();
            return Ok(caixas);
        }

        [HttpPost]

        public async Task<ActionResult<CaixaResponse>> SacarCaixaAsync([FromBody] SaqueInput saqueInput) {

            var caixas = await _caixaService.ListCaixaAsync();
            return Ok(caixas);
        }

    }
}
