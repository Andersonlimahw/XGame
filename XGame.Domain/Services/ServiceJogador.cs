﻿using prmToolkit.NotificationPattern;
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
            Jogador jogador = new Jogador(request.Email, request.Senha)
            {
                Nome = request.Nome,
                Status = Enum.EnumSituacaoJogador.EmAndamento
            };

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

            var email = new Email(request?.Email);
            var jogador = new Jogador(
                email,
                request.Senha
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
