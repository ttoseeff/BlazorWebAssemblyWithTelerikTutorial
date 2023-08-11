using System;
using Telerik.DataSource;

namespace BlazorProject.Client.Models.Teleril
{
    public class GridFilter
    {
        public string Member { get; set; }
        public FilterOperator Operator { get; set; }
        public string Value { get; set; }
        public string MemberType { get; internal set; }
    }
}
