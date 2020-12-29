using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Projeto.Data.Entities
{
   public class OS
    {
		
		public int Cod_OS { get; set; }			
		public DateTime Data_Geracao { get; set; }
		public int Quantidade_Coletada { get; set; }
		public DateTime? Data_Coleta { get; set; }
		public bool? Flag_Coleta { get; set; }
		public bool? Flag_Envio_Email { get; set; }		
		public bool? Flag_Cancelado { get; set; }
		public string Motivo_Cancelamento { get; set; }
		public DateTime? Data_Cancelamento { get; set; }

		public List<Cliente> Clientes { get; set; }
		public int Cod_Cliente { get; set; }
		public Configuracao Configuracao { get; set; }
		public int? Cod_Configuracao { get; set; }
		public int Cod_Contrato { get; set; }
		public Contrato Contrato { get; set; }

		public int Cod_MesReferencia { get; set; }
		public MesReferencia MesReferencia { get; set; }
   
		public string Email_Cliente { get; set; }
		public string Hora_Entrada { get; set; }
		public string Hora_Saida { get; set; }
		public string Placa { get; set; }
		public string Endereco_Cliente { get; set; }
		public string NomeCompleto_RazaoSocial_Cliente { get; set; }
		
		public int? Coleta_Contratada { get; set; }
		public decimal? Valor_Limite { get; set; }
		public decimal? Valor_Unidade { get; set; }


    }
}
