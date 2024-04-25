using CursoDesignPatterns.Models;
using CursoDesignPatterns.Templates;

namespace CursoDesignPatterns.Impostos;

public class Ikcv : TemplateImpostoCondicional
{
    protected override double MaximaTaxacao(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens * 0.1;
    }

    protected override double MinimaTaxacao(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens * 0.06;
    }

    protected override bool UtilizaMaximaTaxacao(Orcamento orcamento)
    {
        return orcamento.ValorTotalItens > 500
            && orcamento.Itens.Exists(i => i.Valor > 100);
    }
}
