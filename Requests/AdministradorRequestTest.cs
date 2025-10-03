

using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MinimalApi.Dominio.ModelViews;
using MinimalApi.DTOs;
using Test.Helpers;

namespace Test.Requests;
    


[TestClass]
public  class AdministradorRequestTest
{
    [ClassInitialize]

    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }

    [ClassCleanup]

    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }

    [TestMethod]
    public async Task TestarGetSetPropriedadesAdministrador()

    {
        //arrange
        var loginDTO = new LoginDTO
        {
            Email = "adm@teste.com",
            Senha = "123456"
        };

        var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "Application/json");



        //act

        var response = await Setup.client.PostAsync("/administradores/login", content);




        //assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();
        var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.IsNotNull(admLogado?.Email ?? "");

        Assert.IsNotNull(admLogado?.Token ?? "");
        Assert.IsNotNull(admLogado?.Perfil ?? "");

    }
}