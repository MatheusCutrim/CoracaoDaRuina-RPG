# CoracaoDaRuina-RPG
RPGzin criado através de conheciementos básicos de POO em C#.

Estudo de POO com esse jogo: **Os 4 Pilares.**

---

## **Encapsulamento🔒**
Esconde os dados internos da classe e controla o acesso.

- Usa: `private`, `protected`, `public`.
- Evita bagunça e acesso indevido.

Ex:
private int vida;
```csharp
public void ReceberDano(int dano)
{
    vida -= dano;
}
```

## **Herança🧬**
Uma classe herda características de outra.

- Reutiliza código.
- Cria hierarquia.

Ex:
```csharp
class Personagem { }

class Guerreiro : Personagem { }`
```

## **Polimorfismo🔄**
Um mesmo método pode ter comportamentos diferentes.

- Usa: `override`, `virtual`.
- Cada classe faz do seu jeito.

Ex:
```csharp
public virtual void Atacar() { }

public override void Atacar()
{
    // ataque diferente
}
```

## **Abstração🧩** 
Mostra só o essencial e esconde a complexidade.

- Usa: `abstract`, `interface`.
- Define “o que fazer”, não “como”.

Ex:
```csharp
abstract class Personagem
{
    public abstract void Atacar();
}
```
---

**Resumo em 1 linha**:
Encapsulamento → proteger dados
Herança → reaproveitar código
Polimorfismo → comportamentos diferentes
Abstração → esconder complexidade
