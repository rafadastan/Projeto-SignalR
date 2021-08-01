using Microsoft.AspNetCore.SignalR;
using Projeto02.Presentation.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Mvc.Hubs
{
    public class ContasHub : Hub
    {
        public async Task SendMessage(ContaViewModel contaViewModel)
        {
            contaViewModel.DataHora = DateTime.Now; //gerando data..

            //criando uma rotina para as páginas que irão 'ouvir'
            //os eventos (mensagens / notificações) que chegam no hub
            await Clients.All.SendAsync("ReceiveMessage", contaViewModel);
        }
    }
}
