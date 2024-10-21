using Domain.Interfaces.IServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinanceiroServico
    {
        private readonly IUsuarioSistemaFinanceiro _IUsuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroServico(IUsuarioSistemaFinanceiro IUsuarioSistemaFinanceiro)
        {
            _IUsuarioSistemaFinanceiro = IUsuarioSistemaFinanceiro;
        }

        public async Task CadastrarUsuario(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _IUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}
