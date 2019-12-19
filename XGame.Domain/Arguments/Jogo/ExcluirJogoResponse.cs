using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogo
{
    public class ExcluirJogoResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator ExcluirJogoResponse(Entities.Jogo entity)
        {
            return new ExcluirJogoResponse()
            {
                Id = entity.Id,
                Message = $"Jogo {entity.Nome} removido com sucesso!"
            };
        }
    }
}
