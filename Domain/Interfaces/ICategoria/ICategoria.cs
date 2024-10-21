using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICategoria
{
    public interface ICategoria : IGenerics<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario);   
    }
}
