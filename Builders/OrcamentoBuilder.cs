using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Builders;

public class OrcamentoBuilder
{
    private List<Item> _itens = new List<Item>();
    private List<Imposto> _impostos = new List<Imposto>();

    public Orcamento Build()
    {
        return new Orcamento(_itens, _impostos);
    }

    public OrcamentoBuilder WithItem(Item item)
    {
        _itens.Add(item);
        return this;
    }

    public OrcamentoBuilder WithImposto(Imposto imposto)
    {
        _impostos.Add(imposto);
        return this;
    }
}
