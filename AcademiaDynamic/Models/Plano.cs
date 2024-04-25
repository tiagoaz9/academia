using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiaDynamic.Models;

[Table("Planos")]
public class Plano
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(100, ErrorMessage = "O Nome do produto deve possuir no máximo 100 caracteres")]
    public string Name { get; set; }

    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10)")]
    [Required(ErrorMessage = "Por favor, informe o Preço")]
    public decimal Price { get; set; }
}
