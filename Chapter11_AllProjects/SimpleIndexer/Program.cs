using System;
using SimpleIndexer;

PersonCollectionStringIndexer map = new();
map["Homer"] = new("Homer", 40);
map["Marge"] = new("Marge", 38);
Console.WriteLine(map["Homer"]);
