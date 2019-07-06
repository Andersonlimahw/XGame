using System;
using XGame.Domain.Arguments.Jogador;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request);

        Guid Adicionar(AdicionarJogadorRequest request);
    }
}
