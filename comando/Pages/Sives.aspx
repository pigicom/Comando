<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sives.aspx.cs" Inherits="WebApp.Sives" %>

<%@ Register Src="~/UserControl/ControlTrasgressore.ascx" TagPrefix="uc1" TagName="ControlTrasgressore" %>
<%@ Register Src="~/UserControl/ControlAvvocato.ascx"     TagPrefix="uc1" TagName="ControlAvvocato" %>
<%@ Register Src="~/UserControl/ControlAgente.ascx"       TagPrefix="uc1" TagName="ControlAgente" %>
<%@ Register Src="~/UserControl/Menu.ascx"                TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/UserControl/ControlPatente.ascx"      TagPrefix="uc1" TagName="ControlPatente" %>
<%@ Register Src="~/UserControl/ControlVeicolo.ascx"      TagPrefix="uc1" TagName="ControlVeicolo" %>
<%@ Register Src="~/UserControl/ControlProprietario.ascx" TagPrefix="uc1" TagName="ControlProprietario" %>
<%@ Register Src="~/UserControl/ControlAttore.ascx"       TagPrefix="uc1" TagName="ControlAttore" %>
<%@ Register Src="~/UserControl/ControlCustode.ascx"      TagPrefix="uc1" TagName="ControlCUstode" %>
  
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

         if ( <%=sotto%>==2 ||  <%=sotto%>==4)
             $('h3').last().remove();
     });
 </script>
 
       <div id="Page" class="section pagina" style ="margin-left:145px;width :960px;align-content :center;">
            <h3>Dati Verbale</h3>
            <div id ="divAgente" class="panel" >
                <uc1:ControlAgente runat="server" id="ControlAgente" />
            </div>
        
            <h3>Trasgressore</h3>
            <div id="divTrasgressore" class="panel">
                <uc1:ControlTrasgressore runat ="server" id="ControlTrasgressore"  style="height:350px;"/>
            </div>

            <h3>Documento Di Riconoscimento Trasgressore</h3>
            <div id="divPatente" class="shortpanel">
                <uc1:ControlPatente runat ="server" id="ControlPatente"  style="height:250px;"/>
            </div>

            <h3>Veicolo</h3>
            <div id="divVeicolo" class="panel">
                <uc1:ControlVeicolo runat ="server" id="ControlVeicolo"  style="height:350px;"/>
            </div> 
       
            <h3>Proprietario</h3>
            <div id="divProprietario" class="panel">
                <uc1:ControlProprietario runat ="server" id="ControlProprietario"  style="height:350px;"/>
            </div>

            <h3>Documento Di Riconoscimento Proprietario</h3>
            <div id="divPatenteProprietario" class="shortpanel">
                <uc1:ControlPatente runat ="server" id="ControlPatenteProprietario"  style="height:250px;"/>
            </div>

            <h3>Custode</h3>
            <div id="divCustode" class="shortpanel">
                <uc1:ControlCustode runat ="server" id="ControlCustode1"  style="height:250px;" />
            </div>
         </div>
            <div id="buttons" >
              <uc1:Menu runat="server" id="Menu" />
            </div>
   
</asp:Content>


