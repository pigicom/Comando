<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlCustode.ascx.cs" Inherits="WebApp.UserControl.ControlCustode" %>


<style type="text/css">
    .auto-style1 {
        width: 178px;
        height: 50px;
    }
    .auto-style2 {
     
    }
</style>


<asp:Panel ID="Panel1" runat="server"  >
      <img alt="carro attrezzi" class="auto-style1" src="../images/carro-attrezzi-con-auto.jpg"  style="width:100px;height:100px" />
      <br />
      &nbsp;<fieldset>
        <legend>
            Dati Custode</legend>
    <table style="width:100%;  "  >
        <tr>
            <td    >Ditta</td> <td class="auto-style5"> 
              <%--  <asp:RequiredFieldValidator  runat="server" CssClass="error" ID="reqNome" ErrorMessage="Campo Obbligatorio" ControlToValidate="txtNome" Display="Dynamic"></asp:RequiredFieldValidator></td>--%>
              <asp:TextBox ID="txtDitta" runat="server" Width="100%" />
            <td  ></td>
            </tr>
        <tr>
            <td >Comune</td>
            <td >
                <asp:TextBox ID="txtComune" runat="server" Width="100%" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >Indirizzo</td>
            <td >
                <asp:TextBox ID="txtIndirizzo" runat="server"  Width="100%" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </fieldset>
 </asp:Panel>


