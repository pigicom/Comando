<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlTrasgressore.ascx.cs" Inherits="WebApp.UserControl.ControlTrasgressore" %>
<link href="../Styles/ui.jqgrid.css" rel="stylesheet" />
<script src="../Scripts/i18n/grid.locale-it.js"></script>
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
        
        function GetCittaList(IdCitta, IdCap) {
            var testo = $('#' + IdCitta).val();
            $.ajax({
                type: "POST",
                url: "Domicilio.aspx/GetCittaList",
                data: '{"testo":"' + testo + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var target = msg.d;
                    $(function (event, ui) {
                        $('#' + IdCitta).autocomplete({
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
                data: "{cap:'" + cap + "'}",
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
            if ($("#<%=txtCapNascita.ClientID%>").val().length > 4)
                GetCittaDaCAP($(<%=txtCittaNascita1.ClientID%>).attr("id"), $("#<%=txtCapNascita.ClientID%>").val());
        });

        //da citta a cap
        $("#<%=txtCAPResidenza.ClientID%>").keyup(function () {
            if ($("#<%=txtCAPResidenza.ClientID%>").val().length > 4)
                GetCittaDaCAP($(<%=txtCittaResidenza.ClientID%>).attr("id"), $("#<%=txtCAPResidenza.ClientID%>").val());
        });

    });

</script>

<asp:Panel ID="Panel1" runat="server">
    &nbsp;<img alt="trasgressore" class="icon" src="../images/uomo.png" /><asp:TextBox ID="txtCF" runat="server" Visible="False" Width="241px" />
&nbsp;<fieldset>
        <legend>Dati Del Trasgressore
        </legend>
        <table style="width: 100%;">
            <tr>
                <td>Nome*<asp:HiddenField ID="TrasgressoreId" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server" Width="250px" />
                </td>
                <td>Cognome*</td>
                <td>
                    <asp:TextBox ID="txtCognome" runat="server" Style="margin-bottom: 0px" Width="354px" />
                </td>
            </tr>
            <tr>
                <%--<td>Documento Riconoscimento</td>
                <td>
                    <asp:DropDownList ID="txtTipoDocumento" runat="server" Width="250px">
                        <asp:ListItem Text="Patente" Value="Patente" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Carta Identità" Value="Carta Identità"></asp:ListItem>
                        <asp:ListItem Text="Passaporto" Value="Passaporto"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Documento Numero</td>
                <td>
                    <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="250px"></asp:TextBox>
                </td>--%>
            </tr>
            <tr>
                <td>Data Nascita</td>
                <td>
                    <asp:TextBox ID="txtNascita" runat="server" CssClass="data" />
                </td>
                <td>Nazionalita</td>
                <td>
                    <asp:TextBox ID="txtStatoNascita" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Citta Nascita</td>
                <td>
                    <asp:TextBox ID="txtCittaNascita1" runat="server" Width="241px" />
                </td>
                <td>Sesso</td>
                <td>
                    <asp:DropDownList ID="ddlSesso" runat="server">
                        <asp:ListItem Selected="true" Text="M" Value="M"></asp:ListItem>
                        <asp:ListItem   Text              ="F" Value="F"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Citta Residenza</td>
                <td>
                    <asp:TextBox ID="txtCittaResidenza" runat="server" Width="241px" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtCAPResidenza" runat="server" Width="119px" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>Via Residenza</td>
                <td>
                    <asp:TextBox ID="txtViaResidenza" runat="server" Width="241px" />
                </td>
                <td>Civico</td>
                <td>
                    <asp:TextBox ID="txtCivicoResidenza" runat="server" Width="161px" />
                </td>
            </tr>
            <tr>
                <td>Citta Domicilio</td>
                <td>
                    <asp:TextBox ID="txtCittaDomicilio" runat="server" Width="241px" />
                </td>
                <td>Indirizzo Domicilio</td>
                <td>
                    <asp:TextBox ID="txtViaDomicilio" runat="server" Width="241px" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <input type="button"   value="Leggi Da Archivio" onclick="CaricaTrasgressori()" class="myButton" style="cursor:pointer" />
                    <asp:TextBox ID="txtCapNascita" runat="server" Visible="False" Width="116px" />  
                </td>
            </tr>
        </table>
    </fieldset>
   
</asp:Panel>
<br />
 <div id="divArchivio" style="width: 771px; min-height: 20px; max-height: none; height: 425px;display:none" class="quickmenu">
            <table id="jqGrid"></table>
            <div id="jqGridPager"></div>
 </div>

 <script type="text/javascript">
          function CaricaTrasgressori() {
              $('#divArchivio').dialog({ title: 'Trasgressori', width: 800 }).prev(".ui-dialog-titlebar").css("background", "#3498db");;
                $.ajax({
                  type: "POST",
                  url: "Services.aspx/GetTrasgressore",
                  data: "{}",
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (source) {
                            $("#jqGrid").jqGrid({
                              data: JSON.parse(source.d),
                              datatype: "local",
                              regional:'it',
                              contentType: "application/json; charset=utf-8",
                              colNames: ['Id', 'Nome', 'Cognome', 'Data Nascita', 'Citta Nascita'],
                              colModel: [
                                          { label: 'id', name: 'Id', key: true, width: 75, hidden:true },
                                          { label: 'Nome', name: 'Nome', width: 150 },
                                          { label: 'Cognome', name: 'Cognome', width: 150 },
                                          { label: 'DataNascita', name: 'DataNascita', width: 150,formatter: 'date' },
                                          { label: 'CittaNascita', name: 'CittaNascita', width: 150 }
                              ],
                              width: 780,
                              height: 350,
                              pager: "#jqGridPager",
                              ondblClickRow: function (rowId) {
                                  var rowData = jQuery(this).getRowData(rowId);
                                  var Id = rowData['Id'];
                                  var Nome = rowData['Nome'];
                                  var Cognome = rowData['Cognome'];
                                  var DataNascita =new Date(rowData['DataNascita']);
                                  var CittaNascita = rowData['CittaNascita']
                                  $("#<%=txtNome.ClientID%>").val(Nome);
                                  $("#<%=txtCognome.ClientID%>").val(Cognome);
                                  $("#<%=txtNascita.ClientID%>").val(moment(DataNascita).format('DD/MM/YYYY'));
                                  $("#<%=txtCittaNascita1.ClientID%>").val(CittaNascita);
                              },
                                'loadComplete': function (data) {
                                    $(this).jqGrid('setGridParam', 'rowNum', data.total);
                                },
                            });
                      $('#jqGrid').jqGrid('filterToolbar', { stringResult: true, searchOnEnter: true, defaultSearch: "cn" });
                  },
                  error: function (xhr, error) {
                      console.debug(xhr); console.debug(error);
                  },
                });
          }
    </script>
   



