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
            if (request == null)
            {
                AddNotification("AdicionarJogoResponse", "É obrigatório!");
            }

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
            if (request == null)
            {
                AddNotification("AlterarJogoResponse", "É obrigatório!");
                return null;
            }

            Jogo jogo = _repositoryJogo.ObterPorId(request.Id);
            if(jogo == null)
            {
                AddNotification("Id", $"Id {request.Id} - Não encontrado");
                return null;
            }

            jogo.Alterar(
                request.Nome,
                request.Descricao,
                request.Produtora,
                request.Distribuidora,
                request.Genero,
                request.Site);

            if(this.IsInvalid())
            {
                return null;
            }

            _repositoryJogo.Editar(jogo);

            return (AlterarJogoResponse)jogo;
        }

        public ExcluirJogoResponse Excluir(Guid request)
        {
            if (request == null)
            {
                AddNotification("Id", "É obrigatório!");
                return null;
            }

            Jogo jogo = _repositoryJogo.ObterPorId(request);

            if (jogo == null)
            {
                AddNotification("Jogo", $"O Jogo com o id {request}, não foi encontrado!");
                return null;
            }

            _repositoryJogo.Remover(jogo);
            return (ExcluirJogoResponse)jogo;
        }

        public IEnumerable<JogoResponse> Listar()
        {
            return _repositoryJogo.Listar()
                .ToList()
                .Select(jogo => (JogoResponse)jogo)
                .ToList();
        }
    }
}
