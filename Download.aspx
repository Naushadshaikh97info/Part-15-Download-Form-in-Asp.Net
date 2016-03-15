<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                EmailID
                </td>
                <td>
                    <asp:TextBox ID="txt_emailid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
                <asp:Button ID="btn_sendlink" runat="server" Text="Send Me the Link" OnClick="btn_sendlink_Click1" />
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
