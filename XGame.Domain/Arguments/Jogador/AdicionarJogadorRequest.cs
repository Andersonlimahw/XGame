using XGame.Domain.Interfaces.Arguments;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorRequest: IRequest
    {
        public Nome Nome { get; set; }
        public Email Email { get; set; }

        public string Senha { get; set; }
    }
}
