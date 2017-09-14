using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery = from student in Student.students
                                                where student.Scores[0] > 90
                                                orderby student.Scores[0] descending
                                                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1}, {2}",student.Last,student.First,student.Scores[0]);
            }

            var studentQuery2 = from student in Student.students
                                group student by student.Last[0] into studentGroup
                                orderby studentGroup.Key
                                select studentGroup;

            Console.WriteLine("\nResult of second Query with group by");
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key) ;
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine(" {0}, {1}",student.Last,student.First);
                }
            }

            //let keyword
            Console.WriteLine("\nResult of third query with let keyword");
            var studentQuery3 = from student in Student.students
                                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2]
                                select totalScore;

            //foreach (var item in studentQuery3)
            //{
            //    Console.WriteLine(item);
            //}

            double averageScore = studentQuery3.Average();

            Console.WriteLine("Average score of students is : {0}",averageScore);

            //project a new object in select
            Console.WriteLine("\n 4 Query result with specific projection");
            var studentQuery4 = from student in Student.students
                                select new { Name = student.First + " " + student.Last, Score = student.Scores[0] };

            foreach (var item in studentQuery4)
            {
                Console.WriteLine("Student Name: {0} and Score is: {1}",item.Name,item.Score);
            }
            Console.ReadKey();
        }
    }
}
