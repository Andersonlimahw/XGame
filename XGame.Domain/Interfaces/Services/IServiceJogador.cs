using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador : IServiceBase
    {
        AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request);

        AdicionarJogadorResponse Adicionar(AdicionarJogadorRequest request);

        AlterarJogadorResponse Alterar(AlterarJogadorRequest request);

        IEnumerable<JogadorResponse> ListarJogador();

        ResponseBase Excluir(Guid id);
    }
}
