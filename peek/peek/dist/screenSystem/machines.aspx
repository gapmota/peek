<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="machines.aspx.cs" Inherits="peek.dist.screenSystem.maquinas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/main.css" />
    <link rel="stylesheet" href="../css/temp.css" />
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
                    <a href="infraDashboard.aspx" class="nav-link">
                        <i class="far fa-user"></i>
                        Dashboard                         
                    </a>
                </li>
                <li class="nav-item">
                    <a href="addLab.aspx" class="nav-link">
                        <i class="fas fa-flask"></i>
                        Laboratórios 
                    </a>
                </li>
                <li class="nav-item">
                    <a href="login.aspx" class="nav-link">
                        <i class="fas fa-power-off"></i>
                        Sair                         
                    </a>
                </li>
            </div>
        </nav>
    </header>


    <div id="modal_process" class="fnd_modal_machines_off">
        <div id="modal_machine">
            <div id="fechar" onclick="fechar()"></div>
            <div class="header">
                <p class="estilo_texto_header" id="id_computador_modal">ID: 52</p>
                <p class="estilo_texto_header" id="processador_modal">Processador: Intel I3 | Usando 70%</p>
                <p class="estilo_texto_header" id="ram_modal">Memoria Ram: 8GB | Usando 50%</p>
                <p class="estilo_texto_header" id="downladUpload_modal">Download: 50mbps | Upload: 10mbps</p>
                <p class="estilo_texto_header" id="hd_modal">C: 80% Espaço livre | D: 60% Livre</p>
            </div>
            <div class="processos_ativos">

                <div id="area_processos">
                </div>
            </div>
        </div>
    </div>

    <main id="maquinasLab" class="maqui-lab">
        <h1 class="title-heading">Controle de <span class="text-secondary">Maquinas</span></h1>
        <asp:Panel ID="machines" class="boxMachines" runat="server">
            <div class="legendaMaquinasLab">
                <div class="textoIdMaq">ID </div>
                <div class="textoProcMaq">PROCESSADOR</div>
                <div class="textoRamMaq">RAM</div>
                <i class="fas fa-desktop" id="iconPC"></i>
            </div>
        </asp:Panel>
    </main>

    <div id="modal_cmd" class="modal_cmd_off">

        <span class="area_historico">
            <div id="todos_os_comandos_executados"></div>
            <div id="limpar_todos_os_comandos"></div>
        </span>

        <div class="area_cmd">

            <div class="area_titulo_cmd">
                <div id="titulo_cmd"></div>
                <div id="fechar_cmd" onclick="fecharModalCmd()"></div>
            </div>

            <div id="area_prompt_remoto" class="prompt_remoto">
            </div>
            <div class="acoes_cmd">
                <div id="digite_sem_texto"></div>
                <input type="text" id="txtComandoParaSerExecutado" class="txtComandoExecutar" tabindex="1">
                <div id="btn_executar_comando"></div>
            </div>
        </div>
    </div>



    <script src="../js/main.js"></script>
    <script src="../js/cmd_remoto.js"></script>
    <script src="../js/machines.js"></script>
    <script src="../js/request.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</body>
</html>
