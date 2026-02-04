using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Credito_Cliente.Models;

public class Produto : Entity
{
    [Required(ErrorMessage = "Ocampo Marca deve ser preenchido.")]
    [DisplayName("Marca")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O campo Preco deve ser preenchido.")]
    [DisplayName("Preço")]
    [DataType(DataType.Currency)]
    public double Preco { get; set; }

    [DisplayName("Código de Barras")]
    public string Codigo_Barras { get; set; }

    public Produto() { }
}