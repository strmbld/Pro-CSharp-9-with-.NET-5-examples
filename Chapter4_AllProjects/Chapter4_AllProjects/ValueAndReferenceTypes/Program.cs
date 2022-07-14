using System;

namespace ValueAndReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value and Reference types");

            ValueTypeCompositionRefType();

            Console.WriteLine("Created person object");
            Person fred = new Person("Fred", 12);
            Console.WriteLine(fred.ToString());
            Console.WriteLine("Now trying to change with pass by value");
            PassRefTypeByValue(fred);
            Console.WriteLine("Changed object:");
            Console.WriteLine(fred.ToString());
            string s1 = "passing ref type object by value you copy reference to object in memory\n" +
                "so if you make some changes to object they become persisted and visible for all other references\n" +
                "since it's same object after all\n" +
                "but since you passed ref type object by value you got just local copy of reference\n" +
                "and w/e you'd undertake to change this reference like re-assign it to another or new object\n" +
                "it's only visible for local reference and other references to passed refType object\n" +
                "just don't care\n";
            Console.WriteLine(s1);
            Console.WriteLine();

            Console.WriteLine("PASSING REF TYPE OBJ BY REF");
            Person p1 = new Person("Mel", 23);
            Console.WriteLine($"Created person obj: {p1.ToString()}");
            Console.WriteLine("Passing by ref now");
            PassRefTypeByReference(ref p1);
            Console.WriteLine($"After call: {p1.ToString()}");
            string s2 = "passing ref type by ref you have strong reference in method local scope\n" +
                "i.e. direct access to object in memory~~memory itself\n" +
                "so you may apply some changes to object which will be visible for all references to this object\n" +
                "or you may even delete, overwrite etc this object~~edit memory itself\n" +
                "what will affect all references to this memory address\n";
            Console.WriteLine(s2);
            Console.WriteLine();

            string s = "new string";
            Console.WriteLine($"created string: {s}");
            Console.WriteLine("Called method");
            PassStringByValue(s);
            Console.WriteLine($"string now: {s}");
        }

        static void PassStringByValue(string s)
        {
            //s = "__suffix";
            s += "__suffix";
        }

        static void PassStringByRef(ref string s)
        {
            s += "__suffix";
        }
        static void PassRefTypeByReference(ref Person p)
        {
            p.age = 555;
            Console.WriteLine($"intermediate changes: {p.ToString()}");
            p = new Person("haaaa", 9999);
        }
        static void PassRefTypeByValue(Person p)
        {
            p.age = 99;
            p = new Person("Ivan", 228);
        }

        static void ValueTypeCompositionRefType()
        {
            Console.WriteLine("Creating r1");
            Rectangle r1 = new Rectangle("First Rectangle", 10, 10, 50, 50);
            Console.WriteLine($"r1 info: {r1.getInfo()}");
            Console.WriteLine("Assigning r1 to r2");
            Rectangle r2 = r1;
            Console.WriteLine($"r2 info: {r2.getInfo()}");
            Console.WriteLine("Changing info in r2");
            r2.shapeInfo.InfoString = "new info";
            Console.WriteLine($"now r2 info is: {r2.getInfo()} and r1 info(was 'First Rectangle') is: {r1.getInfo()} yeah changed aswell");
            string s = "cloning value type containing reference type in composition leads to\n" +
                "copying value types by values like deep copy and so getting new instances\n" +
                "but for reference types in composition just reference got copied so\n" +
                "there is no new ref type instance but just another reference on same object in memory\n" +
                "reference type object becomes like shared resource for intances containing this object\n";
            Console.WriteLine(s);
            Console.WriteLine();
        }
    }

    class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return "Person: name = " + this.name + ", age = " + this.age;
        }
    }
    struct Rectangle
    {
        public ShapeInfo shapeInfo;

        public int RectTop, RectLeft, RectBottom, RectRight;

        public Rectangle(string shapeInfo, int rectTop, int rectLeft, int rectBottom, int rectRight)
        {
            this.shapeInfo = new ShapeInfo(shapeInfo);
            RectTop = rectTop;
            RectLeft = rectLeft;
            RectBottom = rectBottom;
            RectRight = rectRight;
        }

        public string getInfo()
        {
            return shapeInfo.InfoString;
        }
    }
    class ShapeInfo
    {
        public string InfoString { get; set; }

        public ShapeInfo(string infoString)
        {
            InfoString = infoString;
        }
    }
}
