using System;
using System.Collections.Generic;

using Fizzbuzz.Model;

namespace Fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FizzBuzzParameters> plist = new List<FizzBuzzParameters>() { new FizzBuzzParameters() { Number = 3, Text = "Fizz" }, new FizzBuzzParameters() { Number = 5, Text = "Buzz" } };
            //List<FizzBuzzParameters> plist = new List<FizzBuzzParameters>(){new FizzBuzzParameters(){Number=3,Text="Fizz"},new FizzBuzzParameters(){Number=5,Text="Buzz"},new FizzBuzzParameters(){Number=7,Text="Foo"}};
            //List<FizzBuzzParameters> plist = new List<FizzBuzzParameters>(){new FizzBuzzParameters(){Number=5},new FizzBuzzParameters(){Text="Buzz"}};

            // FizzBuzzer.Go();
            // FizzBuzzer.Go(50);
            // FizzBuzzer.Go(50,"aaa","bbb");
            // FizzBuzzer.GoParallel(50, plist);
            // FizzBuzzer.GoParallel(50, plist, true);
            // FizzBuzzer.GoTasks(50, plist);
            // FizzBuzzer.GoTasks(50, plist,true);


            Console.ReadLine();
        }
    }
}
