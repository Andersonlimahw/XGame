using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador Autenticar(string email, string senha);

        Jogador Adicionar(Jogador jogador);
    }
}
