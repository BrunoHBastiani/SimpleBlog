using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Application.DTOs.Posts.Requests
{
    public record UpdatePostRequest
    {
        [MaxLength(100, ErrorMessage = $"O tamanho máximo do campo '{nameof(Title)}' é de 100 caracteres.")]
        public string? Title { get; set; }

        [MaxLength(2000, ErrorMessage = $"O tamanho máximo do campo '{nameof(Content)}' é de 2000 caracteres.")]
        public string? Content { get; set; }
    }
}
