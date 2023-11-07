using System.ComponentModel.DataAnnotations;

namespace CRUDCliente.Application.DTOs;

public class ClienteDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Nome is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "The Cpf is Required")]
    [MinLength(11)]
    [MaxLength(11)]
    public string? Cpf { get; set;}

    [Required(ErrorMessage = "The Telefone is Required")]
    [MinLength(9)]
    public string? Telefone { get; set;}
}
