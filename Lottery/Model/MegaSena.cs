using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottery
{
    public class MegaSena
    {
        /*Properties of bet*/
        public string NumAposta { get; set; }
        public List<int> NumSelecionados { get; set; }
        public DateTime Data { get; set; }
        public string Resultado { get; set; }
    }
}