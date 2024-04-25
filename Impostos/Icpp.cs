using CursoDesignPatterns.Models;
using CursoDesignPatterns.Templates;

namespace CursoDesignPatterns.Impostos;

public class Icpp : TemplateImpostoCondicional
{
    protected override double MaximaTaxacao(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens * 0.07;
    }

    protected override double MinimaTaxacao(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens * 0.05;
    }

    protected override bool UtilizaMaximaTaxacao(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens >= 500;
    }
}
