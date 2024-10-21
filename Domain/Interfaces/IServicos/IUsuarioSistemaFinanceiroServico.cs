﻿using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServicos
{
    public interface IUsuarioSistemaFinanceiroServico
    {
        Task CadastrarUsuario(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}
