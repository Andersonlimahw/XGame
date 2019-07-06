using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse: IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
