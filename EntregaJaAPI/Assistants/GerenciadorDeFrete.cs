using System;
using System.Text.RegularExpressions;

namespace EntregaJaAPI.Assistants
{
	public class GerenciadorDeFrete
	{
		public GerenciadorDeFrete()
		{

		}

		public decimal CalcularFrete(string cep)
		{
			var cepApenasDigitos = RetornarApenasDigitos(cep);

			ValidarCep(cepApenasDigitos);



			if (EhRioDeJaneiroCapital(cepApenasDigitos) || EhRioDeJaneiroRegiaoMetropolitana(cepApenasDigitos)) return 10;

			if (EhRioDeJaneiroInterior(cepApenasDigitos)) return 20;

			return 40;
		}


		private void ValidarCep(string cep)
		{
			if (cep.Length != 8) throw new Exception("Cep Invalido!");
		}

		private bool EhRioDeJaneiroCapital(string cep)
		{
			Regex ehRioDeJaneiroCapital = new Regex(@"[2]{1}[0-3]{1}[0-7]{1}[0-9]{2}[0-9]{3}");

			return ehRioDeJaneiroCapital.IsMatch(cep) ? true : false;
		}

		private bool EhRioDeJaneiroRegiaoMetropolitana(string cep)
		{
			Regex ehRioDeJaneiroRegiaoMetropolitana = new Regex(@"[2]{1}[0-6]{1}[0-5]{1}[0-9]{2}[0-9]{3}");

			return ehRioDeJaneiroRegiaoMetropolitana.IsMatch(cep) ? true : false;
		}

		private bool EhRioDeJaneiroInterior(string cep)
		{
			Regex ehRioDeJaneiroInterior = new Regex(@"[2]{1}[6-8]{1}[6-9]{1}[0-9]{2}[0-9]{3}");

			return ehRioDeJaneiroInterior.IsMatch(cep) ? true : false;
		}

		private string RetornarApenasDigitos(string cep)
		{
			return Regex.Replace(cep, @"[^\d]", "");
		}
	}
}