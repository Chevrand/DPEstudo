using CursoDesignPatterns.Models;

namespace CursoDesignPatterns.Interfaces;

public interface IDesconto
{
    IDesconto? ProximoDesconto { get; set; }
    double Desconta(Orcamento orcamento);
}
