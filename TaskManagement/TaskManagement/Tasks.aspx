<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="TaskManagement.Tasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                    <asp:Button ID="btnSaveTask" runat="server" Text="Save" OnClick="btnSaveTask_Click" /></td>
                <td>
                <asp:Button ID="btnTaskList" runat="server" Text="View Tasks" OnClick="btnTaskList_Click"/></td>
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
