using System.ComponentModel.DataAnnotations;

namespace EntregaJaAPI.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
