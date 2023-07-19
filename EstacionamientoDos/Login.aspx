<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EstacionamientoDos.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous">
    <link href="Style/sign-in.css" rel="stylesheet">


    <link rel="icon" type="image/png" href="Style/Login/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <%--<link rel="stylesheet" type="text/css" href="Style/Login/vendor/bootstrap/css/bootstrap.min.css">--%>
    <link rel="stylesheet" type="text/css" href="Style/Login/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Style/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Style/Login/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Style/Login/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Style/Login/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Style/Login/css/util.css">
    <link rel="stylesheet" type="text/css" href="Style/Login/css/main.css">
    <!--===============================================================================================-->


    <style>
        .mppBkLoad {
            background-color: gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .mppLoad {
            background-color: rgba(255, 255, 255, 0);
            border-width: 0px;
            border-style: solid;
            border-color: ThreeDShadow;
            padding: 0px;
            text-align: center;
        }
    </style>
</head>
<body style="align-content: center; align-items: center;" class="text-center">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-geWF76RCwLtnZ8qwWowPQNguL3RmwHVBC9FhGdlKrxdiJJigb/j/68SIy3Te4Bkz" crossorigin="anonymous"></script>

    <div class="limiter">
        <div class="container-login100">
            <div>


                <form action="#" runat="server" class="login100-form validate-form">




                    <img class="mb-4" src="Img/companyLogo.jpg" alt="" width="72" height="57">
                    <h1 class="h3 mb-3 fw-normal">Please sign in</h1>

                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtUser" TextMode="Email" CssClass="form-control" placeholder="name@example.com" ToolTip="Correo" Width="300px"></asp:TextBox>
                        <%--<input type="email" class="" id="floatingInput" placeholder="name@example.com">--%>
                        <label for="floatingInput">Email address</label>
                    </div>
                    <br />
                    <div class="form-floating">
                        <%--<input type="password" class="form-control" id="floatingPassword" placeholder="Password">--%>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control" placeholder="name@example.com" ToolTip="Correo" Width="300px"></asp:TextBox>
                        <label for="floatingPassword">Password</label>
                    </div>
                    <br />

                    <%--<div class="checkbox mb-3">
                <label>
                    <input type="checkbox" value="remember-me">
                    Remember me
     
                </label>
            </div>--%>
                    <asp:Button runat="server" CssClass="w-100 btn btn-lg btn-primary" Text="Ingresar" OnClick="btnSignIn_Click" />
                    <p class="mt-5 mb-3 text-muted">&copy; 2017–2021</p>



                    <!-- Modal -->
                    <div class="divModal">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
                        <asp:UpdatePanel ID="uppnlModalmenVal" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:Button ID="btnMensajeMaster" runat="server" Text="Cancelar Modal" Style="display: none;" />
                                <ajaxToolkit:ModalPopupExtender ID="mpeMensajeMaster" runat="server" TargetControlID="btnMensajeMaster" OkControlID="btnAceptarMensajeMaster"
                                    PopupControlID="pnlMensajeMaster" EnableViewState="true" BackgroundCssClass="mppBkLoad" BehaviorID="mpeMensajeMaster">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Panel ID="pnlMensajeMaster" runat="server" CssClass="mppLoad" Style="display: none;">

                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header" style="text-align: left;">
                                                <asp:Label ID="lblTituloMensajeMaster" runat="server" Text="Se encontraron coincidencias en la busqueda"
                                                    CssClass="modal-title" Style="font-size: 20px; font-weight: bold; color: #47658d;" />
                                            </div>
                                            <div class="modal-body" style="text-align: left;">
                                                <asp:Label ID="lblMensajeMaster" runat="server" Text=""
                                                    Style="font-size: 18px; color: #47658d;" />
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnAceptarMensajeMaster" runat="server" Text="Aceptar" CssClass="btn btn-primary btn-lg" />
                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>

                                <asp:Button ID="btnCancelModal" runat="server" Text="Cancelar Modal" Style="display: none;" />
                                <ajaxToolkit:ModalPopupExtender ID="PleaseWaitPopup" runat="server" TargetControlID="btnCancelModal"
                                    PopupControlID="pnlProcesando" EnableViewState="true" BackgroundCssClass="mppBkLoad" BehaviorID="PleaseWaitPopup">
                                </ajaxToolkit:ModalPopupExtender>

                                <asp:Panel ID="pnlProcesando" runat="server" Height="100px" Width="250px" CssClass="alert"
                                    Style="border-radius: 15px; border-color: #bce8f1; background-color: #FFFFFF; box-shadow: 10px 10px 5px #888888; padding-left: 5px; padding-right: 5px; padding-top: 20px; padding-bottom: 10px; display: none; display: none;">
                                    <div class="container-fluid">
                                        <h4 style="color: #47658d; text-align: left; text-shadow: 0.1em 0.1em #CCCCCC;">Procesando...</h4>
                                        <div class="progress progress-striped active">
                                            <div role="progressbar" aria-valuetransitiongoal="100" class="progress-bar progress-bar-info" aria-valuenow="100" style="width: 100%;"></div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>



                </form>

            </div>
        </div>
    </div>
</body>
</html>
