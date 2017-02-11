﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ZobShop.Web.Product.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="ErrorLabel"></asp:Label>

    <asp:FormView runat="server" ID="DetailsView">
        <ItemTemplate>
            <div>
            </div>
        </ItemTemplate>
    </asp:FormView>


    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanelResults">
        <ContentTemplate>
            <asp:SqlDataSource ID="SqlDataSourceComments" runat="server"
                ConnectionString="<%$ ConnectionStrings:ZobShopDb %>"></asp:SqlDataSource>
            <asp:Label runat="server" ID="PanelResults"></asp:Label>

            <asp:GridView runat="server" DataSourceID="SqlDataSourceComments" AutoGenerateColumns="True"></asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelComment" runat="server" class="panel"
        UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TextBox runat="server" ID="CommentBox"></asp:TextBox>
            <asp:Button runat="server" ID="Comment" Text="Add Review" OnClick="Comment_OnClick" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
