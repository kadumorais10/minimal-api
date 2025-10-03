using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTest

{
    private DbContexto CriarContextoDeTeste()
{
    var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    var basePath = assemblyPath ?? Directory.GetCurrentDirectory();

    // diagnóstico: veja se o arquivo está realmente onde esperamos
    var candidate = Path.Combine(basePath, "appsettings.json");
    if (!File.Exists(candidate))
    {
        // tenta verificar pastas parentes (útil quando a estrutura de pastas muda)
        var alt = Path.GetFullPath(Path.Combine(basePath, "..", "..", "..", "appsettings.json"));
        if (File.Exists(alt)) candidate = alt;
    }

    if (!File.Exists(candidate))
        throw new InvalidOperationException($"appsettings.json não encontrado. Verifique se o arquivo existe no output folder. Caminhos checados: {basePath}, {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}");

    var builder = new ConfigurationBuilder()
        .SetBasePath(Path.GetDirectoryName(candidate) ?? basePath)
        .AddJsonFile(Path.GetFileName(candidate), optional: false, reloadOnChange: false)
        .AddEnvironmentVariables();

    var configuration = builder.Build();

    var conn = configuration.GetConnectionString("DefaultConnection")
               ?? configuration["ConnectionStrings:DefaultConnection"];

    if (string.IsNullOrWhiteSpace(conn))
        throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");

    var options = new DbContextOptionsBuilder<DbContexto>()
        .UseMySql(conn, ServerVersion.AutoDetect(conn)) // ajuste se não usar MySql
        .Options;

    return new DbContexto(options);
}



   
    [TestMethod]
    public void TestandoSalvarAdministrador()

    {
        //arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
        adm.Id = 1;
        var administradorServico = new AdministradorServico(context);


        //act
        administradorServico.Incluir(adm);
    

         //assert

        Assert.AreEqual(1, administradorServico.Todos(1).Count());
    }

    public void TestandoBuscaPorId()

    {
        //arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
        adm.Id = 1;
        var administradorServico = new AdministradorServico(context);


        //act
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        //assert


#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.AreEqual(1, admDoBanco.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    }
    
}