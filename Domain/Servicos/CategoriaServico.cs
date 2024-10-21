using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoria _ICategoria;

        public CategoriaServico(ICategoria ICategoria)
        {
            _ICategoria = ICategoria;
        }

        public async Task AdicionarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");
            if (valido)
            {
                await _ICategoria.Add(categoria);
            }
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");
            if (valido)
            {
               await _ICategoria.Update(categoria);
            }
        }
    }
}
