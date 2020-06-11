using System;
using System.Collections.Generic;
using System.Text;
namespace CloudUsagePOC
{

    public partial class CanonicalCostandUsage
    {
        public GroupDefinition[] GroupDefinitions { get; set; }
        public ResultsByTime[] ResultsByTime { get; set; }
    }

    public partial class GroupDefinition
    {
        public string Key { get; set; }
        public string Type { get; set; }
    }

    public partial class ResultsByTime
    {
        public bool Estimated { get; set; }
        public Group[] Groups { get; set; }
        public TimePeriod TimePeriod { get; set; }
        public Total Total { get; set; }
    }

    public partial class Group
    {
        public string[] Keys { get; set; }
        public Metrics Metrics { get; set; }
    }

    public partial class Metrics
    {
        public BlendedCost BlendedCost { get; set; }
        public BlendedCost UnblendedCost { get; set; }
        public BlendedCost UsageQuantity { get; set; }
    }

    public partial class BlendedCost
    {
        public string Amount { get; set; }
        public string Unit { get; set; }
    }

    public partial class TimePeriod
    {
        public DateTimeOffset End { get; set; }
        public DateTimeOffset Start { get; set; }
    }

    public partial class Total
    {
    }
}
