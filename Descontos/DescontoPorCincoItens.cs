using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Descontos;

public class DescontoPorCincoItens : Desconto
{
    public DescontoPorCincoItens() : base() { }
    public DescontoPorCincoItens(Desconto proximoDesconto) : base(proximoDesconto) { }

    public override double Desconta(Orcamento orcamento)
    {
        if (orcamento.Itens.Count >= 5) return orcamento.ValorTotalItens * 0.05;

        return ProximoDesconto is not null ? ProximoDesconto.Desconta(orcamento) : 0.0;
    }
}
