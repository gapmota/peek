<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="peek.dist.sobre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <link rel="stylesheet" href="../css/main.css" />
    <script src="https://wchat.freshchat.com/js/widget.js"></script>
    <title>Sobre Nós</title>
    <link rel="icon" href="../img/icon.png" type="image/x-icon" />
    <link rel="shortcut icon" href="../img/icon.png" type="image/x-icon" />
</head>
<body id="backBody">
    <%-- Chat --%>
    <script>
        window.fcWidget.init({
            token: "6dd74831-da3e-45db-a2cd-3f487123c5c1",
            host: "https://wchat.freshchat.com"
        });
    </script>
    <%-- Fim chat --%>
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
                    <li class="nav-item current">
                        <a href="about.aspx" class="nav-link">Sobre Nós
                        </a>
                    </li>
                    <li class="nav-item ">
                        <a href="work.aspx" class="nav-link">Projeto
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="contact.aspx" class="nav-link">Contato
                        </a>
                    </li>
                </div>
                </div>
            </nav>
        </header>

        <main id="sobre">
            <h1 class="title-heading">Sobre <span class="text-secondary">Nós</span>
            </h1>
            <h2 class="subtitle-heading">Porque acreditamos na tranformação digital ?       
            </h2>
            <div class="integrantes">
                <div class="bio bio-1">
                    <h3 class="text-name">BRUNO</h3>
                    <h6>Desenvolvedor</h6>
                    <img src="../img/bruno.jpg" alt="Sobre nós" class="bio-img">
                </div>
                <div class="bio bio-2">
                    <h3 class="text-name">GIULIANA</h3>
                    <h6>Desenvolvedora e PO</h6>
                    <img src="../img/eu.jpg" alt="Sobre nós" class="bio-img">
                </div>
                <div class="bio bio-3">
                    <h3 class="text-name">GUILHERME</h3>
                    <h6>Desenvolvedor e Scrum</h6>
                    <img src="../img/mota.jpg" alt="Sobre nós" class="bio-img">
                </div>
                <div class="bio bio-4">
                    <h3 class="text-name">MATEUS</h3>
                    <h6>Desenvolvedor e DBA</h6>
                    <img src="../img/covos.jpg" alt="Sobre nós" class="bio-img">
                </div>
                <div class="bio bio-5">
                    <h3 class="text-name">MICHEL</h3>
                    <h6>Desenvolvedor</h6>
                    <img src="../img/michel.jpg" alt="Sobre nós" class="bio-img">
                </div>
            </div>
            <div class="about-info">
                <div class="quadro quadro-1">
                    <h3>SOLUCIONAR PROBLEMAS</h3>
                    <h6>Missão</h6>
                    <p>Atuar como facilitador monitorando desempenho de hardware e udo da rede de ambientes educacionais </p>
                </div>

                <div class="quadro quadro-2">
                    <h3>INOVAÇÃO</h3>
                    <h6>Valor</h6>
                    <p>Sair do convencional trazendo funções e design diferenciados para experiência do usuário no Dashboard</p>
                </div>

                <div class="quadro quadro-3">
                    <h3>FUTURO</h3>
                    <h6>Visão</h6>
                    <p> Implementar melhorias e trabalhar na evolução constante do sistema visando a experiência do usuário</p>
                </div>
            </div>
        </main>

        <footer id="main-footer">
            Copyright &copy; 2018;
        </footer>

        <script src="../js/main.js"></script>

    </form>
</body>
</html>
