using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogo
{
    public class AdicionarJogoResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AdicionarJogoResponse(Entities.Jogo entity)
        {
            return new AdicionarJogoResponse()
            {
                Id = entity.Id,
                Message = $"Jogo {entity.Nome}, adicionadao com sucesso!"
            };
        }
    }
}
