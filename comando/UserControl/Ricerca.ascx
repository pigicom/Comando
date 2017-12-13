<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ricerca.ascx.cs" Inherits="WebApp.UserControl.Ricerca" %> 

<script src="../Scripts/jqgrid/js/jquery.jqGrid.min.js"></script>
<div class="quickmenu">
<asp:GridView ID="GridView1" runat="server" OnRowCommand="OnRowCommand"
      CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" Width="100%" AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="btnSelect" runat="server" CommandName="Select" Text="Seleziona" CommandArgument='<%#Bind("id")%>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Data Creazione">
            <ItemTemplate>
                <asp:Label ID="data" runat="server" Text='<%#(Eval("Data")!=null) ? ((DateTime)Eval("Data")).ToShortDateString() : ""%>'   />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Protocollo">
            <ItemTemplate>
                <asp:Label ID="data2" runat="server" Text='<%#Bind("Protocollo")%>'/>
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Trasgressore">
            <ItemTemplate>
                <asp:Label ID="data3" runat="server" Text='<%#Bind("Nome")%>'/>
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Descrizione">
            <ItemTemplate>
                <asp:Label ID="data4" runat="server" Text='<%#Bind("Descrizione")%>'/>
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="Agente">
            <ItemTemplate>
                <asp:Label ID="data5" runat="server" Text='<%#Bind("Cognome")%>'/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>      

 

</div>               

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              