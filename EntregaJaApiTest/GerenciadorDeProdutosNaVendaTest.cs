using EntregaJaAPI.Assistants;
using EntregaJaAPI.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EntregaJaApiTest
{
	[TestClass]
	public class GerenciadorDeProdutosNaVendaTest
	{

		[TestMethod]
		public void AoProcurarProdutoDeveRetornarFalso()
		{
			var temErro = false;
			var gerenciadorDeProdutosNaVenda = new GerenciadorDeProdutosNaVenda();

			var produtoNaVenda = new Mock<ProdutoNaVenda>();
			var produto = new Mock<Produto>();

			try
			{
				gerenciadorDeProdutosNaVenda.PreecnherDadosBasicosDoProdutoNaVenda(produtoNaVenda.Object, produto.Object);
			}
			catch
			{
				temErro = true;
			}

			temErro.Should().BeFalse();
		}
	}
}
