using System;
using System.Linq;
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

            AutenticarJogadorRequest request = new AutenticarJogadorRequest() {
                Email = "andeson@lima.com",
                Senha = "123456"
            };
            Console.WriteLine("Instância da request criada.");
            Console.WriteLine($"Email: {request.Email} ");

            var response = service.Autenticar(request);
            //var invalidRequest = service.Autenticar(null);
            Console.WriteLine($" Serviço é valido -> {service.IsValid()}");
             
            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine($"Message:  {x.Message}");
            });
            Console.ReadKey();


        }
    }
}
