using XGame.Domain.Arguments.Plataforma;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServicePlataforma
    {
        AdicionarPlataformaResponse Adicionar(AdicionarPlataformaRequest request);
    }
}
