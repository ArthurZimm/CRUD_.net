using System.ComponentModel.DataAnnotations;

namespace Crud.Models;

public class Empresa
{
    [Key]
    [Required]
    public int IdEmpresa { get; set; }
    [Required(ErrorMessage = "O nome da empresa é obrigatório!")]
    public string NomeEmpresa { get; set; }
    [Required(ErrorMessage = "A descrição da empresa é obrigatório!")]
    public string DescricaoEmpresa { get; set; }
    [Required(ErrorMessage = "O segmento da empresa é obrigatório!")]
    public string Segmento { get; set; }
}
