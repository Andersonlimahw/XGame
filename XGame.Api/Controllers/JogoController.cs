using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Api.Controllers.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controllers
{
    [RoutePrefix("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly IServiceJogo _serviceJogo;

        public JogoController(IUnitOfWork unitOfWork, IServiceJogo serviceJogo) : base(unitOfWork)
        {
            _serviceJogo = serviceJogo;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.Adicionar(request);

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceJogo.Listar();
                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
      


    }
}