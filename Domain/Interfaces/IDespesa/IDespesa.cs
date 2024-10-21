using Domain.Interfaces.Generics;
using Entities.Entidades;


namespace Domain.Interfaces.IDespesa
{
    public interface IDespesa: IGenerics<Despesa>
    {
        Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario);
        Task<IList<Despesa>> ListarDespesasNaoPagas(string emailUsuario);
    }
}
