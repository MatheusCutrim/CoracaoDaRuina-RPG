using CoracaoDaRuinaRPG.Utils;
using CoracaoDaRuinaRPG.Interface;
namespace CoracaoDaRuinaRPG.Models;

public static class Combate
{
    public static bool Duelo(Personagem jogador, Personagem inimigo)
    {
        Console.WriteLine($"{jogador.Nome} X {inimigo.Nome}");

        while (jogador.Vida > 0 && inimigo.Vida > 0)
        {
            Console.Clear();

            ExibirStatus(jogador, inimigo);

            TurnoJogador(jogador, inimigo);
            Thread.Sleep(200);
            TurnoInimigo(jogador, inimigo);
            Thread.Sleep(800);
        }

        if(!jogador.EstaVivo())
        {
            Falas.Narrador("Você lutou bravamente, mas caiu em combate... Você está MORTO!");
            Thread.Sleep(1000);
            return false;
        }
        else
        {
            Falas.Narrador("O Inimigo caiu! Você VENCEU!");
            Thread.Sleep(1000);
            return true;
        }
        
    }

    private static void TurnoJogador(Personagem jogador, Personagem inimigo)
    {
        Console.WriteLine($"\n1 - {(jogador is Guerreiro ? "Atacar [Fúria +5]" : jogador is Mago ? "Atacar [Mana +5]" : jogador is Ladino ? "Atacar [Foco +5]" : "")}");
        Console.WriteLine($"2 - {(jogador is Guerreiro ? "Ataque Furioso [Fúria = 20]" : jogador is Mago ? "Poder Especial [Mana = 20]" : jogador is Ladino ? "Ataque Ágil [Foco = 20]" : "")}");
        Console.WriteLine($"0 - Pular Turno");

        int escolhaJogador;

        Console.Write("Digite o número da sua escolha: ");
        while (!int.TryParse(Console.ReadLine(), out escolhaJogador))
        {
            Falas.Sistema("Entrada inválida.");
            continue;
        }

        switch (escolhaJogador)
        {
            case 1:
                if (jogador is IAtaque atacante)
                    atacante.Atacar(inimigo);
                Thread.Sleep(1000);
                break;
            case 2:
                if (jogador is Guerreiro guerreiro)
                    guerreiro.AtaqueFurioso(inimigo);
                else if (jogador is Mago mago)
                    mago.FeiticoEspecial(inimigo);
                else if (jogador is Ladino ladino)
                    ladino.AtaqueAgil(inimigo);
                Thread.Sleep(1000);
                break;
            case 0:
                Console.WriteLine("Você pulou o turno.");
                Thread.Sleep(1000);
                break;
        }
    }

    private static void TurnoInimigo(Personagem jogador, Personagem inimigo)
    {
        if (!inimigo.EstaVivo())
            return;

        if (inimigo is IAtaque atacante)
        {
            atacante.Atacar(jogador);
        }
    }

    public static void ExibirStatus(Personagem jogador, Personagem inimigo)
    {
        Console.WriteLine($"========= {jogador.Nome} X {inimigo.Nome} =========");
        Console.WriteLine($"Lvl {jogador.Nivel} | {jogador.Nome}: {jogador.Vida} HP | {(jogador is Guerreiro guerreiro ? $"Armadura: {guerreiro.Armadura} | Fúria: {guerreiro.Furia}/{guerreiro.FuriaMaxima}" : jogador is Mago mago ? $"Mana: {mago.Mana}/{mago.ManaMaxima}" : jogador is Ladino ladino ? $"Foco: {ladino.Foco}/{ladino.FocoMaximo}" : "")} ");
        Console.WriteLine($"Lvl {inimigo.Nivel} | {inimigo.Nome}: {inimigo.Vida} HP | {(inimigo is Esqueleto esqueleto ? $"Armadura: {esqueleto.Armadura}" : "")}");
        Console.WriteLine($"===================================================");
    }
}
