using AtlanticoBank.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticoBank.Application.HubConfig
{
    public class BankHub : Hub
    {
        public async Task BroadcastChartData(List<Caixa> data) => await Clients.All.SendAsync("broadcastchartdata", data);

    }
}
