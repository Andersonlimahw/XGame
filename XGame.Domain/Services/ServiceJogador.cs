using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;
        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request)
        {
            Guid id = _repositoryJogador.Adicionar(request);
            return new AdicionarJogadorResponse()
            {
                Id = id,
                Message = "Operação realizada com sucesso!"
            };
        }

        public AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
