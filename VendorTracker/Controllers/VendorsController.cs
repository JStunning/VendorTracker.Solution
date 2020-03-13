using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
    public class VendorsController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index() 
        {
            List<Vendor> allVendors = Vendor.GetAll();
            return View(allVendors); 
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }


        [HttpPost("/vendors")]
        public ActionResult Create(string vendorName, string VendorDescription)
        {
            Vendor newVendor = new Vendor(vendorName, VendorDescription);
            return RedirectToAction("Index");
        }

        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor selectedVendor = Vendor.FindVendor(id);
            List<Order> vendorOrders = selectedVendor.Orders;
            model.Add("vendor", selectedVendor);
            model.Add("orders", vendorOrders);
            return View(model);
        }

        // This one creates new Orders within a given Vendor, not new Categories:
        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string orderDescription, string orderTitle)
        {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vendor foundVendor = Vendor.FindVendor(vendorId);
        Order newOrder = new Order(orderTitle, orderDescription);
        foundVendor.AddOrder(newOrder);
        List<Order> vendorOrders = foundVendor.Orders;
        model.Add("orders", vendorOrders);
        model.Add("vendor", foundVendor);
        return View("Show", model);
        }
    }
}