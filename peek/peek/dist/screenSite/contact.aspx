<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="peek.dist.screenSite.contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous" />
    <link rel="stylesheet" href="../css/main.css" />
    <title>Nos contate</title>
</head>
<body id="bodyContato">
    <form id="form1" runat="server">
        <header>
            <div class="menu-btn">
                <div class="btn-line"></div>
                <div class="btn-line"></div>
                <div class="btn-line"></div>
            </div>

            <nav class="menu">
                <div class="menu-branding">
                </div>
                <div class="menu-nav">
                    <li class="nav-item">
                        <a href="home.aspx" class="nav-link">Home
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="about.aspx" class="nav-link">Sobre Nós
                        </a>
                    </li>
                    <li class="nav-item ">
                        <a href="work.aspx" class="nav-link">Projeto
                        </a>
                    </li>
                    <li class="nav-item current">
                        <a href="contact.aspx" class="nav-link">Contato
                        </a>
                    </li>
                </div>
                </div>
            </nav>
        </header>

        <main id="contato">

            <div class="div-left">
                <h3 class="title-heading">Fale <span class="text-secondary">Conosco</span>
                </h3>
                <h2 class="subtitle-heading">Envie sua dúvida ou feedback...     
                </h2>
            </div>
            <div class="div-right">
                <div class="container">
                    <asp:TextBox runat="server" ID="txtNome" Class="input" placeholder="Nome" />
                    <asp:TextBox runat="server" ID="txtEmail" Class="input" placeholder="E-mail" />
                    <asp:TextBox runat="server" ID="txtMensagem" Class="mensagem" TextMode="MultiLine" placeholder="Sua mensagem..." />
                    <asp:Button runat="server" ID="btnEnviar" Class="btnMensagem" Text="Enviar" OnClick="btnEnviar_Click" />
                </div>
            </div>
        </main>

        <script src="../js/main.js"></script>
    </form>
</body>
</html>
