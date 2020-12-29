﻿using Projeto.Data.Seedwork.Notifying;
using Projeto.Data.Validators.PrimitiveValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Commands
{
    public class AtualizarMotoristaCommand : Validatable, IValidatable
    {
        public int Cod_Motorista { get; set; }
        public string Nome { get; set; }
        public string Ajudante1 { get; set; }
        public string Ajudante2 { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Placa { get; set; }


        public override void Validate()
        {
            if (!Nome.HasMaxLength(200))
            {
                AddNotification(nameof(Nome), "O Nome permite no máximo 200 caracteres");
            }
      
        }
    }
}
