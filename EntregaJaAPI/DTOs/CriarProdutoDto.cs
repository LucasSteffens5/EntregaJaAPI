using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntregaJaAPI.Data.DTOs
{
    public class CriarProdutoDto
    {

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo de preço é obrigatório")]
        public decimal Preco { get; set; }

    }
}
