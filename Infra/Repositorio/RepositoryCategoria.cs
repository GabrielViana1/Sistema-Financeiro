using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    //RepositoryCategoria herda de RepositoryGenerics, onde <T> é Categoria e implementa a interface ICategoria
    public class RepositoryCategoria : RepositoryGenerics<Categoria>, ICategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryCategoria()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario) && us.sistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
