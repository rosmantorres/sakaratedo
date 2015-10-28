<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M14_VisorCarnet.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_VisorCarnet" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportSource ID="DataCarnet" runat="server">
            <Report FileName="Carnet.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    <div style="text-align:center">
        <CR:CrystalReportViewer  ID="VisorCarnet" runat="server" AutoDataBind="true" ReportSourceID="DataCarnet" />
    </div>
    </form>
</body>
</html>
