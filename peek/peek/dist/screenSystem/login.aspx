<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="peek.dist.screenSystem.login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link rel="stylesheet" href="../css/styleLogin.css" />
    <link rel="stylesheet" media="Screen (max-width: 1024px)" href="login.css" />
    <link rel="stylesheet" media="Screen (min-width: 360px)" href="login.css" />
    <title>Peek - Login</title>
    <link rel="icon" href="../img/icon.png" type="image/x-icon" />
    <link rel="shortcut icon" href="../img/icon.png" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <main>
                <div class="container">
                    <h1>Entre</h1>
                    <div>
                        <asp:TextBox runat="server" ID="txtEmail" Class="input" placeholder="E-mail" />
                    </div>
                    <asp:TextBox runat="server" type="password" ID="txtSenha" Class="input" placeholder="Senha" />
                    <asp:Button runat="server" ID="btnVoltar" Class="voltar" Text="Voltar" OnClick="btnVoltar_Click" />
                    <asp:Button runat="server" ID="btnEnviar" Class="enviar" Text="Iniciar" OnClick="btnEnviar_Click" TabIndex="1" />
                    <p>
                        Não possui cadastro?
                    <a href="register.aspx">Cadastre-se</a>
                    </p>
                </div>
            </main>
        </div>
    </form>
</body>
</html>
