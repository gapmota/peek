<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="work.aspx.cs" Inherits="peek.dist.work" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/main.css"/>
    <script src="https://wchat.freshchat.com/js/widget.js"></script>
    <title>Nosso projeto</title>
</head>
<body id="bodyWork">
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

    <main id="work">
        <h1 class="title-heading">
            Nosso <span class="text-secondary">Projeto</span>
        </h1>
        <h2 class="subtitle-heading">
         Mais que um Dashboard, um facilitador...     
        </h2>
        <div class="projects">
            <div class="item">
                <a href="#!">
                    <img src="../img/projects/dashRede.jpg" alt="Project">
                </a>
                <a href="#" class="btn-light">
                     Ver mais <i class="far fa-eye"></i>
                </a>
            </div>
            <div class="item">
                <a href="#!">
                    <img src="../img/projects/responsa.jpg" alt="Project">
                </a>
                <a href="#" class="btn-light">
                     Ver mais <i class="far fa-eye"></i>
                </a>
            </div>
            <div class="item">
                <a href="#!">
                    <img src="../img/projects/dashInfra.jpg" alt="Project">
                </a>
                <a href="#" class="btn-light">
                     Ver mais <i class="far fa-eye"></i>
                </a>
            </div>
            <div class="item">
                <a href="#!">
                    <img src="../img/projects/project4.jpeg" alt="Project">
                </a>
                <a href="#" class="btn-light">
                     Ver mais <i class="far fa-eye"></i>
                </a>
            </div>
            <div class="item">
                <a href="#!">
                    <img src="../img/projects/project5.jpeg" alt="Project">
                </a>
                <a href="#" class="btn-light">
                     Ver mais <i class="far fa-eye"></i>
                </a>
            </div>
            <div class="item">
                <a href="#!">
                    <img src="../img/projects/project3.jpeg" alt="Project">
                </a>
                <a href="#" class="btn-light">
                     Ver mais <i class="far fa-eye"></i>
                </a>
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
