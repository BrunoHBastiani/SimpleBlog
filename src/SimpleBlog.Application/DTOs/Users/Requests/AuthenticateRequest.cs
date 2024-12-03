using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Application.DTOs.Users.Requests
{
    public record AuthenticateRequest
    {
        [Required(ErrorMessage = $"O campo '{nameof(Email)}' é obrigatório.")]
        [EmailAddress(ErrorMessage = $"O campo '{nameof(Email)}' possui um valor inválido.")]
        public string Email { get; init; }

        [Required(ErrorMessage = $"O campo '{nameof(Password)}' é obrigatório")]
        [MaxLength(2000, ErrorMessage = $"O tamanho máximo do campo '{nameof(Password)}' é de 200 caracteres.")]
        public string Password { get; init; }
    }
}
