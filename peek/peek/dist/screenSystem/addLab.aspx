<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addLab.aspx.cs" Inherits="peek.dist.addLab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/styleAddLab.css"/>
    <title>Dashboard da Infra</title>
</head>
<body id="body-menu" class="backBodyLab"> 
	<header>
        <div class="imgLogo"></div>
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
                    <li class="nav-item current">
                        <a href="#" class="nav-link">
                        <i class="far fa-user"></i>
                        Meu Perfil                         
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="#" class="nav-link">
                        <i class="fas fa-flask"></i>
                        Laboratórios 
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="#" class="nav-link">
                        <i class="far fa-bell"></i>
                        Notificações                        
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="#" class="nav-link">
                        <i class="fas fa-power-off"></i>
                        Sair                         
                        </a>
                    </li>               
            </div>
        </nav>
    </header>

    <main id="work" class="ad-lab">
        <h1 class="title-heading">
            Controle de <span class="text-secondary">Laboratórios</span>
        </h1>

        <div class="projects">
            <form class="item form" id="form1" runat="server">
                <div class="legenda">ADICIONAR LAB</div>  
                        <input type="text" class="btn-dark" required name="nome-lab" placeholder="Nome do lab">
                <button class="btn-dark add" >
                        <i class="fas fa-plus-square"></i> Adicionar
                </button>
            </form>
        </div>      
    </main>

	<script
        src="https://code.jquery.com/jquery-3.3.1.js"
        integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60="
        crossorigin="anonymous">
    </script>
    <script src="../js/lab.js"></script>
    <script src="../js/main.js"></script>
</body>
</html>
