<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin/Site.Master" AutoEventWireup="true" CodeBehind="RolModule.aspx.cs" Inherits="EstacionamientoDos.Views.Configuration.RolModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Panel runat="server" ID="pnlPrincipal">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" ValidationGroup="ValidationRolModule" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <span>Rol*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:DropDownList runat="server" ID="ddlRol" CssClass="form-control select2bs4" data-live-search="true"></asp:DropDownList>
                            </div>
                        </div>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRol" 
	                    ValidationGroup="ValidationRolModule"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Modulo*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:DropDownList runat="server" ID="ddlModule" CssClass="form-control select2bs4" data-live-search="true"></asp:DropDownList>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlModule" 
	                    ValidationGroup="ValidationRolModule"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6"></div>
                </div>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" RenderMode="Block">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-default">
                            <div class="card-body" style="height: auto; width: auto; overflow: auto; max-height: 800px;">
                                <asp:GridView ID="gvResume" runat="server" CssClass="table table-bordered table-hover table-striped"
                                    GridLines="None" AutoGenerateColumns="false" AllowPaging="false" DataKeyNames="idRolModule"
                                    EmptyDataText="No se encuentran registros." OnRowDataBound="gvResume_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#48848E" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="Rol" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span>
                                                    <asp:DropDownList runat="server" ID="ddlRolOper" CssClass="form-control select2bs4" data-live-search="true"></asp:DropDownList>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Modulo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span>
                                                    <asp:DropDownList runat="server" ID="ddlModuleOper" CssClass="form-control select2bs4" data-live-search="true"></asp:DropDownList>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Creacion" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>


                                                <span>
                                                    <asp:TextBox ID="txtcreateOper" runat="server" CssClass="form-control float-right" />
                                                </span>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span class="btn btn-default" style="margin: 0 0 0 0; padding: 0 0 0 0; width: 32px; height: 32px;">
                                                    <asp:ImageButton ID="ibtnConsultarOper" CausesValidation="false"  runat="server" ToolTip="Editar" Width="32px" ImageUrl="~/Img/btnEdit.png" OnClick="ibtnConsultarOper_Click" />
                                                    <asp:ImageButton ID="ibtnGuardarOper" CausesValidation="false"  runat="server" ToolTip="Guardar" Width="32px" ImageUrl="~/Img/btnsave.png" OnClick="ibtnGuardarOper_Click" />
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span class="btn btn-default" style="margin: 0 0 0 0; padding: 0 0 0 0; width: 32px; height: 32px;">
                                                    <asp:ImageButton ID="ibtnEliminarOper" CausesValidation="false"  runat="server" ToolTip="Eliminar" Width="32px" ImageUrl="~/Img/btnDelete.png" OnClick="ibtnEliminarOper_Click" />
                                                    <asp:ImageButton ID="ibtnCancelOper" CausesValidation="false"  runat="server" ToolTip="Cancelar" Width="32px" ImageUrl="~/Img/btnCancel.png" OnClick="ibtnCancelOper_Click" />
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>


</asp:Content>
