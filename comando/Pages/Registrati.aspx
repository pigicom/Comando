<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrati.aspx.cs" Inherits="Comando.Pages.Regitstrati" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <script src="../Scripts/jquery-1.10.2.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <title></title>
    <style>
    
    .auto-style1 {
        width: 271px;
        height: 44px;
        float: right;
    }
    
        </style>
  <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
    <div style="width:99%;margin-left:5px;margin-right:5px">
         <br/>
               <fieldset style="width:99%;margin-left:5px;margin-right:5px">
                <legend style="color: #3498db;margin-left:10px">Inserire Cerdenziali<img alt="" style="margin-top:-18px;margin-left:5px" class="auto-style1" src="../images/logoComunale.gif" /></legend>
                <table style="background-image: url('/Comando/images/polizialocale_bn2.png');opacity: 0.9; width:100%"  >
            <tr style="height:100px">
                <td class="auto-style12" style="margin-right: 5px; ">&nbsp;</td>
                <td class="auto-style12" style="margin-right: 5px;width:10%"></td>
                <td class="auto-style13" style="margin-right: 5px; "></td>
               
            </tr>

            <tr>
                <td class="auto-style15" style="margin-right: 5px; ">&nbsp;</td>
                <td class="text-right" style="margin-right: 5px; "><label>Utente&nbsp; </label></td>
                <td class="auto-style16" style="margin-right: 5px; "><asp:TextBox runat="server" id="username" CssClass="k-widget k-autocomplete k-header form-control k-state-default" Width="277px"/> </td>
            
            </tr>
            <tr >
                 <td class="auto-style6" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="text-right" style="margin-right: 5px; "><label>Password&nbsp; </label></td>
                 <td class="auto-style10" style="margin-right: 5px; "><asp:TextBox  runat="server" id="password1" CssClass="k-widget k-autocomplete k-header form-control k-state-default" Width="277px" TextMode="Password"/> </td>
         
            </tr>
            <tr style="height:35px">
                 <td class="auto-style6" style="margin-right: 5px; " >&nbsp;</td>
                 <td class="text-right" style="margin-right: 5px; " ><label>Ripeti Password&nbsp;</label></td>
                 <td class="auto-style10" style="margin-right: 5px; " ><asp:TextBox runat="server" id="password2" CssClass="k-widget k-autocomplete k-header form-control k-state-default" Width="277px" TextMode="Password"/> </td>
            
            </tr>
            <tr style="height:35px">
                 <td class="text-center"  style="margin-right: 5px; " colspan="3"><asp:Label runat="server" id="lblError" Font-Size="16px" ForeColor="Red" ></asp:Label></td>
                 
            </tr>
            <tr style="height:35px">
                 <td class="auto-style7"  style="margin-right: 5px; " colspan="3"><hr  style="width:50%"/></td>
                 
            </tr>
            <tr style="height:35px">
                 <td class="auto-style7" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="auto-style7" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="auto-style9" style="margin-right: 5px; "><asp:Button ID="salva" runat="server" Text="Salva" CssClass="btn btn-danger" OnClick="salva_Click" OnClientClick="return checkForm()" />&nbsp;<asp:Button ID="Button1" runat="server" Text="Vai a Login >>" CssClass="btn btn-primary" OnClick="Button1_Click"/></td>
                 
            </tr>
            <tr style="height:35px">
                 <td class="auto-style7" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="auto-style7" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="auto-style9" style="margin-right: 5px; ">&nbsp;</td>
                 
            </tr>
            <tr style="height:35px">
                 <td class="auto-style7" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="auto-style7" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="auto-style9" style="margin-right: 5px; ">&nbsp;</td>
                 
            </tr>
            <tr style="height:35px">
                 <td class="auto-style7" style="margin-right: 5px;width:33% ">&nbsp;</td>
                 <td class="auto-style7" style="margin-right: 5px; ">&nbsp;</td>
                 <td class="auto-style9" style="margin-right: 5px; ">&nbsp;</td>
             
            </tr>
            <tr style="height:35px">
                 <td style="margin-right: 5px;" colspan="3"><hr  style ="80%"/>&nbsp;</td>
             
            </tr>
        </table>
   
    </fieldset>
      
    </div>
    </form>
</body>
</html>
 <script>

     $(document).ready(function(){
         $('label').addClass('col-md-12 control-label');
     })

   
     function checkForm()
     {
         if ($('#username').val().toString().length < 1) {
             $('#lblError').html('Il nome utente non può essere vuoto');
             return false;
         }

         if ($('#password').val().toString().length < 1) {
             $('#lblError').html('la password non può essere vuota');
             return false;
         }

         else {
             return true;}
     }
 </script>