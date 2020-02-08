using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context) : base(context)
        {
            _context = context;
        }


        public List<JogadorResponse> Filtrar(string filtro, string valor)
        {
            if(!string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(valor))
            {
                // ToList executa a query no banco de dados enquando Iqueryable está apenas montando.
                IQueryable<Jogador> jogadores = _context.Jogadores.AsQueryable();
                if(filtro.Equals("nome"))
                {
                    jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.Contains(valor) || 
                        x.Nome.UltimoNome.Contains(valor));
                }

                if (filtro.Equals("email"))
                {
                    jogadores = jogadores.Where(x => x.Email.Endereco.Contains(valor));
                }

                return jogadores
                    .ToList()
                    .Select(jogador => (JogadorResponse)jogador)
                    .ToList();
            }

            return new List<JogadorResponse>();
        }

    }
}
