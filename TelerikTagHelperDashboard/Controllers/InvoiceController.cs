using System;
using System.Linq;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace TelerikTagHelperDashboard.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly NorthwindDBContext db;

        public InvoiceController(NorthwindDBContext context)
        {
            db = context;
        }

        public ActionResult Invoices_Read([DataSourceRequest]DataSourceRequest request,
            string salesPerson,
            DateTime statsFrom,
            DateTime statsTo)
        {
            // For demo purposes, if a salesPerson is empty, we'll set some defaults.
            if (string.IsNullOrEmpty(salesPerson))
            {
                salesPerson = db.Employees.First().FullName;
                statsFrom = new DateTime(1996, 1, 1);
                statsTo = new DateTime(1998, 1, 1);
            }
            var invoices = db.Invoices.Where(inv => inv.Salesperson == salesPerson)
                .Where(inv => inv.OrderDate >= statsFrom && inv.OrderDate <= statsTo);
            DataSourceResult result = invoices.ToDataSourceResult(request, invoice => new
            {
                invoice.OrderID,
                invoice.CustomerName,
                invoice.OrderDate,
                invoice.ProductName,
                invoice.UnitPrice,
                invoice.Quantity,
                invoice.Salesperson
            });

            return Json(result);
        }
    }
}