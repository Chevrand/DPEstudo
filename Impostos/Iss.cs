using CursoDesignPatterns.Interfaces;
using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Impostos;

public class Iss : IImposto
{
    public double Calcula(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens * 0.06;
    }
}
