using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Credito_Cliente.Models;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("Data de Cadastro")]
    public DateTime Data_Cadastro { get; set; }

    [Required]
    [DisplayName("Data última atualização")]
    [DataType(DataType.DateTime)]
    public DateTime Data_Atualizacao { get; set; }
}