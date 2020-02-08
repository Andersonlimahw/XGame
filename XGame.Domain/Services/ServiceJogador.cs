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
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;


        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }


        public AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request)
        {
            Email email = new Email(request.Email);
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            Jogador jogador = new Jogador(email, request.Senha, nome);

            if(_repositoryJogador.Existe(x => x.Email.Endereco == request.Email))
            {
                AddNotification("E-mail", $"o endereço de e-mail {request.Email}, já existe.");
            }

            if (this.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.Adicionar(jogador);
            return (AdicionarJogadorResponse)jogador;

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
                request.Senha
            );

            AddNotifications(jogador, email);

            if (jogador.IsInvalid()) {
                return null;
            }
            // Autentica
            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco && x.Senha == jogador.Senha);
            if (jogador == null)
            {
                AddNotification("Jogador", $"Jogador não encontrado com o e-mail {request.Email}");
                return null;
            }

            return (AutenticarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse Alterar(AlterarJogadorRequest request)
        {
            if (request == null) {
                AddNotification("AlterarJogadorRequest", "É obrigatório!");
            }

            // Recupera do banco de dados
            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);
            if (jogador == null) {
                AddNotification($"Id", $"Id {request.Id} - Não encontrado.");
                return null;
            }

            // Faz alterações do objeto
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            Email email = new Email(request.Email);
            jogador.Alterar(nome, email, EnumSituacaoJogador.Ativo);
            AddNotifications(jogador);

            // Verifica validação
            if (this.IsInvalid())
            {
                return null;
            }
            // Salva alterações no banco de dados e retorna o objeto atualizado.
            _repositoryJogador.Editar(jogador);
            return (AlterarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            // Converte cada jogador para um JogadorResponse.
            return _repositoryJogador.Listar()
                .ToList()
                .Select(jogador => (JogadorResponse)jogador)
                .ToList();
        }

        public ResponseBase Excluir(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);
            if(jogador == null)
            {
                AddNotification("Id", "Dados não encontrados");
                return null;
            }
            _repositoryJogador.Remover(jogador);
            return new ResponseBase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro">valores possíveis, nome, email</param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public List<JogadorResponse> Filtrar(string filtro, string valor)
        {
            // Converte cada jogador para um JogadorResponse.
            return _repositoryJogador.Filtrar(filtro, valor)
                .ToList();
        }
    }
}
