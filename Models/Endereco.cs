using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Credito_Cliente.Models;

public class Endereco : Entity
{
    [DisplayName("Rua")]
    public String Rua { get; set; }

    [DisplayName("Bairro")]
    public String Bairro { get; set; }

    [DisplayName("Cidade")]
    public String Cidade { get; set; }

    [DisplayName("Cep")]
    [MaxLength(8), MinLength(8)]
    public String Cep { get; set; }

    [DisplayName("Estado")]
    public String Estado { get; set; }

    public Cliente Cliente { get; set; }
    public int ClienteId { get; set; }

    public Endereco() { }


}