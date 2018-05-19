<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ register Assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ register Assembly="DevExpress.Web.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      .highlight
      {
      	background-color:#99FF66;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
      <tr>
        <td>
          <dx:aspxtextbox ID="searchTxt" runat="server" Width="170px">
          </dx:aspxtextbox>
        </td>
        <td>
          <dx:aspxbutton ID="searchBtn" runat="server" AutoPostBack="false" Text="Search" 
                onclick="searchBtn_Click">
          </dx:aspxbutton>
        </td>
      </tr>
    </table>
    <dx:aspxgridview ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
        KeyFieldName="ProductID" DataSourceID="AccessDataSource1" 
        oncustomcolumndisplaytext="ASPxGridView1_CustomColumnDisplayText">
      
      
        <columns>
            <dx:gridviewdatatextcolumn FieldName="ProductID" ReadOnly="True" 
                VisibleIndex="0">
                <editformsettings Visible="False" />
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn FieldName="ProductName" VisibleIndex="1">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn FieldName="CategoryID" VisibleIndex="2">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn FieldName="UnitPrice" VisibleIndex="3">
            </dx:gridviewdatatextcolumn>
        </columns>
       
    </dx:aspxgridview>
    
    
    <asp:accessdatasource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/nwind.mdb" 
        SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products]">
    </asp:accessdatasource>
    </form>
</body>
</html>
