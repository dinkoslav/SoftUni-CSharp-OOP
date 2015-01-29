using System;

namespace HumanStudentWorker
{
    class Worker : Human
    {
        private const int WorkDaysInWeek = 5;

        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("WeekSalary can not be negative!");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Work hours per day can not be negative!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            if (this.workHoursPerDay == 0)
            {
                return 0;
            }

            return (this.weekSalary / WorkDaysInWeek) / this.workHoursPerDay;
        }

        public override string ToString()
        {
            return base.ToString() + ", week salary: " + this.weekSalary + ", payment per hour: " +
                string.Format("{0:F2}", this.MoneyPerHour());
        }
    }
}
