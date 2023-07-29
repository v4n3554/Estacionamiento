using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.Model
{
    public class RptEstacionamientoTotalesModel
    {
        public long ingresadasTotal { get; set; }
        public long HrsTotal { get; set; }
        public decimal EfectivoTotal { get; set; }
        public decimal TPVTotal { get; set; }
    }
}