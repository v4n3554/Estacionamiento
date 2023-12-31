﻿using EstacionamientoDos.Data;
using EstacionamientoDos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.BLL
{
    public class ReporteEstacionamientoBll
    {
        public Data.DashboardEntities _dbo = new Data.DashboardEntities();

        public List<report_data> Get_RptEstacionamientoModel(RptEstacionamientoRequestModel objreporte)
        {
            var regreso = new  List<report_data>();
            try
            {
                if (objreporte.fechaInicio != DateTime.MinValue && objreporte.fechaFin != DateTime.MinValue) {
                    regreso = _dbo.report_data.Where(x => x.fecha >= objreporte.fechaInicio && x.fecha <= objreporte.fechaFin).ToList();
                
                }
                else if (objreporte.fechaInicio != DateTime.MinValue) {
                    regreso = _dbo.report_data.Where(x => x.fecha >= objreporte.fechaInicio ).ToList();
                }
                else if (objreporte.fechaFin != DateTime.MinValue)
                {
                    regreso = _dbo.report_data.Where(x => x.fecha <= objreporte.fechaFin).ToList();
                }
                else
                    regreso = _dbo.report_data.ToList();


            }
            catch {
                return null;
            }

            return regreso;
        }



    }
}