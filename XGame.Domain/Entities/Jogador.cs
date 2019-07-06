using prmToolkit.NotificationPattern;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A Senha deve ter entre 6 e 32 digitos.");
        }

        public Nome Nome { get; set; }
        public Email Email { get; set; }

        public string Senha { get; set; }

        public EnumSituacaoJogador Status { get; set; }
    }
}
