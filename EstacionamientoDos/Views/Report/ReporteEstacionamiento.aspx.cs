using EstacionamientoDos.Model;
using EstacionamientoDos.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EstacionamientoDos.Views.Report
{
    public partial class ReporteEstacionamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //aqui se sebe de buscar la informacion y agregarla en un listado de tipo RptEstacionamientoModel.



                // Ejemplo de la lista:
                var lstReporte = new List<RptEstacionamientoModel>() {
                     new RptEstacionamientoModel(){ diaSemanatxt="L",diaSemanaNum="1",ingresadas=315,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="2",ingresadas=343,horas=11,efectivo=300,tpv=30},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="3",ingresadas=353,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="J",diaSemanaNum="4",ingresadas=43,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="V",diaSemanaNum="5",ingresadas=402,horas=2,efectivo=60,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="S",diaSemanaNum="6",ingresadas=388,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="D",diaSemanaNum="7",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="L",diaSemanaNum="8",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="9",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="10",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="J",diaSemanaNum="11",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="V",diaSemanaNum="12",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="S",diaSemanaNum="13",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="D",diaSemanaNum="14",ingresadas=1,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="L",diaSemanaNum="15",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="16",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="17",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="J",diaSemanaNum="18",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="V",diaSemanaNum="19",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="S",diaSemanaNum="20",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="D",diaSemanaNum="21",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="L",diaSemanaNum="22",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="23",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="24",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="J",diaSemanaNum="25",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="V",diaSemanaNum="26",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="S",diaSemanaNum="27",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="D",diaSemanaNum="28",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="L",diaSemanaNum="29",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="30",ingresadas=0,horas=0,efectivo=0,tpv=0},
                     new RptEstacionamientoModel(){ diaSemanatxt="M",diaSemanaNum="31",ingresadas=0,horas=0,efectivo=0,tpv=0},

                     new RptEstacionamientoModel(){ diaSemanatxt="-1",diaSemanaNum="0",ingresadas=100,horas=150,efectivo=2000,tpv=300}

                };




                // se descarga el excel
                DownloadExcel(lstReporte);

            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }


        private void DownloadExcel(List<RptEstacionamientoModel> lst)
        {
            try
            {
                var NameXLS = "RepEstacionamiento"+DateTime.Now.ToString("_yyyyMMdd_hhmmss")+".xlsx";
                var numStarRegister = 4;
                var infoEncabezado = lst.Where(x => x.diaSemanatxt == "-1").FirstOrDefault();
                

                var countIngreso = lst.Where(x => x.diaSemanaNum != "-1").Select(x => x.ingresadas).Sum();
                var countHrs = lst.Where(x => x.diaSemanaNum != "-1").Select(x => x.horas).Sum();
                var countEfectivo = lst.Where(x => x.diaSemanaNum != "-1").Select(x => x.efectivo).Sum();
                var countTPV = lst.Where(x => x.diaSemanaNum != "-1").Select(x => x.tpv).Sum();


                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    // Crear una nueva hoja de trabajo
                    var worksheet = package.Workbook.Worksheets.Add("Hoja1");

                    // Establecer el estilo de la celda de encabezado
                    var headerStyle = worksheet.Cells["E1:G1"].Style;
                    headerStyle.Font.Bold = true;
                    headerStyle.Fill.PatternType = ExcelFillStyle.Solid;
                    headerStyle.Fill.BackgroundColor.SetColor(0, 221, 235, 247);

                    //sub Encabezado1
                    var SubheaderStyle1 = worksheet.Cells["E2:F2"].Style;
                    SubheaderStyle1.Fill.PatternType = ExcelFillStyle.Solid;
                    SubheaderStyle1.Fill.BackgroundColor.SetColor(0,180,198,231);
                    
                    //sub Encabezado2
                    var SubheaderStyle2 = worksheet.Cells["G2"].Style;
                    SubheaderStyle2.Fill.PatternType = ExcelFillStyle.Solid;
                    SubheaderStyle2.Fill.BackgroundColor.SetColor(0, 198, 224, 180);

                    //sub Encabezado3
                    var SubheaderStyle3 = worksheet.Cells["D3"].Style;
                    SubheaderStyle3.Font.Bold = true;
                    SubheaderStyle3.Fill.PatternType = ExcelFillStyle.Solid;
                    SubheaderStyle3.Fill.BackgroundColor.SetColor(0, 189,215,238);

                    

                    // Agregar encabezados
                    worksheet.Cells["F1"].Value = "Tablet";
                    worksheet.Cells["E2"].Value = "Hrs";
                    worksheet.Cells["F2"].Value = "Efectivo";
                    worksheet.Cells["G2"].Value = "TPV";
                    worksheet.Cells["D3"].Value = "Ingresadas";
                    worksheet.Cells["E3"].Value = infoEncabezado.horas.ToString();
                    worksheet.Cells["F3"].Value = infoEncabezado.efectivo.ToString();
                    worksheet.Cells["G3"].Value = infoEncabezado.tpv.ToString();


                    foreach (var objeto in lst.Where(x => x.diaSemanatxt != "-1").ToList()) {
                        worksheet.Cells["B" + numStarRegister.ToString()].Value = objeto.diaSemanatxt ;
                        worksheet.Cells["C" + numStarRegister.ToString()].Value = objeto.diaSemanaNum ;
                        worksheet.Cells["D" + numStarRegister.ToString()].Value = objeto.ingresadas.ToString() ;
                        worksheet.Cells["E" + numStarRegister.ToString()].Value = objeto.horas.ToString() ;
                        worksheet.Cells["F" + numStarRegister.ToString()].Value = objeto.efectivo.ToString() ;
                        worksheet.Cells["G" + numStarRegister.ToString()].Value = objeto.tpv.ToString() ;

                        numStarRegister++;
                    }

                    //style Totales
                    var TotheaderStyle1 = worksheet.Cells["D"+ numStarRegister.ToString()+":F" + numStarRegister.ToString()].Style;
                    TotheaderStyle1.Font.Bold = true;
                    TotheaderStyle1.Fill.PatternType = ExcelFillStyle.Solid;
                    TotheaderStyle1.Fill.BackgroundColor.SetColor(0, 189, 215, 238);

                    var TotheaderStyle2 = worksheet.Cells["G" + numStarRegister.ToString()].Style;
                    TotheaderStyle2.Font.Bold = true;
                    TotheaderStyle2.Fill.PatternType = ExcelFillStyle.Solid;
                    TotheaderStyle2.Fill.BackgroundColor.SetColor(0, 198, 224, 180);

                    worksheet.Cells["D"+numStarRegister.ToString()].Value = countIngreso.ToString();
                    worksheet.Cells["E"+numStarRegister.ToString()].Value = countHrs.ToString();
                    worksheet.Cells["F"+numStarRegister.ToString()].Value = countEfectivo.ToString();
                    worksheet.Cells["G"+numStarRegister.ToString()].Value = countTPV.ToString();




                    // Ajustar el ancho de las columnas
                    worksheet.Column(1).AutoFit();
                    worksheet.Column(2).AutoFit();




                    // Guardar el archivo en la ruta deseada
                    var RutaDescargas = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                    RutaDescargas = (Path.Combine(RutaDescargas, "Downloads"));
                    File.WriteAllBytes(RutaDescargas + "\\" + NameXLS, package.GetAsByteArray());
                }


                Utils.ModalAlertaMsj(this,"Download","Archivo almacenado en Descargas");
            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this, "Error",ex.Message);
            }
        }
    }
}