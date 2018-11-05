<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="visualizarDados.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../css/indexStyle.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Peek - Database</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="boxTitle">
                    Dados do computador:
                </div>
                <br />      
                <asp:Label class="lbl" runat="server" id="lblIdPc"/> <br /><br />
                <asp:Label class="lbl" runat="server" id="lblRam"/> <br />
                <asp:Label class="lbl" runat="server" id="lblProc"/> <br />
                <asp:Label class="lbl" runat="server" id="lblMac"/> <br />
            </div>
            <div class="container">
                <div class="boxTitle">
                    Dados do processador:
                </div>
                <br />      
                <asp:Label class="lbl" runat="server" id="lblIdPc_Proc"/> <br /><br />
                <asp:Label class="lbl" runat="server" id="lblIdProc"/> <br />
                <asp:Label class="lbl" runat="server" id="lblTime"/> <br />
                <asp:Label class="lbl" runat="server" id="lblDate"/> <br />
            </div>
            <div class="container">
                <div class="boxTitle">
                    Dados da RAM:
                </div>
                <br />      
                <asp:Label class="lbl" runat="server" id="lblIdPc_Ram"/> <br /><br />
                <asp:Label class="lbl" runat="server" id="lblTotal"/> <br />
                <asp:Label class="lbl" runat="server" id="lblFree"/> <br />
                <asp:Label class="lbl" runat="server" id="lblUse"/> <br />
            </div>
            <div class="container">
                <div class="boxTitle">
                    Dados da Rede:
                </div>
                <br />      
                <asp:Label class="lbl" runat="server" id="lblIdPc_Rede"/> <br /><br />
                <asp:Label class="lbl" runat="server" id="lblIdRede"/> <br />
                <asp:Label class="lbl" runat="server" id="lblIpv4"/> <br />
                <asp:Label class="lbl" runat="server" id="lblIpv6"/> <br />
                <asp:Label class="lbl" runat="server" id="lblMacAddress"/> <br />
                <asp:Label class="lbl" runat="server" id="lvlDown"/> <br />
                <asp:Label class="lbl" runat="server" id="lblUpload"/> <br />
                <asp:Label class="lbl" runat="server" id="lblDateRede"/> <br />
            </div>
            <div class="container">
                <div class="boxTitle">
                    Dados do MAC:
                </div>
                <br />      
                <asp:Label class="lbl" runat="server" id="lblIdPc_Mac"/> <br /><br />
                <asp:Label class="lbl" runat="server" id="lblMacAd"/> <br />
                <asp:Label class="lbl" runat="server" id="lblConnec"/> <br />
                <asp:Label class="lbl" runat="server" id="lblDateCad"/> <br />
            </div>
        </div>
    </form>
</body>
</html>
