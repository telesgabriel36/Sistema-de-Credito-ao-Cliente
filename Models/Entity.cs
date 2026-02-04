using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Credito_Cliente.Models;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
    [DisplayName("Nome")]
    public String Nome { get; set; }
}