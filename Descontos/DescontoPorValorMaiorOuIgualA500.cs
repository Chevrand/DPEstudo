using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Descontos;

public class DescontoPorValorMaiorOuIgualA500 : Desconto
{
    public override double Desconta(Orcamento orcamento)
    {
        if (orcamento.ValorTotalItens >= 500) return orcamento.ValorTotalItens * 0.1;

        return ProximoDesconto is not null ? ProximoDesconto.Desconta(orcamento) : 0.0;
    }
}
