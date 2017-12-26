<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anagrafiche.aspx.cs" Inherits="Comando.Pages.Anagrafiche" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Gestione Anagrafiche</title>
<link href="../Content/Site.css" rel="stylesheet" />
<script src="../Scripts/jquery.js"></script>
<script src="../Scripts/jquery-ui.js"></script>
<script src="../Scripts/jquery.jqGrid.min.js"></script>
<link href="../Styles/jquery-ui.css" rel="stylesheet" />
<link href="../Content/jquery.jqGrid/ui.jqgrid.css" rel="stylesheet" />
<script src="../Scripts/i18n/grid.locale-it.js"></script>
<link href="~/menu/styles.css" rel="stylesheet" />
    <link href="../Content/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <style>
        .voce {
            /*  background-color: black; */ /*#3498db;*/
            font-family: Calibri;
            font-size: 16px;
            z-index: 99999999;
            width: 200px;
            height: 40px;
            font-weight: bold;
            text-decoration: none;
            text-align: center;
        }

            .voce:hover {
                background-color: black; /*#3498db;;*/
            }
            .ui-jqgrid tr.ui-row-ltr td {text-align:left;border-right-width: 1px; border-right-color: inherit; border-right-style: solid;}
    </style>
</head>

<body style="background-image: url('/Comando/images/polizialocale_bn2.png');padding-top:8px" >
    <table style="width:100%; align-items:center; margin-left: 0px ; background-color:#3498db; border:2px solid #e1e1e1"">
            <tr>
                <td style="vertical-align: top">
                    <div class="voce"><a href="/Comando/Pages/Domicilio.aspx?cat=1" style="text-decoration: none; color: white;">Elezione Domicilio Stranieri</a></div>
                </td>
                <td style="vertical-align: top">
                    <div class="voce"><a href="/Comando/Pages/Ebbrezza.aspx?cat=2" style="text-decoration: none; color: white;">Guida In Stato Di Ebbrezza</a></div>
                </td>
                <td style="vertical-align: top">
                    <div class="voce"><a href="/Comando/Pages/Polizia.aspx?cat=3" style="text-decoration: none; color: white;">Polizia Giudiziaria</a></div>
                </td>
                <td style="vertical-align: top">
                    <div class="voce" id="Sives"><a style="text-decoration: none; color: white;" href="#" id="link">Sives >></a></div>
                    <div style="display: none; position: absolute; z-index: 9999999; background-color: #3498db; color: white;" id="sottomenu">
                        <table>
                            <tr>
                                <td>
                                    <div class="voce" type="sottovoce"><a style="text-decoration: none; color: white;" href="/Comando/Pages/Sives.aspx?cat=4&sotto=1">Fermo Custode</a></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="voce" type="sottovoce"><a style="text-decoration: none; color: white;" href="/Comando/Pages/Sives.aspx?cat=4&sotto=2">Fermo Proprietario</a></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="voce" type="sottovoce"><a style="text-decoration: none; color: white;" href="/Comando/Pages/Sives.aspx?cat=4&sotto=3">Sequestro Custode</a></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="voce" type="sottovoce"><a style="text-decoration: none; color: white;" href="/Comando/Pages/Sives.aspx?cat=4&sotto=4">Sequestro Proprietario</a></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="vertical-align: top">
                    <div class="voce"><a style="text-decoration: none; color: white;" href="/Comando/Pages/Stranieri.aspx?cat=5">Stranieri</a></div>
                </td>
                <td style="vertical-align: top">
                    <div class="voce"><a style="text-decoration: none; color: white;" href="/Comando/Pages/Veicoli.aspx?cat=6">Veicoli Provenienza Furtiva</a></div>
                </td>
                <td style="text-align: right">
                    
                </td>
            </tr>
        </table>
 
    <form id="form1" runat="server">
    <div>
        
        <h3 style="margin-left:10px" >Anagrafiche Agenti</h3>
    <table style="width:100%;">
        <tr>
            <td style="width:33%"> </td>
            <td style="text-align:center">
                  <table id="jqGridAgenti"></table>
                  <div id="jqGridPagerAgenti"></div>
            </td>
           <td style="width:33%"> </td>
        </tr>
    </table>
   
   

    </div>
    </form>
