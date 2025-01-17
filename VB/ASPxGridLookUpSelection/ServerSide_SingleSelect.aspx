﻿<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="ServerSide_SingleSelect.aspx.vb" Inherits="ASPxGridLookUpSelection.ServerSide_SingleSelect" %>

<%@ Register Assembly="DevExpress.Web.v24.2, Version=24.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Go to the Default Page" NavigateUrl="~/Default.aspx">
            </dx:ASPxHyperLink>

            <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" ClientInstanceName="gridLookUp" TextFormatString="{0}" AutoGenerateColumns="False" DataSourceID="AccessDataSource1" Width="300px" KeyFieldName="ProductID">
                <GridViewProperties>
                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
                </GridViewProperties>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridLookup>

            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Selected Products" PopupElementID="GetSelectionButton">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                        <dx:ASPxListBox ID="ASPxListBox1" runat="server" ValueType="System.String" Width="100%"></dx:ASPxListBox>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>

            <%--Get Selection:--%>
            <dx:ASPxButton ID="GetSelectionButton" runat="server" OnClick="GetSelectionButton_Click" Text="Get Selected Product">
            </dx:ASPxButton>

            <%--Set Selection:--%>
            <dx:ASPxButton ID="SetSelectionButton" runat="server" OnClick="SetSelectionButton_Click" Text="Set Selected Product">
            </dx:ASPxButton>

            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
                SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products]"></asp:AccessDataSource>
        </div>
    </form>
</body>
</html>