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
using EstacionamientoDos.BLL;

namespace EstacionamientoDos.Views.Report
{
    public partial class ReporteEstacionamiento : System.Web.UI.Page
    {
        public ReporteEstacionamientoBll objRptBll = new ReporteEstacionamientoBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //aqui se sebe de buscar la informacion y agregarla en un listado de tipo RptEstacionamientoModel.


                var objeto = new RptEstacionamientoRequestModel()
                {
                    fechaInicio = Convert.ToDateTime(txtFechaInicio.Text)
                    ,
                    fechaFin = Convert.ToDateTime(txtFechaFin.Text)
                };

                var lista = objRptBll.Get_RptEstacionamientoModel(objeto);

                var LstName = lista.Select(x => x.Name_tcc_num).Distinct().ToList();

                if (LstName.Count > 0)
                {
                    var lstReporte = new List<RptEstacionamientoModel>();
                    foreach (var nombre in LstName)
                    {
                        foreach (var renglon in lista.Where(x => x.Name_tcc_num == nombre).OrderBy(x => x.fecha).ToList())
                        {
                            lstReporte.Add(new RptEstacionamientoModel()
                            {
                                diaSemanatxt = Utils.GetDayOfWeekSpanish(Convert.ToDateTime(renglon.fecha).DayOfWeek).Substring(0, 1),
                                diaSemanaNum = Convert.ToDateTime(renglon.fecha).Day.ToString(),
                                ingresadas = ((long)renglon.cuenta),
                                horas = 0,
                                efectivo = (renglon.tipoPago == "E" ? ((decimal)renglon.cantidad) : 0),
                                tpv = (renglon.tipoPago == "T" ? ((decimal)renglon.cantidad) : 0)
                                ,
                                Nombre = nombre.Trim()
                            });

                        }
                    }

                    DownloadExcel(lstReporte);
                }

            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }


