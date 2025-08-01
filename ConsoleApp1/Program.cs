//docs C#: https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/
//docs DOTNET: https://learn.microsoft.com/pt-br/dotnet/api/
//docs VISUAL STUDIO: https://learn.microsoft.com/pt-br/visualstudio/?view=vs-2022

//Screen Sound
using System.Xml;

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
    Console.WriteLine("Digite 2: Para Mostrar Todas As Bandas");
    Console.WriteLine("Digite 3: Para Avaliar Uma Banda");
    Console.WriteLine("Digite 4: Para Conferir A Média de Avaliação De Uma Banda");
    Console.WriteLine("Digite 5: Para Sair");

    Console.Write("\nDigite a opção desejada: ");
    string opcaoDesejada = Console.ReadLine()!;
    int opcaoDesejadaNumerica = int.Parse(opcaoDesejada);

    switch (opcaoDesejadaNumerica)
    {
        case 1: 
            RegistrarBanda();
            break;
        case 2: 
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            CalcularMediaDeBanda();
            break;
        case 5: 
            Console.WriteLine("Opção 5 selecionada.");
            break;
        default: 
            Console.WriteLine("Opção inválida! Por favor, escolha uma opção entre 1 e 5.");
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
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso! Redirecionando para o menu...");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("EXIBINDO AS BANDAS REGISTRADAS");

    if (bandasRegistradas.Keys.Count == 0)
    {
        Console.WriteLine("Nenhuma banda registrada. Seja a primeira pessoa a fazer o registro!");
    } else
    {
        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine(banda);
        }
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

void CalcularMediaDeBanda()
{
    //TO-DO: adicionar categorias. se a banda for maior que 8.5 é pq ela é MUITO BOA
    Console.Clear();
    ExibirTituloDaOpcao("ANÁLISE DE MÉDIAS POR BANDA");
    Console.Write("Digite o nome da banda que deseja conferir a média de avaliação: ");
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