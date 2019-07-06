using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Plataforma
{
    public class AdicionarPlataformaResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Message { get; set; }
    }
}
