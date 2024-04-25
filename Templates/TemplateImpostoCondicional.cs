using CursoDesignPatterns.Interfaces;
using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Templates;

public abstract class TemplateImpostoCondicional : IImposto
{
    public double Calcula(Orcamento orcamento)
    {
        return UtilizaMaximaTaxacao(orcamento)
            ? MaximaTaxacao(orcamento)
            : MinimaTaxacao(orcamento);
    }

    protected abstract bool UtilizaMaximaTaxacao(Orcamento orcamento);
    protected abstract double MaximaTaxacao(Orcamento orcamento);
    protected abstract double MinimaTaxacao(Orcamento orcamento);
}
