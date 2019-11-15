using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;

namespace PoCNewIds
{
    class Program
    {
        static void Main(string[] args)
        {
            var id = new NewId("11790000-cf25-b808-dc58-08d367322210");

            Console.WriteLine($"ToGuid {id.ToGuid()}");
            Console.WriteLine($"ToSequentialGuid {id.ToSequentialGuid()}");
            Console.WriteLine($"ToString {id.ToString()}");

            Console.WriteLine("\r\n\r\n");

            Enumerable.Range(0, 50).Select(item => {
                var idNext = NewId.Next();

                Console.WriteLine($"{item} ToString: {idNext.ToString()} \t Timestamp: {idNext.Timestamp.Millisecond}");

                return item;
            }).ToArray();
        }
    }
}
