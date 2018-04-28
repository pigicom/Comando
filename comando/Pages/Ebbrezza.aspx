<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ebbrezza.aspx.cs" Inherits="Comando.Ebbrezza" %>
<%@ Register Src="~/UserControl/ControlTrasgressore.ascx" TagPrefix="uc1" TagName="ControlTrasgressore" %>
<%@ Register Src="~/UserControl/ControlAvvocato.ascx" TagPrefix="uc1" TagName="ControlAvvocato" %>
<%@ Register Src="~/UserControl/ControlAgente.ascx" TagPrefix="uc1" TagName="ControlAgente" %>
<%@ Register Src="~/UserControl/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/UserControl/ControlPatente.ascx" TagPrefix="uc1" TagName="ControlPatente" %>
<%@ Register Src="~/UserControl/ControlVeicolo.ascx" TagPrefix="uc1" TagName="ControlVeicolo" %>
<%@ Register Src="~/UserControl/ControlProprietario.ascx" TagPrefix="uc1" TagName="ControlProprietario" %>



 


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
  
    <script>
        $(document).ready( function (){
            $("#Page").accordion();
            $('fieldset').eq(0).find('table tbody tr td').eq(2).hide();
            $('fieldset').eq(0).find('table tbody tr td').eq(3).hide();
            $('fieldset').eq(0).find('table tbody tr td').eq(4).text('Ora Verbale');
            $('fieldset').eq(0).find('table tbody tr').eq(1).hide();
            //$('fieldset').eq(0).find('table tbody tr').eq(2).hide();
            $('fieldset').eq(1).find('table tbody tr td').eq(2).hide(); //tolgo articolo label 
            $('fieldset').eq(1).find('table tbody tr td').eq(3).hide();//tolgo articolo valore
        });

        function ValidateForm() {
            if (!Page_IsValid) {
                alert('Per creare il documento prima correggere gli errori');
            }
        }

     
    
 

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
       
         <h3>Patente</h3>
        <div id ="divPatente" class="shortpanel" >
            <uc1:ControlPatente runat="server" id="ControlPatente" />
        </div>
        
        <h3>Veicolo</h3>
        <div id="divVeicolo" class="panel">
          <uc1:ControlVeicolo runat="server" id="ControlVeicolo1" style="height:350px;"/>
        </div>

        <h3>Proprietario</h3>
        <div id="divProprietario" class="panel">
        <uc1:ControlProprietario runat="server" ID="ControlProprietario" />
        </div>

        </div>
         <div id="buttons" class="buttons">
          <uc1:Menu runat="server" id="Menu" />
        </div>
</asp:Content>
