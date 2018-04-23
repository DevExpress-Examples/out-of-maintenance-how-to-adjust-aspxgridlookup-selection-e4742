using System;
using DevExpress.Web;

namespace ASPxGridLookUpSelection {
    public partial class ServerSide_SingleSelect : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void GetSelectionButton_Click(object sender, EventArgs e) {
            ASPxGridView grid = ASPxGridLookup1.GridView;
            object value = grid.GetRowValues(grid.FocusedRowIndex, new string[] { "ProductName" });
            ASPxListBox1.Items.Clear();

            if(value != null) {
                ASPxListBox1.Items.Add(value.ToString());
            }
        }

        protected void SetSelectionButton_Click(object sender, EventArgs e) {
            int maxUnitPrice = 0;
            int maxUnitPriceKey = 0;

            ASPxGridView grid = ASPxGridLookup1.GridView;
            for(int i = grid.VisibleStartIndex; i < grid.VisibleRowCount; i++) {
                int unitPrice = Convert.ToInt32(grid.GetRowValues(i, new string[] { "UnitPrice" }));
                maxUnitPrice = (unitPrice > maxUnitPrice) ? unitPrice : maxUnitPrice;
                maxUnitPriceKey = (unitPrice == maxUnitPrice) ? i : maxUnitPriceKey;
            }

            //Prior to version 16.1.6
            //grid.Selection.SelectRow(maxUnitPriceKey);

            //Starting with version 16.1.6
            ASPxGridLookup1.Value = maxUnitPriceKey;
        }
    }
}