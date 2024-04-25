using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Impostos;

public class Iss : Imposto
{
    public override double Calcula(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens * 0.06;
    }
}
