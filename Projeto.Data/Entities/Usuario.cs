﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
   public class Usuario
    {
        public int Cod_Usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
