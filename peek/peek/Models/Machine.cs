using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peek.Models
{
    public class Machine
    {
        int codPc;
        String ram;
        String proc;

        public int CodPc { get => codPc; set => codPc = value; }
        public string Ram { get => ram; set => ram = value; }
        public string Proc { get => proc; set => proc = value; }
    }
}