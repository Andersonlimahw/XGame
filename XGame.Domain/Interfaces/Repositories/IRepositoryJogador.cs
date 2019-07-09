using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador Autenticar(string email, string senha);

        Jogador Adicionar(Jogador jogador);

        void Alterar(Jogador jogador);

        IEnumerable<Jogador> Listar();

        Jogador ObterPorId(Guid Id);

    }
}
