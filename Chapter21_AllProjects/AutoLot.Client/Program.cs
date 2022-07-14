using System;
using System.Linq;
using System.Collections.Generic;
using AutoLot.Dal.BulkCopy;
using AutoLot.Dal.Model;
using AutoLot.Dal.DataOperations;

InventoryDal dal = new();

List<CarViewModel> ls = dal.GetAllInventory();
Console.WriteLine("*** Inventory ***");
Console.WriteLine("id\tMake\tColor\tName");
foreach (var x in ls) Console.WriteLine($"{x.Id}\t{x.Make}\t{x.Color}\t{x.PetName}");
Console.WriteLine();

CarViewModel c = dal.GetCarById(ls.OrderBy(i=>i.Color).Select(i=>i.Id).First());
Console.WriteLine("*** First by color ***");
Console.WriteLine("id\tMake\tColor\tName");
Console.WriteLine($"{c.Id}\t{c.Make}\t{c.Color}\t{c.PetName}");
Console.WriteLine();

try
{
    dal.DeleteCarById(5); // in order
    Console.WriteLine("Called DELETE");
}
catch (Exception e)
{
    Console.WriteLine($"An exception occured: {e.Message}");
    Console.WriteLine();
}

dal.AddCar(new() { Color = "Blue", MakeId = 5, PetName = "TowMonster" });
ls = dal.GetAllInventory();
var newCar = ls.First(n => n.PetName == "TowMonster");
Console.WriteLine("*** New car ***");
Console.WriteLine("id\tMake\tColor\tName");
Console.WriteLine($"{newCar.Id}\t{newCar.Make}\t{newCar.Color}\t{newCar.PetName}");
Console.WriteLine();

dal.DeleteCarById(newCar.Id);
Console.WriteLine("Called DELETE");
Console.WriteLine();

var name = dal.GetCarNameSP(c.Id);
Console.WriteLine("*** Stored procedure result ***");
Console.WriteLine($"res: {name}");

// FlagCustomer();
// DoBulkCopy();

void FlagCustomer()
{
    Console.WriteLine("*** Testing transaction ***");
    bool throwEx = true;
    Console.WriteLine("Throw? [Y] or [N]:");
    string input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) || input.Equals("N", StringComparison.OrdinalIgnoreCase))
    {
        throwEx = false;
    }
    InventoryDal dal = new();
    dal.ProcessCreditRisk(throwEx, 1);
    Console.WriteLine("Check CreditRisks table");
}
void DoBulkCopy()
{
    Console.WriteLine("*** Do Bulk ***");

    List<Car> cars = new()
    {
        new() { Color = "Blue", MakeId = 1, PetName = "Car1" },
        new() { Color = "Red", MakeId = 2, PetName = "Car2" },
        new() { Color = "White", MakeId = 3, PetName = "Car3" },
        new() { Color = "Yellow", MakeId = 4, PetName = "Car4" },
    };

    ProcessBulkCopy.ExecuteBulkCopy(cars, "Inventory");

    InventoryDal dal = new();

    List<CarViewModel> ls = dal.GetAllInventory();

    Console.WriteLine("*** Inventory ***");
    Console.WriteLine("CarId\tMake\tColor\tName");
    foreach (var x in ls) Console.WriteLine($"{x.Id}\t{x.Make}\t{x.Color}\t{x.PetName}");
    Console.WriteLine();
}