using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MOD6._7HW2
{
    class Query
    {
        //creating new context to be able to access the data in the DB
        static SchoolGradesDBEntities context = new SchoolGradesDBEntities();
        static void Main(string[] args)
        {
            ViewWithLINQ();
        }

        public static void ViewWithLINQ()
            //using LINQ to query the data
        {
            IQueryable<SchoolGradesDBEntities> students = (IQueryable<SchoolGradesDBEntities>)(from e in context.Students
                                                              orderby e.LastName
                                                              select e);
            //displaying the results from the query.
            foreach(var lastname in students)
            {
                Console.WriteLine(lastname.Students);
            }

        }
    }
}
