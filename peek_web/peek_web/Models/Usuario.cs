using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peek_web.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Senha { get; set; }

    }
}