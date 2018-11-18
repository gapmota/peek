using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class Lab
    {
        public int IDdLab { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string Andar { get; set; }
        public string DataCadastro { get; set; }
        public string DataAtualizacao { get; set; }

    }

    public class LabConsumo
    {
        public int IDdLab { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string Andar { get; set; }
        public double Download { get; set; }
        public double Upload { get; set; }
    }
}