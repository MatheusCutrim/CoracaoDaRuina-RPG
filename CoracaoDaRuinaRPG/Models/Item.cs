using CoracaoDaRuinaRPG.Enums;

namespace CoracaoDaRuinaRPG.Models;

public class Item
{
    public Item(string nome, int quantidade, TipoItemEnum tipo) {}
    
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }
    public TipoItemEnum Tipo { get; private set; }
}
