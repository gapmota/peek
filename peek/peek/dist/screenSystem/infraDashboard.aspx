<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infraDashboard.aspx.cs" Inherits="peek.dist.css.infraDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <link rel="stylesheet" href="../css/main.css"/>
    <title>Dashboard da Infra</title>
</head>
<body id="body-menu">
    <form id="form1" runat="server">
        <div>
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
                        <a href="../screenSystem/addLab.aspx" class="nav-link">
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


    <div id="dashboardInfra">
        <div class="legendaMaster">DASHBOARD DE INFRA</div>  
        <div class="grid1">           
            <div class="histDesemp">
                <div class="legenda">HISTORICO DE DESEMPENHO</div>                
            </div>
            <div class="processos">
                <div class="legenda">PROCESSOS</div>
            </div>                   
        </div>
        <div class="grid2">
            <div class="usoProcessos">
                <div class="legenda">PROCESSOS MAIS USADOS</div>
            </div>
            <div class="qtdMaquinas">
                <div class="legenda">QUANTIDADE DE MAQUINAS</div>
            </div>
            <div class="bonusDash">
                <div class="legenda">DECIDIR</div>
            </div>  
        </div> 
    </div>



    <div id="dashboardRede">
        <div class="legendaMaster">DASHBOARD DE REDE</div>  
        <div class="grid1">           
            <div class="consumo">
                <div class="legenda">CONSUMO</div>                
            </div>
            <div class="processos">
                <div class="legenda" onclick="pegarDownload()">PROCESSOS</div>
                <p id="txtDownload"></p>
                <p id="txtUpload"></p>
            </div>     
            <div class="aplicacoes">
                <div class="legenda">USO APLICAÇÕES</div>
            </div>               
        </div>
        <div class="grid2">
            <div class="qtdLabs">
                <div class="legenda">QUANTIDADE LABORATÓRIOS</div>
                <p id="txtQuantidadeLaboratorio"></p>
            </div>
            <div class="lab1">
                <div class="legenda">NOME LAB</div>
            </div>
            <div class="lab2">
                <div class="legenda">NOME LAB</div>
            </div>  
            <div class="lab3">
                <div class="legenda">NOME LAB</div>
            </div> 
        </div> 
    </div>

    <div class="btn-dash">
        <i class="fas fa-arrow-circle-down fa-3x"></i>
    </div>   

    <script src="../js/main.js"></script>
    <script src="../js/request.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    
        </div>
    </form>
</body>
</html>
