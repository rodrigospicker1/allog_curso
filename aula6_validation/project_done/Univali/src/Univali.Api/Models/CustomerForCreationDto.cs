using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public class CustomerForCreationDto
{
    [Required(ErrorMessage = "The filed ir required")]
    [MaxLength(100, ErrorMessage = "The name shouldn't have more than 100 chatacters")]
    public string Name {get; set;} = string.Empty;

    [Required(ErrorMessage = "The filed ir required")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "Cpf should have 11 chatacters")]
    public string Cpf {get; set;} = string.Empty;
}