namespace CoracaoDaRuinaRPG.Utils;

public static class Falas 
{
    public static void Narrador(string texto)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        foreach(char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(40);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public static void NPC(string nome, string texto)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{nome}: ");
        foreach(char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(40);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public static void Jogador(string nome, string texto)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{nome}: ");
        foreach(char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(40);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public static void Sistema(string texto)
    {
        Console.ForegroundColor = ConsoleColor.White;
        foreach(char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(40);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public static void Inimigo(string nome, string texto)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{nome}: ");
        foreach(char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(100);
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}
