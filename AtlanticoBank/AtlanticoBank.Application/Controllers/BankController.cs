using AtlanticoBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlanticoBank.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caixa>>> GetCaixaAsync()
        {
            return Ok();
        }


    }
}
