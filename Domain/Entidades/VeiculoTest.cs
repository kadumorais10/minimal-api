using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedadesVeiculo()

    {
        //arrange
        var veiculo = new Veiculo();

        //act
        veiculo.Ano = 2010 ;
        veiculo.Id = 2;
        veiculo.Marca = "toyotta";
        veiculo.Nome = "Corolla";



        //assert

        Assert.AreEqual(2, veiculo.Id);
        Assert.AreEqual(2010, veiculo.Ano);
        Assert.AreEqual("Corolla", veiculo.Nome);
        Assert.AreEqual("toyotta", veiculo.Marca);
    }
}