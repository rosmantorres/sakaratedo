<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M14_VisorInscripcion.aspx.cs" Inherits="templateApp.GUI.Modulo14.M14_VisorInscripcion" %>

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
    
        <CR:CrystalReportSource ID="DataInscripcion" runat="server">
            <Report FileName="Inscripcion.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
        <CR:CrystalReportViewer ID="VisorInscripcion" runat="server" AutoDataBind="true" ReportSourceID="DataInscripcion" />
    </form>
</body>
</html>
