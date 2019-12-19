using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogo : IServiceBase
    {

        IEnumerable<JogoResponse> Listar();
        AdicionarJogoResponse Adicionar(AdicionarJogoRequest request);

        AlterarJogoResponse Alterar(AlterarJogoRequest request);

        ExcluirJogoResponse Excluir(Guid id);
    }
}
