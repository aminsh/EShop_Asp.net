using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace WebSite.Classes.ComponentX
{
    public class ComboX : RadComboBox
    {
        public ComboX()
        {
            Width = 300;
        }
    }

    public sealed class ComboSearchableX : RadComboBox
    {
        public ComboSearchableX()
        {
            LoadingMessage = "بارگزاری ...";
            Filter = RadComboBoxFilter.Contains;
            ItemsPerRequest = 10;
            EnableLoadOnDemand = true;
            ShowMoreResultsBox = true;
            EnableVirtualScrolling = true;
            EnableAutomaticLoadOnDemand = true;
            Width = 300;
        }

        public String EntityName { get; set; }

        public override string EmptyMessage
        {
            get { return string.Format("یک {0} را انتخاب کنید ...", EntityName); }
            set
            {
                base.EmptyMessage = value;
            }
        }

    }
}