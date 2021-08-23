using Microsoft.AspNetCore.SignalR;
using Projeto02.Application.Interfaces;
using Projeto02.Application.Models.Contas;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Mvc.Hubs
{
    public class ContasHub : Hub
    {
        private readonly IContaApplicationService _contaApplicationService;

        public ContasHub(IContaApplicationService contaApplicationService)
        {
            _contaApplicationService = contaApplicationService;
        }

        //método para que a página de cadastro possa
        //envia uma notificação para o Hub contendo
        //os dados de uma conta
        public async Task SendMessage(AddContasModel model)
        {
            //cadastrar a conta
            _contaApplicationService.Add(model);

            //criando uma rotina para as páginas que irão 'ouvir'
            //os eventos (mensagens / notificações) que chegam no hub
            await Clients.All.SendAsync("ReceiveMessage", model);
        }
    }
}
