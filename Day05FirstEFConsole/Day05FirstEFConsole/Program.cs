using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05FirstEFConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SocietyDbContext ctx = new SocietyDbContext();
                Random rnd = new Random();
                Person person = new Person { Name = "Zeen" + rnd.Next(100), Age = rnd.Next(100) };
                ctx.People.Add(person); // insert operation is scheduled but not executed yet!
                ctx.SaveChanges();
                Console.WriteLine("record added");

                
            }catch(SystemException ex)
            {
                Console.WriteLine("database operation failed: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
}
