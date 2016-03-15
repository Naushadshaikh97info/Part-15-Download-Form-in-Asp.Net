<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Default2" %>

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
                    Image Name
                </td>
                <td>
                    <asp:TextBox ID="txt_img" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    File Upload
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                    <asp:Button ID="btn_update" runat="server" Text="Update" 
                        onclick="btn_update_Click" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="code"
                        AllowPaging="true" PageSize="5" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing">
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("img") %>' Height="100px"
                                        Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Button" />
                            <asp:CommandField HeaderText="Edit" ShowEditButton="true" ButtonType="Button" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