</body>
</html>

 
<script>
   
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            async: true,
            url: "Services.aspx/GetAgenti",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (source) {
                $("#jqGridAgenti").jqGrid({
                    data: JSON.parse(source.d),
                    datatype: "local",
                    contentType: "application/json; charset=utf-8",
                    colNames: ['Id', 'Nome', 'Congnome', 'Grado'],
                    colModel: [
                                { label: 'id', name: 'Id', key: true, width: 75, hidden: true },
                                { label: 'Nome', name: 'Nome', editable: true, edittype: 'text', width: 60 },
                                { label: 'Cognome', name: 'Cognome', editable: true, edittype: 'text', width: 120 },
                                { label: 'Grado', name: 'Grado', editable: true, edittype: 'text', width: 80 },
                    ],
                    width: 780,
                    height: 350,
                    pager: "#jqGridPagerAgenti",
                    ondblClickRow: function (rowid) {
                        $('#edit_jqGridAgenti').click();
                    },
                    loadonce: true,
                    beforeShowForm: function (formID) {
                        alert()
                    },
                });


                $('#jqGridAgenti').navGrid('#jqGridPagerAgenti',
                // the buttons to appear on the toolbar of the grid
                {
                    edit: true,  
                    addtext: 'Inserisci',
                    edittext: 'Modifica',
                    deltext: 'Cancella',
                    add: true, 
                    del: true,  
                    search: false,
                    refresh: false,
                    view: false,
                    position: "left",
                    cloneToTop: false,
                }, {
                    url: window.location.origin + "/Comando/agenti.asmx/PutAgente",
                    reloadAfterSubmit: true, checkOnSubmit: true,checkOnUpdate: true, closeOnEscape: true ,
                    beforeShowForm: function (formID) {
                        var selectedRowId = $('#jqGridAgenti').jqGrid('getGridParam', 'selrow'),
                        cellValue = $('#jqGridAgenti').jqGrid('getCell', selectedRowId, 'Id');
                        $('#sData').hide();
                        $('#Act_Buttons').prepend('<a id="MyData" class="fm-button ui-state-default ui-corner-all fm-button-icon-left">Ok<span class="ui-icon ui-icon-close"></span></a>');
                        $('#MyData').click(function () {
                            var agente = { 'Nome': $('#Nome').val(), 'Cognome': $('#Cognome').val(), 'Grado': $('#Grado').val() };
                            $.ajax({
                                type: "GET",
                                url: window.location.origin + "/Comando/agenti.asmx/EditAgente?Id=" + selectedRowId + "&Nome='" + agente.Nome + "'&Cognome='" + agente.Cognome + "'&Grado='" + agente.Grado + "'",
                                contentType: "application/json; charset=utf-8",
                                success: function (msg) {
                                    location.reload();
                                },
                                error: function (jqXHR, textStatus, errorThrown) {
                                    alert("Chiamata fallita, si prega di riprovare...");
                                }
                            });
                        });
                    },
                   

                },
                {
                    reloadAfterSubmit: true, checkOnSubmit: true, checkOnUpdate: true, closeOnEscape: true,
                    beforeShowForm: function (formID) {
                        $('#sData').hide();
                        $('#Act_Buttons').prepend('<a id="MyData" class="fm-button ui-state-default ui-corner-all fm-button-icon-left">Ok<span class="ui-icon ui-icon-close"></span></a>');
                        $('#MyData').click(function () {
                            var agente = { 'Nome': $('#Nome').val(), 'Cognome': $('#Cognome').val(), 'Grado': $('#Grado').val() };
                            $.ajax({
                                type: "GET",
                                url: window.location.origin+"/Comando/agenti.asmx/InsertAgente?Nome='" + agente.Nome + "'&Cognome='"+ agente.Cognome + "'&Grado='"+agente.Grado + "'",
                                contentType: "application/json; charset=utf-8",
                                success: function (msg) {
                                    location.reload();
                                },
                                error: function (jqXHR, textStatus, errorThrown) {
                                    alert("Chiamata fallita, si prega di riprovare...");
                                }
                            });
                        });
                    }
                },

                 {
                     url: window.location.origin + "/Comando/agenti.asmx/DeleteAgente",
                     reloadAfterSubmit: true, checkOnSubmit: true, checkOnUpdate: true, closeOnEscape: true,
                     beforeShowForm: function (formID) {
                         var selectedRowId = $('#jqGridAgenti').jqGrid('getGridParam', 'selrow'),
                         cellValue = $('#jqGridAgenti').jqGrid('getCell', selectedRowId, 'Id'); 
                         $('#sData').hide();
                         $('#Act_Buttons').prepend('<a id="MyData" class="fm-button ui-state-default ui-corner-all fm-button-icon-left">Ok<span class="ui-icon ui-icon-close"></span></a>');
                         $('#MyData').click(function () {
                             $.ajax({
                                 type: "GET",
                                 url: window.location.origin + "/Comando/agenti.asmx/DeleteAgente?Id=" + selectedRowId,
                                 dataType: "json",
                                 contentType: "application/json; charset=utf-8",
                                 success: function (msg) {
                                     location.reload();
                                 },
                                 error: function (jqXHR, textStatus, errorThrown) {
                                     alert("Chiamata fallita, si prega di riprovare...");
                                 }
                             });
                         });
                     }
                 }
                );
            }
        });
    });
</script>
<script>
    $(document).ready(function () {
        $('.ui-jqgrid-labels').attr('style', 'height:30px');
        $('th').attr('style', 'height:30px');
    })
</script>