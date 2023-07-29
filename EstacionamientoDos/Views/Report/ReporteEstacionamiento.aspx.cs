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
            if (!IsPostBack) {
                ddlTypeReport_SelectedIndexChanged(sender, new EventArgs());
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaciones())
                {
                    //aqui se sebe de buscar la informacion y agregarla en un listado de tipo RptEstacionamientoModel.
                    var objeto = new RptEstacionamientoRequestModel();

                    if (ddlTypeReport.SelectedValue == "0")//todos
                        objeto = new RptEstacionamientoRequestModel();
                    else // por día
                    {
                        objeto = new RptEstacionamientoRequestModel()
                        {
                            fechaInicio = string.IsNullOrEmpty(txtFechaInicio.Text) ? DateTime.MinValue : Convert.ToDateTime(txtFechaInicio.Text)
                            ,
                            fechaFin = string.IsNullOrEmpty(txtFechaFin.Text) ? DateTime.MinValue : Convert.ToDateTime(txtFechaFin.Text)
                        };
                    }

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
                                    ,fecha = ((DateTime)renglon.fecha)
                                });

                            }
                        }

                        DownloadExcel(lstReporte);
                    }
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
                var lstTotales = new List<RptEstacionamientoTotalesModel>();
                var NameXLS = "RepEstacionamiento" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".xlsx";
                var lstNombres = lstGral.Select(x => x.Nombre).Distinct().ToList();
                var vueltas = 0;
                var filaMaxima = 5;
                var numStarName = 4;
                var numEndName = 6;
                var numStarIngresadas = 3;
                var numStarTotales = 3;
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
                        SubheaderStyle3.Fill.BackgroundColor.SetColor(0, 198, 224, 180);
                        worksheet.Cells[3, numStarName + 2, 3, numStarName + 2].Value = "TPV";

                        //sub Encabezado3
                        var SubheaderStyle4 = worksheet.Cells[4, numStarIngresadas].Style;
                        SubheaderStyle4.Fill.PatternType = ExcelFillStyle.Solid;
                        SubheaderStyle4.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                        worksheet.Cells[4, numStarIngresadas].Value = "Ingresadas";

                        lstTotales.Add(new RptEstacionamientoTotalesModel()
                        {
                            EfectivoTotal= lstGral.Where(x => x.Nombre == nombre).Select(x => x.efectivo).Sum()
                            ,HrsTotal= lstGral.Where(x => x.Nombre == nombre).Select(x => x.horas).Sum()
                            ,ingresadasTotal= lstGral.Where(x => x.Nombre == nombre).Select(x => x.ingresadas).Sum()
                            ,TPVTotal= lstGral.Where(x => x.Nombre == nombre).Select(x => x.tpv).Sum()
                        });
                       
                        var fila = 5;
                        
                        foreach (var registro in lstGral.Where(x => x.Nombre == nombre).OrderBy(x=> x.fecha))
                        {
                            worksheet.Cells[fila, numStarcamp5].Style.Numberformat.Format = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + "#,##0.00";
                            worksheet.Cells[fila, numStarcamp6].Style.Numberformat.Format = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + "#,##0.00";
                            

                            worksheet.Cells[fila,numStarcamp1].Value = registro.diaSemanatxt;
                            worksheet.Cells[fila, numStarcamp2].Value = registro.diaSemanaNum;
                            worksheet.Cells[fila, numStarcamp3].Value = registro.ingresadas;
                            worksheet.Cells[fila, numStarcamp4].Value = registro.horas;
                            worksheet.Cells[fila, numStarcamp5].Value = registro.efectivo;
                            worksheet.Cells[fila, numStarcamp6].Value = registro.tpv;


                            fila++;
                            if (fila > filaMaxima)
                                filaMaxima++;

                            


                        }


                        

                        numStarName += 9;
                        numEndName += 9;
                        numStarIngresadas += 9;
                        numStarcamp1 += 9;
                        numStarcamp2 += 9;
                        numStarcamp3 += 9;
                        numStarcamp4 += 9;
                        numStarcamp5 += 9;
                        numStarcamp6 += 9;

                    }
                    if (lstTotales.Count > 0) {
                        filaMaxima++;
                        foreach (var registroTotal in lstTotales) {
                            //totales
                            
                            var footer1 = worksheet.Cells[filaMaxima, numStarTotales].Style;
                            footer1.Fill.PatternType = ExcelFillStyle.Solid;
                            footer1.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                            worksheet.Cells[filaMaxima, numStarTotales].Value = registroTotal.ingresadasTotal.ToString();

                            var footer2 = worksheet.Cells[filaMaxima, numStarTotales + 1].Style;
                            footer2.Fill.PatternType = ExcelFillStyle.Solid;
                            footer2.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                            worksheet.Cells[filaMaxima, numStarTotales + 1].Value = registroTotal.HrsTotal.ToString();

                            var footer3 = worksheet.Cells[filaMaxima, numStarTotales + 2].Style;
                            footer3.Fill.PatternType = ExcelFillStyle.Solid;
                            footer3.Fill.BackgroundColor.SetColor(0, 180, 198, 231);
                            worksheet.Cells[filaMaxima, numStarTotales + 2].Value = registroTotal.EfectivoTotal.ToString();
                            worksheet.Cells[filaMaxima, numStarTotales + 2].Style.Numberformat.Format = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + "#,##0.00";

                            var footer4 = worksheet.Cells[filaMaxima, numStarTotales + 3].Style;
                            footer4.Fill.PatternType = ExcelFillStyle.Solid;
                            footer4.Fill.BackgroundColor.SetColor(0, 198, 224, 180);
                            worksheet.Cells[filaMaxima, numStarTotales + 3].Value = registroTotal.TPVTotal.ToString();
                            worksheet.Cells[filaMaxima, numStarTotales + 3].Style.Numberformat.Format = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + "#,##0.00";

                            numStarTotales += 9;

                        }
                    }


                    #region se descarga el archivo directamente
                    //var RutaDescargas = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                    //RutaDescargas = (Path.Combine(RutaDescargas, "Downloads"));


                    //HttpContext.Current.Response.Clear();

                    //HttpContext.Current.Response.Buffer = true;

                    //HttpContext.Current.Response.ContentType = "application/vnd.ms-xml";

                    //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + RutaDescargas + "\\" + NameXLS );

                    //HttpContext.Current.Response.Charset = "UTF-8";

                    //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;

                    //HttpContext.Current.Response.Write(package.GetAsByteArray());

                    //HttpContext.Current.Response.End();

                    #endregion

                    #region Guardar el archivo en la ruta deseada
                    var RutaDescargas = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                    RutaDescargas = (Path.Combine(RutaDescargas, "Downloads"));
                    File.WriteAllBytes(RutaDescargas + "\\" + NameXLS, package.GetAsByteArray());
                    #endregion
                }



                Utils.ModalAlertaMsj(this, "Download", "Archivo almacenado en Descargas");
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        protected void ddlTypeReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlTypeReport.SelectedValue == "0")
                {
                    
                    txtFechaInicio.Enabled = false;
                    txtFechaInicio.CausesValidation = false;

                    txtFechaFin.Enabled = false;
                    txtFechaFin.CausesValidation = false;
                }
                else {
                    txtFechaInicio.Text = string.Empty;
                    txtFechaInicio.Enabled = true;
                    txtFechaInicio.CausesValidation = true;

                    txtFechaFin.Text = string.Empty;
                    txtFechaFin.Enabled = true;
                    txtFechaFin.CausesValidation = true;
                }


            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        public bool validaciones() {

            #region valida que las fechas concuerden

            if (!string.IsNullOrEmpty(txtFechaInicio.Text) && !string.IsNullOrEmpty(txtFechaFin.Text))
            {
                if (ddlTypeReport.SelectedValue == "1" && (Convert.ToDateTime(txtFechaFin.Text) < Convert.ToDateTime(txtFechaInicio.Text)))
                {
                    Utils.ModalAlertaMsj(this, "", "Las Fechas son incorrectas");
                    return false;
                }
            }

           

            #endregion

            return true;
        }

    }
}