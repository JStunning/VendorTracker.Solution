using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {

    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public int Price { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string title, string description)
    {
      Title = title;
      Description = description;
      Date = "Today";
      _instances.Add(this);
      Id = _instances.Count;
      Price = Id * 5;
    }

    public static List<Order> GetAll()
    {
        return _instances;
    }

    public static void ClearAll()
    {
        _instances.Clear();
    }

    public static Order FindOrder(int searchId)
    {
        return _instances[searchId - 1];
    }
  }
}