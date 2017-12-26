<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="Comando.Pages.CambioPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <link href="../Styles/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    
        td {
           
        }
        .auto-style2 {
            text-align: right;
            width: 18%;
        }
        .auto-style3 {
            width: 18%;
        }
        .auto-style4 {
            text-align: right;
            width: 33%;
        }
        .auto-style7 {
            width: 33%;
        }
    </style>
</head>
<body style="width:99%">
     
    <form id="form1" runat="server">
    <div >
         <br />
    <fieldset >
    <legend style="color: #3498db;margin-left:10px">Cambio Password:</legend>
        <br />
        <table style="width:100%;background-image: url('/Comando/images/polizialocale_bn2.png');">
            <tr>
                <td style="height:50px">

                    &nbsp;</td>
                <td colspan="3" style="height:50px">

                </td>
                </tr>
            <tr>
                <td style="width:33%;margin-top:80px" class="auto-style1">&nbsp;</td>
                <td style="margin-top:80px" class="auto-style2"><label>Vecchia Password:</label>&nbsp;&nbsp;</td>
                <td><asp:TextBox runat="server" id="vecchiapassword" TextMode="Password" Width="277px"/></td>
                <td style="width:33%">&nbsp;</td>
            </tr>
            <tr >
                 <td style="width:33%;" class="auto-style1">&nbsp;</td>
                 <td class="auto-style2"><label>Nuova Password:</label>&nbsp;&nbsp;</td>
                 <td><asp:TextBox  runat="server" id="nuovapassword" TextMode="Password" Width="277px"/> </td>
                 <td style="width:33%">&nbsp;</td>
            </tr>
            <tr >
                 <td class="auto-style4"></td>
                 <td class="auto-style2"><label>Ripeti Password:</label>&nbsp;&nbsp;</td>
                 <td><asp:TextBox runat="server" id="confermapassword" TextMode="Password" Width="277px"/> </td>
                 <td class="auto-style7"></td>
            </tr>
            <tr style="height:30px"> 
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr style="height:35px">
                 <td style="width:33%">&nbsp;</td>
                 <td class="auto-style3">&nbsp;</td>
                 <td>
                     <asp:Panel runat="server" ID="divError"></asp:Panel>
                     <asp:Label ID="lblError" Visible="false" CssClass="alert alert-success fade in" runat="server" Text=""></asp:Label>
                     </td>
                 <td style="width:50%">&nbsp;</td>
            </tr>
            <tr style="height:35px">
                 <td style="width:33%">&nbsp;</td>
                 <td class="auto-style3">&nbsp;</td>
                 <td><asp:Button ID="salva" runat="server" Width="100px" Text="Salva" OnClick="salva_Click" CssClass="btn btn-danger" /></td>
                 <td style="width:50%">&nbsp;</td>
            </tr>
            <tr style="height:35px">
                 <td>&nbsp;</td>
                 <td colspan="3"><hr style="width:50%" /></td>
            </tr>
            <tr style="height:35px">
                 <td style="width:33%">&nbsp;</td>
                 <td class="auto-style3">&nbsp;</td>
                 <td>&nbsp;</td>
                 <td style="width:50%">&nbsp;</td>
            </tr>
            <tr style="height:35px">
                 <td style="width:33%">&nbsp;</td>
                 <td class="auto-style3">&nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td style="width:50%">&nbsp;</td>
            </tr>
        </table>
   
    </fieldset>
      
    </div>
    </form>
     
</body>
</html>
<script>
    $(document).ready(function () {
        $('input').addClass('k-widget k-autocomplete k-header form-control k-state-primary');
        $('label').addClass('col-md-12 control-label');
    })
    $('#salva').click(function () {
        if ($(nuovapassword).val() != $(confermapassword).val()) {
            alert('Le Password inserite non coincidono');
            return false;
        }
        return true;
    });
</script>