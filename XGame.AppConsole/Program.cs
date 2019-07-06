using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando....");
            var service = new ServiceJogador();
            Console.WriteLine("Instância do serviço criada.");

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            Console.WriteLine("Instância da request criada.");
            request.Email = "teste";
            request.Senha = "testersrsrs";

            var response = service.Autenticar(request);
            Console.WriteLine($"Resposta recebida: {response}");
            Console.ReadKey();

        }
    }
}
