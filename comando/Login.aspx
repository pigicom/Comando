<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Comando.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Styles/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <fieldset style="width:99%;margin-left:5px;margin-right:5px">
                <legend style="color: #3498db;margin-left:10px">Inserire Cerdenziali<img alt="" style="margin-top:-18px" class="auto-style1" src="images/logoComunale.gif" /></legend>
                <table style="background-image: url('/Comando/images/polizialocale.png');opacity: 0.9;width:1120px;height:480px " class="auto-style3">
                    <tr>
                        <td style="width: 13%"></td>
                        <td style="text-align: center">
                            <asp:Login ID="Login1" Style="align-items: center; margin-left: 30%;" runat="server" Height="206px" OnAuthenticate="Login1_Authenticate" Width="428px">
                            </asp:Login>
                            <br />
                            <table class="nav-justified" style="width:100%">
                                <tr>
                                    <td>
                            <asp:Button  runat="server" CssClass="btn btn-danger" Width="100px" Text="Registrami" id="registrami" OnClick="registrami_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <hr style="width: 50%;margin-right:100px" />
                        </td>
                        <td style="width: 13%"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            &nbsp;</td>
                        <td></td>
                    </tr>

                </table>
            </fieldset>
        </div>
        <table style="width: 100%">
            <tr>
                <td style="text-align: right">
                    <h2 style="color: #3498db;margin-right:10px;   font-style: italic;">
                        Polizia Locale </h2>
                </td>
            </tr>
        </table>

    </form>


</body>
</html>
<style>
    label {
        color: white;
    }
    .auto-style1 {
        width: 271px;
        height: 44px;
        float: right;
    }
    .auto-style2 {
        width: 114px;
        height: 62px;
    }
    .auto-style3 {
        width: 100%;
        height: 600px;
    }
</style>
<script>
    $(document).ready(function () {
        $('#Login1_LoginButton').addClass('btn btn-primary');
        $('input').addClass('k-widget k-autocomplete k-header form-control k-state-default')
        $('label').addClass('col-md-12 control-label');
        $('#Login1_LoginButton').attr('style', 'width:100px');
        $('#Login1_RememberMe').hide();
    })


</script>
