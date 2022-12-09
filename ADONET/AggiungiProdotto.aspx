<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AggiungiProdotto.aspx.cs" Inherits="ADONET.AggiungiProdotto" %>
<%@ OutputCache Duration="60" VaryByParam="none" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nome Prodotto: <asp:TextBox ID="txtNome" runat="server"></asp:TextBox> <br />
            Prezzo Prodotto: <asp:TextBox ID="txtPrezzo" runat="server"></asp:TextBox> <br />
            In Promozion:  <asp:CheckBox ID="ckcInPromozione" runat="server" /><br />
            Categoria: <asp:DropDownList ID="ddpCategoria" runat="server"></asp:DropDownList> <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

            <hr />
            <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal"  runat="server"></asp:RadioButtonList>
            <asp:Button ID="Button2" runat="server" Text="Filtra" OnClick="Button2_Click" /><br />
            
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" ItemType="ADONET.Prodotto">
                <Columns>
                    <asp:TemplateField HeaderText="Nome prodotto">
                        <ItemTemplate>
                            <p><%# Item.NomeProdotto %></p>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Prezzo prodotto">
                        <ItemTemplate>
                            <p><%# Item.Prezzo.ToString("c2") %></p>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
