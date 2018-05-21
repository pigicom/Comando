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
                          <asp:ListItem Text="PATENTE A1"  Value="PATENTE A1"></asp:ListItem>
                          <asp:ListItem Text="PATENTE A2"  Value="PATENTE A2"></asp:ListItem>
                          <asp:ListItem Text="PATENTE AM"  Value="PATENTE AM"></asp:ListItem>
                          <asp:ListItem Text="PATENTE B"   Value="PATENTE B"></asp:ListItem>
                          <asp:ListItem Text="PATENTE B1"  Value="PATENTE B1"></asp:ListItem>
                          <asp:ListItem Text="PATENTE BE"  Value="PATENTE BE"></asp:ListItem>
                          <asp:ListItem Text="PATENTE C"   Value="PATENTE C"></asp:ListItem>
                          <asp:ListItem Text="PATENTE C1"  Value="PATENTE C1"></asp:ListItem>
                          <asp:ListItem Text="PATENTE CE"  Value="PATENTE CE"></asp:ListItem>
                          <asp:ListItem Text="PATENTE C1E" Value="PATENTE C1E"></asp:ListItem>
                          <asp:ListItem Text="PATENTE D"   Value="PATENTE D"></asp:ListItem>
                          <asp:ListItem Text="PATENTE D1"  Value="PATENTE D1"></asp:ListItem>
                          <asp:ListItem Text="PATENTE DE"  Value="PATENTE DE"></asp:ListItem>
                          <asp:ListItem Text="PATENTE D1E" Value="PATENTE D1E"></asp:ListItem>
                          <asp:ListItem Text="PATENTE KA"  Value="PATENTE KA"></asp:ListItem>
                          <asp:ListItem Text="PATENTE KB"  Value="PATENTE KB"></asp:ListItem>
                          <asp:ListItem Text="PATENTE KC"  Value="PATENTE KC"></asp:ListItem>
                          <asp:ListItem Text="PASSAPORTO"  Value="  PASSAPORTO"></asp:ListItem>
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


