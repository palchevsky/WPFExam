using ERP.Model;
using System;

namespace ERP

{
    public class Task
    {
        static readonly Random Rnd = new Random();

        #region Properties
        public Customer Customer { get; set; }

        public ProjectNames ProjectName { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        public int PercentCompleted { get; set; }
        #endregion

        public Task()
        {
            //Generate random tasks for employees
            Array values = Enum.GetValues(typeof(Customer));
            Customer = (Customer)values.GetValue(Rnd.Next(values.Length));
            values = Enum.GetValues(typeof(ProjectNames));
            ProjectName = (ProjectNames)values.GetValue(Rnd.Next(values.Length));
            DateBegin = new DateTime(Rnd.Next(2006, 2017), Rnd.Next(1, 12), Rnd.Next(1, 28));
            DateEnd = DateBegin.AddDays(Rnd.Next(7, 100));
            PercentCompleted = Rnd.Next(0, 100);
        }

    }
}
