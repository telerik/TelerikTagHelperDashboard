using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelerikTagHelperDashboard
{
    public class Invoice
    {
        public string CustomerName { get; set; }
        [Key]
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public string Salesperson { get; set; }

    }
}