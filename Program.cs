using CursoDesignPatterns.Impostos;
using CursoDesignPatterns.Models;

var orcamento = new Orcamento(new List<Item>
{
    new("Shampoo", 12.9),
    new("Condicionador", 12.9),
    new("Sabonete", 2.9),
    new("Lamina de Barbear", 2.99),
    new("Desodorante", 11.99),
    new("Ozempic", 899.9),
});

orcamento.AddImposto(new Icms());
orcamento.AddImposto(new Iss());
orcamento.AddImposto(new Icpp());
orcamento.AddImposto(new Ikcv());

Console.WriteLine(orcamento);