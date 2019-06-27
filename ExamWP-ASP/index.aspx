<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ExamWP_ASP.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exam</title>
</head>
<body>
    <form id="form1" runat="server">
        <div><asp:HiddenField ID="hiddenfieldID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Name" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textName" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Professor" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textProfessor" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Duration" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="textDuration" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Save" ID="buttonSave" runat="server" OnClick="buttonSave_Click" />
                        <asp:Button Text="Clear" ID="buttonClear" runat="server" OnClick="buttonClear_Click" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="labelSuccessMessage" runat="server" Forecolor="Green" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="labelErrorMessage" runat="server" Forecolor="Red" />
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td>
                        <asp:Label Text="CourseID" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="TextBoxCourseID" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Restriction" runat="server"/>
                    </td>
                    <td colspan ="2">
                        <asp:TextBox ID="TextBoxRestriction" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Save" ID="button1" runat="server" OnClick="buttonSaveRestriction_Click" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="label1" runat="server" Forecolor="Green" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="label2" runat="server" Forecolor="Red" />
                    </td>
                </tr>
            </table>
            
            <br />
            <br />
            
            <asp:GridView ID="gvName" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Professor" HeaderText="Professor" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Select" ID="linkSelect" CommandArgument='<%# Eval("ID") %>' runat="server" OnClick="linkSelect_OnClick" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="LabelSearch" runat="server" Text="Courses :"></asp:Label>
                    </td>

                    <td colspan="2">
                        <asp:DropDownList ID="CourseList" runat="server" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </td>

                </tr>
            </table>
            <br />
            <br />

            <asp:GridView ID="gvTimetable" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="IDCourse" HeaderText="Course" />
                    <asp:BoundField DataField="IDRoom" HeaderText="Room" />
                    <asp:BoundField DataField="day" HeaderText="day" />
                    <asp:BoundField DataField="beginningHour" HeaderText="beginningHour" />
                    <asp:BoundField DataField="endingHour" HeaderText="endingHour" />
                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
