using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context)
        {
            _context = context;
        }

        public Jogador Adicionar(Jogador jogador)
        {
            
            try
            {
                // Inserindo registro no banco de dados
                _context.Jogadores.Add(jogador);
                _context.SaveChanges();
                return jogador;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adcionar jogador : {ex}");
                throw;
            }
        }

        public void Alterar(Jogador jogador)
        {
            throw new NotImplementedException();
        }

        public Jogador Autenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogador> Listar()
        {
            return _context.Jogadores.ToList();
        }

        public Jogador ObterPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Jogador> Filtrar(string filtro, string valor)
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

                if (filtro.Equals("status"))
                {
                    jogadores = jogadores.Where(x => x.Status.Equals(valor));
                }

                return jogadores.AsParallel().ToList();
            }

            return new List<Jogador>();
        }

    }
}
