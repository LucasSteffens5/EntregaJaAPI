﻿using System.ComponentModel.DataAnnotations;

namespace EntregaJaAPI.Models
{
	public class Produto
    {
        [Key]
        [Required]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo de preço é obrigatório")]
        public decimal Preco { get; set; }

    }
}
