<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infraDashboard.aspx.cs" Inherits="peek.dist.css.infraDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- Google Charts --%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.1/Chart.min.js"></script>
    <link rel="stylesheet" href="../css/main.css" />
    <link rel="icon" href="../img/icon.png" type="image/x-icon" />
    <link rel="shortcut icon" href="../img/icon.png" type="image/x-icon" />
    <title>Peek - Dashboard</title>
    <style>
        #mediaUsoProcessador {
            width: 100%;
            height: 5vh;
            padding-left: 2vh;
            padding-top: 0.5vh;
            text-align: left;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        #mediaUsoMemoriaRam {
            width: 100%;
            height: 5vh;
            padding-left: 2vh;
            padding-top: 0.5vh;
            text-align: left;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
    </style>
</head>

<body id="body-menu">
    <form id="form1" runat="server">

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
                    <!-- <div class="overlay">
                          <div class="text">Hello World</div>
                         </div> -->
                </div>
                <div class="menu-nav">
                    <li class="nav-item">
                        <a href="addLab.aspx" class="nav-link">
                            <i class="fas fa-flask"></i>
                            Laboratórios 
                        </a>
                    </li>
                    <li class="nav-item">
                        <a target="_blank" href="https://stefaninigf.slack.com/messages/CE55PAPC5/details/" class="nav-link">
                            <i class="fab fa-slack"></i>
                            Slack                        
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


        <div id="dashboardInfra">
            <div class="legendaMaster">DADOS DOS LABORATÓRIOS</div>
            <div class="grid1">
                <div class="histDesemp">
                    <div class="legenda">HISTORICO DE DESEMPENHO - PROCESSADOR</div>
                    <canvas id="infraHistory"></canvas>
                </div>
                <div class="processos">
                    <div class="legenda">HD e RAM - Média</div>
                    <div class="mediaProcessador">
                        <p id="mediaUsoProcessador"></p>
                    </div>
                    <div class="mediaProcessador">
                        <p id="mediaUsoMemoriaRam"></p>
                    </div>
                    <div class="mediaProcessadorFrase">PROCESSADOR</div>
                    <div class="mediaProcessadorFrase">RAM</div>
                </div>
                <div class="qtdMaquinas">
                    <div class="legenda">MÁQUINAS</div>
                    <div class="BoxComputers">
                        <asp:Label Text="" ID="lblComp" runat="server" onClick="seeMaquinas()" />
                    </div>
                </div>
            </div>
            <div class="grid2">
                <div class="bonusDash">
                    <div class="legenda">HD - alto <i class="fas fa-circle A"></i></div>
                    <p id="pouco_hd"></p>
                </div>
                <div class="bonusDash">
                    <div class="legenda">HD - Médio <i class="fas fa-circle B"></i></div>
                    <p id="media_hd"></p>
                </div>
                <div class="bonusDash">
                    <div class="legenda">HD - Baixo <i class="fas fa-circle C"></i></div>
                    <p id="muito_hd"></p>
                </div>
                <div class="usoProcessos">
                    <div class="legenda">PROCESSOS MAIS USADOS</div>
                    <canvas id="infraMoreUse" style="width: 20%;"></canvas>
                </div>

            </div>
        </div>


        <div id="dashboardRede">
            <div class="legendaMaster">DADOS DA REDE</div>
            <div class="grid1">

                <div class="processos">
                    <div class="legenda">VELOCIDADE</div>
                    <p id="txtDownload"></p>
                    <div id="procGraphi" class="procGraphi"></div>
                    <p id="txtUpload"></p>
                </div>
                <div class="consumo">
                    <div class="legenda">CONSUMO DE REDE</div>
                    <canvas id="consumeGraphi"></canvas>
                </div>
                <div class="aplicacoes">
                    <div class="legenda">USO DAS APLICAÇÕES / PROCESSOS</div>
                    <canvas id="useGraphi"></canvas>
                </div>
            </div>
            <div class="grid2">
                <div class="qtdLabs">
                    <div class="legenda">QUANTIDADE DE LABORATÓRIOS</div>
                    <br />
                    <br />
                    <br />
                    <asp:Label Text="" ID="lblQuantLabs" runat="server" onClick="seeLabs()" CssClass="BoxLabs" />
                </div>
                <div class="lab1">
                    <div class="legenda">ALTA UTILIZAÇÃO DA REDE <i class="fas fa-circle"></i></div>
                    <p id="alta_utilizacao" class="nomeLab3"></p>
                    <a href="machines.aspx" class="btn-dark Enc">Encerrar Processos</a>
                </div>
                <div class="lab2">
                    <div class="legenda">MÉDIA UTILIZAÇÃO DA REDE <i class="fas fa-circle"></i></div>
                    <p id="media_utilizacao" class="nomeLab3"></p>
                    <a href="machines.aspx" class="btn-dark Enc">Encerrar Processos</a>
                </div>
                <div class="lab3">
                    <div class="legenda">BAIXA UTILIZAÇÃO DA REDE <i class="fas fa-circle"></i></div>
                    <p id="baixa_utilizacao" class="nomeLab3"></p>
                    <a href="machines.aspx" class="btn-dark Enc">Encerrar Processos</a>
                </div>
            </div>
        </div>

        <div class="btn-dash">
            <i class="fas fa-arrow-circle-down fa-3x"></i>
        </div>
    </form>
</body>
<script src="../js/main.js"></script>
<script src="../js/request.js"></script>
<script src="../js/graphics.js"></script>
<script src="../js/refresh.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<% Response.Write("<script>iniciar(" + ((peek.Models.User)Session["Usuario"]).Id + ");</script>");%>
</html>

