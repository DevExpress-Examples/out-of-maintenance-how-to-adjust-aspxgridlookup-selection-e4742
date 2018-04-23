Imports Microsoft.VisualBasic
Imports DevExpress.Web.ASPxGridView
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ASPxGridLookUpSelection
	Partial Public Class ServerSide_SingleSelect
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub GetSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim grid As ASPxGridView = ASPxGridLookup1.GridView
			Dim value As Object = grid.GetRowValues(grid.FocusedRowIndex, New String() { "ProductName" })
			ASPxListBox1.Items.Clear()

			If value IsNot Nothing Then
				ASPxListBox1.Items.Add(value.ToString())
			End If
		End Sub

		Protected Sub SetSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim maxUnitPrice As Integer = 0
			Dim maxUnitPriceKey As Integer = 0

			Dim grid As ASPxGridView = ASPxGridLookup1.GridView
			For i As Integer = grid.VisibleStartIndex To grid.VisibleRowCount - 1
				Dim unitPrice As Integer = Convert.ToInt32(grid.GetRowValues(i, New String() { "UnitPrice" }))
				maxUnitPrice = If((unitPrice > maxUnitPrice), unitPrice, maxUnitPrice)
				maxUnitPriceKey = If((unitPrice = maxUnitPrice), i, maxUnitPriceKey)
			Next i

			grid.Selection.SelectRow(maxUnitPriceKey)
		End Sub
	End Class
End Namespace