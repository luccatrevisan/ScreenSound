namespace ScreenSound.Modelos;

class Musica
{
    public Musica(Banda artista, string nome) //defino uma regra assim que uma Musica for criada, exigindo nome do artista ou banda
    {
        Artista = artista;
        Nome = nome;
    }

    public string? Nome { get; } //qual a diferença exata entre public e private?
    public Banda Artista { get; } //ao apagar set, mostro para o sistema que essa propriedade não pode ser escrita, apenas lida.
    public int Duracao { get; set; }//get (leitura) e set (escrita)
    public bool Disponivel { get; set; }
    public string? DescricaoResumida => $"{Nome} - {Artista}"; //lambda

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"{Nome}");
        Console.WriteLine($"{Artista.Nome}"); //por que Artista.Nome?
        Console.WriteLine($"{Duracao}s");
        if (Disponivel)
        {
            Console.WriteLine("Música disponível!\n");
        }
        else
        {
            Console.WriteLine("Música indiponível! Adquira o Plano Plus+ para ouvir essa PEDRADA.\n");
        }
    }
}