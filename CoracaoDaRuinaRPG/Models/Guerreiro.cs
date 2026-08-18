using CoracaoDaRuinaRPG.Interface;
using CoracaoDaRuinaRPG.Utils;
namespace CoracaoDaRuinaRPG.Models;

public class Guerreiro : Personagem, IAtaque
{
    public Guerreiro(string nome) : base(nome)
    {
        Vida = 70;
        VidaMaxima = 70;
        Armadura = 20;
        ArmaduraMaxima = 20;
        DanoBase = 15;
        Furia = 0;
        FuriaMaxima = 20;
    }

    public int Armadura { get; private set; }
    public int ArmaduraMaxima { get; private set; }
    public int DanoBase { get; private set; }
    public int Furia { get; private set; }
    public int FuriaMaxima { get; protected set; }

    public void Atacar(Personagem alvo)
    {
        Random random = new Random();
        int chance = random.Next(1, 21);

        Console.WriteLine($"Valor do dado: {chance}!");
        Thread.Sleep(500);

        if (chance <= 5)
        {
            Falas.Sistema($"\n{Nome} errou o ataque em {alvo.Nome}!");
            return;
        }

        Falas.Sistema($"\n{Nome} atacou {alvo.Nome} com sua espada!");
        alvo.ReceberDano(DanoBase);
        Furia += 5;

        if (Furia >= 20)
        {
            Furia = 20;
        }
    }

    public void AtaqueFurioso(Personagem alvo)
    {
        int danoFurioso = DanoBase;

        if (Furia < 20)
        {
            Falas.Sistema("Você não possui Fúria o suficiente!");
            return;
        }

        danoFurioso *= 2;
        Falas.Sistema($"{Nome} usou o ataque furioso em {alvo.Nome}! Dano: {danoFurioso}!");
        alvo.ReceberDano(danoFurioso);
        Furia = 0;
    }
    public override void ReceberDano(int dano)
    {
        if (Armadura > 0)
        {
            Armadura -= dano;
            if (dano > ArmaduraMaxima)
                Armadura = 0;
        }
        else
        {
            Armadura = 0;
            base.ReceberDano(dano);
        }
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
        ArmaduraMaxima += 10;
        Armadura = ArmaduraMaxima;
    }
}