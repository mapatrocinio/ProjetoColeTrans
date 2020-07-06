﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Contracts
{
   public interface IBaseDapperRepository<TEntity>
        where TEntity : class

    {
        void Inserir(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);

        List<TEntity> ConsultarTodos();
        TEntity ObterPorId(int id);

    }
}
