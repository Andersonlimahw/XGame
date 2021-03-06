﻿using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse: IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        // Cast, coversão explicita
        public static explicit operator AdicionarJogadorResponse(Entities.Jogador entity)
        {
            return new AdicionarJogadorResponse()
            {
               Id = entity.Id,
               Message = $"Jogador {entity.Nome.PrimeiroNome}, adicionadao com sucesso!"
            };
        }
    }
}
