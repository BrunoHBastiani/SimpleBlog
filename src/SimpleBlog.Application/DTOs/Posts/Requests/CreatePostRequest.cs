using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Application.DTOs.Posts.Requests
{
    public record CreatePostRequest
    {
        [Required(ErrorMessage = $"O campo '{nameof(Title)}' é obrigatório")]
        [MaxLength(100, ErrorMessage = $"O tamanho máximo do campo '{nameof(Title)}' é de 100 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = $"O campo '{nameof(Content)}' é obrigatório")]
        [MaxLength(2000, ErrorMessage = $"O tamanho máximo do campo '{nameof(Content)}' é de 2000 caracteres.")]
        public string Content { get; set; }
    }
}
