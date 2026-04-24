using CoracaoDaRuinaRPG.Interface;
using CoracaoDaRuinaRPG.Utils;
namespace CoracaoDaRuinaRPG.Models;


public class Esqueleto : Personagem, IAtaque
{
    public Esqueleto(string nome) : base(nome)
    {
        Vida = 50;
        Armadura = 15;
        DanoBase = 10;
    }

    public int Armadura { get; private set; }
    public int DanoBase { get; private set; }

    public void Atacar(Personagem alvo)
    {
        Random random = new Random();
        int chance = random.Next(1, 21);

        if (chance <= 1)
        {
            Falas.Sistema($"{Nome} errou o ataque em {alvo.Nome}!");
            return;
        }

        Falas.Sistema($"{Nome} cortou {alvo.Nome} com sua espada de ossos!");
        alvo.ReceberDano(DanoBase);
    }

    public override void ReceberDano(int dano)
    {
        if(Armadura > 0)
        {
            Armadura -= dano;
            if(dano > Armadura)
                Armadura = 0;
            return;
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
        int valor = 10;
        Vida += valor;
    }
}
