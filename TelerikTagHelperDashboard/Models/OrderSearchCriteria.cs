using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikTagHelperDashboard.Models
{
    public class OrderSearchCriteria
    {
        public int EmployeeId { get; set; }
        public string SalesPerson { get; set; }
        public DateTime StatsFrom { get; set; }
        public DateTime StatsTo { get; set; }

    }
}
