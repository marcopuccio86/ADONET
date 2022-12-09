<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADONET.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Cognome: <asp:TextBox ID="txtCognome" runat="server"></asp:TextBox><br />
            Nome: <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="INSERT" OnClick="Button1_Click" />
            <hr />

            <asp:Button ID="Button2" runat="server" Text="UPDATE" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="DELETE" OnClick="Button3_Click" /> 
            <asp:Button ID="Button4" runat="server" Text="SELECT PRODOTTI" OnClick="Button4_Click" />

            <div class="container">
                <div class="row">                    
                   <%-- <asp:Repeater ID="Repeater1" runat="server" ItemType="ADONET.Prodotto">
                        <ItemTemplate>
                            
                            <div class="col-md-3">
                                <p style="font-size: 15px; font-weight: bold; color: blue"><%# Item.NomeProdotto %></p>
                                <p><%# Item.Prezzo.ToString("c2") %></p>
                                <a href="DettagliProdotto.aspx?idprodotto=<%# Item.IdProdotto %>">Dettagli</a>
                              <hr />
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>--%>

                    <asp:GridView ID="GridView1" CssClass="table table-bordered" 
                        AutoGenerateColumns="false" runat="server" ItemType="ADONET.Prodotto">
                        
                        <Columns>
                               <asp:TemplateField HeaderText="Nome Prodotto">
                                    <ItemTemplate>
                                        <p><%# Item.NomeProdotto %></p>
                                    </ItemTemplate>
                               </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="Prezzo al pubblico">
                                    <ItemTemplate>
                                        <p><%# Item.Prezzo.ToString("c2") %></p>
                                    </ItemTemplate>
                               </asp:TemplateField>

                             <asp:TemplateField HeaderText="Prezzo al pubblico">
                                    <ItemTemplate>
                                       <a href="DettagliProdotto.aspx?idProdotto=<%# Item.IdProdotto %>">Scheda prodotto</a>
                                    </ItemTemplate>
                               </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>
            </div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
