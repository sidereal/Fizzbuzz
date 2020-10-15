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

        public static void Go(int count)
        {
            if (count < 0) 
            {
                Console.WriteLine("count must be > 0");
                return;
            }
            for (int i = 1; i <= count; i++)
            {
                string output = "";
                if (i % 3 == 0) output += "Fizz";
                if (i % 5 == 0) output += "Buzz";

                Console.WriteLine(output == "" ? i.ToString() : output);
            }
        }

        public static void Go(int count, string fizz = "Fizz", string buzz = "Buzz")
        {
            if (count < 0) 
            {
                Console.WriteLine("count must be > 0");
                return;
            }
            for (int i = 1; i <= count; i++)
            {
                string output = "";
                if (i % 3 == 0) output += fizz;
                if (i % 5 == 0) output += buzz;

                Console.WriteLine(output == "" ? i.ToString() : output);
            }
        }

        public static void Go(int count, List<FizzBuzzParameters> parametersList)
        {
            if (count < 0) 
            {
                Console.WriteLine("count must be > 0");
                return;
            }
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

        public static void GoParallel(int count, List<FizzBuzzParameters> parametersList)
        {
            if (count < 0) 
            {
                Console.WriteLine("count must be > 0");
                return;
            }
            var countList = Enumerable.Range(1, count).ToList();
            ConcurrentBag<string> results = new ConcurrentBag<string>();

            Parallel.ForEach<int>(countList, (n) =>
            {
                string output = "";
                foreach (var pl in parametersList)
                {
                    if (n % pl.Number == 0) output += pl.Text;
                }
                results.Add(output == "" ? n.ToString() : output);
            });

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static void GoParallelSorted(int count, List<FizzBuzzParameters> parametersList)
        {
            if (count < 0) 
            {
                Console.WriteLine("count must be > 0");
                return;
            }
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
            var sortedList = results.OrderBy(r => r.Number).ToList();
            foreach (var item in sortedList)
            {
                Console.WriteLine(string.IsNullOrEmpty(item.Text) ? item.Number.ToString() : item.Text);
            }
        }

        public static void GoTasks(int count, List<FizzBuzzParameters> parametersList)
        {
            if (count < 0) 
            {
                Console.WriteLine("count must be > 0");
                return;
            }
            var countList = Enumerable.Range(1, count).ToList();
            ConcurrentBag<string> results = new ConcurrentBag<string>();
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
                    results.Add(output == "" ? number.ToString() : output);
                }
                ));
            }
            Task.WaitAll(tasks.ToArray());
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static void GoTasksSorted(int count, List<FizzBuzzParameters> parametersList)
        {
            if (count < 0) 
            {
                Console.WriteLine("count must be > 0");
                return;
            }
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
            var sortedList = results.OrderBy(r => r.Number).ToList();
            foreach (var item in sortedList)
            {
                Console.WriteLine(string.IsNullOrEmpty(item.Text) ? item.Number.ToString() : item.Text);
            }
        }

    }
}


