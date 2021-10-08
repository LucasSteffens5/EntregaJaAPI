using EntregaJaAPI.Assistants;
using EntregaJaAPI.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EntregaJaApiTest
{
	[TestClass] 
	public class GerenciadorDeVendasTest
	{

		[TestMethod]
		public void AoBuscarVendaDeveRetornarFalse()
		{
			var gerenciadorDeVendas = new GerenciadorDeVendas();

			var venda = new Mock<Venda>();

			var resultado = gerenciadorDeVendas.VendaNaoEncontrada(venda.Object);

			resultado.Should().BeFalse();
		}
	}
}
