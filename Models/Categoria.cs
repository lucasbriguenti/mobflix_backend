namespace Mobflix_backend.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Color { get; set; }
    public virtual List<Video> Videos { get; set; }
}