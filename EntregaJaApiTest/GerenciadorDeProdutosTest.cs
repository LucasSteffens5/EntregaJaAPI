using EntregaJaAPI.Assistants;
using EntregaJaAPI.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EntregaJaApiTest
{

	[TestClass]
	public class GerenciadorDeProdutosTest
	{

		[TestMethod]
		public void AoProcurarProdutoDeveRetornarFalso()
		{
			var gerenciadorDeProdutos = new GerenciadorDeProdutos();

			var produto = new Mock<Produto>();

			var resultado = gerenciadorDeProdutos.ProdutoNaoEncontrado(produto.Object);

			resultado.Should().BeFalse();
		}

	}
}
