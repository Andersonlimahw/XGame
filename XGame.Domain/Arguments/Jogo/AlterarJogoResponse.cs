using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogo
{
    public class AlterarJogoResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AlterarJogoResponse(Entities.Jogo entity)
        {
            return new AlterarJogoResponse()
            {
                Id = entity.Id,
                Message = $"Jogo {entity.Nome}, atualizado com sucesso!"
            };
        }
    }
}
