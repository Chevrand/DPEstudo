using CursoDesignPatterns.Services;
using System.Text;

namespace CursoDesignPatterns.Models;

public class Orcamento
{
    public double ValorTotal { get; private set; }
    public List<Item> Itens { get; private set; }
    public List<Imposto> Impostos { get; private set; }
    public double ValorTotalItens => Itens.Sum(i => i.Valor);

    public Orcamento()
    {
        Itens = new List<Item>();
        Impostos = new List<Imposto>();
        CalcularValorTotal();
    }

    public Orcamento(List<Item> itens)
    {
        Itens = itens;
        Impostos = new List<Imposto>();
        CalcularValorTotal();
    }

    public void AddItem(Item item)
    {
        Itens.Add(item);
        CalcularValorTotal();
    }

    public void AddImposto(Imposto imposto)
    {
        Impostos.Add(imposto);
        CalcularValorTotal();
    }

    private void CalcularValorTotal()
    {
        double valorItens = Itens.Sum(i => i.Valor);
        double valorImpostos = Impostos.Sum(i => i.Calcula(this));

        ValorTotal = valorItens + valorImpostos;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("### Itens ###");
        Itens.ForEach(i => sb.AppendLine(i.ToString()));

        sb.AppendLine("\n### Impostos ###");
        Impostos.ForEach(i => sb.AppendLine($"{i.GetType().Name} - {i.Calcula(this).ToString("C")}"));

        sb.AppendLine("\n### Desconto ###");
        sb.AppendLine(CalculadoraDesconto.CalculaDescontoOrcamento(this).ToString("C"));

        sb.AppendLine("\n### Valor Total ###");
        sb.AppendLine(ValorTotal.ToString("C"));

        return sb.ToString();
    }
}
