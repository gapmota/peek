<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="peek_web.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
        <link rel="stylesheet" href="css/CadastroStyle.css"/>
        <link rel="stylesheet" media="Screen (max-width: 1024px)" href="cadastro.css"/>
        <link rel="stylesheet" media="Screen (max-width: 768px)" href="cadastro.css"/>
        <title>Cadastre-se</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <main>
            <div class="container">
                <h1>Cadastre-se</h1>
                <asp:TextBox runat="server" ID="txtNome" Class="input" placeholder="Nome" />
                <!--<input type="text" placeholder="Nome"/><br>-->
                <asp:TextBox runat="server" ID="txtEmail" Class="input" placeholder="E-mail" />
                <!--<input type="text" placeholder="E-mail"/><br>-->
                <asp:TextBox runat="server" ID="txtTelefone" Class="input" placeholder="Telefone" />
                <!--<input type="text" placeholder="Telefone"/><br>-->
                <asp:TextBox runat="server" ID="txtSenha" Class="input" placeholder="Senha" />
                <!--<input type="password" placeholder="Senha"/><br>-->
                <asp:TextBox runat="server" ID="txtConfirmaSenha" Class="input" placeholder="Confirmar Senha" />
                <!--<input type="password" placeholder="Confirmar senha"/><br>-->
                <div>
                    <asp:Button runat="server" ID="btnVoltar" Class="voltar" Text="Voltar" OnClick="btnVoltar_Click"/>
                    <!--<button type="reset" class="voltar">Voltar</button>-->
                    <asp:Button runat="server" ID="btnEnviar" Class="enviar" Text="Cadastrar" OnClick="btnEnviar_Click"/>
                    <!--<button type="submit" class="enviar">Enviar</button>-->
                </div>
            </div>
        </main>
        </div>
    </form>
</body>
</html>
