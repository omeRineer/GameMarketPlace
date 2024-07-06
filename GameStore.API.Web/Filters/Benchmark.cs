using Core.Entities.Concrete.ProcessGroups.Enums.Types;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Filters
{
    public class Benchmark : ActionFilterAttribute
    {
        readonly int MaxMilliseconds;
        readonly Stopwatch Stopwatch;
        readonly LogTypeEnum[] logTo;

        public Benchmark(int maxTimeout = 5000, params LogTypeEnum[] logTypes)
        {
            MaxMilliseconds = maxTimeout;
            Stopwatch = Stopwatch.StartNew();
            logTo = logTypes;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Stopwatch.Stop();

            double milliSeconds = Math.Round(Stopwatch.Elapsed.TotalMilliseconds, 2);

            if (milliSeconds > MaxMilliseconds)
                AlertTo(context, milliSeconds);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Stopwatch.Reset();
            Stopwatch.Start();
        }
        private void AlertTo(ActionExecutedContext context, double milliSeconds)
        {
            foreach (var logType in logTo)
            {
                switch (logType)
                {
                    case LogTypeEnum.Console:
                        break;

                    case LogTypeEnum.Debug:
                        break;

                    case LogTypeEnum.Notification:
                        NotificationHelper.Publish("Benchmark", NotificationTypeEnum.Warning, new
                        {
                            Action = context.ActionDescriptor.DisplayName,
                            Milliseconds = milliSeconds
                        });
                        break;

                }
            }
        }
    }
}
