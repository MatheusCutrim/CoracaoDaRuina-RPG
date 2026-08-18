using CoracaoDaRuinaRPG.Enums;
using CoracaoDaRuinaRPG.Interface;
using CoracaoDaRuinaRPG.Utils;
namespace CoracaoDaRuinaRPG.Models;

public class Mago : Personagem, IAtaque
{
    public Mago(string nome, Feiticos elemento) : base(nome)
    {
        Vida = 60;
        VidaMaxima = 60;
        DanoBase = 20;
        Mana = 0;
        ManaMaxima = 20;
        Elemento = elemento;
    }

    public int DanoBase { get; private set; }
    public int Mana { get; private set; }
    public int ManaMaxima { get; protected set; }
    public Feiticos Elemento { get; set; }
    public void Atacar(Personagem alvo)
    {
        Random random = new Random();
        int chance = random.Next(1, 21);

        if (chance <= 5)
        {
            Console.WriteLine($"\nValor do dado: {chance}!");
            Falas.Sistema($"{Nome} errou o ataque em {alvo.Nome}!");
            return;
        }


        Console.WriteLine($"\nValor do dado: {chance}!");
        Thread.Sleep(500);

        switch (Elemento)
        {
            case Feiticos.Fogo:
                Falas.Sistema($"{Nome} atacou {alvo.Nome} com um poder de Fogo!");
                break;

            case Feiticos.Gelo:
                Falas.Sistema($"{Nome} atacou {alvo.Nome} com um poder de Gelo!");
                break;

            case Feiticos.Terra:
                Falas.Sistema($"{Nome} atacou {alvo.Nome} com um poder de Terra!");
                break;

            case Feiticos.Ar:
                Falas.Sistema($"{Nome} atacou {alvo.Nome} com um poder de Ar!");
                break;

            case Feiticos.Eletricidade:
                Falas.Sistema($"{Nome} atacou {alvo.Nome} com um poder de Eletricidade!");
                break;
        }

        alvo.ReceberDano(DanoBase);
        Mana += 5;

        if (Mana >= 20)
        {
            Mana = 20;
        }
    }

    public void FeiticoEspecial(Personagem alvo)
    {
        if (Mana < 20)
        {
            Falas.Sistema("Você não possui Mana o suficiente!");
            return;
        }

        int danoEspecial = DanoEspecial(Elemento);

        string mensagemFeitico = Elemento switch
        {
            Feiticos.Fogo => $"{Nome} atacou {alvo.Nome} com a Rajada de Fogo! Dano: {danoEspecial}!",
            Feiticos.Gelo => $"{Nome} atacou {alvo.Nome} com os Espinhos de Gelo! Dano: {danoEspecial}!",
            Feiticos.Terra => $"{Nome} atacou {alvo.Nome} com a Manipulação Sísmica! Dano: {danoEspecial}!",
            Feiticos.Ar => $"{Nome} atacou {alvo.Nome} com o Ciclone Furioso! Dano: {danoEspecial}!",
            Feiticos.Eletricidade => $"{Nome} atacou {alvo.Nome} com a Tempestade de Raios! Dano: {danoEspecial}!",
            _ => $"{Nome} atacou {alvo.Nome} com um soco!"
        };

        Falas.Sistema(mensagemFeitico);
        alvo.ReceberDano(danoEspecial);
        Mana -= 20;
    }

        private int DanoFogo = 30;
        private int DanoGelo = 25;
        private int DanoTerra = 35;
        private int DanoAr = 25;
        private int DanoEletricidade = 30;

    public int DanoEspecial(Feiticos poder)
    {
        switch (poder)
        {
            case Feiticos.Fogo: return DanoFogo;
            case Feiticos.Gelo: return DanoGelo;
            case Feiticos.Terra: return DanoTerra;
            case Feiticos.Ar: return DanoAr;
            case Feiticos.Eletricidade: return DanoEletricidade;
            default: return 5;
        }
    }

    public override void AumentarDano()
    {
        int valor = 10;
        DanoBase += valor;

        DanoFogo += valor;
        DanoGelo += valor;
        DanoTerra += valor;
        DanoAr += valor;
        DanoEletricidade += valor;

    }
    public override void AumentarVida()
    {
        VidaMaxima += 20;
        Vida = VidaMaxima;
    }
}
