<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Polizia.aspx.cs" Inherits="Comando.Polizia" %>

<%@ Register Src="~/UserControl/ControlTrasgressore.ascx" TagPrefix="uc1" TagName="ControlTrasgressore" %>
<%@ Register Src="~/UserControl/ControlAvvocato.ascx" TagPrefix="uc1" TagName="ControlAvvocato" %>
<%@ Register Src="~/UserControl/ControlAgente.ascx" TagPrefix="uc1" TagName="ControlAgente" %>
<%@ Register Src="~/UserControl/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/UserControl/ControlPatente.ascx" TagPrefix="uc1" TagName="ControlPatente" %>
<%@ Register Src="~/UserControl/ControlVeicolo.ascx" TagPrefix="uc1" TagName="ControlVeicolo" %>
<%@ Register Src="~/UserControl/ControlProprietario.ascx" TagPrefix="uc1" TagName="ControlProprietario" %>
<%@ Register Src="~/UserControl/ControlAttore.ascx" TagPrefix="uc1" TagName="ControlAttore" %>

  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
     $(document).ready(function () {
         $("#Page").accordion();
         $('#ContentPlaceHolder1_ControlAgente_txtVerbaleIndirizzo').val('COMANDO DI POLIZIA LOCALE');
         $('#ContentPlaceHolder1_ControlAgente_txtCittaViolazione').val('BRUGHERIO');

         $('#ContentPlaceHolder1_ControlTrasgressore_txtTipoDocumento').on('change', function ()
         { 
             if ($('#ContentPlaceHolder1_ControlTrasgressore_txtTipoDocumento').val() == 'Patente')
                 $('#ui-id-3').show();
             else
                 $('#ui-id-3').hide();
             }
         );



     });
 </script>
 
       <div id="Page" class="section pagina" style ="margin-left:5px;width :960px;margin-top:10px">
        
        <h3>Dati Verbale</h3>
        <div id ="divAgente" class="panel" >
            <uc1:ControlAgente runat="server" id="ControlAgente" />
        </div>
        
        <h3>Trasgressore</h3>
        <div id="divTrasgressore" class="panel">
            <uc1:ControlTrasgressore runat ="server" id="ControlTrasgressore"  style="height:350px;"/>
        </div>

        <h3>Patente o altro documento di riconoscimento</h3>
        <div id="divDocumento" class="shortpanel">
            <uc1:ControlPatente runat ="server" id="ControlPatente"  style="height:350px;"/>
        </div> 
       
        <h3>Avvocato</h3>
        <div id="divAvvocato" class="panel">
            <uc1:ControlAvvocato runat ="server" id="ControlAvvocato"  style="height:350px;"/>
        </div>

        </div>
         <div id="buttons" class="buttons">
          <uc1:Menu runat="server" id="Menu" />
        </div>
</asp:Content>

