<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ReporteEstacionamiento.aspx.cs" Inherits="EstacionamientoDos.Views.Report.ReporteEstacionamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="pnlPrincipal">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Buscar" ID="btnBuscar" ValidationGroup="ValidationReportEstac" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <span>Fecha Inicio*</span>
                        <div class="form-group">
                            <div class="input-icon right">
                                <asp:TextBox ID="txtFechaInicio" runat="server" placeholder="Fecha dd/MM/yyyy" CssClass="form-control" ToolTip="Fecha"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy"
                                    PopupButtonID="txtBusFechaOperacion" CssClass="cal_Theme1" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaInicio"
                            ValidationGroup="ValidationReportEstac"
                            ErrorMessage="Campo Requerido"
                            CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Fecha Fin*</span>
                        <div class="form-group">
                            <div class="input-icon right">
                                <asp:TextBox ID="txtFechaFin" runat="server" placeholder="Fecha dd/MM/yyyy" CssClass="form-control" ToolTip="Fecha"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFin" Format="dd/MM/yyyy"
                                    PopupButtonID="txtBusFechaOperacion" CssClass="cal_Theme1" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaFin"
                            ValidationGroup="ValidationReportEstac"
                            ErrorMessage="Campo Requerido"
                            CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Tipo de Reporte*</span>
                        <div class="form-group" >
                            <asp:DropDownList Width="200px" runat="server" ID="ddlTypeReport" CssClass="btn btn-secondary dropdown-toggle">
                                <asp:ListItem Text="Todos" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Por día" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTypeReport"
                            ValidationGroup="ValidationReportEstac"
                            ErrorMessage="Campo Requerido"
                            CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>


</asp:Content>
