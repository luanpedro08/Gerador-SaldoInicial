using System;
using System.Collections.Generic;
using System.Text;

namespace Cruzamento_Toyota.DbAccess
{
    public class UsuarioBanco
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Servidor { get; set; }
        public string Schema { get; set; }
        public string Host { get; set; }
        public string Porta { get; set; }
    }
}
