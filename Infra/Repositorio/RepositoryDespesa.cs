﻿using Domain.Interfaces.IDespesa;
using Entities.Entidades;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositoryDespesa : RepositoryGenerics<Despesa>, IDespesa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryDespesa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Despesa>> ListarDespesasNaoPagas(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in banco.Despesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano 
                     select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                (from s in banco.SistemaFinanceiro
                 join c in banco.Categoria on s.Id equals c.IdSistema
                 join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                 join d in banco.Despesa on c.Id equals d.IdCategoria
                 where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                 select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
