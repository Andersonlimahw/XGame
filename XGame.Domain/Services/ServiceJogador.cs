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

        public ServiceJogador()
        {

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
            if (request == null) {
                // Exception gera custo de processamento e afeta o desempenho
                // TODO usar notificações.
                throw new Exception("AutenticarJogadorRequest é obrigigatório!");
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Informe um e-mail");
            }

            if (isEmail(request.Email))
            {
                throw new Exception("Informe um e-mail válido");
            }

            if (string.IsNullOrEmpty(request.Senha))
            {
                throw new Exception("Informe a senha.");
            }

            if (!string.IsNullOrEmpty(request.Senha) && request?.Senha.Length < 6)
            {
                throw new Exception("A Senha deve ter ao menos 6 dígitos.");
            }

            var response = _repositoryJogador.Autenticar(request);
            return response;

        }

        private bool isEmail(string email)
        {
            return false;
        }
    }
}
