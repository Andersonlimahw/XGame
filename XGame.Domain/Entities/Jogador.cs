using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enum;
using XGame.Domain.Extensions;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha, Nome nome)
        {
            Id = Guid.NewGuid();
            Email = email;
            Senha = senha;
            Nome =  nome;
            Status = EnumSituacaoJogador.EmAnalise;
            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A Senha deve ter entre 6 e 32 digitos.");
            if (IsValid())
            {
                Senha = Senha.ConvertToMd5();
            }
            
            AddNotifications(nome, email);
        }
        

        public Guid Id { get; set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; private set; }

        internal string retornaNomeCompleto()
        {
            return $"{Nome.PrimeiroNome} {Nome.UltimoNome}";
        }
    }
}
