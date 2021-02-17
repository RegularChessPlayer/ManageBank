using AtlanticoBank.Application.HubConfig;
using AtlanticoBank.Application.TimerFeatures;
using AtlanticoBank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticoBank.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankHubController : ControllerBase
    {
        private IHubContext<BankHub> _hub;
        private ICaixaService _caixaService;

        public BankHubController(IHubContext<BankHub> hub, ICaixaService caixaService)
        {
            _hub = hub;
            _caixaService = caixaService;
        }

        public async Task<IActionResult> GetAsync()
        {
            var caixas = await _caixaService.ListCaixaAsync();

            var timerManager = new TimerManager( () => {
                 _hub.Clients.All.SendAsync("caixadata", caixas);
               }  
            );
            return Ok(new { Message = "Request Completed" });
        }


    }


}
