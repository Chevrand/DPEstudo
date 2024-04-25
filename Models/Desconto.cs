namespace CursoDesignPatterns.Models;

public abstract class Desconto
{
    public Desconto? ProximoDesconto { get; set; }
    public abstract double Desconta(Orcamento orcamento);
}
