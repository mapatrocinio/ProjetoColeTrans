using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Models.MesReferencia
{
    public class MesReferenciaConsultaModel
    {        
        public int Cod_MesReferencia { get; set; }     
        public string Codigo { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime? Data_Termino { get; set; }
        public bool Flag_Encerramento { get; set; }
        public DateTime? Data_Encerramento { get; set; }
        
    }
}
