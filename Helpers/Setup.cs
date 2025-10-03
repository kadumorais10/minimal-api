
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;
using Test.Mocks;



namespace Test.Helpers;

public class Setup
{
    public const string PORT = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;

        // Cria a factory e configura o host de teste
        var factory = new WebApplicationFactory<Startup>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", Setup.PORT)
                       .UseEnvironment("Testing");

                // Preferível em testes: ConfigureTestServices para sobrescrever serviços
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
                });
            });

        // Atribui a factory estática (agora já criada)
        Setup.http = factory;

        // Cria o HttpClient a partir da factory (fora do lambda)
        Setup.client = Setup.http.CreateClient();
    }
    public static void ClassCleanup()
    {
        Setup.http.Dispose();
    }
}





