using System.ComponentModel.DataAnnotations;

namespace Crud.Data.Dtos;

public class CreateEmpresaDto
{
    
    
    [Required(ErrorMessage = "O nome da empresa é obrigatório!")]
    [StringLength(50, ErrorMessage = "O nome da empresa é muito grande!")]
    public string NomeEmpresa { get; set; }
    [Required(ErrorMessage = "A descrição da empresa é obrigatório!")]
    public string DescricaoEmpresa { get; set; }
    [Required(ErrorMessage = "O segmento da empresa é obrigatório!")]
    public string Segmento { get; set; }
}
