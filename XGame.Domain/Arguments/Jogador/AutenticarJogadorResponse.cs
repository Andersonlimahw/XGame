using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse: IResponse
    {
        public string Nome { get; set; }
    }
}
