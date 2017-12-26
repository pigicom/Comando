<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAgente.ascx.cs" Inherits="Comando.UserControl.ControlAgente" %>
<script>
    $(document).ready(function () {

        $("#<%=txtOraApertura.ClientID%>").timeMask();
        $("#<%=txtOraChiusura.ClientID%>").timeMask();
        $("#<%=txtOra.ClientID%>").timeMask();
    });

    function  leaveChange(e)
    {
        <%--if ($("#<%=ddlA1.ClientID%> option[selected='selected']").val()==$("#<%=ddlA2.ClientID%> option[selected='selected']").val())
        {
            if ($("#<%=ddlA1.ClientID%> option[selected='selected']").text().trim()!="")
            Messaggio('Agente segnalato più di una volta!');
        }--%>
               
    }
    
    </script>
        <asp:Panel ID="Panel1" Height="284px" runat="server"  >
      &nbsp;<img alt="agente" class="icon" src="../images/vigile.jpg" /><asp:HiddenField ID="VerbaleDomicilioId" runat="server" />
      &nbsp;<fieldset>
         <legend>Verbale</legend>
       <table style="width:100%;">
         <tr>
             <td>
                 Data*</td><td >
                 <asp:TextBox ID="txtDataVerbale"  runat="server" cssclass="data"  width="80px"/>
             </td>

             <td>Data Apertura</td>
             <td>
                 <asp:TextBox ID="txtDataApertura" runat="server" cssclass="data" />
             </td>
             <td class="auto-style3">Ora Apertura HH:mm</td>
             <td>
                 <asp:TextBox ID="txtOraApertura"  onblur="AggiungiMinuti(this)" runat="server" Width="100px"></asp:TextBox>
             </td>
             
         </tr>
           <tr>
               <td colspan="2">&nbsp;</td>
               <td>Data Chiusura</td>
               <td>
                   <asp:TextBox ID="txtDataChiusura" runat="server"  cssclass="data" />
               </td>
               <td class="auto-style3">Ora Chiusura HH:mm</td>
               <td>
                   <asp:TextBox ID="txtOraChiusura" Width="100px" runat="server" onblur="AggiungiMinuti(this)"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td colspan="2" style="text-align: right">&nbsp;&nbsp;&nbsp;&nbsp; </td>
               <td>
                   Indirizzo</td>
               <td colspan="2">
                   <asp:TextBox ID="txtVerbaleIndirizzo" runat="server" Width="100%" />
               </td>
               <td>&nbsp;</td>
           </tr>
       </table>
       </fieldset>
    <br />
  
    <fieldset>
         <legend>Violazione</legend>
            <table style="width:100%;">
              <tr>
               <td >Data*&nbsp;</td>
               <td   >
                   <asp:TextBox ID="txtViolazioneData" runat="server" cssclass="data" Width="80px" />
                   &nbsp;
               </td>
                  <td >Ora </td>
                  <td >
                      <asp:TextBox ID="txtOra" runat="server"  onblur="AggiungiMinuti(this)" Width="60px" />
                  </td>
               <td >Articolo&nbsp;</td>
                    <td> <asp:TextBox ID="txtArticolo" runat="server" Width="60px" /></td>
                  <td>&nbsp;Città&nbsp;</td>
                  <td >
                      <asp:TextBox ID="txtCittaViolazione"  Text="Brugherio" runat="server" Width="110px"></asp:TextBox>
                  </td>
                  <td>&nbsp;Indirizzo&nbsp;</td>
                  <td>
                      <asp:TextBox ID="txtIndirizzoViolazione" runat="server" Width="225px" />
                      <asp:HiddenField ID="ViolazioneId" runat="server" />
                  </td>
           </tr>
           </table>
        </fieldset>

      <br /> 
       <fieldset>
          <legend>Agenti Verbalizzanti</legend>
          <table style="width:100%;"> 
              <tr>
                  <td>Agente 1</td>
                  <td>
                      <asp:HiddenField ID="Agente1ID" runat="server" />
                  </td>
                  <td>
                      <asp:DropDownList ID="ddlA1" runat="server" on="" onchange="leaveChange(this)" Width="100%">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td>Agente 2</td>
                  <td>
                      <asp:HiddenField ID="Agente2ID" runat="server" />
                  </td>
                  <td>
                      <asp:DropDownList ID="ddlA2" runat="server" onchange="leaveChange(this)" Width="100%">
                      </asp:DropDownList>
                    </td>
              </tr>
              
          </table>
      </fieldset>
 </asp:Panel>

<script>
   function   AggiungiMinuti(e){
       if ((e.value.indexOf(':') > 0) && (e.value.length<4)) {
           $(e).val($(e).val() + '00');
       }
       if ((e.value.length < 3)) {
           $(e).val($(e).val() + ':00');
       }
    }
</script>