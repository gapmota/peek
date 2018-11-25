<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="peek.dist.screenSystem.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
        <link rel="stylesheet" href="../css/styleRegister.css"/>
        <link rel="stylesheet" media="Screen (max-width: 1024px)" href="cadastro.css"/>
        <link rel="stylesheet" media="Screen (max-width: 768px)" href="cadastro.css"/>
        <title>Peek - Cadastro</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <main>
            <div class="container">
                <h1>Cadastre-se</h1>
                <asp:TextBox runat="server" ID="txtNome" Class="input" placeholder="Nome" />
                <asp:TextBox runat="server" ID="txtEmail" Class="input" placeholder="E-mail" />
                <asp:TextBox runat="server" ID="txtTelefone" Class="input" placeholder="Telefone" />
                <asp:TextBox runat="server" type="password" ID="txtSenha" Class="input" placeholder="Senha" />
                <asp:TextBox runat="server" type="password" ID="txtConfirmaSenha" Class="input" placeholder="Confirmar Senha" />
                <div>
                    <asp:Button runat="server" ID="btnVoltar" Class="voltar" Text="Voltar" OnClick="btnVoltar_Click"/>
                    <asp:Button runat="server" ID="btnEnviar" Class="enviar" Text="Cadastrar" OnClick="btnEnviar_Click"/>
                </div>
            </div>
        </main>
        </div>
    </form>
</body>
</html>
