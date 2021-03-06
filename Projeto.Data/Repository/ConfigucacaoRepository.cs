using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Data.Repository
{
   public class ConfigucacaoRepository : BaseRepository<Configucacao>, IConfigucacaoRepository
    {
        private readonly DataColetrans dataContext;

        public ConfigucacaoRepository(DataColetrans dataContext) : base(dataContext) //construtor da classe pai..
        {
            this.dataContext = dataContext;
        }

        #region MyRegion

        ////sobrescrita de mA�todo (OVERRIDE)
        //public override List<Rota> Consultar()
        //{
        //    //retornar uma consulta de Rota 
        //    //fazendo JOIN com a entidade Motorista
        //    return dataContext.Rota
        //            .Include(p => p.Motorista) //JOIN..
        //            .ToList();
        //}

        ////sobrescrita de mA�todo (OVERRIDE)
        //public override List<Rota> Consultar(Func<Rota, bool> where)
        //{
        //    //retornar uma consulta de Rota 
        //    //fazendo JOIN com a entidade Motorista
        //    return dataContext.Rota
        //            .Include(p => p.Motorista) //JOIN..
        //            .Where(where)
        //            .ToList();
        //}

        ////sobrescrita de mA�todo (OVERRIDE)
        //public override Rota Obter(Func<Rota, bool> where)
        //{
        //    //retornar uma consulta de Rota 
        //    //fazendo JOIN com a entidade Motorista
        //    return dataContext.Rota
        //            .Include(p => p.Motorista) //JOIN..
        //            .Where(where)
        //            .FirstOrDefault();
        //}

        ////sobrescrita de mA�todo (OVERRIDE)
        //public override Rota ObterPorId(int id)
        //{
        //    //retornar uma consulta de Rota 
        //    //fazendo JOIN com a entidade Motorista
        //    return dataContext.Rota
        //            .Include(p => p.Motorista) //JOIN..
        //            .FirstOrDefault(p => p.CodRota == id);
        //}

        #endregion
    }
}

