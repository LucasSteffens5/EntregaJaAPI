using EntregaJaAPI.Data;
using EntregaJaAPI.Models;

namespace EntregaJaAPI.Assistants
{
	public class GerenciadorDeProdutosNaVenda
	{
		public GerenciadorDeProdutosNaVenda()
		{

		}

		public void AdicionarProdutoNaVendaNaBaseDeDados(DataContext contexto, ProdutoNaVenda produtoNaVenda)
		{
			contexto.ProdutosNaVenda.Add(produtoNaVenda);
		}


		public void PreecnherDadosBasicosDoProdutoNaVenda(ProdutoNaVenda produto, Produto item)
		{
			produto.Nome = item.Nome;
			produto.Preco = item.Preco;
		}

	}
}
