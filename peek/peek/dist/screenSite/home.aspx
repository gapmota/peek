<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="peek.dist.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/main.css"/>
    <title>Front do projeto</title>
</head>
<body id="bg-img">
    <form id="form1" runat="server">
        <div>
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
                        <a href="home.aspx" class="nav-link">
                        Home
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="about.aspx" class="nav-link">
                        Sobre Nós
                        </a>
                    </li>
                    <li class="nav-item current">
                        <a href="work.aspx" class="nav-link">
                        Projeto
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="contact.aspx" class="nav-link">
                        Contato
                        </a>
                    </li>               
            </div>              
            </div>
        </nav>
    </header>

    <main id="home">
        <h1 class="title-heading">
            Projeto <span class="text-secondary">Peek</span>
        </h1>
        <h2 class="subtitle-heading">
          Desenvolvido com amor por estagiários da BandTec.       
        </h2>
        <div class="icons">
            <!--Os icones são usados do site que esta no head-->
            <a href="#!">
                <i class="fab fa-twitter fa-2x"></i>
            </a>
            <a href="#!">
                    <i class="fab fa-facebook fa-2x"></i>
            </a>
            <a href="#!">
                    <i class="fab fa-github fa-2x"></i>
            </a>
        </div>

        <a href="#" class="btn-dark Log">CADASTRAR</a>
        <a href="#" class="btn-dark Cad">LOGAR</a>
    </main>

    <script src="../js/main.js"></script>
        </div>
    </form>
</body>
</html>
