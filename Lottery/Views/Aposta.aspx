<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aposta.aspx.cs" Inherits="Lottery.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link href="../Style.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="#003300" Text="Selecione os números da sua aposta: "></asp:Label>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" BackColor="Gainsboro" BorderColor="#669999" BorderStyle="Solid" Width="230px">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium" Font-Strikeout="False"></asp:CheckBoxList>
        </asp:Panel>

        <br />
        <br />

        <asp:Button ID="btnIncluirAposta" runat="server" Text="Incluir Aposta" OnClick="btnIncluirAposta_Click" />
        <asp:Button ID="btnGerarSurpresinha" runat="server" Text="Apostar surpresinha" OnClick="btnGerarSurpresinha_Click" />
        <asp:Button ID="btnSortear" runat="server" Text="Sortear" OnClick="btnSortear_Click" />
        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />

        <br />
        <br />
        <br />

        <asp:Label ID="message" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" ForeColor="Red"></asp:Label>


        <div class="alignCenter">

            <asp:Label ID="lblNumeroSorteado" CssClass="label" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="X-Large" ForeColor="#009900"></asp:Label>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Calibri" ForeColor="Gray">
                <AlternatingRowStyle BorderStyle="None" Font-Names="Calibri" />
                <Columns>
                    <asp:BoundField DataField="NumAposta" ItemStyle-HorizontalAlign="Center" HeaderText="Número do Jogo">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NumSelecionados" ItemStyle-HorizontalAlign="Center" HeaderText="Números">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Data" ItemStyle-HorizontalAlign="Center" HeaderText="Data">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Resultado" ItemStyle-HorizontalAlign="Center" HeaderText="Resultado">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#333333" />
                <HeaderStyle BackColor="#006666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="Black" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>

            <br />
            <br />
            <br />


        </div>
    </form>
</body>
</html>
