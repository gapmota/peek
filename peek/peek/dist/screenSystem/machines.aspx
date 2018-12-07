<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="machines.aspx.cs" Inherits="peek.dist.screenSystem.maquinas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/main.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>Peek - Maquinas Do Lab</title>
</head>
<body id="body-menu" class="bodyMaq">
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

    <main id="maquinasLab" class="maqui-lab">
        <h1 class="title-heading">Controle de <span class="text-secondary">Maquinas</span></h1>
        <asp:Panel ID="machines" class="boxMachines" runat="server">
                
        </asp:Panel>
    </main>
    <script src="../js/main.js"></script>
</body>
</html>
