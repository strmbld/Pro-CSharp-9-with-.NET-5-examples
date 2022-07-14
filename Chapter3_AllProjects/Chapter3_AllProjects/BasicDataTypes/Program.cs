using System;
using System.Numerics;

Console.WriteLine("************Primitives***********");
DefaultDeclarations();
ObjectFunctionality();
DataTypeFunctionality();
CharFunctionality();
Test tst = new Test();
tst.doSomething();
ParseFromString();
ParseFromStringsWithTryParse();
UseDateTime();
UseBigInteger();
DigitSeparators();
BinaryLiterals();

static void DefaultDeclarations()
{
    Console.WriteLine("********Default Declarations:");
    // string mInt = new();
    int i = new();
    int j = default;
    Console.WriteLine("i: {0}, j: {1}", i, j);
    // if (mInt == null) Console.WriteLine("NULL");

}

static void ObjectFunctionality()
{
    Console.WriteLine("=> System.Object Functionality:");
    // A C# int is really a shorthand for System.Int32,
    // which inherits the following members from System.Object.
    Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
    Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
    Console.WriteLine("12.ToString() = {0}", 12.ToString());
    Console.WriteLine("12.GetType() = {0}", 12.GetType());
    Console.WriteLine();
}

static void DataTypeFunctionality()
{
    Console.WriteLine("*********DATA TYPE FUNCTIONALITY*******");

    Console.WriteLine("MAX INT {0}", int.MaxValue);
    Console.WriteLine("MIN INT {0}", int.MinValue);
    Console.WriteLine("MAX DOUBLE {0}", double.MaxValue);
    Console.WriteLine("MIN DOUBLE {0}", double.MinValue);
    Console.WriteLine("double.Epsilon {0}", double.Epsilon);
    Console.WriteLine("double.PositiveInfinity {0}", double.PositiveInfinity);
    Console.WriteLine("double.NegativeInfinity {0}", double.NegativeInfinity);
    Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
    Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
    Console.WriteLine();
}

static void CharFunctionality()
{
    Console.WriteLine("******CHAR FUNCTIONALITY*******");
    char mChar = 'a';
    Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(mChar));
    Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(mChar));
    Console.WriteLine("char.IsWhiteSpace('a'): {0}", char.IsWhiteSpace(mChar));
    Console.WriteLine("char.IsWhiteSpace('hello there', 5): {0}", char.IsWhiteSpace("hello there", 5));
    Console.WriteLine("char.IsWhiteSpace('hello there', 6): {0}", char.IsWhiteSpace("hello there", 6));
    Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
    Console.WriteLine();
}

static void ParseFromString()
{
    Console.WriteLine("**********PARSE FROM STRINGS************");
    bool b = bool.Parse("TRUE");
    Console.WriteLine("Value b: {0}", b);
    double d = double.Parse("99.884");
    Console.WriteLine("Value d: {0}", d);
    int i = int.Parse("8");
    Console.WriteLine("Value i: {0}", i);
    char c = char.Parse("w");
    Console.WriteLine("value c: {0}", c);
    Console.WriteLine();

}

static void ParseFromStringsWithTryParse()
{
    Console.WriteLine("=> Data type parsing with TryParse:");
    if (bool.TryParse("True", out bool b))
    {
        Console.WriteLine("Value of b: {0}", b);
    }
    else
    {
        Console.WriteLine("Default value of b: {0}", b);
    }
    string value = "Hello";
    if (double.TryParse(value, out double d))
    {
        Console.WriteLine("Value of d: {0}", d);
    }
    else
    {
        Console.WriteLine("Failed to convert the input ({0}) to a double and the variable was " +
            "assigned the default {1}", value, d);
    }
    Console.WriteLine();
}

static void UseDateTime()
{
    Console.WriteLine("DATETIME");
    DateTime dt = new DateTime(2015, 10, 17);
    Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
    dt = dt.AddMonths(2);
    Console.WriteLine("Month now: {0}", dt.Month);
    Console.WriteLine("Daylight savings: {0}", dt.IsDaylightSavingTime());
    Console.WriteLine("TIMESPAN");
    TimeSpan ts = new TimeSpan(4, 30, 0);
    Console.WriteLine("TS: {0}", ts);
    Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));
    Console.WriteLine();
}

static void UseBigInteger()
{
    Console.WriteLine("***************BigInteger*******");
    BigInteger biggy = BigInteger.Parse("9999999999999999999999999999999999999999999999");
    Console.WriteLine("biggy value: {0}", biggy);
    Console.WriteLine("Even: {0}", biggy.IsEven);
    Console.WriteLine("is power of two: {0}", biggy.IsPowerOfTwo);
    BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("8888888888888888888888888888888888888888888"));
    Console.WriteLine("reallyBig value: {0}", reallyBig);
    Console.WriteLine();
}

static void DigitSeparators()
{
    Console.WriteLine("************Digit Separators*********");
    Console.Write("Int: ");
    Console.WriteLine(123_456);
    Console.Write("Long: ");
    Console.WriteLine(123_456_789L);
    Console.Write("Float: ");
    Console.WriteLine(123_456_1234F);
    Console.Write("Double: ");
    Console.WriteLine(123_456.12D);
    Console.Write("Decimal: ");
    Console.WriteLine(123_456.12M);
    Console.Write("Hex: ");
    Console.WriteLine(0x_00_00_FF);
}

static void BinaryLiterals()
{
    Console.WriteLine("***********Binary literals***********");
    Console.WriteLine("16: {0}", 0b_0001_0000);
    Console.WriteLine("32: {0}", 0b_0010_0000);
    Console.WriteLine("64: {0}", 0b_0100_0000);
}

struct Test
{
    public string name { get; set; }
    public void doSomething()
    {
        Console.WriteLine("Something done");
    }
}

