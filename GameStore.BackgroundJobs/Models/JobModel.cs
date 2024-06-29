using System;
using System.Linq.Expressions;

namespace BackgroundJobs.Models
{
    public class JobModel
    {
        public string JobName { get; set; }
        public Expression<Action> Action { get; set; }
    }
}
