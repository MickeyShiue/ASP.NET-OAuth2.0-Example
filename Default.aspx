<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication6.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                 <asp:Button ID="GoogleLogin" runat="server" Text="google登入" OnClick="GoogleLogin_Click" />
                 <asp:Button ID="FacebookLogin" runat="server" Text="Facebook登入" OnClick="FacebookLogin_Click" />
        </div> 
    </form>
</body>
</html>

