using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;


namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("name", "description");
      string resultName = newVendor.Name;
      string resultDescription = newVendor.Description;
      int resultId = newVendor.Id;

      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
      Assert.AreEqual(resultName, "name");
      Assert.AreEqual(resultDescription, "description");
      Assert.AreEqual(resultId, 1);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      //Arrange
      Vendor newVendor1 = new Vendor("name1", "description1");
      Vendor newVendor2 = new Vendor("name2", "description2");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      Vendor newVendor1 = new Vendor("name1", "description1");
      Vendor newVendor2 = new Vendor("name2", "description2");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }
  }
}