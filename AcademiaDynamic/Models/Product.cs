using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiaDynamic.Models;

[Table("Products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Por favor, informe o Nome")]
    [StringLength(100, ErrorMessage = "O Nome do produto deve possuir no máximo 100 caracteres")]
    public string Name { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(4000, ErrorMessage = "A Descrição deve possuir no máximo 4000 caracteres")]
    public string Description { get; set; }

    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Required(ErrorMessage = "Por favor, informe o Preço")]
    public decimal Price { get; set; }

    [Display(Name = "Estoque")]
    [Required(ErrorMessage = "Por favor, informe o Estoque")]
    public int StockQuantity { get; set; }

    [Display(Name = "Imagem")]
    [StringLength(200)]
    public string Image { get; set; }
}
