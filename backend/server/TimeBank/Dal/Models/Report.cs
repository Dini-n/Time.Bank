using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.Models
{
    public partial class Report
    {
        public Report()
        {
            ReportsDetails = new HashSet<ReportsDetail>();
        }

        public short Id { get; set; }
        public short MemberCategoryId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string Note { get; set; }

        public virtual MemberCategory MemberCategory { get; set; }
        public virtual ICollection<ReportsDetail> ReportsDetails { get; set; }
    }
}
