<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Music.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        hi<br />
    
        adress:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        is comnnected:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Start Server" />
        <br />
        song:
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Upload" />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="274px" Width="332px"></asp:ListBox>
    
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Play" Width="463px" />
        </p>
    </form>

</body>
</html>
