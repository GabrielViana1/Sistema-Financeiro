using Domain.Interfaces.IUsuarioSistemaFinanceiro;
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
    public class RepositoryUsuarioSitestemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, IUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryUsuarioSitestemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from us in banco.UsuarioSistemaFinanceiro
                     where us.IdSistema == IdSistema
                     select us).AsNoTracking().ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using(var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from us in banco.UsuarioSistemaFinanceiro
                     where us.EmailUsuario.Equals(emailUsuario)
                     select us).AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuariosSistemaFinanceiro)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                banco.UsuarioSistemaFinanceiro.RemoveRange(usuariosSistemaFinanceiro);
                await banco.SaveChangesAsync();
            }
        }
    }
}
