using System.Collections.Generic;
using XGame.Domain.Arguments.Jogador;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador
    {
        AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request);

        AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request);

        AlterarJogadorResponse Alterar(AlterarJogadorRequest request);

        IEnumerable<JogadorResponse> ListarJogador();
    }
}
