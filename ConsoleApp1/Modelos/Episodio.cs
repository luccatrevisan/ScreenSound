namespace ScreenSound.Modelos;

class Episodio
{
    public Episodio(string titulo, int duracao)
    {
        Titulo = titulo;
        Duracao = duracao;
    }

    private List<string> convidados = new List<string>();
    public string? Titulo { get; }
    public int Duracao { get; }
    public string? Resumo => $"{Titulo} ({Duracao} min)" + (convidados.Count() > 0 ? $"\n Convidados: {string.Join(", ", convidados)}" : "");
    //normalmente o C# não transforma a lista em uma única string, por isso 'string.Join()')
    public void AdicionarConvidados(string convidado)
    {
        convidados.Add(convidado);
    }
}