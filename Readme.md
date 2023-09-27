<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128531222/16.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4742)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# How to adjust ASPxGridLookup selection
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4742/)**
<!-- run online end -->

This example demonstrates how to access selected data on the client and server in single and multiple [selection modes](https://docs.devexpress.com/AspNet/9075/components/grid-view/concepts/aspxgridlookup/selection-modes).

## Access the selection on the client in single selection mode.

To get selected row value on the client in the single selection mode, call the [ASPxClientGridView.GetRowValues](https://docs.devexpress.com/AspNet/js-ASPxClientGridView.GetRowValues(visibleIndex-fieldNames-onCallback)) method.
  
```js  
function OnGetSelectionButtonClick(s, e) {  
    var grid = gridLookUp.GetGridView();  
    grid.GetRowValues(grid.GetFocusedRowIndex(), 'ProductName;ProductID', OnGetRowValues);  
}  

function OnGetRowValues(values) {  
    if (values[0] == null) return;  
    alert('Product: ' + values[0]);  
}  
```

## Access the selection on the client in multiple selection mode.

To get selected row values on the client, in multiple selection mode, call the [ASPxClientGridView.GetSelectedFieldValues](https://docs.devexpress.com/AspNet/js-ASPxClientGridView.GetSelectedFieldValues(fieldNames-onCallback)) method.
  
```js  
function OnGetSelectionButtonClick(s, e) {  
    var grid = gridLookUp.GetGridView();  
    grid.GetSelectedFieldValues('ProductName', OnGetSelectedFieldValues);  
}  

function OnGetSelectedFieldValues(selectedValues) {  
    if (selectedValues.length == 0) return;  
    s = "";  
    for (i = 0; i < selectedValues.length; i++) {  
        for (j = 0; j < selectedValues[i].length; j++) {  
            s = s + selectedValues[i][j];  
        }  
        s += "\n";  
    }  
    alert("Selected Products:\n" + s);  
}  
```

## Access the selection on the server in single selection mode.

To get selected row value on the server, in single selection mode, call the [ASPxGridView.GetRowValues](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.GetRowValues(System.Int32-System.String--)) method.
  
```cs  
protected void GetSelectionButton_Click(object sender, EventArgs e) {  
    ASPxGridView grid = ASPxGridLookup1.GridView;  
    object value = grid.GetRowValues(grid.FocusedRowIndex, new string[] { "ProductName" });  
    ASPxListBox1.Items.Clear();  

    if(value != null) {  
        ASPxListBox1.Items.Add(value.ToString());  
    }  
}  
```  
  
```vb  
Protected Sub GetSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs)  
    Dim grid As ASPxGridView = ASPxGridLookup1.GridView  
    Dim value As Object = grid.GetRowValues(grid.FocusedRowIndex, New String() { "ProductName" })  
    ASPxListBox1.Items.Clear()  

    If value IsNot Nothing Then  
        ASPxListBox1.Items.Add(value.ToString())  
    End If  
End Sub  
```  

To set selected rows on the server, use the [ASPxGridLookup.Value](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridLookup.Value) property.  
    
```cs  
protected void SetSelectionButton_Click(object sender, EventArgs e) {  
    int maxUnitPrice = 0;  
    int maxUnitPriceKey = 0;  

    ASPxGridView grid = ASPxGridLookup1.GridView;  
    for(int i = grid.VisibleStartIndex; i < grid.VisibleRowCount; i++) {  
        int unitPrice = Convert.ToInt32(grid.GetRowValues(i, new string[] { "UnitPrice" }));  
        maxUnitPrice = (unitPrice > maxUnitPrice) ? unitPrice : maxUnitPrice;  
        maxUnitPriceKey = (unitPrice == maxUnitPrice) ? i : maxUnitPriceKey;  
    }  
    ASPxGridLookup1.Value = maxUnitPriceKey;  
}  
```  
  
```vb  
Protected Sub SetSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs)  
    Dim maxUnitPrice As Integer = 0  
    Dim maxUnitPriceKey As Integer = 0  

    Dim grid As ASPxGridView = ASPxGridLookup1.GridView  
    For i As Integer = grid.VisibleStartIndex To grid.VisibleRowCount - 1  
        Dim unitPrice As Integer = Convert.ToInt32(grid.GetRowValues(i, New String() { "UnitPrice" }))  
        maxUnitPrice = If(unitPrice > maxUnitPrice, unitPrice, maxUnitPrice)  
        maxUnitPriceKey = If(unitPrice = maxUnitPrice, i, maxUnitPriceKey)  
    Next i  
    ASPxGridLookup1.Value = maxUnitPriceKey  
End Sub  
```  


## Access the selection on the server in multiple selection mode.
 
To get selected row values on the server in multiple selection mode, call the [ASPxGridView.GetSelectedFieldValues](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.GetSelectedFieldValues(System.String--)) method.
  
```cs  
protected void GetSelectionButton_Click(object sender, EventArgs e) {  
    ASPxGridView grid = ASPxGridLookup1.GridView;  
    List<object> fieldValues = grid.GetSelectedFieldValues(new string[] { "ProductName" });  
    ASPxListBox1.Items.Clear();  

    if(fieldValues.Count > 0) {  
        foreach(object item in fieldValues)  
            ASPxListBox1.Items.Add(item.ToString());  
    }  
}  
```  
  
```vb  
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
```  

To set selected rows on the server, use the [ASPxGridLookup.Value](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridLookup.Value) property.  
  
```cs  
protected void SetSelectionButton_Click(object sender, EventArgs e) {  
    ASPxGridView grid = ASPxGridLookup1.GridView;  
    int minUnitPrice = 25;  

    grid.Selection.UnselectAll();  

    List<int> valuesToSelect = new List<int>();  

    for(int i = grid.VisibleStartIndex; i < grid.VisibleRowCount; i++) {  
        int unitPrice = Convert.ToInt32(grid.GetRowValues(i, new string[] { "UnitPrice" }));  
        if(unitPrice > minUnitPrice) {  
            valuesToSelect.Add((int)grid.GetRowValues(i, ASPxGridLookup1.KeyFieldName));  
        }  
    }  
    ASPxGridLookup1.Value = valuesToSelect;  
}  
```  
  
```vb  
Protected Sub SetSelectionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim grid As ASPxGridView = ASPxGridLookup1.GridView
            Dim minUnitPrice As Integer = 25

            grid.Selection.UnselectAll()

            Dim valuesToSelect As New List(Of Integer)()

            For i As Integer = grid.VisibleStartIndex To grid.VisibleRowCount - 1
                Dim unitPrice As Integer = Convert.ToInt32(grid.GetRowValues(i, New String() { "UnitPrice" }))
                If unitPrice > minUnitPrice Then
                    valuesToSelect.Add(CInt((grid.GetRowValues(i, ASPxGridLookup1.KeyFieldName))))
                End If
            Next i
            ASPxGridLookup1.Value = valuesToSelect
End Sub
```  
  


*Files to look at*:

* **[ClientSide_MultiSelect.aspx](./CS/ASPxGridLookUpSelection/ClientSide_MultiSelect.aspx) (VB: [ClientSide_MultiSelect.aspx](./VB/ASPxGridLookUpSelection/ClientSide_MultiSelect.aspx))**
* [ClientSide_MultiSelect.aspx.cs](./CS/ASPxGridLookUpSelection/ClientSide_MultiSelect.aspx.cs) (VB: [ClientSide_MultiSelect.aspx.vb](./VB/ASPxGridLookUpSelection/ClientSide_MultiSelect.aspx.vb))
* [ClientSide_SingleSelect.aspx](./CS/ASPxGridLookUpSelection/ClientSide_SingleSelect.aspx) (VB: [ClientSide_SingleSelect.aspx](./VB/ASPxGridLookUpSelection/ClientSide_SingleSelect.aspx))
* [ClientSide_SingleSelect.aspx.cs](./CS/ASPxGridLookUpSelection/ClientSide_SingleSelect.aspx.cs) (VB: [ClientSide_SingleSelect.aspx.vb](./VB/ASPxGridLookUpSelection/ClientSide_SingleSelect.aspx.vb))
* [Default.aspx](./CS/ASPxGridLookUpSelection/Default.aspx) (VB: [Default.aspx](./VB/ASPxGridLookUpSelection/Default.aspx))
* [ServerSide_MultiSelect.aspx](./CS/ASPxGridLookUpSelection/ServerSide_MultiSelect.aspx) (VB: [ServerSide_MultiSelect.aspx](./VB/ASPxGridLookUpSelection/ServerSide_MultiSelect.aspx))
* [ServerSide_MultiSelect.aspx.cs](./CS/ASPxGridLookUpSelection/ServerSide_MultiSelect.aspx.cs) (VB: [ServerSide_MultiSelect.aspx.vb](./VB/ASPxGridLookUpSelection/ServerSide_MultiSelect.aspx.vb))
* [ServerSide_SingleSelect.aspx](./CS/ASPxGridLookUpSelection/ServerSide_SingleSelect.aspx) (VB: [ServerSide_SingleSelect.aspx](./VB/ASPxGridLookUpSelection/ServerSide_SingleSelect.aspx))
* [ServerSide_SingleSelect.aspx.cs](./CS/ASPxGridLookUpSelection/ServerSide_SingleSelect.aspx.cs) (VB: [ServerSide_SingleSelect.aspx.vb](./VB/ASPxGridLookUpSelection/ServerSide_SingleSelect.aspx.vb))
<!-- default file list end -->
