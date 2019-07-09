using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse: IResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        // Cast, coversão explicita
        public static explicit operator AutenticarJogadorResponse(Entities.Jogador entity)
        {
            return new AutenticarJogadorResponse()
            {
                Email = entity.Email.Endereco,
                PrimeiroNome = entity.Nome.PrimeiroNome,
                Status = (int)entity.Status
            };
        }
    }
}
