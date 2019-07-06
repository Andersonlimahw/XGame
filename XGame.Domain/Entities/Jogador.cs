using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador
    {

        public Nome Nome { get; set; }
        public Email Email { get; set; }

        public string Senha { get; set; }

        public EnumSituacaoJogador Status { get; set; }
    }
}
