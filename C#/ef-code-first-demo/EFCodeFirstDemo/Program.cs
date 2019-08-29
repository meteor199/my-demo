using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "server=127.0.0.1;user id=root;password=123456;persistsecurityinfo=True;database=blogging";
            using (var db = new BloggingContext(s))
            {

                Console.Write("Enter a name for a new Blog:");
                var name = Console.ReadLine();

                var blogs = new blogs() { Name = name };
                db.blogs.Add(blogs);
                db.SaveChanges();

                var query = from b in db.blogs
                            orderby b.Name
                            select b;
                Console.WriteLine("All blogs in the database:");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
