using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int vitorias = 0;
int derrotas = 0;
int empates = 0;

Console.WriteLine("😀 Olá! Vamos jogar Jokenpo?");
Console.WriteLine("1 - Sim ou 0 - Não");

var continuar = Console.ReadKey().KeyChar;
Console.WriteLine();

while (continuar == '1')
{
    Console.WriteLine("\nEscolha uma opção: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
    var opcao = Console.ReadKey().KeyChar;
    Console.WriteLine();

    if (opcao != '0' && opcao != '1' && opcao != '2')
    {
        Console.WriteLine("❌ Opção inválida! Digite 0, 1 ou 2.");
        Console.WriteLine("\nQuer jogar de novo?");
        Console.WriteLine("1 - Sim ou 0 - Não");
        continuar = Console.ReadKey().KeyChar;
        Console.WriteLine();
        continue;
    }

    var opcaoPC = new Random().Next(3);
    int opcaoJogador = int.Parse(opcao.ToString());

    string[] nomes = { "Pedra ✊", "Papel ✋", "Tesoura ✌" };

    Console.WriteLine($"\nVocê escolheu {nomes[opcaoJogador]}!");
    Console.WriteLine($"Eu escolhi {nomes[opcaoPC]}!");

    if (opcaoJogador == opcaoPC)
    {
        Console.WriteLine("\n🤝 Empatamos!");
        empates++;
    }
    else if ((opcaoJogador == 0 && opcaoPC == 2) ||
             (opcaoJogador == 1 && opcaoPC == 0) ||
             (opcaoJogador == 2 && opcaoPC == 1))
    {
        Console.WriteLine("\n🎉 Parabéns! Você venceu!");
        vitorias++;
    }
    else
    {
        Console.WriteLine("\n😏 Haha, eu venci! Mais sorte na próxima.");
        derrotas++;
    }

    Console.WriteLine($"\n📊 Placar: {vitorias} vitória(s) | {derrotas} derrota(s) | {empates} empate(s)");

    Console.WriteLine("\nQuer jogar de novo?");
    Console.WriteLine("1 - Sim ou 0 - Não");
    continuar = Console.ReadKey().KeyChar;
    Console.WriteLine();
}

Console.WriteLine("\n--- Resultado Final ---");
Console.WriteLine($"✅ Vitórias:  {vitorias}");
Console.WriteLine($"❌ Derrotas:  {derrotas}");
Console.WriteLine($"🤝 Empates:   {empates}");
Console.WriteLine("\n👋 Tchau! Até a próxima!");
