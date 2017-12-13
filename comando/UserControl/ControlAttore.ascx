<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlAttore.ascx.cs" Inherits="WebApp.UserControl.ControlAttore" %>

<script>
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "Domicilio.aspx/GetStatiList",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Replace the div's content with the page method's return.
                $(function () {
                    var availableTags = msg.d;
                    $("#<%=txtStatoNascita.ClientID%>").autocomplete({
                        source: availableTags
                    });
                });
            }
        });



        function GetCittaList(IdCitta,IdCap) {
            var testo = $('#' + IdCitta).val();
            $.ajax({
                type: "POST",
                url: "Domicilio.aspx/GetCittaList",
                data: '{"testo":"' + testo + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var target = msg.d;
                    $(function (event,ui) {
                        $('#'+IdCitta).autocomplete({
                            source: JSON.parse(target),
                            select: function (event, ui) {
                                event.preventDefault();
                                $('#' + IdCap).val(ui.item.value);
                                $('#' + IdCitta).val(ui.item.label);
                            }
                        })
                    });
                }
            });
        }


                
        function GetCittaDaCAP(id, cap) {
            $.ajax({
                type: "POST",
                url: "Domicilio.aspx/GetCittaDaCAP",
                data: "{cap:'" + cap +"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $('#' + id).val(JSON.parse(msg.d).citta);
                }
            });
        }



        //da CAP a citta
        $("#<%=txtCittaNascita1.ClientID%>").keyup(function () {
            if ($("#<%=txtCittaNascita1.ClientID%>").val().length > 2)
                GetCittaList($("#<%=txtCittaNascita1.ClientID%>").attr("id"), $("#<%=txtCapNascita.ClientID%>").attr("id"));
        });

        //da cap a citta
        $("#<%=txtCittaResidenza.ClientID%>").keyup(function () {
            if ($("#<%=txtCittaResidenza.ClientID%>").val().length > 2)
                GetCittaList($("#<%=txtCittaResidenza.ClientID%>").attr("id"), $("#<%=txtCAPResidenza.ClientID%>").attr("id"));
        });
        
        //da citta a cap
        $("#<%=txtCapNascita.ClientID%>").keyup(function () {
            if  ($("#<%=txtCapNascita.ClientID%>").val().length>4)
                GetCittaDaCAP($(<%=txtCittaNascita1.ClientID%>).attr("id"),  $("#<%=txtCapNascita.ClientID%>").val());
        });

        //da citta a cap
        $("#<%=txtCAPResidenza.ClientID%>").keyup(function () {
            if  ($("#<%=txtCAPResidenza.ClientID%>").val().length>4)
                GetCittaDaCAP($(<%=txtCittaResidenza.ClientID%>).attr("id"), $("#<%=txtCAPResidenza.ClientID%>").val());
        });

      });
    
  </script>

 
<asp:Panel ID="Panel1" runat="server" >
    &nbsp;<img alt="trasgressore" class="icon" src="../images/uomo.png" />
    <fieldset>
        <legend>
            Dati Del Trasgressore
        </legend>
    
    <table style="width:100%;">
        <tr>
            <td>Nome<asp:HiddenField ID="TrasgressoreId" runat="server" />
            </td>
            <td >
                <asp:TextBox ID="txtNome" runat="server" Width="300px" />
            </td>
            <td>Cognome</td>
            <td>
                <asp:TextBox ID="txtCognome" runat="server" style="margin-bottom: 0px" Width="354px" />
            </td>
        </tr>
        <tr>
            <td>Documento Riconoscimento</td>
            <td>
                <asp:DropDownList ID="txtTipoDocumento" runat="server" Width="300px">
                    <asp:ListItem Text="Patente" Value="Patente" Selected ="true"></asp:ListItem>
                    <asp:ListItem Text="Carta Identità" Value="Carta Identità"></asp:ListItem>
                    <asp:ListItem Text="Passaporto" Value="Passaporto"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>Documento Numero</td>
            <td>
                <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="354px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Data Nascita</td>
            <td >
                <asp:TextBox ID="txtNascita" runat="server" cssclass="data" />
            </td>
            <td>Stato Nascita</td>
            <td>
                <asp:TextBox ID="txtStatoNascita" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Citta Nascita</td>
            <td >
                <asp:TextBox ID="txtCittaNascita1" runat="server" Width="241px" />
            </td>
            <td>Cap Nascita</td>
            <td>
                <asp:TextBox ID="txtCapNascita" runat="server" Width="116px" />
            </td>
        </tr>
        <tr>
            <td>Citta Residenza</td>
            <td >
                <asp:TextBox ID="txtCittaResidenza" runat="server" Width="241px" />
            </td>
            <td>CAP residenza</td>
            <td>
                <asp:TextBox ID="txtCAPResidenza" runat="server" Width="119px" />
            </td>
        </tr>
        <tr>
            <td>Via Residenza</td>
            <td >
                <asp:TextBox ID="txtViaResidenza" runat="server" Width="241px" />
            </td>
            <td>Civico Residenza</td>
            <td>
                <asp:TextBox ID="txtCivicoResidenza" runat="server" Width="161px" />
            </td>
        </tr>
        <tr>
            <td>CF</td>
            <td >
                <asp:TextBox ID="txtCF" runat="server" Width="241px" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </fieldset>
    </asp:Panel>
<br />


