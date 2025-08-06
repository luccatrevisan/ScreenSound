namespace ScreenSound.Modelos;

class Banda
{
    private List<Album> albums = new List<Album>();
    private List<int> notas = new List<int>();

    public Banda(string nome)
    {
        Nome = nome;
    }
    public string? Nome { get; }
    public double Media => notas.Average();
    public List<Album> Albuns => albums;

    public void AdicionarAlbum(Album album)
    {
        albums.Add(album);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"{Nome}: Discografia\n");
        foreach (Album album in albums)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"{album.Nome} ({album.DuracaoTotal}s)");
        }
    }
}