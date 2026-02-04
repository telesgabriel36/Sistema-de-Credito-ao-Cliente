using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Credito_Cliente.Models;

public class Cliente : Entity
{
    [Required(ErrorMessage = "O campo Cpf deve ser preenchido.")]
    [DisplayName("Cpf")]
    [StringLength(maximumLength: 11, MinimumLength = 11)]
    public String Cpf { get; set; }

    [DisplayName("Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateOnly Data_Nascimento { get; set; }

    public Endereco Endereco { get; set; }

    [Required]
    public Contato Contato { get; set; }

    public Cliente() { }
}