using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public static List<Vendor> _instances = new List<Vendor> { };
    public string Name { get; set; }
    public string Description { get; set; }
    public int Total { get; set; }
    public int Id { get; set; }
    public List<Order> Orders { get; set; }

    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order> { };
      Total = 0;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static Vendor FindVendor(int Id)
    {
      return _instances[Id - 1];
    }


    public void AddOrder(Order order)
    {
      Orders.Add(order);
      UpdateTotal();
    }

    public void UpdateTotal()
    {
      Total += 5;
    }
  }
}