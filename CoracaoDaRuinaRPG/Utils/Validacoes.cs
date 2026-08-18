using CoracaoDaRuinaRPG.Models;
namespace CoracaoDaRuinaRPG.Utils;

public class Validacoes
{
    public static string ValidandoNome()
    {
        bool testeNome = true;
        string nome = "";
        int tentativas = 0;

        while (testeNome)
        {
            Console.WriteLine();
            Console.Write("Seu nome: ");
            nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nome))
                return nome;

            tentativas++;

            if (tentativas == 1)
                Falas.NPC("???", "Tais lembrado não? Ou só não quer falar?");
            else
            {
                Falas.NPC("???", $"Tá certo, vou insistir mais não, pode ficar de boa, vou te chamar por hora de Viajante.");
                nome = "Viajante";
                testeNome = false;
            }
        }

        return nome;
    }



    public static int ValidandoClasse()
    {
        int classe;

        Console.WriteLine();
        Console.Write("Digite o número correspondente: ");

        while (!int.TryParse(Console.ReadLine(), out classe) || classe < 1 || classe > 3)
        {
            Falas.Sistema("Digite uma número válido. 1,2 ou 3");
            Console.Write("Digite o número correspondente: ");
        }

        return classe;
    }

    public static int ValidandoElemento()
    {
        bool testeElemento = true;
        int elemento = 0;

        while (testeElemento)
        {
            Console.WriteLine();
            Falas.Sistema("Digite uma número válido. 1 ao 5");
            Console.Write("Digite o número correspondente: ");

            while (!int.TryParse(Console.ReadLine(), out elemento) || elemento < 1 || elemento > 5)
            {
                Falas.Sistema("Digite uma número válido. 1 ao 5");
                Console.Write("Digite o número correspondente: ");
            }

            switch (elemento)
            {
                case 1:
                    Falas.NPC("Marius", "Fogo. Sempre soube que existiam magos que não temem a destruição.");
                    Falas.NPC("Marius", "Mas se bem que você não me parece almejar o mal, mesmo sendo um devoto do Fogo.");
                    testeElemento = false;
                    break;

                case 2:
                    Falas.NPC("Marius", "Gelo. Ao contrário do que muitos dizem, a frieza não é fraqueza. É controle.");
                    Falas.NPC("Marius", "E pela sua fala, você possui esse controle na palma das mãos...");
                    testeElemento = false;
                    break;

                case 3:
                    Falas.NPC("Marius", "Terra. A força mais antiga de todas. Paciente e inabalável.");
                    Falas.NPC("Marius", "Você deve possuir ancestrais fortes, pois poucos conseguiram dominar a Terra...");
                    testeElemento = false;
                    break;

                case 4:
                    Falas.NPC("Marius", "Ar. Livre, imprevisível... e letal quando subestimado.");
                    Falas.NPC("Marius", "Um elemento padrão dos magos, mas dependendo da experiência, pode possuir um poder incomparável.");
                    testeElemento = false;
                    break;

                case 5:
                    Falas.NPC("Marius", "Eletricidade. Rápido e fulminante. Nem morto eu me atreveria a cruzar o caminho de um mago elétrico.");
                    Falas.NPC("Marius", "Um elemento instável, veloz, mas quando controlado, possui um poder imensurável e letal.");
                    testeElemento = false;
                    break;
            }
        }

        return elemento;
    }

    public static int ValidandoBifurcacao()
    {
        int escolha;

        Console.Write("\nDigite o número correspondente: ");

        while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 2)
        {
            Falas.Sistema("Digite uma número válido. 1 ou 2");
            Console.Write("Digite o número correspondente: ");
        }

        Console.Clear();
        return escolha;
    }

    public static int ValidacaoSimNao()
    {
        int escolha;

        Console.WriteLine();
        Falas.Sistema("Digite uma número válido. 1 ou 2");
        Console.Write("Digite o número correspondente: ");

        while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 2)
        {
            Falas.Sistema("Digite uma número válido. 1 ou 2");
            Console.Write("Digite o número correspondente: ");
        }

        Console.Clear();
        return escolha;
    }
}
