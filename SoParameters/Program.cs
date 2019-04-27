using System;

namespace SoParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            var prms = new MyPatameters();  

            Console.WriteLine(prms.SomeParameters("Andres", "Descalzo", new DateTime(1975, 10, 14)));
            Console.WriteLine(prms.SomeParameters(firstName: "Andres", lastName: "Descalzo", birthDay: new DateTime(1975, 10, 14)));
            Console.WriteLine(prms.SomeParameters(firstName: "Andres", last: "Descalzo", birthDay: new DateTime(1975, 10, 14)));
        }
    }

    class MyPatameters
    {
        public string SomeParameters(string firstName, string lastName, DateTime birthDay)
        {
            return $"{firstName} | {lastName} | {birthDay}";
        }
    }
}
