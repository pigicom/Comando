<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Domicilio.aspx.cs" Inherits="comando.NewPages.Domicilio" %>

<%@ Register Src="~/UserControl/ControlTrasgressore.ascx" TagPrefix="uc1" TagName="ControlTrasgressore" %>
<%@ Register Src="~/UserControl/ControlAvvocato.ascx" TagPrefix="uc1" TagName="ControlAvvocato" %>
<%@ Register Src="~/UserControl/ControlAgente.ascx" TagPrefix="uc1" TagName="ControlAgente" %>
<%@ Register Src="~/UserControl/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>
            $(document).ready(function () {
                $("#Page").accordion();
            });

            function ValidateForm() {
                if (!Page_IsValid) {
                    alert('Per creare il documento prima correggere gli errori');
                }
            }
        </script>
           <asp:HiddenField ID="idverbale" runat="server" />
           <div id="Page" class="section pagina" style ="margin-left:145px;width :960px;align-content :center;margin-top:10px">
        
            <h3>Agente Verbalizzante</h3>
            <div id ="divAgente" class="panel" >
                <uc1:ControlAgente runat="server" id="ControlAgente" />
            </div>
            <h3>Trasgressore</h3>
            <div id ="divTrasgressore" class="panel" >
                <uc1:ControlTrasgressore runat="server" id="ControlTrasgressore" />
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
   
      

 
