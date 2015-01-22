using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace WebSite.Classes.ComponentX
{
    public sealed class GridViewX : RadGrid
    {
        public GridViewX()
        {
            AllowPaging = true;
            AllowFilteringByColumn = true;
            AllowPaging = true;
            AllowSorting = true;
            Culture = new CultureInfo("fa-IR");
        }
    }
}