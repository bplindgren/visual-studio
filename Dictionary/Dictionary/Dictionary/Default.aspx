<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dictionary._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>DICTIONARY</h1>
        <p class="lead">This is the World's Greatest Dictionary App. This app is so powerful, it will change your life.</p>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label>Letter</label>
                <asp:DropDownList ID="ddlLetter" CssClass="form-control" runat="server">
                    <asp:ListItem Value="a">"A"</asp:ListItem>
                    <asp:ListItem Value="b">"B"</asp:ListItem>
                    <asp:ListItem Value="c">"C"</asp:ListItem>
                    <asp:ListItem Value="d">"D"</asp:ListItem>
                    <asp:ListItem Value="e">"E"</asp:ListItem>
                    <asp:ListItem Value="f">"F"</asp:ListItem>
                    <asp:ListItem Value="g">"G"</asp:ListItem>
                    <asp:ListItem Value="h">"H"</asp:ListItem>
                    <asp:ListItem Value="i">"I"</asp:ListItem>
                    <asp:ListItem Value="j">"J"</asp:ListItem>
                    <asp:ListItem Value="k">"K"</asp:ListItem>
                    <asp:ListItem Value="l">"L"</asp:ListItem>
                    <asp:ListItem Value="m">"M"</asp:ListItem>
                    <asp:ListItem Value="n">"N"</asp:ListItem>
                    <asp:ListItem Value="o">"O"</asp:ListItem>
                    <asp:ListItem Value="p">"P"</asp:ListItem>
                    <asp:ListItem Value="q">"Q"</asp:ListItem>
                    <asp:ListItem Value="r">"R"</asp:ListItem>
                    <asp:ListItem Value="s">"S"</asp:ListItem>
                    <asp:ListItem Value="t">"T"</asp:ListItem>
                    <asp:ListItem Value="u">"U"</asp:ListItem>
                    <asp:ListItem Value="v">"V"</asp:ListItem>
                    <asp:ListItem Value="w">"W"</asp:ListItem>
                    <asp:ListItem Value="x">"X"</asp:ListItem>
                    <asp:ListItem Value="y">"Y"</asp:ListItem>
                    <asp:ListItem Value="z">"Z"</asp:ListItem>
                </asp:DropDownList>
            
                <label class="padding-top-10">Query</label>
                <asp:DropDownList ID="ddlQuery" CssClass="form-control" runat="server">
                    <asp:ListItem Value="begin">Number of Words that Begin with Letter</asp:ListItem>
                    <asp:ListItem Value="end">Number of Words that End with Letter</asp:ListItem>
                    <asp:ListItem Value="avgNumChar">Average # of Characters in Words that Begin with Letter</asp:ListItem>
                    <asp:ListItem Value="shortest">Shortest Words that begin with Letter</asp:ListItem>
                    <asp:ListItem Value="longest">Longest Words that begin with Letter</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="padding-bottom-10">
                <asp:Button ID="myButton" runat="server" Text="Get Result" class="btn btn-primary centering" OnClick="myButton_Click" />
            </div>
        </div>

        <div class="col-md-6">
            <div class="message">
                <asp:Literal ID="Result" runat="server" />
            </div>
        </div>

    </div>

</asp:Content>
