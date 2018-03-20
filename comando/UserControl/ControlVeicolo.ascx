<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlVeicolo.ascx.cs" Inherits="Comando.UserControl.ControlVeicolo" %>


<asp:Panel ID="Panel1" runat="server"  >
    <img alt="Veicolo" class="icon" src="../images/veicolo.png"  />
      &nbsp;<fieldset>
          <legend>
              
              Dati Veicolo</legend>
          <table style="width:100%;  ">
              <tr>
                     <td>Tipo Veicolo</td>
                     <td class="auto-style5">
                     <%-- <asp:TextBox ID="txtNome" runat="server" Width="241px" />--%>
                      <%--  <asp:RequiredFieldValidator  runat="server" CssClass="error" ID="reqNome" ErrorMessage="Campo Obbligatorio" ControlToValidate="txtNome" Display="Dynamic"></asp:RequiredFieldValidator></td>--%>
                          <asp:DropDownList ID="ddlTipoVeicolo" runat="server" DataSourceID="SqlDataSource1" DataTextField="Descrizione" DataValueField="Id" Width="251px">
                          </asp:DropDownList>
                          <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ComandoConnectionString %>" SelectCommand="SELECT [Id], [Descrizione] FROM [TipoVeicolo]"></asp:SqlDataSource>--%>
                      <td>Marca</td>
                      <td>
                        <%--  <asp:TextBox ID="txtMarca" runat="server" Width="241px" />--%>
                          <%--  <asp:RequiredFieldValidator CssClass="error" runat="server"   ID="reqCognome" ControlToValidate="txtCognome" Display="Dynamic" ErrorMessage="Campo Obbligatorio"></asp:RequiredFieldValidator>--%>
                          <asp:TextBox ID="txtMarca" runat="server" Width="241px" />
                          </td>
                  </td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td class="auto-style5">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ComandoConnectionString %>" SelectCommand="SELECT [Id], [Descrizione] FROM [TipoVeicolo]"></asp:SqlDataSource>
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>Modello</td>
                  <td class="auto-style5">
                      <asp:TextBox ID="txtModello" runat="server" Width="241px" />
                  </td>
                  <td>Targa</td>
                  <td>
                      <asp:TextBox ID="txtTarga" runat="server" Width="241px" />
                  </td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td class="auto-style5">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>Telaio</td>
                  <td class="auto-style5">
                      <asp:TextBox ID="txtTelaio" runat="server" />
                  </td>
                  <td>Colore</td>
                  <td>
                      <asp:TextBox ID="txtColore" runat="server" Width="241px" />
                  </td>
              </tr>
          </table>
      </fieldset>
 </asp:Panel>


