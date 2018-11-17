<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="peek.dist.sobre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <link rel="stylesheet" href="../css/main.css"/>
    <title>Sobre Nós</title>
</head>
<body id="backBody">
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
                <div class="portrait"></div>
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
        </nav>
    </header>

    <main id="sobre">
        <h1 class="title-heading">
            Sobre <span class="text-secondary">Nós</span>
        </h1>
        <h2 class="subtitle-heading">
         Porque acreditamos na tranformação digital ?       
        </h2>
        <div class="about-info">
            <img src="../img/flag.jpg" alt="Sobre nós" class="bio-img">  
            <div class="bio">
                <h3 class="text-secondary">BIO</h3>
                <P> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Fugit distinctio ullam voluptatum qui, temporibus nesciunt fugiat quis accusamus, tempore vero rerum suscipit ea ex. Rerum aspernatur quisquam at consequatur sequi.
                </P>
            </div>

            <div class="quadro quadro-1">
                <h3>123 quadro 1</h3>
                <h6>Teste quadro 1</h6>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Quod error odio temporibus laborum, repudiandae exercitationem voluptatem similique eum laudantium eos?</p>
            </div>

            <div class="quadro quadro-2">                
                <h3>123 quadro 2</h3>
                <h6>Frase quadro 2</h6>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Quod error odio temporibus laborum, repudiandae exercitationem voluptatem similique eum laudantium eos?</p>
            </div>

            <div class="quadro quadro-3">                
                <h3>123 quadro 3</h3>
                <h6>Algo no quadro 3</h6>
                <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Quod error odio temporibus laborum, repudiandae exercitationem voluptatem similique eum laudantium eos?</p>
            </div>
        </div>
    </main>

    <footer id="main-footer">
        Copyright &copy; 2018;
    </footer>

    <script src="../js/main.js"></script>
        </div>
    </form>
</body>
</html>
