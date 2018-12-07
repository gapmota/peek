using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peek.Models
{
    public class Labs
    {
        int IDLab;
        String nome;
        String andar;
        String capacity;

        public int IDLab1 { get => IDLab; set => IDLab = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Andar { get => andar; set => andar = value; }
        public string Capacity { get => capacity; set => capacity = value; }
    }
}