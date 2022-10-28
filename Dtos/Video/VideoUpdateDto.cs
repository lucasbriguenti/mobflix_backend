using System.ComponentModel.DataAnnotations;

namespace Mobflix_backend.Dtos.Video;

public class VideoUpdateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Titulo { get; set; }
    [Required]
    public string Descricao { get; set; }
    [Url]
    public string Url { get; set; }
}
