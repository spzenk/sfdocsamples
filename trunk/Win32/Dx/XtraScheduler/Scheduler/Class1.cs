using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler;

namespace Scheduler
{
    public class CustomTimeScaleDay : TimeScaleDay
    {
        public override DateTime Floor(DateTime date)
        {
            if (date == DateTime.MinValue)
                return date.AddHours(8);

            DateTime start = base.Floor(date);
            if (date.Hour < 8)
                start = start.AddDays(-1);

            return start.AddHours(8);
        }
    }

    public class CustomTimeScaleHour : TimeScale
    {
        private const int StartHour = 10;
        private const int FinishHour = 1;

        protected override string DefaultDisplayFormat { get { return "HH:mm"; } }
        protected override string DefaultMenuCaption { get { return "10:00-12:30"; } }

        protected override TimeSpan SortingWeight
        {
            get { return TimeSpan.FromHours(FinishHour - StartHour + 1); }
        }
        public override DateTime Floor(DateTime date)
        {
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
                return RoundToHour(date, date.Hour);

            if (date.Hour < StartHour)
                // Round down to the end of the previous working day.
                return RoundToHour(date.AddDays(-1), FinishHour);

            if (date.Hour > FinishHour)
                // Round down to the end of the current working day.
                return RoundToHour(date, FinishHour);

            return RoundToHour(date, date.Hour);
        }
        protected DateTime RoundToHour(DateTime date, int hour)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
        }
        protected override bool HasNextDate(DateTime date)
        {
            return date <= RoundToHour(DateTime.MaxValue, FinishHour);
        }
        public override DateTime GetNextDate(DateTime date)
        {
            return (date.Hour > FinishHour - 1) ? RoundToHour(date.AddDays(1), StartHour) : date.AddHours(1);
        }
    }
}
