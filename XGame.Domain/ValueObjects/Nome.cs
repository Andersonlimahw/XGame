using System;
using prmToolkit.NotificationPattern;

namespace XGame.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 50, "Primeiro nome dever ter entre 3 e 50 digitos.")
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 50, "Ultimo nome dever ter entre 3 e 50 digitos.");
        }

        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; private set; }
    }
}
