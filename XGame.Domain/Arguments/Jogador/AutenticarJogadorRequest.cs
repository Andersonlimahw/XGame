using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorRequest : IRequest
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
 