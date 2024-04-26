using CursoDesignPatterns.Descontos;
using CursoDesignPatterns.Enums;
using CursoDesignPatterns.Exceptions;
using System.Text;

namespace CursoDesignPatterns.Models;

public class Orcamento
{
    public Status StatusOrcamento { get; set; }
    public List<Item> Itens { get; private set; }
    public List<Imposto> Impostos { get; private set; }
    public double ValorTotalItens => Itens.Sum(i => i.Valor);
    public double ValorTotal => CalculaValorTotal();

    public double DescontoExtra { get; private set; }

    public Orcamento()
    {
        DescontoExtra = 0.0;

        StatusOrcamento = Status.EM_ANALISE;
        Itens = new List<Item>();
        Impostos = new List<Imposto>();
    }

    public Orcamento(List<Item> itens)
    {
        DescontoExtra = 0.0;

        StatusOrcamento = Status.EM_ANALISE;
        Itens = itens;
        Impostos = new List<Imposto>();
    }

    public void AddItem(Item item)
    {
        Itens.Add(item);
    }

    public void AddImposto(Imposto imposto)
    {
        Impostos.Add(imposto);
    }

    public void AplicarDescontoExtra()
    {
        if (DescontoExtra > 0) throw new DescontoExtraException("Desconto extra já foi aplicado para este orçamento");

        DescontoExtra = StatusOrcamento.GetDescontoExtra(this);
    }

    #region Gerenciamento de Status
    public void Aprovar()
    {
        StatusOrcamento = StatusOrcamento.GetAprovacao();
    }

    public void Reprovar()
    {
        StatusOrcamento = StatusOrcamento.GetReprovacao();
    }

    public void Finalizar()
    {
        StatusOrcamento = StatusOrcamento.GetFinalizacao();
    }
    #endregion

    private double CalculaValorTotal()
    {
        double valorItens = Itens.Sum(i => i.Valor);
        double valorImpostos = Impostos.Sum(i => i.Calcula(this));

        return (valorItens + valorImpostos) - CalculaDesconto();
    }

    private double CalculaDesconto()
    {
        var desconto = new DescontoPorValorMaiorOuIgualA500(new DescontoPorCincoItens());

        return desconto.Desconta(this) + DescontoExtra;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("### Status ###");
        sb.AppendLine(StatusOrcamento.ToString());

        sb.AppendLine("\n### Itens ###");
        Itens.ForEach(i => sb.AppendLine(i.ToString()));

        sb.AppendLine("\n### Impostos ###");
        Impostos.ForEach(i => sb.AppendLine($"{i.GetType().Name} - {i.Calcula(this).ToString("C")}"));

        sb.AppendLine("\n### Desconto ###");
        sb.AppendLine(CalculaDesconto().ToString("C"));

        sb.AppendLine("\n### Valor Total ###");
        sb.AppendLine(ValorTotal.ToString("C"));

        return sb.ToString();
    }
}