        private void DownloadExcel(List<RptEstacionamientoModel> lstGral)
        {
            try
            {
                var NameXLS = "RepEstacionamiento" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".xlsx";
                var lstNombres = lstGral.Select(x => x.Nombre).Distinct().ToList();
                var vueltas = 0;

                var numStarName = 4;
                var numEndName = 6;
                var numStarIngresadas = 3;
                var numStarcamp1 = 1;
                var numStarcamp2 = 2;
                var numStarcamp3 = 3;
                var numStarcamp4 = 4;
                var numStarcamp5 = 5;
                var numStarcamp6 = 6;


                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Hoja1");

                    foreach (var nombre in lstNombres)
                    {
                        vueltas++;

                        //Establecer el estilo de la celda de encabezado
                        var headerStyle = worksheet.Cells[2,numStarName,2,numEndName].Style;
                        headerStyle.Font.Bold = true;
                        headerStyle.Fill.PatternType = ExcelFillStyle.Solid;
                        headerStyle.Fill.BackgroundColor.SetColor(0, 221, 235, 247);
                        worksheet.Cells[2, numStarName, 2, numStarName].Value = nombre.ToUpper();


                        //sub Encabezado1
                        var SubheaderStyle1 = worksheet.Cells[3, numStarName].Style;
                        SubheaderStyle1.Fill.PatternType = ExcelFillStyle.Solid;
                        SubheaderStyle1.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                        worksheet.Cells[3, numStarName, 3, numStarName].Value = "Hrs";

                        //sub Encabezado2
                        var SubheaderStyle2 = worksheet.Cells[3, numStarName+1].Style;
                        SubheaderStyle2.Fill.PatternType = ExcelFillStyle.Solid;
                        SubheaderStyle2.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                        worksheet.Cells[3, numStarName+1, 3, numStarName+1].Value = "Efectivo";

                        //sub Encabezado3
                        var SubheaderStyle3 = worksheet.Cells[3, numStarName + 2].Style;
                        SubheaderStyle3.Fill.PatternType = ExcelFillStyle.Solid;
                        SubheaderStyle3.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                        worksheet.Cells[3, numStarName + 2, 3, numStarName + 2].Value = "TPV";

                        //sub Encabezado3
                        var SubheaderStyle4 = worksheet.Cells[4, numStarIngresadas].Style;
                        SubheaderStyle4.Fill.PatternType = ExcelFillStyle.Solid;
                        SubheaderStyle4.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                        worksheet.Cells[4, numStarIngresadas, 4, numStarIngresadas].Value = "Ingresadas";


                        numStarName += 9;
                        numEndName += 9;
                        numStarIngresadas += 9;
                       

                        var infoEncabezado = lstGral.Where(x => x.diaSemanatxt == "-1" && x.Nombre == nombre).FirstOrDefault();
                        var countIngreso = lstGral.Where(x => x.diaSemanaNum != "-1" && x.Nombre == nombre).Select(x => x.ingresadas).Sum();
                        var countHrs = lstGral.Where(x => x.diaSemanaNum != "-1" && x.Nombre == nombre).Select(x => x.horas).Sum();
                        var countEfectivo = lstGral.Where(x => x.diaSemanaNum != "-1" && x.Nombre == nombre).Select(x => x.efectivo).Sum();
                        var countTPV = lstGral.Where(x => x.diaSemanaNum != "-1" && x.Nombre == nombre).Select(x => x.tpv).Sum();

                        var fila = 5;
                        foreach (var registro in lstGral.Where(x => x.Nombre == nombre).OrderBy(x=> x.diaSemanaNum))
                        {

                            worksheet.Cells[fila,numStarcamp1].Value = registro.diaSemanatxt;
                            worksheet.Cells[fila, numStarcamp2].Value = registro.diaSemanaNum;
                            worksheet.Cells[fila, numStarcamp3].Value = registro.ingresadas;
                            worksheet.Cells[fila, numStarcamp4].Value = registro.horas;
                            worksheet.Cells[fila, numStarcamp5].Value = registro.efectivo;
                            worksheet.Cells[fila, numStarcamp6].Value = registro.tpv;


                            fila++;


                            //// Agregar encabezados
                            //worksheet.Cells["F"+(1*vueltas).ToString()].Value = nombre;
                            //worksheet.Cells["E"+ (2 * vueltas).ToString()].Value = "Hrs";
                            //worksheet.Cells["F"+ (2 * vueltas).ToString()].Value = "Efectivo";
                            //worksheet.Cells["G"+ (2 * vueltas).ToString()].Value = "TPV";
                            //worksheet.Cells["D"+ (3 * vueltas).ToString()].Value = "Ingresadas";
                            //if (infoEncabezado != null)
                            //{
                            //    worksheet.Cells["E" + (3 * vueltas).ToString()].Value = infoEncabezado.horas.ToString();
                            //    worksheet.Cells["F" + (3 * vueltas).ToString()].Value = infoEncabezado.efectivo.ToString();
                            //    worksheet.Cells["G" + (3 * vueltas).ToString()].Value = infoEncabezado.tpv.ToString();
                            //}

                            //foreach (var objeto in lstGral.Where(x => x.diaSemanatxt != "-1" && x.Nombre==nombre).ToList())
                            //{
                            //    worksheet.Cells["B" + numStarRegister.ToString()].Value = objeto.diaSemanatxt;
                            //    worksheet.Cells["C" + numStarRegister.ToString()].Value = objeto.diaSemanaNum;
                            //    worksheet.Cells["D" + numStarRegister.ToString()].Value = objeto.ingresadas.ToString();
                            //    worksheet.Cells["E" + numStarRegister.ToString()].Value = objeto.horas.ToString();
                            //    worksheet.Cells["F" + numStarRegister.ToString()].Value = objeto.efectivo.ToString();
                            //    worksheet.Cells["G" + numStarRegister.ToString()].Value = objeto.tpv.ToString();

                            //    numStarRegister++;
                            //}

                            ////style Totales
                            //var TotheaderStyle1 = worksheet.Cells["D" + numStarRegister.ToString() + ":F" + numStarRegister.ToString()].Style;
                            //TotheaderStyle1.Font.Bold = true;
                            //TotheaderStyle1.Fill.PatternType = ExcelFillStyle.Solid;
                            //TotheaderStyle1.Fill.BackgroundColor.SetColor(0, 189, 215, 238);

                            //var TotheaderStyle2 = worksheet.Cells["G" + numStarRegister.ToString()].Style;
                            //TotheaderStyle2.Font.Bold = true;
                            //TotheaderStyle2.Fill.PatternType = ExcelFillStyle.Solid;
                            //TotheaderStyle2.Fill.BackgroundColor.SetColor(0, 198, 224, 180);

                            //worksheet.Cells["D" + numStarRegister.ToString()].Value = countIngreso.ToString();
                            //worksheet.Cells["E" + numStarRegister.ToString()].Value = countHrs.ToString();
                            //worksheet.Cells["F" + numStarRegister.ToString()].Value = countEfectivo.ToString();
                            //worksheet.Cells["G" + numStarRegister.ToString()].Value = countTPV.ToString();




                            ////// Ajustar el ancho de las columnas
                            ////worksheet.Column(1).AutoFit();
                            ////worksheet.Column(2).AutoFit();




                        }

                        numStarcamp1 += 9;
                        numStarcamp2 += 9;
                        numStarcamp3 += 9;
                        numStarcamp4 += 9;
                        numStarcamp5 += 9;
                        numStarcamp6 += 9;

                    }
                    // Guardar el archivo en la ruta deseada
                    var RutaDescargas = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                    RutaDescargas = (Path.Combine(RutaDescargas, "Downloads"));
                    File.WriteAllBytes(RutaDescargas + "\\" + NameXLS, package.GetAsByteArray());

                }





                //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //using (var package = new ExcelPackage())
                //{
                // Crear una nueva hoja de trabajo
                //var worksheet = package.Workbook.Worksheets.Add("Hoja1");

                //// Establecer el estilo de la celda de encabezado
                //var headerStyle = worksheet.Cells["E1:G1"].Style;
                //headerStyle.Font.Bold = true;
                //headerStyle.Fill.PatternType = ExcelFillStyle.Solid;
                //headerStyle.Fill.BackgroundColor.SetColor(0, 221, 235, 247);

                ////sub Encabezado1
                //var SubheaderStyle1 = worksheet.Cells["E2:F2"].Style;
                //SubheaderStyle1.Fill.PatternType = ExcelFillStyle.Solid;
                //SubheaderStyle1.Fill.BackgroundColor.SetColor(0, 180, 198, 231);

                ////sub Encabezado2
                //var SubheaderStyle2 = worksheet.Cells["G2"].Style;
                //SubheaderStyle2.Fill.PatternType = ExcelFillStyle.Solid;
                //SubheaderStyle2.Fill.BackgroundColor.SetColor(0, 198, 224, 180);

                ////sub Encabezado3
                //var SubheaderStyle3 = worksheet.Cells["D3"].Style;
                //SubheaderStyle3.Font.Bold = true;
                //SubheaderStyle3.Fill.PatternType = ExcelFillStyle.Solid;
                //SubheaderStyle3.Fill.BackgroundColor.SetColor(0, 189, 215, 238);



                //// Agregar encabezados
                //worksheet.Cells["F1"].Value = "Tablet";
                //worksheet.Cells["E2"].Value = "Hrs";
                //worksheet.Cells["F2"].Value = "Efectivo";
                //worksheet.Cells["G2"].Value = "TPV";
                //worksheet.Cells["D3"].Value = "Ingresadas";
                //worksheet.Cells["E3"].Value = infoEncabezado.horas.ToString();
                //worksheet.Cells["F3"].Value = infoEncabezado.efectivo.ToString();
                //worksheet.Cells["G3"].Value = infoEncabezado.tpv.ToString();


                //foreach (var objeto in lst.Where(x => x.diaSemanatxt != "-1").ToList())
                //{
                //    worksheet.Cells["B" + numStarRegister.ToString()].Value = objeto.diaSemanatxt;
                //    worksheet.Cells["C" + numStarRegister.ToString()].Value = objeto.diaSemanaNum;
                //    worksheet.Cells["D" + numStarRegister.ToString()].Value = objeto.ingresadas.ToString();
                //    worksheet.Cells["E" + numStarRegister.ToString()].Value = objeto.horas.ToString();
                //    worksheet.Cells["F" + numStarRegister.ToString()].Value = objeto.efectivo.ToString();
                //    worksheet.Cells["G" + numStarRegister.ToString()].Value = objeto.tpv.ToString();

                //    numStarRegister++;
                //}

                ////style Totales
                //var TotheaderStyle1 = worksheet.Cells["D" + numStarRegister.ToString() + ":F" + numStarRegister.ToString()].Style;
                //TotheaderStyle1.Font.Bold = true;
                //TotheaderStyle1.Fill.PatternType = ExcelFillStyle.Solid;
                //TotheaderStyle1.Fill.BackgroundColor.SetColor(0, 189, 215, 238);

                //var TotheaderStyle2 = worksheet.Cells["G" + numStarRegister.ToString()].Style;
                //TotheaderStyle2.Font.Bold = true;
                //TotheaderStyle2.Fill.PatternType = ExcelFillStyle.Solid;
                //TotheaderStyle2.Fill.BackgroundColor.SetColor(0, 198, 224, 180);

                //worksheet.Cells["D" + numStarRegister.ToString()].Value = countIngreso.ToString();
                //worksheet.Cells["E" + numStarRegister.ToString()].Value = countHrs.ToString();
                //worksheet.Cells["F" + numStarRegister.ToString()].Value = countEfectivo.ToString();
                //worksheet.Cells["G" + numStarRegister.ToString()].Value = countTPV.ToString();




                //// Ajustar el ancho de las columnas
                //worksheet.Column(1).AutoFit();
                //worksheet.Column(2).AutoFit();




                //// Guardar el archivo en la ruta deseada
                //var RutaDescargas = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                //RutaDescargas = (Path.Combine(RutaDescargas, "Downloads"));
                //File.WriteAllBytes(RutaDescargas + "\\" + NameXLS, package.GetAsByteArray());
                //}


                Utils.ModalAlertaMsj(this, "Download", "Archivo almacenado en Descargas");
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }
    }
}