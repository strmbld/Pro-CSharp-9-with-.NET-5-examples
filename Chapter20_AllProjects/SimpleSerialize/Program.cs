using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using SimpleSerialize;

JsonSerializerOptions options = new()
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    IncludeFields = true,
    WriteIndented = true,
    NumberHandling = JsonNumberHandling.AllowReadingFromString // | JsonNumberHandling.WriteAsString,
};

// JsonSerializerOptions options = new(JsonSerializerDefaults.Web) { WriteIndented = true };

JamesBondCar jbc = new()
{
    canFly = true,
    canSubmerge = false,
    radio = new()
    {
        stationPresets = new() { 89.3, 105.1, 97.1 },
        hasTweeters = true,
    },
};
Person p = new()
{
    Name = "James",
    isAlive = true,
};

SaveXml(jbc, "CarData.xml");
Console.WriteLine("Saved CarData.xml");
SaveXml(p, "PersonData.xml");
Console.WriteLine("Saved PersonData.xml");
SaveXmlBatch();
Console.WriteLine("Saved CarCollection.xml");

JamesBondCar fromFile = ReadXml<JamesBondCar>("CarData.xml");
Console.WriteLine($"Orig: {jbc}");
Console.WriteLine($"From file: {fromFile}");

List<JamesBondCar> listFromFile = ReadXml<List<JamesBondCar>>("CarCollection.xml");
foreach (var c in listFromFile) Console.WriteLine(c);

ToJson(jbc, "CarData.json", options);
Console.WriteLine("Saved CarData.json");
ToJson(p, "PersonData.json", options);
Console.WriteLine("Saved PersonData.json");
ListToJson("CarCollection.json", options);

JamesBondCar savedJsonCar = ReadFromJsonFile<JamesBondCar>(options, "CarData.json");
Console.WriteLine("Read Car: {0}", savedJsonCar.ToString());

static void SaveXml<T>(T objGraph, string filename)
{
    XmlSerializer xmlFormat = new(typeof(T));
    using (Stream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        xmlFormat.Serialize(fs, objGraph);
    }
}
static void SaveXmlBatch()
{
    List<JamesBondCar> cars = new()
    {
        new JamesBondCar{ canFly = true, canSubmerge = true },
        new JamesBondCar { canFly = true, canSubmerge = false },
        new JamesBondCar { canFly = false, canSubmerge = true },
        new JamesBondCar { canFly = false, canSubmerge = false },
    };
    using(Stream fs = new FileStream("CarCollection.xml", FileMode.Create, FileAccess.Write, FileShare.None))
    {
        XmlSerializer xmlFormat = new(typeof(List<JamesBondCar>));
        xmlFormat.Serialize(fs, cars);
    }
}
static T ReadXml<T>(string filename)
{
    XmlSerializer xmlFormat = new(typeof(T));
    using(Stream fs = new FileStream(filename, FileMode.Open))
    {
        T obj = default;
        obj = (T)xmlFormat.Deserialize(fs);
        return obj;
    }
}
static void ToJson<T>(T objGraph, string filename, JsonSerializerOptions options)
{
    // var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true, };
    File.WriteAllText(filename, System.Text.Json.JsonSerializer.Serialize(objGraph, options));
}
static void ListToJson(string filename, JsonSerializerOptions options)
{
    List<JamesBondCar> cars = new()
    {
        new JamesBondCar { canFly = true, canSubmerge = true },
        new JamesBondCar { canFly = true, canSubmerge = false },
        new JamesBondCar { canFly = false, canSubmerge = true },
        new JamesBondCar { canFly = false, canSubmerge = false },
    };
    File.WriteAllText(filename, System.Text.Json.JsonSerializer.Serialize(cars, options));
}
static T ReadFromJsonFile<T>(JsonSerializerOptions options, string filename) =>
    System.Text.Json.JsonSerializer.Deserialize<T>(File.ReadAllText(filename), options);