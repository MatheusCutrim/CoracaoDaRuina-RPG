using CoracaoDaRuinaRPG.Models;
using CoracaoDaRuinaRPG.Utils;
using CoracaoDaRuinaRPG.Enums;

namespace CoracaoDaRuinaRPG.Jogo;

public static class Jogo
{
    public static string NomeJogador;
    public static Personagem Jogador;

    public static void IniciarJogo()
    {
        Abertura();

        Musica.Tocar("Assets/Taverna.wav", 0.5f, true);
        Introducao();
        Musica.Parar();

        Musica.Tocar("Assets/Masmorra.wav");
        Masmorra();
    }

    public static void Abertura()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine();
        Console.WriteLine(@"
        
        ╔════════════════════════════════════════╗
        ║         O CORAÇÃO DA RUÍNA RPG         ║
        ╚════════════════════════════════════════╝

        ");

        Thread.Sleep(2000);

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine(@"
        

             Desenvolvido por Matheus Cutrim
        

        ");

        Thread.Sleep(2000);

        for (int i = 0; i < 2; i++)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@"
        

                    .
        

            ");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@"
        

                    ..
        

            ");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@"
        

                    ...
        

            ");
            Thread.Sleep(500);
            Console.Clear();
        }
    }

    private static void Introducao()
    {
        Falas.Narrador(@"Você começa a acordar e abrir os olhos... parece estar sentado em uma cadeira de madeira velha, apoiando os braços em algum tipo de bancada, 
e uma tontura toma conta da sua cabeça...");
        Falas.Narrador(@"O cheiro de madeira queimada e cerveja velha preenchem o ar. Quando você finalmente recupera os sentidos, você sente um vazio na mente, 
como se sua memória tivesse sido apagada...");
        Falas.Narrador("Nesse momento, um velho com uma barba branca, meio calvo, usando vestimentas velhas se aproxima de você: ");
        Console.WriteLine();
        Falas.NPC($"???", "Bom dia meu jovem, finalmente acordou em, tava cansado né? Ontem eu te vi no meio da estrada desmaiado, e te trouxe pra cá pra ver o que tinha acontecido");
        Falas.NPC($"???", "Antes de tentar entender melhor o que aconteceu contigo, qual teu nome? ");

        NomeJogador = Validacoes.ValidandoNome();

        Falas.NPC($"???", $"{NomeJogador}... certo.");
        Falas.NPC($"???", "A propósito, esqueci de me apresentar, eu sou Marius, dono da Taverna desse vilarejo! Normalmente ela sempre está cheia, está meio vazia agora por conta da hora.");
        Falas.NPC($"Marius", "Outra coisa que reparei em você, suas vestimentas longas talvez escondem o seu passado, poderia mostrar como suas mãos estão?");
        Falas.NPC($"Marius", "Se me mostrar, posso te guiar para um lugar que pode te ajudar a recuperar suas memórias, mas antes preciso saber de você.");

        Falas.Sistema(@"[1] Estão calejadas e marcadas por batalhas (Guerreiro)
[2] Estão finas, com manchas de tinta e ervas (Mago)
[3] Parecem ágeis, com cicatrizes quase invisíveis (Ladino)");

        int classe = Validacoes.ValidandoClasse();

        if (classe == 1)
        {
            Jogador = new Guerreiro(NomeJogador);
            Falas.NPC("\nMarius", "Então você é um Guerreiro, pela suas cicatrizes, ficou fácil de identificar...");
            Falas.NPC("Marius", "Vou lhe dar uma coisa que pode te ajudar, espera um segundo.");
            Falas.Sistema("Marius entra por trás da cozinha da taverna, e após alguns segundos, volta com uma Espada Longa de duas mãos, e uma grande Armadura de Ferro.");
            Falas.NPC("Marius", "Um guerreiro como você deve aguentar isso.");
        }
        else if (classe == 2)
        {
            Falas.NPC("\nMarius", "UAU! Um mago por aqui, há anos não via um desses, e sobre seu elemento? Acredito que não se lembre, mas eu posso lhe recordar...");
            Falas.Sistema("Marius entorna uma taça de vinho e olha fixamente para você.");
            Falas.NPC("Marius", "Vamos ver se assim você se lembra...");
            Falas.Sistema("Marius então joga um punhado de pó no ar e uma chama rosada surge entre vocês.");
            Falas.NPC("Marius", "O que você sente?");

            Falas.Sistema(@"[1] Vontade de alimentá-la, vê-la crescer e consumir tudo
[2] Vontade de apagá-la, substituí-la pelo frio e pela calma
[3] Curiosidade sobre o que a mantém viva, a terra que a sustenta
[4] Vontade de soprá-la, espalhá-la pelo ar em mil fagulhas
[5] Vontade de atravessá-la como um raio, sentir a energia que pulsa dentro dela");

            int elementoEscolhido = Validacoes.ValidandoElemento();

            if (elementoEscolhido == 1)
                Jogador = new Mago(NomeJogador, Feiticos.Fogo);
            else if (elementoEscolhido == 2)
                Jogador = new Mago(NomeJogador, Feiticos.Gelo);
            else if (elementoEscolhido == 3)
                Jogador = new Mago(NomeJogador, Feiticos.Terra);
            else if (elementoEscolhido == 4)
                Jogador = new Mago(NomeJogador, Feiticos.Ar);
            else if (elementoEscolhido == 5)
                Jogador = new Mago(NomeJogador, Feiticos.Eletricidade);

            Falas.NPC("\nMarius", "Ótimo, agora que sei isso, vou lhe entregar algo que vai te ajudar.");
            Falas.Sistema("Marius entra por trás da cozinha da taverna, e após alguns segundos, ele volta com um Manto de cor azul escuro, e um Cajado de Madeira");
            Falas.NPC("Marius", "Pronto, isso aqui foi de um antigo mago que frequentava essa taverna, acho que vai servir pra você.");
        }
        else if (classe == 3)
        {
            Jogador = new Ladino(NomeJogador);
            Falas.NPC("\nMarius", "Um ladino, não sou muito chegado a eles, principalmente porque TODO DIA um deles rouba bebidas sem eu perceber.");
            Falas.NPC("Marius", "Mas como você parece ser tranquilo, vou lhe dar algo que pode te ajudar.");
            Falas.Sistema("Marius entra por trás da cozinha da taverna, e após alguns segundos, ele volta com duas pequenas Adagas bem afiadas, e um manto Vermelho.");
            Falas.NPC("Marius", "Pronto, isso aqui foi uma das coisas que consegui pegar de um deles quando tentaram de roubar de novo, vai servir pra você.");
        }

        Console.Write("Aperte ENTER pra continuar. ");
        Console.ReadLine();

        Console.Clear();

        Falas.Sistema($"*Você sente uma dor de cabeça muito forte, como se seu cérebro estivesse querendo lembrar de algo, mas não consegue*");
        Falas.Jogador($"{NomeJogador}", "Tá mas pera aí, poderia me explicar primeiro o que é isso tudo? Eu realmente perdi minhas memórias? Como eu faço pra recuperar?");
        Falas.NPC("Marius", "Calma, provavelmente você perdeu sim, como eu não sei, mas conheço algo que pode te ajudar.");
        Falas.NPC("Marius", "O Coração da Ruína.");
        Falas.Jogador($"{NomeJogador}", "O coração do que?");
        Falas.NPC("Marius", @"Há muitos anos atrás, uma lenda surgiu, de que quem entrasse na masmorra próxima desse vilarejo, e derrotasse o Vampiro que nela habita,
possuiria o coração dele, que foi apelidado de coração das ruínas, algo capaz de fazer realizar qualquer tipo de desejo, e pra você que almeja recuperar suas memórias...
acho que é a melhor coisa.");
        Falas.Jogador($"{NomeJogador}", "Certo... entendi, e onde exatamente fica essa masmorra?");
        Falas.NPC("Marius", "Há mais ou menos 30 minutos daqui, ao Sul do vilarejo.");
        Falas.Jogador($"{NomeJogador}", "Tá certo, então irei pra lá, espero que eu consiga voltar com alguma coisa...");
        Falas.NPC("Marius", "Tem mais um detalhe, ninguém que foi, voltou...");
        Falas.Jogador($"{NomeJogador}", "Então terei que ser o primeiro. Valeu por tudo Marius, volto mais tarde com notícias.");
        Falas.NPC("Marius", $"Boa sorte {NomeJogador}! Você de longe é um dos mais corajosos que já conheci, espero que consiga.");
        Falas.Sistema($"*Você acena uma última vez pra Marius, pensando que essa pode ser a última vez que tenha uma conversa com algúem...*");

        Console.Write("Aperte ENTER pra continuar. ");
        Console.ReadLine();
    }

    public static void Masmorra()
    {
        Console.Clear();

        Falas.Sistema("Você caminha reto em direção ao sul do vilarejo, mais ou menos uns 30 minutos, e chega até uma grande abertura de caverna.");
        Falas.Sistema("Ao lado da grande abertura, uma placa de madeira escrita 'Masmorra do Coração da Ruína' pode ser vista.");
        Falas.Sistema(@"Você só pensa em recuperar suas memórias, então sem pensar, você pega uma tocha que estava encostada ao lado da placa, acende, 
e adentra naquela escuridão...");

        Console.Write("Aperte ENTER pra continuar. ");
        Console.ReadLine();

        Console.Clear();

        Falas.Sistema("Ao entrar, você sente um frio, sons estranhos ao redor da grande masmorra, mas você continua indo em linha reta.");
        Falas.Sistema("Até que poucos segundos depois, você escuta:");
        Falas.NPC("???", "SOCORRO, SOCORRO!");
        Falas.Sistema(@"Você imediatamente corre em direção do grito, e ao chegar, você vê um homem atrás de uma pedra, e na sua frente, o que parece ser um
esqueleto em pé, usando uma armadura, uma espada e um escudo, prestes a atacar o homem.");
        Falas.NPC("???", "ME AJUDA, SOCORRO!!!");
        Falas.Jogador(NomeJogador, "EI! Vem atacar algúem do teu tamanho");
        Falas.Inimigo("Esqueleto", "Arrgh... Grrr...");
        Thread.Sleep(500);

        Personagem esqueleto1 = new Esqueleto("Esqueleto");

        Musica.Parar();
        Musica.Tocar("Assets/Batalha.wav");
        Combate.Duelo(Jogador, esqueleto1);
        Musica.Parar();

        Falas.Sistema("\nVocê subiu de nível!");
        Falas.Sistema($"Level {Jogador.Nivel} -> {Jogador.Nivel + 1}");
        Jogador.AumentarNivel();

        Console.Write("\nAperte ENTER pra continuar. ");
        Console.ReadLine();

        Console.Clear();

        Musica.Tocar("Assets/Masmorra.wav");
        Falas.Sistema("Após você terminar de derrotar o Esqueleto, o homem vira pra você e diz:");
        Falas.NPC("???", "Meu Deus, muito obrigado por me salvar... Achei que ia morrer!");
        Falas.Jogador($"{NomeJogador}", "Nada. Mas o que você tá fazendo aqui??");
        Falas.NPC("???", @"Eu tava tentando achar umas gemas, pensei que caso eu viesse sem chamar muita atenção eu conseguiria pegar e sair rápido, até que esse 
bixo apareceu");
        Falas.Jogador($"{NomeJogador}", "Cara, a única coisa que você tem que fazer agora é sair daqui, deixa comigo por aqui.");
        Falas.NPC("???", "Tá certo, mas antes de ir, pega isso, eu achei no caminho até aqui, pode te ajudar eu acho.");
        Falas.Sistema("*Ele te entrega um Mapa*");
        Falas.NPC("???", "Parece ser o mapa desse lugar, é gigante...");
        Falas.Jogador($"{NomeJogador}", "Caramba! Valeu por isso, vai ser útil. Qual seu nome?");
        Falas.NPC("???", "Meu nome é Zéfero, moro no vilarejo aqui perto.");
        Falas.Jogador($"{NomeJogador}", $"Prazer Zéfero, {NomeJogador}, vou tentar entender melhor esse lugar, agora pode sair daqui.");
        Falas.NPC("???", "Obrigado mais uma vez!");
        Falas.Sistema("*Zéfero sai correndo do lugar.*");

        Console.Write("\nAperte ENTER pra continuar. ");
        Console.ReadLine();

        Console.Clear();

        Falas.Sistema(@"Olhando para o mapa, você observa uns traçados pretos apontando para diversos caminhos diferentes, e no meio do mapa, existe um grande X,
de cor vermelha, com uma seta saindo dele e apontando para uma frase escrita: 'O Coração está AQUI!'");
        Falas.Sistema("Ao ver isso, você se localiza no mapa, e começa a andar seguindo os traçados...");
        Falas.Sistema("Andando por alguns minutos na escuridão profunda, você se vê diante de uma bifurcação.");
        Falas.Sistema("Você pode ir para esquerda ou para direita.");
        Falas.Sistema("\n[1] Esquerda");
        Falas.Sistema("[2] Direita");

        if (Validacoes.ValidandoBifurcacao() == 1)
            MasmorraEsquerda();
        else
            MasmorraDireita();

        Musica.Parar();
        Musica.Tocar("Assets/Velisar.wav");
        Falas.Narrador(@"Você caminha mais e mais por essa masmorra, que parece nunca ter fim... E quando parecia que essa jornada não ia ter um fim... Você enxerga:");
        Falas.Narrador(@"Uma grande parte aberta dentro da caverna, o que parece ser um grande salão, repleto de tochas cravadas nas paredes, o chão aqui é completamente
revestido por um tapete vermelho, todo decorado, no ar você sente uma leve neblina tomando conta de todo espaço... E no fim desse enorme salão, um trono pode ser visto no meio, 
com uma figura sentada nele...");
        Falas.Narrador(@"Usando vestimentas pretas cobrindo todo seu corpo, uma grande capa vermelha, pele branca acinzentada, orelhas pontudas, com dedos longos e pontudos. 
Ela parece estar com o olhar baixo..."); 
        Falas.Narrador(@"A figura então sente que chegou algúem, ela levanta o olhar, relevando um rosto amendrontador, com olhos vazios, com buracos no lugar dos olhos...");
        Falas.Inimigo("???", "Olá, muito prazzer, o que te traz aqui...");
        Falas.Jogador($"{NomeJogador}", "Então você é o tal vampiro que tanto falam? Eu vim buscar algo que eu preciso.");
        Falas.Inimigo("???", "Peerdão pela minhaa faalta de educação, nem mee apresenntei, meu nome é Velisar, e há muito, muito temmpo, guardo meu coração como uma relíquia...");
        Falas.Jogador($"{NomeJogador}", "Chegou onde eu queria, é esse seu coração que eu quero.");
        Falas.Inimigo("Velisar", "...");
        Falas.Inimigo("Velisar", "Pouucos chegarram atté aqui com vidda... admiro sua força...");
        Falas.Inimigo("Velisar", "Por que voccêê quer eele?");
        Falas.Jogador($"{NomeJogador}", "Preciso saber o que aconteceu comigo, e me disseram que esse seu coração pode fazer isso.");
        Falas.Inimigo("Velisar", "...");
        Falas.Inimigo("Velisar", "Acceita um vinnho??");
        Falas.Jogador($"{NomeJogador}", "Que?? Não interessa pra você, vai me dar seu coração por bem ou por mal?");
        Falas.Narrador($"Sua cabeça começa a pulsar, como se uma briga estivesse acontecendo no seu cérebro. Dói demais.");
        Falas.Jogador($"{NomeJogador}", "AAAAHHH! Olha só, eu preciso desse coração, vai me dar seu coração por bem ou por mal?");
        Falas.Inimigo("Velisar", "Não acho mmuito educcado da sua pparte virr aqui atráás da mminha relíquia, mas reconhheço sua coragemm...");
        Falas.Jogador($"{NomeJogador}", "Então vai ser por mal mesmo?");
        Falas.Inimigo("Velisar", "...");
        Falas.Inimigo("Velisar", "...");
        Falas.Jogador($"{NomeJogador}", "Oi?");
        Falas.Inimigo("Velisar", "...");
        Falas.Narrador($"Velisar levanta do trono, revelando seus mais de 2 metros de altura, e começa a andar calmamente em sua direção...");
        Falas.Inimigo("Velisar", "Não qqueria ter que mmatar você, mass já faz um temmpo que algúemm não chegga até aqui, quero brinncar umm pouco...");
        Falas.Jogador($"{NomeJogador}", "Então vem!");

        BatalhaFinal();
    }

    private static void MasmorraDireita()
    {
        Falas.Sistema(@"Você então escolhe o lado direito para seguir seu rumo, e andando por mais alguns minutos, você vê mais um daqueles esqueletos armadurados em seu
caminho, a única solução para continuar seria acabar com ele...");

        Console.Write("\nAperte ENTER pra batalhar. ");
        Console.ReadLine();

        Personagem esqueleto2 = new Esqueleto("Esqueleto");

        Musica.Parar();
        Musica.Tocar("Assets/Batalha.wav");
        bool venceu = Combate.Duelo(Jogador, esqueleto2);
        Musica.Parar();

        if (!venceu)
        {
            Falas.Sistema("Você desperta novamente na entrada da masmorra...");
            Console.Write("Aperte ENTER para voltar. ");
            Console.ReadLine();
            Console.Clear();
            MasmorraDireita();
            return;
        }

        Console.WriteLine("Você subiu de nível!");
        Console.WriteLine($"Level {Jogador.Nivel} -> {Jogador.Nivel + 1}");
        Jogador.AumentarNivel();

        Console.Write("\nAperte ENTER pra continuar. ");
        Console.ReadLine();

        Console.Clear();

        Musica.Tocar("Assets/Masmorra.wav");
        Falas.Sistema("Depois de mais um esqueleto derrotado, você então segue em frente, e cada vez mais próximo do seu destino final.");
        Falas.Sistema(@"Embora o clima seja de frieza e calafrios, você sente uma força incomum em você, como se estivesse ficando mais forte a cada batalha, e que
está pronto para o que vier.");
        Falas.Sistema("Após mais alguns minutos de caminhada, você observa o que parece ser um baú na sua frente, todo estilizado com pedras e joias em sua volta.");
        Falas.Sistema("Abrir baú?");
        Falas.Sistema("[1] Sim");
        Falas.Sistema("[2] Não");

        if (Validacoes.ValidacaoSimNao() == 1)
        {
            Falas.Sistema(@"Você vai em direção ao baú, e ao tocar nele... UMA BOCA se abre de dentro do baú, revelando uma criatura asquerosa que usa a tampa
do baú como grande boca com dentes afiados que tentam te morder!");
            Falas.Inimigo("???", "AAAAAHHGRRR!");
            Thread.Sleep(500);
        }
        else
        {
            Falas.Sistema(@"Você olha e ignora o baú, entretanto, ao andar um pouco, um barulho de um grito atrás de você ecoa, e ao virar para trás... UMA ABERRAÇÃO,
que antes parecia um baú estilizado, agora, revela uma criatura asquerosa que usa a tampa do baú como uma grande boca com dentes afiados que tentam te morder!");
            Falas.Inimigo("???", "AAAAAHHGRRR!");
            Thread.Sleep(500);
        }

        Mimic mimic = new Mimic("Mimic");
        Musica.Parar();
        Musica.Tocar("Assets/Batalha.wav");
        venceu = Combate.Duelo(Jogador, mimic);
        Musica.Parar();

        if (!venceu)
        {
            Falas.Sistema("Você desperta novamente na entrada da masmorra...");
            Console.ReadLine();
            MasmorraDireita();
            return;
        }

        Console.WriteLine("Você subiu de nível!");
        Console.WriteLine($"Level {Jogador.Nivel} -> {Jogador.Nivel + 1}");
        Jogador.AumentarNivel();

        Console.Write("\nAperte ENTER pra continuar. ");
        Console.ReadLine();
    }

    private static void MasmorraEsquerda()
    {
        Musica.Tocar("Assets/Masmorra.wav");
        Falas.Sistema(@"Você então escolhe o lado esquerdo para seguir seu rumo, e andando por mais alguns minutos, você vê algo que chama um pouco sua atenção...
um brilho pode ser visto um pouco na distância...");
        Falas.Sistema("Após mais alguns minutos de caminhada, você observa o que parece ser um baú na sua frente, todo estilizado com pedras e joias brilhosas em sua volta.");
        Falas.Sistema("Abrir baú?");
        Falas.Sistema("[1] Sim");
        Falas.Sistema("[2] Não");

        if (Validacoes.ValidacaoSimNao() == 1)
        {
            Falas.Sistema(@"Você vai em direção ao baú, e ao tocar nele... UMA BOCA se abre de dentro do baú, revelando uma criatura asquerosa que usa a tampa
do baú como grande boca com dentes afiados que tentam te morder!");
            Falas.Inimigo("???", "AAAAAHHGRRR!");
            Thread.Sleep(1000);
        }
        else
        {
            Falas.Sistema(@"Você olha e ignora o baú, entretanto, ao andar um pouco, um barulho de um grito atrás de você ecoa, e ao virar para trás... UMA ABERRAÇÃO,
que antes parecia um baú estilizado, agora, revela uma criatura asquerosa que usa a tampa do baú como uma grande boca com dentes afiados que tentam te morder!");
            Falas.Inimigo("???", "AAAAAHHGRRR!");
            Thread.Sleep(1000);
        }
            

        Mimic mimic = new Mimic("Mimic");
        Musica.Parar();
        Musica.Tocar("Assets/Batalha.wav");
        bool venceu = Combate.Duelo(Jogador, mimic);
        Musica.Parar();

        if (!venceu)
        {
            Falas.Sistema("Você desperta novamente na entrada da masmorra...");

            Jogador.RestaurarVida();
            Console.Write("Aperte ENTER para voltar. ");
            Console.ReadLine();
            Console.Clear();
            MasmorraEsquerda();
            return;
        }

        Console.WriteLine("Você subiu de nível!");
        Console.WriteLine($"Level {Jogador.Nivel} -> {Jogador.Nivel + 1}");
        Jogador.AumentarNivel();

        Console.Write("\nAperte ENTER pra continuar. ");
        Console.ReadLine();
        Console.Clear();

        Musica.Tocar("Assets/Masmorra.wav");
        Falas.Sistema(@"Depois de derrotar a criatura, você então segue em frente, e cada vez mais próximo do seu destino final.");
        Falas.Sistema(@"Ao caminhar mais um pouco, você observa, pelo que pareceu, um forma humanoide, de estatura baixa, meio magra, pele cinza usando uma capa preta, 
orelhas pontudas, e olhos pretos, parece um vampiro pequeno, provavelmente servo do Vampiro principal...");

        Console.Write("\nAperte ENTER pra batalhar. ");
        Console.ReadLine();

        Vampiro vampiro1 = new Vampiro("Vampiro Servo");
        
        Musica.Parar();
        Musica.Tocar("Assets/Batalha.wav");
        Combate.Duelo(Jogador, vampiro1);
        venceu = Combate.Duelo(Jogador, vampiro1);
        Musica.Parar();

        if (!venceu)
        {
            Falas.Sistema("Você desperta novamente na entrada da masmorra...");
            Console.ReadLine();
            MasmorraDireita();
            return;
        }

        Falas.Sistema("\nVocê subiu de nível!");
        Falas.Sistema($"Level {Jogador.Nivel} -> {Jogador.Nivel + 1}");
        Jogador.AumentarNivel();

        Console.Write("\nAperte ENTER pra continuar. ");
        Console.ReadLine();
    }

    private static void BatalhaFinal()
    {
        Vampiro vampiroChefe = new Vampiro("Velisar");
        vampiroChefe.AumentarNivel();
        vampiroChefe.AumentarNivel();
        vampiroChefe.AumentarNivel();
        vampiroChefe.AumentarNivel();

        Musica.Parar();
        Musica.Tocar("Assets/Batalha.wav");
        bool venceu = Combate.Duelo(Jogador, vampiroChefe);
        Musica.Parar();

        if (!venceu)
        {
            Falas.Inimigo("Velisar", "Vvocê foi beemm diverttido...");
            Falas.Sistema("Você desperta novamente...");
            Console.ReadLine();
            BatalhaFinal();
            return;
        }
    }
}
