<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Comando.UserControl.Menu" %>
<%@ Register Src="Ricerca.ascx" TagName="Ricerca" TagPrefix="uc1" %>

<style type="text/css">
    .auto-style1 {
        text-align: center;
    }

    .button {
        vertical-align: bottom;
        width: 110px;
        height: 40px;
        background: #fff;
        -webkit-border-radius: 4px;
        -moz-border-radius: 4px;
        border-radius: 4px;
        padding: 3px;
        -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
        -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
    }
</style>

<script>
    function ricerca() {
        $('#pnlRicerca').attr('visibility', 'visible');
        $('#pnlRicerca').dialog({
            modal: true,
            title: 'Ricerca Verbale',
            resizable: false,
            height: 440, width: 800, modal: true,
            buttons: { 'Chiudi': function () { $(this).dialog('close'); } }
        });
    }

    function conferma(e) {

        if (e.name.indexOf('New') >= 0)
            return true;

        var esito = true;

        if ($('#ContentPlaceHolder1_ControlAgente_txtViolazioneData').val() == '')
            esito = false;

        if ($('#divTrasgressore').length>0) //se c'è il trasgressore allora è obbligatorio nome e cognome e data nascita
        {
            if ($('#ContentPlaceHolder1_ControlAgente_txtViolazioneData').val == ''  ||
                $('#ContentPlaceHolder1_ControlTrasgressore_txtNome').val == ''      ||
                $('#ContentPlaceHolder1_ControlTrasgressore_txtCognome').val() == '' ||
                $('#ContentPlaceHolder1_ControlTrasgressore_txtNascita').val() == '')
            {
                esito=false;
            }
        }
        if (($('#divTrasgressore').length==0) && ($('#divProprietario').length>0)) //sennò è il proprietario ad essere campo obbligatorio
        {
            if ($('#ContentPlaceHolder1_ControlAgente_txtViolazioneData').val == ''  ||
                    $('#ContentPlaceHolder1_ControlProprietario_txtNome').val == '' ||
                    $('#ContentPlaceHolder1_ControlProprietario_txtCognome').val() == '' ||
                    $('#ContentPlaceHolder1_ControlProprietario_txtNascita').val() == '')
            {
                esito=false;
            }
        }

        if (esito==false)
            {
            $("#msg").text('Controllare i campi obbligatori');
            $('#pnlConferma').dialog({
                title: 'Errore',
                resizable: false,
                height: 200, width: 300, modal: true,
                buttons: {
                    //'Ok': function () {__doPostBack(e.name,'') },
                    'Ok': function () {
                        $(this).dialog('close');
                    }
                }
            });
            return false;
        }

    }

    function Messaggio(text) {
        $("#msg").text(text);
        $('#pnlConferma').dialog({
            title: 'Errore',
            resizable: false,
            height: 200, width: 400, modal: false,
            buttons: {
                'Ok': function () {
                    $(this).dialog('close');
                    $('#ContentPlaceHolder1_Menu_ImageButton1').click();
                }
            }
        });
        return false;
    }


    function openAttach()
    {
        window.open('<%=System.Configuration.ConfigurationManager.AppSettings["URLNuovi"]%>', '_blank', 'width:500px;height:300px');
        return false;
    }
</script>


   
<div id="divmenulaterale" style="position: absolute; left: 1150px; top: 200px">
    <fieldset>
     <legend>Azioni</legend>
    <table style="width: 100px; align-content: center;padding:10px" >
        <tr style="align-items: center">
            <td style="width: 25%" class="auto-style1">
                <asp:ImageButton CausesValidation="false" class="button" src="../images/nuovo.png" runat="server" ID="btnNew" OnClientClick="return conferma(this)" OnClick="btnNew_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 25%" class="auto-style1">
                <asp:ImageButton ID="btnSave" CausesValidation="false" class="button" src="../images/salva.png" runat="server" OnClientClick="return conferma(this)" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 25%" class="auto-style1">
                <asp:ImageButton ID="btnSearch" runat="server" class="button" CausesValidation="false" src="../images/cerca.png" OnClientClick="CaricaRicerca();return false;" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 25%" class="auto-style1">
                <asp:ImageButton ID="btnCrea" CausesValidation="false" class="button" runat="server" src="../images/stampa.png" OnClientClick="var r= conferma(this); if (r==true) ShowVerbali();return r" OnClick="btnCrea_Click" />
            </td>
        </tr> 
        <tr>
            <td style="width: 25%" class="auto-style1">
                <asp:ImageButton ID="ImageButton1" runat="server" class="button" CausesValidation="false" src="../images/cartella.png" OnClientClick="openAttach()" />
            </td>
        </tr>
        <tr>
            <td style="width: 25%" class="auto-style1">
                <asp:ImageButton ID="ImageButton2" runat="server" class="button" CausesValidation="false" src="../images/nuovo.png" OnClientClick="$('#divUpload').show();$('#divUpload').attr('style','margin-top:-300px;width:75%;margin-left:200px'); $(window).scrollTop(1000);return false;" />
            </td>
        </tr>
    </table>
     </fieldset>
</div>
  
<div id="pnlConferma" style="display: none">
    <span id="msg"></span>
</div>


