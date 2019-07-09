using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable,  IServiceJogador
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
            Email email = new Email(request.Email);
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            Jogador jogador = new Jogador(email, request.Senha, nome);

            Guid id = _repositoryJogador.Adicionar(jogador);
            return new AdicionarJogadorResponse()
            {
                Id = id,
                Message = "Operação realizada com sucesso!"
            };
        }

        public AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request)
        {
            if (request == null) {
                AddNotification("AutenticarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            }

            Email email = new Email(request?.Email);
            Nome nome = new Nome("Anderson", "Lima");
            Jogador jogador = new Jogador(
                email,
                request.Senha, 
                nome
            );

            AddNotifications(jogador, email);

            if (jogador.IsInvalid()) {
                return null;
            }

            AutenticarJogadorResponse response = _repositoryJogador.Autenticar(jogador.Email.Endereco, jogador.Senha);  
            return response;
        }
    }
}
