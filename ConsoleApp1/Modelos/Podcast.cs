class Podcast
{
    public Podcast(string host, string nome)
    {
        Host = host;
        Nome = nome;
    }

    private List<Episodio> episodios = new List<Episodio>();
    public string? Host { get; }
    public string? Nome { get; }
    public int TotalEpisodios => episodios.Count();

    public void AdicionarEpisodio(Episodio episodio)
    {
        episodios.Add(episodio);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine("-------------------------------------------------------------------------");
        Console.WriteLine($"Podcast {Nome} - Apresentado por: {Host}");
        Console.WriteLine("-------------------------------------------------------------------------");

        for (int i = 0; i < TotalEpisodios; i++)
        {
            Console.WriteLine($"\nEpisódio #{i + 1}: {episodios[i].Resumo}");
        }
        Console.WriteLine($"Esse podcast possui um total de {TotalEpisodios} episódios");
    }
}