using CoracaoDaRuinaRPG.Enums;
namespace CoracaoDaRuinaRPG.Models;

public abstract class Personagem
{
    public Personagem(string nome)
    {
        Nome = nome;
        Nivel = 1;
    }

    public string Nome { get; set; }
    public int Vida { get; protected set; }
    public int VidaMaxima { get; protected set; }
    public int Nivel { get; private set; }
    private List<Item> _itens = new List<Item>();

    public virtual void ReceberDano(int dano)
    {
        if (Vida > 0)
            Vida -= dano;

        if (Vida <= 0)
            Vida = 0;
    }

    public bool EstaVivo()
    {
        if (Vida > 0)
            return true;
        else
            return false;
    }

    public void ColetarItem(Item item)
    {
        _itens.Add(item);
        Console.WriteLine($"Você adquiriu {item.Nome}!");
    }

    public void UsarItem(string nome)
    {
        Item itemUsado = _itens.FirstOrDefault(item => item.Nome == nome);

        if (itemUsado == null)
        {
            Console.WriteLine($"{Nome} não possui esse item!");
            return;
        }

        Console.WriteLine($"{Nome} usou {itemUsado.Nome}");

        if (itemUsado.Tipo == TipoItemEnum.Cura)
        {
            int cura = 25;
            _itens.Remove(itemUsado);
            Vida += cura;
            Console.WriteLine("Você se curou!");
        }
        else if (itemUsado.Tipo == TipoItemEnum.Utensílio)
        {
            _itens.Remove(itemUsado);
            Console.WriteLine($"Arma recarregada!");
        }
    }

    public void AumentarNivel()
    {
        Nivel++;
        AumentarDano();
        AumentarVida();
    }

    public virtual void AumentarDano() { }
    public virtual void AumentarVida() { }

    public void RestaurarVida()
    {
        Vida = VidaMaxima;
    }
}

