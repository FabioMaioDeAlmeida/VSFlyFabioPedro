

namespace VSFlyFabioPedro
{
    class Program
    {
        static VSFlyContext ctx;

        static void Main(string[] args)
        {
            ctx = new VSFlyContext();

            var e = ctx.Database.EnsureCreated();

            if (e)
                Console.WriteLine("Database has been created");
            else
                Console.WriteLine("Database already exists");
            Console.WriteLine("Done");

        }
    }
}