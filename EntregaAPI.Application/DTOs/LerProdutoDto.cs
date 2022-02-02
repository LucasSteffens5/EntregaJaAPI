using System;
using System.ComponentModel.DataAnnotations;

namespace EntregaJaAPI.Data.DTOs
{
    public class LerProdutoDto
    {
        [Key]
        [Required]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo de preço é obrigatório")]
        public decimal Preco { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
