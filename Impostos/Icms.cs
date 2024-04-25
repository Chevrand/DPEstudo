using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Impostos;

public class Icms : Imposto
{
    public override double Calcula(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens * 0.1;
    }
}
