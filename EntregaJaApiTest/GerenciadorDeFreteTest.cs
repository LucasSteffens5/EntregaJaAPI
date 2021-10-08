using EntregaJaAPI.Assistants;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EntregaJaApiTest
{
	[TestClass]
	public class GerenciadorDeFretetEST
	{
		[TestMethod]
		public void AoCalcularFreteDeveRetornarFreteParaInteriorDoRioDeJaneiro()
		{
			var caculador = new GerenciadorDeFrete();

			var cep = "27700-000";

			var resultado = caculador.CalcularFrete(cep);

			resultado.Should().Be(20);
		}


		[TestMethod]
		public void AoCalcularFreteDeveRetornarFretePararegiaoMetropolitanaDoRioDeJaneiro()
		{
			var caculador = new GerenciadorDeFrete();

			var cep = "26600-000";

			var resultado = caculador.CalcularFrete(cep);

			resultado.Should().Be(20);
		}

		[TestMethod]
		public void AoCalcularFreteDeveRetornarFreteParaCapitalDoRioDeJaneiro()
		{
			var caculador = new GerenciadorDeFrete();

			var cep = "23580-430";

			var resultado = caculador.CalcularFrete(cep);

			resultado.Should().Be(10);
		}


		[TestMethod]
		public void AoCalcularFreteDeveRetornarFreteParaOutrasCidades()
		{
			var caculador = new GerenciadorDeFrete();

			var cep = "78570-000";

			var resultado = caculador.CalcularFrete(cep);

			resultado.Should().Be(40);
		}

		[TestMethod]
		public void AoCalcularFreteDeveRetornarExecao()
		{
			var caculador = new GerenciadorDeFrete();

			var cep = "olaMundo";
			try
			{
				var resultado = caculador.CalcularFrete(cep);
			}
			catch (Exception ex)
			{
				ex.Message.Should().Be("Cep Invalido!");
			}
		}
	}
}
