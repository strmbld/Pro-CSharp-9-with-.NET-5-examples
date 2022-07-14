using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqExpressions;

// var res = from matchingItem in container select matchingItem
// var res = from item in container where bool_expr select item

ProductInfo[] items = new[]
{
    new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH", UnitsInStock = 24},
    new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love", UnitsInStock = 100},
    new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible", UnitsInStock = 120},
    new ProductInfo{ Name = "Crunchy Pops", Description = "Cheezy, peppery goodness", UnitsInStock = 2},
    new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet", UnitsInStock = 100},
    new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", UnitsInStock = 73},
};

SelectAll(items);
SelectAllNames(items);
GetOver25(items);
Get2Columns(items);
GetTypedSet(items);
GetCountFromQuery();
OrderByName(items);
Diff(); // Except()
Intersection();
Union();
Concat();
Distinct();
AggregateFuncs();

static void SelectAll(ProductInfo[] items)
{
    var all = from p in items select p;
    foreach (var i in all) Console.WriteLine(i.ToString());
    Console.WriteLine();
}
static void SelectAllNames(ProductInfo[] items)
{
    var names = from p in items select p.Name;
    foreach (var n in names) Console.WriteLine(n);
    Console.WriteLine();
}
static void GetOver25(ProductInfo[] items)
{
    var over = from p in items where p.UnitsInStock > 25 select p;
    foreach (var o in over) Console.WriteLine(o.ToString());
    Console.WriteLine();
}
static void Get2Columns(ProductInfo[] items)
{
    var nameDesc = from p in items select new { p.Name, p.Description };
    foreach (var row in nameDesc) Console.WriteLine(row.ToString());
    Console.WriteLine();
}
static Array GetProjectedSubset(ProductInfo[] products)
{
    // can't return var
    var nameDesc =
    from p in products select new { p.Name, p.Description };
    // Map set of anonymous objects to an Array object.
    return nameDesc.ToArray(); // lost types, everything is object
}
static void GetTypedSet(ProductInfo[] items)
{
    IEnumerable<ProductInfoSmall> nameDesc =
        from p
        in items
        select new ProductInfoSmall
        { Name = p.Name, Description = p.Description };
    foreach (ProductInfoSmall i in nameDesc) Console.WriteLine(i.ToString());
    Console.WriteLine();
}
static void GetCountFromQuery()
{
    string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
    // Get count from the query.
    int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();
    // Print out the number of items.
    Console.WriteLine("{0} items honor the LINQ query.", numb);
    Console.WriteLine();
}
static void OrderByName(ProductInfo[] items)
{
    var orderedASC = from p in items orderby p.Name select p;
    Console.WriteLine("ASC:");
    foreach (var o in orderedASC) Console.WriteLine(o.ToString());
    Console.WriteLine();
    var orderedDESC = from p in items orderby p.Name descending select p;
    Console.WriteLine("DESC:");
    foreach (var oD in orderedDESC) Console.WriteLine(oD.ToString());
    Console.WriteLine();
    Console.WriteLine("desc reversed:");
    foreach (var ord in orderedDESC.Reverse()) Console.WriteLine(ord.ToString());
    Console.WriteLine();
}
static void Diff()
{
    List<string> cars1 = new() { "Yugo", "Aztec", "BMW" };
    List<string> cars2 = new(){ "BMW", "Saab", "Aztec" };
    var diff = (from c1 in cars1 select c1).Except(from c2 in cars2 select c2);
    foreach (var d in diff) Console.WriteLine(d);
    Console.WriteLine();
}
static void Intersection()
{
    List<string> cars1 = new() { "Yugo", "Aztec", "BMW" };
    List<string> cars2 = new() { "BMW", "Saab", "Aztec" };
    var inter = (from c1 in cars1 select c1).Intersect(from c2 in cars2 select c2);
    foreach (var i in inter) Console.WriteLine(i);
    Console.WriteLine();
}
static void Union()
{
    // returns common items without repetition (unique)
    List<string> cars1 = new() { "Yugo", "Aztec", "BMW" };
    List<string> cars2 = new() { "BMW", "Saab", "Aztec" };
    var union = (from c1 in cars1 select c1).Union(from c2 in cars2 select c2);
    foreach (var u in union) Console.WriteLine(u);
    Console.WriteLine();
}
static void Concat()
{
    // direct concatenation of one result set with another
    List<string> cars1 = new() { "Yugo", "Aztec", "BMW" };
    List<string> cars2 = new() { "BMW", "Saab", "Aztec" };
    var concat = (from c1 in cars1 select c1).Concat(from c2 in cars2 select c2);
    foreach (var cat in concat) Console.WriteLine(cat);
    Console.WriteLine();
}
static void Distinct() // 'post-union'~remove dupes
{
    List<string> cars1 = new() { "Yugo", "Aztec", "BMW" };
    List<string> cars2 = new() { "BMW", "Saab", "Aztec" };
    var concat = (from c1 in cars1 select c1).Concat(from c2 in cars2 select c2);
    foreach (var cat in concat.Distinct()) Console.WriteLine(cat);
    Console.WriteLine();
}
static void AggregateFuncs()
{
    double[] temps = { 2.0, -21.3, 8, -4, 0, 8.2 };
    Console.WriteLine($"Max(): {(from t in temps select t).Max()}");
    Console.WriteLine($"Min(): {(from t in temps select t).Min()}");
    Console.WriteLine($"Avg(): {(from t in temps select t).Average()}");
    Console.WriteLine($"Sum(): {(from t in temps select t).Sum()}");
    Console.WriteLine();
}