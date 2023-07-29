using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.Model
{
    public class RptEstacionamientoModel
    {
        public string diaSemanatxt { get; set; }

        public DateTime fecha { get; set; }

        public string diaSemanaNum { get; set; }

        public long ingresadas { get; set; }

        public int horas { get; set; }
        public decimal efectivo { get; set; }

        public decimal tpv { get; set; }

        public string Nombre { get; set; }
    }
}