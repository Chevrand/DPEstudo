namespace CursoDesignPatterns.Models;

public abstract class Desconto
{
    public Desconto? ProximoDesconto { get; set; }

    protected Desconto() { }

    protected Desconto(Desconto proximoDesconto)
    {
        ProximoDesconto = proximoDesconto;
    }

    public abstract double Desconta(Orcamento orcamento);
}
