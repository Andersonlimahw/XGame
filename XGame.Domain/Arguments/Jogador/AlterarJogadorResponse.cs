using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse: IResponse
    {
        public Guid Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }
        public string Email { get; set; }

        public string Message { get; set; }

        // Cast, conversão explicita
        public static explicit operator AlterarJogadorResponse(Entities.Jogador entity)
        {
            return new AlterarJogadorResponse()
            {
               Id = entity.Id,
               PrimeiroNome = entity.Nome.PrimeiroNome,
               UltimoNome = entity.Nome.UltimoNome,
               Email = entity.Email.Endereco,
               Message = $"Jogador {entity.Nome.PrimeiroNome}, adicionadao com sucesso!"
            };
        }
    }
}
