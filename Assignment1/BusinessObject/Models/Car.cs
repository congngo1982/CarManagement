using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string? Color { get; set; }

    public string? Manufacture { get; set; }

    public int? Category { get; set; }

    public virtual Category? CategoryNavigation { get; set; }

    public Car(string name, string brand, string? color, string? manufacture, int? category, Category? categoryNavigation)
    {
        Name = name;
        Brand = brand;
        Color = color;
        Manufacture = manufacture;
        Category = category;
    }

    public Car(string name, string brand, string? color, string? manufacture, int? category)
    {
        Name = name;
        Brand = brand;
        Color = color;
        Manufacture = manufacture;
        Category = category;
    }

    public Car() { }
}
