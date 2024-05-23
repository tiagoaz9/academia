using System.ComponentModel.DataAnnotations;

namespace AcademiaDynamic.ViewModels;

public class LoginVM
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Por favor, informe seu email")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Senha de Acesso")]
    [Required(ErrorMessage = "Por favor, informe sua senha")]
    public string Senha { get; set; }

    [Display(Name = "Manter Conectado?")]
    public bool Lembrar { get; set; } = false;
    
    public string UrlRetorno { get; set; }
}