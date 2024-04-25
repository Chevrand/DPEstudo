namespace CursoDesignPatterns.Models;

public class Item
{
    public string Nome { get; set; }
    public double Valor { get; set; }

    public Item(string nome, double valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public override string ToString()
    {
        return $"{Nome} - {Valor:C}";
    }
}
