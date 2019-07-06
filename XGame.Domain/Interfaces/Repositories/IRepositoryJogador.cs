using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse Autenticar(string email, string senha);

        Guid Adicionar(Jogador jogador);
    }
}
