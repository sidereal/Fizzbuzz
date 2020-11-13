using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Fizzbuzz.Model;

namespace Fizzbuzz
{
    static class FizzBuzzer
    {

        public static event EventHandler<string> FizzBuzzing;


        /// <summary>
        /// Traditional fizzbuzz
        /// </summary>
        public static void Go()
        {
            for (int i = 1; i <= 100; i++)
            {
                string output = "";
                if (i % 3 == 0) output += "Fizz";
                if (i % 5 == 0) output += "Buzz";

                Console.WriteLine(output == "" ? i.ToString() : output);
            }
        }
        
        /// <summary>
        /// Passing in a parameter
        /// </summary>
        /// <param name="count"></param>
        public static void Go(int count)
        {
            if (!CheckCount(count)) return;

            for (int i = 1; i <= count; i++)
            {
                string output = "";
                if (i % 3 == 0) output += "Fizz";
                if (i % 5 == 0) output += "Buzz";

                Console.WriteLine(output == "" ? i.ToString() : output);
            }
        }


        /// <summary>
        /// Passing in more customisation options
        /// </summary>
        /// <param name="count"></param>
        /// <param name="fizz"></param>
        /// <param name="buzz"></param>
        public static void Go(int count, string fizz = "Fizz", string buzz = "Buzz")
        {
            if (!CheckCount(count)) return;

            for (int i = 1; i <= count; i++)
            {
                string output = "";
                if (i % 3 == 0) output += fizz;
                if (i % 5 == 0) output += buzz;

                Console.WriteLine(output == "" ? i.ToString() : output);
            }
        }


        /// <summary>
        /// passing in our customisation as 'complex' class objects
        /// </summary>
        /// <param name="count"></param>
        /// <param name="parametersList"></param>
        public static void Go(int count, List<FizzBuzzParameters> parametersList)
        {
            if (!CheckCount(count)) return;
            if (parametersList is null) return;

            for (int i = 1; i <= count; i++)
            {
                string output = "";
                foreach (var pl in parametersList)
                {
                    if (i % pl.Number == 0) output += pl.Text;
                }
                Console.WriteLine(output == "" ? i.ToString() : output);
            }
        }

        /// <summary>
        /// Firing an event with our result
        /// </summary>
        public static void GoEvent()
        {
            for (int i = 1; i <= 100; i++)
            {
                string output = "";
                if (i % 3 == 0) output += "Fizz";
                if (i % 5 == 0) output += "Buzz";

                FizzBuzzing(null, output == "" ? i.ToString() : output);
            }
        }

        /// <summary>
        /// using Parallel.ForEach to parallelise the work
        /// with optional sorting of the results
        /// </summary>
        /// <param name="count"></param>
        /// <param name="parametersList"></param>
        /// <param name="sorted"></param>
        public static void GoParallel(int count, List<FizzBuzzParameters> parametersList, bool sorted = false)
        {
            if (!CheckCount(count)) return;
            if (parametersList is null) return;
            

            var countList = Enumerable.Range(1, count).ToList();
            ConcurrentBag<FizBuzzResults> results = new ConcurrentBag<FizBuzzResults>();

            Parallel.ForEach<int>(countList, (n) =>
            {
                string output = "";
                foreach (var pl in parametersList)
                {
                    if (n % pl.Number == 0) output += pl.Text;
                }
                results.Add(new FizBuzzResults { Number = n, Text = output });
            });

            var resultsList = results.ToList();
            if (sorted) resultsList =  resultsList.OrderBy(r => r.Number).ToList();
            
            foreach (var item in resultsList)
            {
                Console.WriteLine(string.IsNullOrEmpty(item.Text) ? item.Number.ToString() : item.Text);
            }
        }

        /// <summary>
        /// using Task to parallelise the work
        /// with optional sorting of the results
        /// </summary>
        /// <param name="count"></param>
        /// <param name="parametersList"></param>
        /// <param name="sorted"></param>
        public static void GoTasks(int count, List<FizzBuzzParameters> parametersList, bool sorted = false)
        {
            if (!CheckCount(count)) return;
            if (parametersList is null) return;

            var countList = Enumerable.Range(1, count).ToList();
            ConcurrentBag<FizBuzzResults> results = new ConcurrentBag<FizBuzzResults>();
            List<Task> tasks = new List<Task>();

            foreach (var number in countList)
            {
                tasks.Add(Task.Run(() =>
                {
                    string output = "";
                    foreach (var pl in parametersList)
                    {
                        if (number % pl.Number == 0) output += pl.Text;
                    }
                    results.Add(new FizBuzzResults { Number = number, Text = output });
                }
                ));
            }
            Task.WaitAll(tasks.ToArray());

            var resultsList = results.ToList();
            if (sorted) resultsList = resultsList.OrderBy(r => r.Number).ToList();

            foreach (var item in resultsList)
            {
                Console.WriteLine(string.IsNullOrEmpty(item.Text) ? item.Number.ToString() : item.Text);
            }
        }

        /// <summary>
        /// sanity checker for the count input
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        static bool CheckCount(int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("count must be > 0");
                return false;
            }
            return true;
        }

    }
}


