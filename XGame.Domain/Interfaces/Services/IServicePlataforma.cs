using XGame.Domain.Arguments.Plataforma;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServicePlataforma : IServiceBase
    {
        AdicionarPlataformaResponse Adicionar(AdicionarPlataformaRequest request);
    }
}
