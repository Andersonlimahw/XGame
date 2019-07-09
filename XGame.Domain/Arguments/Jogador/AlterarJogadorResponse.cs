using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse: IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        // Cast, coversão explicita
        public static explicit operator AlterarJogadorResponse(Entities.Jogador entity)
        {
            return new AlterarJogadorResponse()
            {
               Id = entity.Id,
               Message = $"Jogador {entity.Nome.PrimeiroNome}, adicionadao com sucesso!"
            };
        }
    }
}
