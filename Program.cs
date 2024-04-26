using CursoDesignPatterns.Builders;
using CursoDesignPatterns.Impostos;

var builder = new OrcamentoBuilder();
var orcamento = builder
    .WithItem(new("Shampoo", 12.9))
    .WithItem(new("Condicionador", 12.9))
    .WithItem(new("Sabonete", 2.9))
    .WithItem(new("Lamina de Barbear", 2.99))
    .WithItem(new("Desodorante", 11.99))
    .WithItem(new("Ozempic", 899.9))
    .WithImposto(new Icms())
    .WithImposto(new Iss())
    .WithImposto(new Icpp())
    .WithImposto(new Ikcv())
    .Build();

try
{
    orcamento.AplicarDescontoExtra();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    orcamento.Aprovar();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine(orcamento);
