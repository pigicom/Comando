<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlPatente.ascx.cs" Inherits="Comando.UserControl.ControlPatente" %>


<asp:Panel ID="Panel1" runat="server"  >
      <img alt="patente" class="icon" src="../images/patente.jpg"  />
      
      <br />
&nbsp;<fieldset>
          <legend>Dati Documento</legend>
          <table style="width:100%;  ">
              <tr>
                  <td>Tipo Patente(o documento)</td>
                  <td class="auto-style5"><%--  <asp:RequiredFieldValidator  runat="server" CssClass="error" ID="reqNome" ErrorMessage="Campo Obbligatorio" ControlToValidate="txtNome" Display="Dynamic"></asp:RequiredFieldValidator></td>--%>
                      <asp:DropDownList ID="ddlCategoria" runat="server" Width="240px">
                          <asp:ListItem Text="A1" Value="A1"></asp:ListItem>
                          <asp:ListItem Text="A2" Value="A2"></asp:ListItem>
                          <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                          <asp:ListItem Text="B" Value="B"></asp:ListItem>
                          <asp:ListItem Text="B1" Value="B1"></asp:ListItem>
                          <asp:ListItem Text="BE" Value="BE"></asp:ListItem>
                          <asp:ListItem Text="C" Value="C"></asp:ListItem>
                          <asp:ListItem Text="C1" Value="C1"></asp:ListItem>
                          <asp:ListItem Text="CE" Value="CE"></asp:ListItem>
                          <asp:ListItem Text="C1E" Value="C1E"></asp:ListItem>
                          <asp:ListItem Text="D" Value="D"></asp:ListItem>
                          <asp:ListItem Text="D1" Value="D1"></asp:ListItem>
                          <asp:ListItem Text="DE" Value="DE"></asp:ListItem>
                          <asp:ListItem Text="D1E" Value="D1E"></asp:ListItem>
                          <asp:ListItem Text="KA" Value="KA"></asp:ListItem>
                          <asp:ListItem Text="KB" Value="KB"></asp:ListItem>
                          <asp:ListItem Text="KC" Value="KC"></asp:ListItem>
                          <asp:ListItem Text="PASSAPORTO" Value="PASSAPORTO"></asp:ListItem>
                          <asp:ListItem Text="CARTA IDENTITA" Value="CARTA IDENTITA"></asp:ListItem>
                      </asp:DropDownList>
                      <td>Numero</td>
                      <td>
                          <asp:TextBox ID="txtNumero" runat="server" Width="241px" />
                          <%--  <asp:RequiredFieldValidator CssClass="error" runat="server"   ID="reqCognome" ControlToValidate="txtCognome" Display="Dynamic" ErrorMessage="Campo Obbligatorio"></asp:RequiredFieldValidator>--%></td>
                  </td>
              </tr>
              <tr>
                  <td>Rialsciata da</td>
                  <td class="auto-style5">
                      <asp:TextBox ID="txtRialsciataDa" runat="server" Width="241px" />
                  </td>
                  <td>In Data</td>
                  <td>
                      <asp:TextBox ID="txtDataRilascio" runat="server" CssClass="data" Width="241px" />
                  </td>
              </tr>
          </table>
      </fieldset>
 </asp:Panel>


