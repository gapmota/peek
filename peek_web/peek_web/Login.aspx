<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="peek_web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
        <link rel="stylesheet" href="css/LoginStyle.css"/>
        <link rel="stylesheet" media="Screen (max-width: 1024px)" href="login.css"/>
        <link rel="stylesheet" media="Screen (min-width: 360px)" href="login.css"/>
        <title>login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <main>
           <div class="container">
               <h1>Entre</h1>
              <div>
                  <asp:TextBox runat="server" ID="txtEmail" Class="input" placeholder="E-mail" />
                <!--<input type="text" placeholder="E-mail"/> <br>-->
              </div>
               <asp:TextBox runat="server" ID="txtSenha" Class="input" placeholder="Senha" />
               <!-- <input type="password" placeholder="Senha"/> <br>-->
               <asp:Button runat="server" ID="btnVoltar" Class="voltar" Text="Voltar" OnClick="btnVoltar_Click" />
               <!--<button type="reset" class="voltar">Voltar</button>-->
               <asp:Button runat="server" ID="btnEnviar" Class="enviar" Text="Iniciar" OnClick="btnEnviar_Click" />
              <!-- <button type="submit" class="enviar">Enviar</button>-->
                <p>Não possui cadastro?
                    <a href="Cadastro.aspx">Cadastre-se</a>
                </p>
           </div>
        </main>
        </div>
    </form>
</body>
</html>
