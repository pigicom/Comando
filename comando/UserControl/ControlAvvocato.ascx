<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAvvocato.ascx.cs" Inherits="Comando.UserControl.ControlAvvocato" %>


<asp:Panel ID="Panel1" runat="server"  >
      <img alt="avvocato" class="icon" src="../images/avvocato.jpg" />
      
    <fieldset>
        <legend>
            Dati Avvocato Difensore</legend>
    <table style="width:100%;  "  >
        <tr>
            <td  >Nome*</td> <td class="auto-style5"><asp:TextBox ID="txtNome" runat ="server" Width="241px" /> 
              <%--  <asp:RequiredFieldValidator  runat="server" CssClass="error" ID="reqNome" ErrorMessage="Campo Obbligatorio" ControlToValidate="txtNome" Display="Dynamic"></asp:RequiredFieldValidator></td>--%>
            <td  >Cognome*</td>
            <td>
                <asp:TextBox ID="txtCognome" runat="server" Width="241px" />
              <%--  <asp:RequiredFieldValidator CssClass="error" runat="server"   ID="reqCognome" ControlToValidate="txtCognome" Display="Dynamic" ErrorMessage="Campo Obbligatorio"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>Città Studio</td>
            <td class="auto-style5">
             <asp:TextBox ID="txtCittaStudio" runat="server" Width="360px" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Indirizzo Studio</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtIndirizzoStudio" runat="server" Width="460px" />
            </td>
            <td>Telefono Studio</td>
            <td>
                <asp:TextBox ID="txtTelefonoStudio" runat="server" Width="241px" />
            </td>
        </tr>
        <tr>
            <td  >Fax Studio</td> <td class="auto-style5"><asp:TextBox ID="txtFaxStudio" runat ="server" /></td>
            <td  >Cellulare</td>
            <td>
                <asp:TextBox ID="txtCellulare" runat="server" Width="241px" />
            </td>
        </tr>
        <tr>
            <td  >Email</td> <td ><asp:TextBox ID="txtEmail" runat ="server" Width="467px" />
            </td>
            <td  >Foro</td>
            <td>
                <asp:TextBox ID="txtForo" runat="server" Width="241px" />
            </td>
        </tr>
        <tr>
            <td>Assegnato D&#39;ufficio</td>
            <td>
                <asp:DropDownList ID="ddlAssegnato" runat="server">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="AvvocatoId" runat="server" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </fieldset>
 </asp:Panel>

<p>
    &nbsp;</p>


