<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlVeicolo.ascx.cs" Inherits="Comando.UserControl.ControlVeicolo" %>


<asp:Panel ID="Panel1" runat="server"  >
    <img alt="Veicolo" class="icon" src="../images/veicolo.png"  />
      &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ComandoConnectionString %>" SelectCommand="SELECT [Id], [Descrizione] FROM [TipoVeicolo]"></asp:SqlDataSource>
    <fieldset>
        <legend>Dati Veicolo</legend>
        <table style="width:100%;  ">
            <tr>
                <td>Tipo Veicolo</td>
                <td class="auto-style5"><%-- <asp:TextBox ID="txtNome" runat="server" Width="241px" />--%><%--  <asp:RequiredFieldValidator  runat="server" CssClass="error" ID="reqNome" ErrorMessage="Campo Obbligatorio" ControlToValidate="txtNome" Display="Dynamic"></asp:RequiredFieldValidator></td>--%>
                    <asp:DropDownList ID="ddlTipoVeicolo" runat="server" DataSourceID="SqlDataSource1" DataTextField="Descrizione" DataValueField="Id" Width="251px">
                    </asp:DropDownList>
                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ComandoConnectionString %>" SelectCommand="SELECT [Id], [Descrizione] FROM [TipoVeicolo]"></asp:SqlDataSource>--%>
                    <td>Marca</td>
                    <td><%--  <asp:TextBox ID="txtMarca" runat="server" Width="241px" />--%><%--  <asp:RequiredFieldValidator CssClass="error" runat="server"   ID="reqCognome" ControlToValidate="txtCognome" Display="Dynamic" ErrorMessage="Campo Obbligatorio"></asp:RequiredFieldValidator>--%>
                        <asp:TextBox list="browsers" ID="txtMarca" runat="server" Width="241px" />
                        <datalist id="browsers">
                            <option>Abarth</option>
                            <option>Acura</option>
                            <option>Alfa Romeo</option>
                            <option>Anhui Jianghuai	</option>
                            <option>Audi</option>
                            <option>Beijing</option>
                            <option>Bentley</option>
                            <option>BMW</option>
                            <option>Brilliance</option>
                            <option>Bugatti</option>
                            <option>Buick</option>
                            <option>BYD</option>
                            <option>Cadillac</option>
                            <option>Chang'an</option>
                            <option>Changhe</option>
                            <option>Chery</option>
                            <option>Chevrolet</option>
                            <option>Chongqing Lifan</option>
                            <option>Chrysler</option>
                            <option>Citroën</option>
                            <option>Dacia</option>
                            <option>Daewoo</option>
                            <option>Daihatsu</option>
                            <option>Dodge</option>
                            <option>Dongfeng</option>
                            <option>FAW	</option>
                            <option>Ferrari</option>
                            <option>FIAT</option>
                            <option>Ford</option>
                            <option>Geely</option>
                            <option>Great Wall Motors</option>
                            <option>Harbin Hafei</option>
                            <option>Holden</option>
                            <option>Honda</option>
                            <option>Hyundai</option>
                            <option>Infiniti</option>
                            <option>Jaguar</option>
                            <option>Jeep</option>
                            <option>Kia</option>
                            <option>Land Rover</option>
                            <option>Lada</option>
                            <option>Lamborghini</option>
                            <option>Lancia</option>
                            <option>Lexus</option>
                            <option>Lincoln</option>
                            <option>Lotus</option>
                            <option>LUAZ</option>
                            <option>Lykan</option>
                            <option>Mahindra</option>
                            <option>Maruti</option>
                            <option>Maserati</option>
                            <option>Mazda</option>
                            <option>Mercedes-Benz</option>
                            <option>Mitsubishi</option>
                            <option>Mini</option>
                            <option>Nissan</option>
                            <option>Opel</option>
                            <option>Peugeot</option>
                            <option>Porsche</option>
                            <option>Proton</option>
                            <option>Renault</option>
                            <option>Rolls-Royce</option>
                            <option>Saab</option>
                            <option>SAIC</option>
                            <option>Samsung</option>
                            <option>Smart</option>
                            <option>SsangYong</option>
                            <option>Subaru</option>
                            <option>SEAT</option>
                            <option>Škoda Auto</option>
                            <option>Suzuki</option>
                            <option>Tata</option>
                            <option>Toyota</option>
                            <option>UAZ</option>
                            <option>Vauxhall</option>
                            <option>Volkswagen</option>
                            <option>Volvo</option>

                        </datalist>
                    </td>
                </td>
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


