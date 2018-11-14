using System;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TelerikTagHelperDashboard.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly NorthwindDBContext db;

        public EmployeesController(NorthwindDBContext context)
        {
            db = context;
        }

        public JsonResult Employees_Read(int? employeeId)
        {
            // Get employees who report to employeeId (null for root nodes)
            var employees = db.Employees.Where(employee => employeeId.HasValue ? employee.ReportsTo == employeeId : employee.ReportsTo == null);

            // Project the results
            var result = employees.Select(employee => new
            {
                employee.EmployeeId,
                employee.FullName,
                HasChildren = employee.Employees.Any()
            }).ToList();

            return Json(result);
        }

        public IActionResult EmployeeQuarterSales(int employeeId, DateTime statsTo)
        {
            DateTime startDate = statsTo.AddMonths(-3);

            var result = EmployeeQuarterSalesQuery(employeeId, statsTo, startDate);

            return Json(result);
        }

        public IActionResult EmployeeAverageSales(int employeeId, DateTime statsFrom, DateTime statsTo)
        {
            var result = EmployeeAverageSalesQuery(employeeId, statsFrom, statsTo);

            return Json(result);
        }

        private IEnumerable<MonthlySalesByEmployeeViewModel> EmployeeAverageSalesQuery(int employeeId, DateTime statsFrom, DateTime statsTo)
        {
            var result = (from allSales in
                                            (from o in db.Orders
                                             join od in db.Order_Details on o.OrderID equals od.OrderID
                                             where o.EmployeeID == employeeId && o.OrderDate >= statsFrom && o.OrderDate <= statsTo
                                             select new
                                             {
                                                 EmployeeID = o.EmployeeID,
                                                 Date = o.OrderDate,
                                                 Sales = od.Quantity * od.UnitPrice
                                             }
                                                ).ToList()
                          group allSales by new DateTime(allSales.Date.Value.Year, allSales.Date.Value.Month, 1) into g
                          select new MonthlySalesByEmployeeViewModel
                          {
                              EmployeeID = g.FirstOrDefault().EmployeeID,
                              EmployeeSales = g.Sum(x => x.Sales),
                              Date = g.Key,
                          }
            );

            return result;
        }

        private IEnumerable<QuarterToDateSalesViewModel> EmployeeQuarterSalesQuery(int employeeId, DateTime statsTo, DateTime startDate)
        {
            var sales = db.Orders.Where(w => w.EmployeeID == employeeId)
                .Join(db.Order_Details, orders => orders.OrderID, orderDetails => orderDetails.OrderID, (orders, orderDetails) => new { Order = orders, OrderDetails = orderDetails })
                .Where(d => d.Order.OrderDate >= startDate && d.Order.OrderDate <= statsTo).ToList()
                .Select(o => new QuarterToDateSalesViewModel
                {
                    Current = (o.OrderDetails.Quantity * o.OrderDetails.UnitPrice) - (o.OrderDetails.Quantity * o.OrderDetails.UnitPrice * (decimal)o.OrderDetails.Discount)
                });
            //TODO: Generate the target based on team's average sales
            return new List<QuarterToDateSalesViewModel>
                {
                     new QuarterToDateSalesViewModel
                     {
                         Current = sales.Sum(s=>s.Current),
                         Target = 15000,
                         OrderDate = statsTo
                     }
                };
        }
    }
}
