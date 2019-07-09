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

            Console.WriteLine("Adicionando jogador...");
            AdicionarJogadorRequest requestAdicionar = new AdicionarJogadorRequest() {
                Email = "anderson.lima@lemontech.com",
                PrimeiroNome = "Anderson",
                UltimoNome = "Lima",
                Senha = "123456"
            };

            var responseAdicionar = service.Adicionar(requestAdicionar);
            Console.WriteLine($"{responseAdicionar.Message}");
            AutenticarJogadorRequest request = new AutenticarJogadorRequest()
            {
                Email = requestAdicionar.Email,
                Senha = requestAdicionar.Senha
            };
            
            Console.WriteLine($"Email: {request.Email}, Senha: {request.Senha} ");
            var response = service.Autenticar(request);
            Console.WriteLine("Jogador autenticado com sucesso!");

            Console.WriteLine($" Serviço é valido -> {service.IsValid()}");
            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine($"Message:  {x.Message}");
            });

            Console.WriteLine($"Listando jogadores");
            service.ListarJogador().ToList().ForEach(jogador => {
                Console.WriteLine($"Jogador -> {jogador.NomeCompleto}, Status: {jogador.Status}");
            });

            Console.ReadKey();


        }
    }
}
