//docs C#: https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/
//docs DOTNET: https://learn.microsoft.com/pt-br/dotnet/api/
//docs VISUAL STUDIO: https://learn.microsoft.com/pt-br/visualstudio/?view=vs-2022

using ScreenSound.Modelos;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!";
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

//início do programa
ExibirMenu();

void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine(@"
    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirMenu()
{
    ExibirMensagemDeBoasVindas();
    Console.WriteLine("\nDigite 1: Para Registrar Uma Banda");
    Console.WriteLine("Digite 2: Para Registrar Um Album");
    Console.WriteLine("Digite 3: Para Mostrar Todas As Bandas");
    Console.WriteLine("Digite 4: Para Avaliar Uma Banda");
    Console.WriteLine("Digite 5: Para Exibir Os Detalhes De Uma Banda");
    Console.WriteLine("Digite 6: Para Acessar a Área de Testes");
    Console.WriteLine("Digite 7: Para Registrar Um Podcast");
    Console.WriteLine("Digite 8: Para Sair");

    Console.Write("\nDigite a opção desejada: ");
    string opcaoDesejada = Console.ReadLine()!;
    int opcaoDesejadaNumerica = int.Parse(opcaoDesejada);

    switch (opcaoDesejadaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            RegistrarAlbum();
            break;
        case 3:
            MostrarBandasRegistradas();
            break;
        case 4:
            AvaliarUmaBanda();
            break;
        case 5:
            ExibirDetalhes();
            break;
        case 6:
            AprendendoClasses();
            break;
        case 7:
            RegistrandoPodcast();
            break;
        case 8:
            Console.WriteLine("Opção de saída selecionada.");
            break;
        default:
            Console.WriteLine("Opção inválida! Por favor, tente novamente.");
            ExibirMenu();
            break;
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void RegistrarBanda()
{
    /*
    TO-DO: 
    - adicionar validação para verificar se o nome da banda já existe no dicionário
    - adicionar padronização: como deixar todas as letras maiúsculas?
    */
    Console.Clear();
    ExibirTituloDaOpcao("REGISTRANDO UMA BANDA");
    Console.Write("Digite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso! Redirecionando automaticamente para o menu...");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}

void RegistrarAlbum()
{
    Console.Clear();
    ExibirTituloDaOpcao("REGISTRANDO UM ÁLBUM");
    Console.Write("Digite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write("Digite o nome do álbum: ");
        string nomeAlbum = Console.ReadLine()!;
        //adicionar à lista do tipo album da classe Album
        Console.WriteLine($"Álbum {nomeAlbum} adicionado com sucesso à Discografia de {nomeBanda}");
    }
    else
    {
        Console.WriteLine("Ainda não temos essa banda no nosso sistema! Seja a primeira pessoa a cadastrar essa banda e depois volte para cadastrar o álbum!");
    }
    Console.Write("Pressione qualquer tecla para voltar ao Menu");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("EXIBINDO AS BANDAS REGISTRADAS");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine(banda);
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("AVALIANDO UMA BANDA");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string bandaDesejada = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(bandaDesejada))
    {
        Console.Write($"Digite a nota de 0 a 10 para a banda {bandaDesejada}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[bandaDesejada].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {bandaDesejada}! Redirecionando para o menu...");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaDesejada} não está no nosso banco de dados. Por favor, volte para o menu e seja o primeiro a registrar ela!");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void ExibirDetalhes()
{
    //TO-DO: adicionar categorias. se a banda for maior que 8.5 é pq ela é MUITO BOA
    Console.Clear();
    ExibirTituloDaOpcao("EXIBIR DETALHES DA BANDA");
    Console.Write("Digite o nome da banda que deseja analisar: ");
    string bandaDesejada = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(bandaDesejada))
    {
        List<int> notas = bandasRegistradas[bandaDesejada];
        if (notas.Count == 0)
        {
            Console.WriteLine($"A banda {bandaDesejada} ainda não possui avaliações.");
        }
        else
        {
            Console.WriteLine($"A média de avaliações da banda {bandaDesejada} é: {notas.Average():F2}");
        }
    }
    else
    {
        Console.WriteLine($"A banda {bandaDesejada} não está registrada. Confira se digitou corretamente ou seja a primeira pessoa a cadastrar a banda!");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void AprendendoClasses()
{
    Console.Clear();
    ExibirTituloDaOpcao("Aprendendo Classes");
    //cria banda e dá nome
    Banda queen = new Banda("Queen");

    //cria album e adiciona à banda
    Album albumDoQueen = new Album("A night at the opera");
    queen.AdicionarAlbum(albumDoQueen);

    //cria música1 e adiciona ao album 
    Musica musica1 = new Musica(queen, "Love of My Life")
    {
        Duracao = 213,
        Disponivel = true,
    };
    albumDoQueen.AdicionarMusica(musica1);

    //cria musica2 e adiciona ao album 
    Musica musica2 = new Musica(queen, "Bohemian Rhapsody")
    {
        Duracao = 354,
        Disponivel = false,
    };
    albumDoQueen.AdicionarMusica(musica2);

    //exibe ficha técnica e albuns da banda
    musica1.ExibirFichaTecnica();
    musica2.ExibirFichaTecnica();
    queen.ExibirDiscografia();
}

void RegistrandoPodcast()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registrando Podcasts");

    //Criando Podcast Caio Mendes e seus Amigos, adicionando episódios
    Podcast CaioMendes = new Podcast("Caio Mendes", "Caio Mendes e seus Amigos");

    Episodio GotEpisodio1 = new Episodio("Game of Thrones", 160);
    GotEpisodio1.AdicionarConvidados("Lucca Trevisan");
    GotEpisodio1.AdicionarConvidados("Fernanda Montenegro");
    CaioMendes.AdicionarEpisodio(GotEpisodio1);

    Episodio GotEpisodio2 = new Episodio("Game of Thrones", 270);
    CaioMendes.AdicionarEpisodio(GotEpisodio2);

    Episodio GotEpisodio3 = new Episodio("Game of Thrones", 234);
    CaioMendes.AdicionarEpisodio(GotEpisodio3);
    GotEpisodio3.AdicionarConvidados("Luiz Alberto");

    CaioMendes.ExibirDetalhes();

    //Criando Podcast de Exemplo da Alura, adicionando episódios
    Podcast podcast = new("Podcast Especial", "Alura");

    Episodio ep1 = new("Técnicas de Facilitação", 45);
    ep1.AdicionarConvidados("Maria");
    ep1.AdicionarConvidados("Marcelo");
    podcast.AdicionarEpisodio(ep1);

    Episodio ep2 = new("Técnicas de Aprendizado", 67);
    ep2.AdicionarConvidados("Fernando");
    ep2.AdicionarConvidados("Marcos");
    ep2.AdicionarConvidados("Flavia");
    podcast.AdicionarEpisodio(ep2);

    podcast.ExibirDetalhes();
}