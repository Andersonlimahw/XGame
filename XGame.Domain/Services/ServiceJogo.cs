using System;
using System.Collections.Generic;
using System.Linq;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Entities;
using XGame.Domain.Enum;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repositoryJogo;

        public ServiceJogo(IRepositoryJogo repositoryJogo)
        {
            _repositoryJogo = repositoryJogo;
        }

        public AdicionarJogoResponse Adicionar(AdicionarJogoRequest request)
        {
            Jogo jogo = new Jogo(
                request.Nome, 
                request.Descricao, 
                request.Produtora, 
                request.Distribuidora, 
                request.Genero,
                request.Site);

            AddNotifications(jogo);

            if(this.IsInvalid())
            {
                return null;
            }

            jogo = _repositoryJogo.Adicionar(jogo);

            return (AdicionarJogoResponse)jogo;

        }

        public AlterarJogoResponse Alterar(AlterarJogoRequest request)
        {
            throw new NotImplementedException();
        }

        public ExcluirJogoResponse Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JogoResponse> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
