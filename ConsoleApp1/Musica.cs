class Musica
{
    public string? nome;
    public string? artista;
    public int duracao;
    public bool disponivel;

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Artista: {artista}");
        Console.WriteLine($"Duração: {duracao} segundos");
        if (disponivel)
        {
            Console.WriteLine("Dispnível para Reprodução!");
        } else
        {
            Console.WriteLine("Essa música não está disponível! Adquira agora o Plano Plus+ para ter acesso a todas as músicas!");
        }
    }
}