using CoracaoDaRuinaRPG.Interface;
using CoracaoDaRuinaRPG.Utils;
namespace CoracaoDaRuinaRPG.Models;

public class Mimic : Personagem, IAtaque
{
    public Mimic(string nome) : base(nome)
    {
        Vida = 100;
        DanoBase = 25;
    }

    public int DanoBase { get; private set; }

    public void Atacar(Personagem alvo)
    {
        Random random = new Random();
        int chance = random.Next(1, 21);

        if (chance <= 3)
        {
            Falas.Sistema($"{Nome} errou o ataque em {alvo.Nome}!");
            return;
        }

        Falas.Sistema($"{Nome} mordeu {alvo.Nome} com seus dentes!");
        alvo.ReceberDano(DanoBase);
    }
}
