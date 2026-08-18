using CoracaoDaRuinaRPG.Interface;
namespace CoracaoDaRuinaRPG.Models;

public class Ladino : Personagem, IAtaque
{
    public Ladino(string nome) : base(nome)
    {
        Vida = 50;
        VidaMaxima = 50;
        DanoBase = 10;
        Foco = 0;
        FocoMaximo = 20;
    }

    public int DanoBase;
    public int Foco;
    public int FocoMaximo;

    public void Atacar(Personagem alvo)
    {
        Random random = new Random();
        int chance = random.Next(1, 21);

        if(chance <= 4)
        {
            Console.WriteLine($"Valor do dado: {chance}!");
            Console.WriteLine($"{Nome} errou o ataque em {alvo.Nome}!");
            return;
        }

        Console.WriteLine($"Valor do dado: {chance}!");
        Thread.Sleep(500);
        Console.WriteLine($"{Nome} atacou {alvo.Nome} com suas adagas!");
        alvo.ReceberDano(DanoBase);
        Foco += 5;

        if(Foco >= 20)
        {
            Foco = 20;
        }
    }
    public void AtaqueAgil(Personagem alvo)
    {
        int danoAgil = DanoBase;

        if(Foco < 20)
        {
            Console.WriteLine("Você não possui Foco o suficiente!");
            return;
        }

        danoAgil *= 3;
        Console.WriteLine($"{Nome} atacou 3 vezes {alvo.Nome} usando o Ataque Ágil! Dano {danoAgil}!");
        alvo.ReceberDano(danoAgil);
        Foco = 0;
    }
    public override void ReceberDano(int dano)
    {
        if(Foco >= 21)
        {
            dano = 0;
            Vida -= dano;
            Console.WriteLine($"{Nome} esquivou do ataque!");
            Foco = 0;
            return;
        }
        else
            base.ReceberDano(dano);
    }

    public override void AumentarDano()
    {
        int valor = 10;
        DanoBase += valor;
    }
    public override void AumentarVida()
    {
        VidaMaxima += 20;
        Vida = VidaMaxima;
    }
}
