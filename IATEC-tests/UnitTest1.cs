using IATEC_desafio.Controllers;
using IATEC_desafio.Common.Models;
namespace IATEC_tests;

public class UnitTest1
{
    public UnitTest1(){
        
    }

    [Fact]
    public void InsereVendedor()
    {
        VendedorDTO v = new VendedorDTO()
        {
            Nome = "Gilmar",
            CPF = "12345678912"
        };
        
        // insert

        // Verificar se inseriu o vendedor
        //Assert.True(true);
    }

    [Fact]
    public void InsereVenda()
    {
        // Criar pedido fake
        // inserir
        //Assert.True(true);

        // TODO - validar vendedor em brando, deve retornar erro 400

        // TODO - validar pedido sem item, deve retornar erro 400
    }

    [Fact]
    public void AlterarStatusVenda()
    {   
        // TODO - validar alteração de status de pedido
        // Deve seguir sequencia.

        // fora da sequencia, deve retornar erro 400 (BadRequest)
        //Assert.True(true);
    }

}