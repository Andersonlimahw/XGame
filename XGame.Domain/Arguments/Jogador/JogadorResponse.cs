using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogador
{
    public class JogadorResponse
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public string NomeCompleto { get; set; }

        public static explicit operator JogadorResponse(Entities.Jogador entity)
        {
            return new JogadorResponse()
            {
                Id = entity.Id,
                Email = entity.Email.Endereco,
                PrimeiroNome = entity.Nome.PrimeiroNome,
                UltimoNome = entity.Nome.UltimoNome,
                NomeCompleto = entity.retornaNomeCompleto(),
                Status = (int)entity.Status
            };
        }
    }
}
