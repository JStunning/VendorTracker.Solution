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
      int resultId = newOrder.Id;

      Assert.AreEqual(typeof(Order), newOrder.GetType());
      Assert.AreEqual(resultTitle, "title");
      Assert.AreEqual(resultDescription, "description");
      Assert.AreEqual(resultDate, "date");
      Assert.AreEqual(resultPrice, 0);
      Assert.AreEqual(resultId, 1);
    }

    [TestMethod]
    public void GetAll_ReturnsPropsOfOrder_OrderList()
    {
      //Arrange
      Order newOrder1 = new Order("title", "description", "date");
      Order newOrder2 = new Order("title", "description", "date");
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(result, newList);
    }

    [TestMethod]
    public void GetId_OrderInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      Order newOrder = new Order("title", "description", "date");

      //Act
      int result = newOrder.Id;

      //Assert
      Assert.AreEqual(result, 1);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      //Arrange
      Order newOrder1 = new Order("title", "description", "date");
      Order newOrder2 = new Order("title", "description", "date");

      //Act
      Order result = Order.Find(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }
  }
}