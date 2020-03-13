using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;


namespace VendorTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("title", "description", "date");
      string resultTitle = newOrder.Title;
      string resultDescription = newOrder.Description;
      string resultDate = newOrder.Date;
      int resultPrice = newOrder.Price;

      Assert.AreEqual(typeof(Order), newOrder.GetType());
      Assert.AreEqual(resultTitle, "title");
      Assert.AreEqual(resultDescription, "description");
      Assert.AreEqual(resultDate, "date");
      Assert.AreEqual(resultPrice, 0);
    }
  }
}