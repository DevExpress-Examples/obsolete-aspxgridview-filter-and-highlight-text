Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxRoundPanel

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub searchBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim searchString As String = searchTxt.Text
		If searchString = "" Then
			ASPxGridView1.FilterExpression = ""
		Else
			Dim fExpr As String = ""
			For Each column As GridViewColumn In ASPxGridView1.Columns
				If TypeOf column Is GridViewDataColumn Then
					If fExpr = "" Then
						fExpr = "[" & (TryCast(column, GridViewDataColumn)).FieldName & "] Like '%" & searchString & "%'"
					Else
						fExpr = fExpr & "OR " & "[" & (TryCast(column, GridViewDataColumn)).FieldName & "] Like '%" & searchString & "%'"
					End If
				End If
			Next column

			ASPxGridView1.FilterExpression = fExpr

		End If

		Session("searchText") = searchString
	End Sub

	Protected Sub ASPxGridView1_CustomColumnDisplayText(ByVal sender As Object, ByVal e As ASPxGridViewColumnDisplayTextEventArgs)
		 Dim searchText As String = searchTxt.Text
		Dim highlightedText As String = e.Value.ToString()

		If (Not highlightedText.Contains(searchText)) OrElse searchText Is Nothing OrElse searchText = String.Empty Then
			Return
		End If
	  e.DisplayText = highlightedText.Replace(searchText,"<span class='highlight'>" & searchText & "</span>")

	End Sub
End Class