<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="computer.aspx.cs" Inherits="visualizarDados.screen.computadores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../css/computerStyle.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Peek - Computadores</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="cadastrados" class="body" runat="server">
                
            </div>
        </div>
    </form>
    <script type="text/javascript"> 
        function atualizar() {
            <%ListarRegistros(); CriarRegistros();%>
            window.location.reload(true);
        }
    </script>      
</body>
</html>
