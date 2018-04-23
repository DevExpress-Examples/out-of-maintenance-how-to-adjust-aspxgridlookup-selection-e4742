using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPxGridLookUpSelection {
    public partial class ServerSide_MultiSelect : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void GetSelectionButton_Click(object sender, EventArgs e) {
            ASPxGridView grid = ASPxGridLookup1.GridView;
            List<object> fieldValues = grid.GetSelectedFieldValues(new string[] { "ProductName" });
            ASPxListBox1.Items.Clear();

            if (fieldValues.Count > 0) {
                foreach (object item in fieldValues)
                    ASPxListBox1.Items.Add(item.ToString());
            }
        }

        protected void SetSelectionButton_Click(object sender, EventArgs e) {
            ASPxGridView grid = ASPxGridLookup1.GridView;
            int minUnitPrice = 25;

            grid.Selection.UnselectAll();
            for (int i = grid.VisibleStartIndex; i < grid.VisibleRowCount; i++) {
                int unitPrice = Convert.ToInt32(grid.GetRowValues(i, new string[] { "UnitPrice" }));
                if (unitPrice > minUnitPrice)
                    grid.Selection.SelectRow(i);
            }
        }
    }
}