Imports System
Imports System.Collections.Generic
Imports DevExpress.Web

Namespace ASPxGridLookUpSelection
    Partial Public Class ServerSide_MultiSelect
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub GetSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim grid As ASPxGridView = ASPxGridLookup1.GridView
            Dim fieldValues As List(Of Object) = grid.GetSelectedFieldValues(New String() { "ProductName" })
            ASPxListBox1.Items.Clear()

            If fieldValues.Count > 0 Then
                For Each item As Object In fieldValues
                    ASPxListBox1.Items.Add(item.ToString())
                Next item
            End If
        End Sub

        Protected Sub SetSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim grid As ASPxGridView = ASPxGridLookup1.GridView
            Dim minUnitPrice As Integer = 25

            grid.Selection.UnselectAll()

            Dim valuesToSelect As New List(Of Integer)()

            For i As Integer = grid.VisibleStartIndex To grid.VisibleRowCount - 1
                Dim unitPrice As Integer = Convert.ToInt32(grid.GetRowValues(i, New String() { "UnitPrice" }))
                If unitPrice > minUnitPrice Then
                    'Prior to version 16.1.6
                    'grid.Selection.SelectRow(i);

                    'Starting with version 16.1.6
                    valuesToSelect.Add(CInt((grid.GetRowValues(i, ASPxGridLookup1.KeyFieldName))))
                End If
            Next i

            'Starting with version 16.1.6
            ASPxGridLookup1.Value = valuesToSelect
        End Sub
    End Class
End Namespace