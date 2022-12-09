<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADO_Disconnesso.aspx.cs" Inherits="ADONET.ADO_Disconnesso" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:GridView CssClass="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="NomeProdotto" HeaderText="Nome Prodotto" SortExpression="NomeProdotto"></asp:BoundField>
                    <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" DataFormatString="{0:c2}" SortExpression="Prezzo"></asp:BoundField>
                    <asp:BoundField DataField="NomeCategoria" HeaderText="Categoria" SortExpression="NomeCategoria"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:SampleEcommerceConnectionString3 %>" SelectCommand="SELECT Prodotti.NomeProdotto, Prodotti.Prezzo, Categoria.NomeCategoria FROM Prodotti INNER JOIN Categoria ON Prodotti.idCategoria = Categoria.idCategoria"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
