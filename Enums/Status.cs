using CursoDesignPatterns.Exceptions;
using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Enums;

public enum Status
{
    EM_ANALISE,
    APROVADO,
    REPROVADO,
    FINALIZADO,
}

public static class StatusExtensions
{
    public static double GetDescontoExtra(this Status status, Orcamento orcamento)
    {
        return status switch
        {
            Status.EM_ANALISE => orcamento.ValorTotalItens * 0.05,
            Status.APROVADO => orcamento.ValorTotalItens * 0.02,
            _ =>  throw new DescontoExtraException("Não é possível aplicar desconto extra em orçamentos do tipo 'REPROVADO' ou 'FINALIZADO'"),
        };
    }

    public static Status GetAprovacao(this Status status)
    {
        return status switch
        {
            Status.EM_ANALISE => Status.APROVADO,
            _ => throw new StatusOrcamentoException("Apenas orçamentos com status 'EM_ANALISE' podem ser aprovados"),
        };
    }

    public static Status GetReprovacao(this Status status)
    {
        return status switch
        {
            Status.EM_ANALISE => Status.REPROVADO,
            _ => throw new StatusOrcamentoException("Apenas orçamentos com status 'EM_ANALISE' podem ser reprovados"),
        };
    }

    public static Status GetFinalizacao(this Status status)
    {
        return status switch
        {
            Status.APROVADO => Status.FINALIZADO,
            Status.REPROVADO => Status.FINALIZADO,
            _ => throw new StatusOrcamentoException("Apenas orçamentos com status 'APROVADO' ou 'REPROVADO' podem ser finalizados"),
        };
    }
}
