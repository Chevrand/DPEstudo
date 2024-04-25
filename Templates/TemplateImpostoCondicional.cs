using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Templates;

public abstract class TemplateImpostoCondicional : Imposto
{
    public override double Calcula(Orcamento orcamento)
    {
        return UtilizaMaximaTaxacao(orcamento)
            ? MaximaTaxacao(orcamento)
            : MinimaTaxacao(orcamento);
    }

    protected abstract bool UtilizaMaximaTaxacao(Orcamento orcamento);
    protected abstract double MaximaTaxacao(Orcamento orcamento);
    protected abstract double MinimaTaxacao(Orcamento orcamento);
}
