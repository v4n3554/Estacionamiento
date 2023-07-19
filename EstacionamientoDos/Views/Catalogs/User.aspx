<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="EstacionamientoDos.Views.Catalogs.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:Panel runat="server" ID="pnlPrincipal">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Block">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" ValidationGroup="ValidationUSer" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <span>Nombre*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" ToolTip="Nombre" CssClass="form-control" MaxLength="100" />
                            </div>
                        </div>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Apellido Paterno*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox ID="txtapp" runat="server" placeholder="A. Paterno" ToolTip="A. Paterno" CssClass="form-control" ValidationGroup="ValidationUSer" MaxLength="100"/>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtapp" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Apellido Materno</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox ID="txtapm" runat="server" placeholder="A. Materno" ToolTip="A. Materno" CssClass="form-control" MaxLength="100" />
                            </div>
                        </div>
                        
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">

                    <div class="col-md-3">
                        <span>Dirección*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox ID="txtaddress" runat="server" placeholder="Direccion" ToolTip="Direccion" CssClass="form-control" ValidationGroup="ValidationUSer" MaxLength="200" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtaddress" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>CP*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox MaxLength="200" ID="txtcp" runat="server" placeholder="Codigo Postal*" ToolTip="Codigo Postal" CssClass="form-control" TextMode="Number" ValidationGroup="ValidationUSer"/>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcp" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Telefono*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox ID="txttel"  MaxLength="10" runat="server" placeholder="Telefono" ToolTip="Telefono" CssClass="form-control" TextMode="Number" ValidationGroup="ValidationUSer"/>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txttel" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Correo*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox MaxLength="200" ID="txtEmail" runat="server" placeholder="Email" ToolTip="Email" CssClass="form-control" TextMode="Email" ValidationGroup="ValidationUSer"/>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />

                <div class="row">
                    <div class="col-md-3">
                        <span>Usuario*</span>
                        <div class="form-group">
                            <div class="right">
                                <asp:TextBox ID="txtUser" MaxLength="100" runat="server" placeholder="Usuario" ToolTip="Usuario" CssClass="form-control" ValidationGroup="ValidationUSer"/>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUser" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <span>Password*</span>
                        <div class="form-group">
                            <asp:TextBox ID="txtPsw" MaxLength="10" runat="server" placeholder="Password" ToolTip="Password" TextMode="Password" CssClass="form-control" ValidationGroup="ValidationUSer"/>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPsw" 
	                    ValidationGroup="ValidationUSer"
	                    ErrorMessage="Campo Requerido"
	                    CssClass="alert alert-danger" Font-Size="9"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6"></div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" RenderMode="Block">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card " style="zoom: 60%">
                            <div  style="height: auto; overflow: auto; max-height: 800px;">
                                <asp:GridView ID="gvResume" runat="server" CssClass="table table-bordered table-hover table-striped"
                                    GridLines="None" AutoGenerateColumns="false" AllowPaging="false" DataKeyNames="idUser"
                                    EmptyDataText="No se encuentran registros." OnRowDataBound="gvResume_RowDataBound"
                                     >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#48848E" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="User"   ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>

                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" RenderMode="Block">
                                                    <ContentTemplate>
                                                        <span>
                                                            <asp:TextBox ID="txtUserOper" MaxLength="100" runat="server" CssClass="form-control float-right" />
                                                        </span>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span>
                                                    <asp:TextBox ID="txtNameOper" MaxLength="100" runat="server" CssClass="form-control float-right" />
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ap. Paterno"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>


                                                <span>
                                                    <asp:TextBox ID="txtAPPOper" MaxLength="100" runat="server" CssClass="form-control float-right" />
                                                </span>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ap. Materno" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>


                                                <span>
                                                    <asp:TextBox ID="txtAPMOper" MaxLength="100" runat="server" CssClass="form-control float-right" />
                                                </span>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Direccion"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span>
                                                    <asp:TextBox ID="txtaddressOper" MaxLength="200" runat="server" CssClass="form-control float-right" />
                                                </span>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CP" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span>
                                                    <asp:TextBox ID="txtcpOper" Width="100px" MaxLength="10" runat="server" CssClass="form-control float-right" />
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Telefono" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span>
                                                    <asp:TextBox ID="txtphoneOper" Width="140px" MaxLength="10" runat="server" CssClass="form-control float-right" TextMode="Number" />
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Correo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <span>
                                                    <asp:TextBox ID="txtEmailOper" MaxLength="200" runat="server" CssClass="form-control float-right" />
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="Creacion"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>


                                                <span>
                                                    <asp:TextBox ID="txtcreateOper" runat="server" CssClass="form-control float-right" />
                                                </span>

                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

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
