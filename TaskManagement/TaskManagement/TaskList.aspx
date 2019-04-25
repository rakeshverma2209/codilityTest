<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="TaskManagement.TaskList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:gridview ID="grdTaskList" runat="server" OnRowEditing="grdTaskList_RowEditing" OnSelectedIndexChanged="grdTaskList_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Edit" ShowHeader="True" Text="Edit" />
        </Columns>
        </asp:gridview>
        <br />
        <br />
        <table>
            <tr>
                <td>Title : </td>
                <td>
                    <asp:TextBox ID="txtTaskTitle" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Details :</td>
                <td>
                    <asp:TextBox ID="txtTaskDetails" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Due Date :</td>
                <td>
                <asp:Calendar ID="cldDueDate" runat="server"></asp:Calendar></td>
                <%--<asp:TextBox ID="txtDueDate" runat="server" TextMode="Date"></asp:TextBox>--%>
            </tr>
            <tr>
                <td>Completed Date :</td>
                <td>
                <asp:Calendar ID="cldCompletedDate" runat="server"></asp:Calendar></td>
                <%--<asp:TextBox ID="txtCompletedDate" runat="server" TextMode="DateTime"></asp:TextBox>--%>
                    
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpdateTask" runat="server" Text="Update" OnClick="btnUpdateTask_Click" /></td>
                <td>
                </td>
                    
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
