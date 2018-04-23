using System;
using System.Collections.Generic;
using DevExpress.Web;

namespace ASPxGridLookUpSelection {
    public partial class ServerSide_MultiSelect : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void GetSelectionButton_Click(object sender, EventArgs e) {
            ASPxGridView grid = ASPxGridLookup1.GridView;
            List<object> fieldValues = grid.GetSelectedFieldValues(new string[] { "ProductName" });
            ASPxListBox1.Items.Clear();

            if(fieldValues.Count > 0) {
                foreach(object item in fieldValues)
                    ASPxListBox1.Items.Add(item.ToString());
            }
        }

        protected void SetSelectionButton_Click(object sender, EventArgs e) {
            ASPxGridView grid = ASPxGridLookup1.GridView;
            int minUnitPrice = 25;

            grid.Selection.UnselectAll();

            List<int> valuesToSelect = new List<int>();

            for(int i = grid.VisibleStartIndex; i < grid.VisibleRowCount; i++) {
                int unitPrice = Convert.ToInt32(grid.GetRowValues(i, new string[] { "UnitPrice" }));
                if(unitPrice > minUnitPrice) {
                    //Prior to version 16.1.6
                    //grid.Selection.SelectRow(i);
                    
                    //Starting with version 16.1.6
                    valuesToSelect.Add((int)grid.GetRowValues(i, ASPxGridLookup1.KeyFieldName));
                }
            }

            //Starting with version 16.1.6
            ASPxGridLookup1.Value = valuesToSelect;
        }
    }
}