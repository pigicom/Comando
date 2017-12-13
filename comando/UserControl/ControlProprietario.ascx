<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlProprietario.ascx.cs" Inherits="WebApp.UserControl.ControlProprietario" %>
    <script src="../Scripts/i18n/grid.locale-it.js"></script>
    
<style type="text/css">
    .auto-style1 {
        height: 50px;
    }
    .auto-style2 {
        width: 403px;
        height: 385px;
    }
</style>
    
    
<script>
    //copia i dati della sezione trasgressore 
    $(document).ready(function () {
        $('#chkCopia').click(function () {
            $('#<%=txtNome.ClientID%>').val($('#ContentPlaceHolder1_ControlTrasgressore_txtNome').val());
            $('#<%=txtCognome.ClientID%>').val($('#ContentPlaceHolder1_ControlTrasgressore_txtCognome').val());
            $('#<%=txtDataNascita.ClientID%>').val($('#ContentPlaceHolder1_ControlTrasgressore_txtNascita').val());
            $('#<%=txtCittaNascita.ClientID%>').val($('#ContentPlaceHolder1_ControlTrasgressore_txtCittaNascita1').val());
            $('#<%=txtCittaResidenza.ClientID%>').val($('#ContentPlaceHolder1_ControlTrasgressore_txtCittaResidenza').val());
            $('#<%=txtIndirizzoResidenza.ClientID%>').val($('#ContentPlaceHolder1_ControlTrasgressore_txtViaResidenza').val() + ' ' + $('#ContentPlaceHolder1_ControlTrasgressore_txtCivicoResidenza').val());
        })
    });
</script>


    <table style="width:100%; height: 49px;">
        <tr>
            <td>
                <img alt="proprietario" class="auto-style2" src="../images/brown-man-icon.png" style="width:100px;height:100px"/></td>
            <td >
                &nbsp;</td>
            <td style="width:150px">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
<fieldset>
    <legend>Proprietario</legend>
    <table>
        <tr>
            <td colspan="2">
            
                &nbsp;</td>
            <td >&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Nome</td>
            <td >
                <asp:TextBox ID="txtNome" runat="server" Width="300px" />
            </td>
            <td >Cognome</td>
            <td>
                <asp:TextBox ID="txtCognome" runat="server" style="margin-bottom: 0px" Width="354px" />
            </td>
        </tr>
        <tr>
            <td>Data Nascita</td>
            <td >
                <asp:TextBox ID="txtDataNascita" runat="server" cssclass="data" />
            </td>
            <td Width="200px">Città Nascita</td>
            <td>
                <asp:TextBox ID="txtCittaNascita" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Città Residenza</td>
            <td >
                <asp:TextBox ID="txtCittaResidenza" runat="server" Width="241px" />
            </td>
            <td >Indirizzo Residenza</td>
            <td>
                <asp:TextBox ID="txtIndirizzoResidenza" runat="server" Width="300px" />
            </td>
        </tr>

       


        <tr>
            <td colspan="4" style="text-align: center">
            
            <input id="chkCopia" type="button"  value="Copia Dati Del Trasgressore" class="myButton" style="cursor:pointer"/></td>
        </tr>
    </table>
</fieldset>
<p>
    &nbsp;</p>

        
