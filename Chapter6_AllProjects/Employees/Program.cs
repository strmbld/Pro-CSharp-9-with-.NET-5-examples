using System;
using Employees;

Console.WriteLine("***** Inheritance *****");

SalesPerson fred = new SalesPerson { Name = "Fred", SalesNumber = 50 };
fred.Show();
Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
chucky.Show();
Console.WriteLine();
Console.WriteLine($"{chucky is Employee}");

double cost = chucky.GetBenefitCost();
Console.WriteLine(cost);

chucky.GiveBonus(300);
chucky.Show();
