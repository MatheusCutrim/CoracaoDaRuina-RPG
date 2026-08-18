using CoracaoDaRuinaRPG.Interface;
using CoracaoDaRuinaRPG.Utils;
namespace CoracaoDaRuinaRPG.Models;

public class Vampiro : Personagem, IAtaque
{
    public Vampiro(string nome) : base(nome)
    {
        Vida = 80;
        DanoBase = 30;
        Regeneracao = 0;
        RegeneracaoMaxima = 20;
    }

    public int DanoBase { get; private set; }
    public int Regeneracao { get; private set; }
    public int RegeneracaoMaxima { get; private set; }

    public void Atacar(Personagem alvo)
    {
        Random random = new Random();
        int chance = random.Next(1, 21);

        if (chance <= 2)
        {
            Falas.Sistema($"{Nome} errou o ataque em {alvo.Nome}!");
            return;
        }

        Falas.Sistema($"{Nome} atacou {alvo.Nome} e drenou seu sangue!");
        alvo.ReceberDano(DanoBase);
        Regeneracao += 5;

        if (Regeneracao >= RegeneracaoMaxima)
        {
            Regenerar();
            Regeneracao = 0;
        }
    }

    public void Regenerar()
    {
        int regeneracao = 20;
        Vida += regeneracao;

        Falas.Sistema($"{Nome} regenerou {regeneracao} de HP!");
        Thread.Sleep(500);
    }

    public override void AumentarDano()
    {
        int valor = 1;
        DanoBase += valor;
    }

    public override void AumentarVida()
    {
        VidaMaxima += 30;
        Vida = VidaMaxima;
    }
}