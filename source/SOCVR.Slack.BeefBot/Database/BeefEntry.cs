using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOCVR.Slack.BeefBot.Database
{
    public class BeefEntry
    {
        [Key]
        public int Id { get; set; }

        public BeefSeverity Severity { get; set; }

        [Required]
        public string ReporterUserId { get; set; }

        public int OffendingChatUserId { get; set; }

        public string Explination { get; set; }

        public DateTimeOffset ReportedOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
    }

    public enum BeefSeverity
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
