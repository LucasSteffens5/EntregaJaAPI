using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntregaJaAPI.Models
{
	public class Venda
	{
		[Key]
		[Required]
		public int IdVenda { get; set; }

		[Required(ErrorMessage = "O campo CEP é obrigatório")]
		public string Cep { get; set; }

		public DateTime DataHoraVenda { get; set; }

		public DateTime DataHoraCancelamentoVenda { get; set; }

		public decimal ValorFrete { get; set; }

		public decimal ValorTotalVenda { get; set; }

		public List<ProdutoNaVenda> ProdutosDaVenda { get; set; }
	}
}
