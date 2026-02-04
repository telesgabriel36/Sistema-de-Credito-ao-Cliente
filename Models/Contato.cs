using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Credito_Cliente.Models;

public class Contato : Entity
{
    [Required(ErrorMessage = "O campo Telefone deve ser preenchido.")]
    [DisplayName("Telefone")]
    [DataType(DataType.PhoneNumber)]
    public String Telefone { get; set; }

    [DisplayName("Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }


    public Cliente Cliente { get; set; }
    public int ClienteID { get; set; }
    public Contato() { }
}