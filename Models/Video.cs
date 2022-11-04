namespace Mobflix_backend.Models;

public class Video
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Url { get; set; }
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }

    protected Video()
    {
        
    }

    public Video(string titulo, string descricao, string url)
    {
        Titulo = titulo;
        Descricao = descricao;
        Url = url;
    }
}
