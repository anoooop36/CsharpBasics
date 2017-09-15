using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1,2,3,4,5,5};
            List<int> list2 = new List<int> { 2,3,5,4};
            List<string> list3 = new List<string> { "aab","ac","aa","ab","aaa" };

            // each elemnet distinct in set
            Console.WriteLine("Distinct operation result perfromed on list:");
            var distinctList = list.Distinct();
            foreach (var item in distinctList)
            {
                Console.Write("{0} ",item);
            }

            // set intersection
            Console.WriteLine("\nIntersection of list and lists2:");
            var commonList = list.Intersect(list2);
            foreach (var item in commonList)
            {
                Console.Write("{0} ",item);
            }

            //Union
            Console.WriteLine("\nUnion of list and list2:");
            var unionList = list.Union(list2);
            foreach (var item in unionList)
            {
                Console.Write("{0} ",item);
            }

            //set difference using Except.
            Console.WriteLine("\nSet difference between list and list2:");
            var diffList = list.Except(list2);
            foreach (var item in diffList)
            {
                Console.Write("{0} ",item);
            }

            //sorting based on single parameter
            Console.WriteLine("\nSorting result on list3 based on length of string:");
            var sortedList=list3.OrderBy(x=>x.Length);
            foreach (var item in sortedList)
            {
                Console.Write("{0} ",item);
            }

            //thenby
            Console.WriteLine("\nSorting list based on second parameter string itself");
            var sortedListUsesThenBy = list3.OrderBy(x => x.Length).ThenBy(x=>x);
            foreach (var item in sortedListUsesThenBy)
            {
                Console.Write("{0} ",item);
            }

            bool checkIntegerNonZero = list.All(x=>x>1);
            Console.WriteLine("\nAll operation performed on list: {0}",checkIntegerNonZero);
            Console.ReadKey();
        }
    }
}
