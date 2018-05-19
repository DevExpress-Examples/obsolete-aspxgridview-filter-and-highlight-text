using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxRoundPanel;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        string searchString = searchTxt.Text;
        if (searchString == "")
        {
            ASPxGridView1.FilterExpression = "";
        }
        else
        {
            string fExpr = "";
            foreach (GridViewColumn column in ASPxGridView1.Columns)
            {
                if (column is GridViewDataColumn)
                {
                    if (fExpr == "")
                    {
                        fExpr = "[" + (column as GridViewDataColumn).FieldName + "] Like '%" + searchString + "%'";
                    }
                    else
                    {
                        fExpr = fExpr + "OR " + "[" + (column as GridViewDataColumn).FieldName + "] Like '%" + searchString + "%'";
                    }
                }
            }

            ASPxGridView1.FilterExpression = fExpr;

        }

        Session["searchText"] = searchString;
    }

    protected void ASPxGridView1_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        string searchText = searchTxt.Text;
        string highlightedText = e.Value.ToString();

        if (!highlightedText.Contains(searchText) || searchText == null || searchText == string.Empty)
            return;
      e.DisplayText = highlightedText.Replace(searchText,"<span class='highlight'>"+searchText+"</span>");

    }
}