using CursoDesignPatterns.Descontos;
using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Services;

public static class CalculadoraDesconto
{
    public static double CalculaDescontoOrcamento(Orcamento orcamento)
    {
        var desconto1 = new DescontoPorValorMaiorOuIgualA500();
        var desconto2 = new DescontoPorCincoItens();

        desconto1.ProximoDesconto = desconto2;

        return desconto1.Desconta(orcamento);
    }
}
