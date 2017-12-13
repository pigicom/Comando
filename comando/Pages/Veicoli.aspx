<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Veicoli.aspx.cs" Inherits="WebApp.Veicoli" %>

<%@ Register Src="~/UserControl/ControlAgente.ascx" TagPrefix="uc1" TagName="ControlAgente" %>
<%@ Register Src="~/UserControl/ControlProprietario.ascx" TagPrefix="uc1" TagName="ControlProprietario" %>
<%@ Register Src="~/UserControl/ControlPatente.ascx" TagPrefix="uc1" TagName="ControlPatente" %>
<%@ Register Src="~/UserControl/ControlVeicolo.ascx" TagPrefix="uc1" TagName="ControlVeicolo" %>
<%@ Register Src="~/UserControl/ControlCustode.ascx" TagPrefix="uc1" TagName="ControlCustode" %>
<%@ Register Src="~/UserControl/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script>
       $(document).ready( function (){
           $("#Page").accordion();
           $('#chkCopia').hide();
           $('#ContentPlaceHolder1_ControlAgente_txtVerbaleIndirizzo').val('COMANDO DI POLIZIA LOCALE');
           $($('#divProprietario td')[7]).html('Nome*');
           $($('#divProprietario td')[9]).html('Cognome*')
           $($('#divProprietario td')[11]).html('Data Nascita*')
       });
      
     </script>
       <div id="Page" class="section pagina" style ="margin-left:145px;width :960px;align-content :center;margin-top:10px">
        
       
        <h3>Verbale</h3>
        <div id="divAgente" class="panel">
            <uc1:ControlAgente runat ="server" id="ControlAgente"  style="height:350px;"/>
        </div> 

        <h3>Veicolo</h3>
        <div id="divDocumento" class="shortpanel">
            <uc1:ControlVeicolo runat ="server" id="ControlVeicolo"  style="height:350px;"/>
        </div> 
       
        <h3>Proprietario</h3>
        <div id="divProprietario" class="panel">
            <uc1:ControlProprietario runat ="server" id="ControlProprietario"  style="height:350px;"/>
        </div>
        
        <h3>Patente o altro documento di riconoscimento</h3>
        <div id="divPatente" class="shortpanel">
            <uc1:ControlPatente runat ="server" id="ControlPatente"  style="height:350px;"/>
        </div>

        <h3>Custode</h3>
        <div id="divCustode" class="shortpanel">
        <uc1:ControlCustode runat ="server" id="ControlCustode"  style="height:350px;"/>
        </div>

        </div>
         <div id="buttons" class="buttons">
          <uc1:Menu runat="server" id="Menu" />
        </div>
</asp:Content>
