﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class OrganizacaoDTO
    {
        public string Cnpj { get; set; }
        public DateTime? DataAbertura { get; set; }
        public byte? Ativo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }
}
