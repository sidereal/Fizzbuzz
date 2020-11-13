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

            //Hooking up the event for FizzBuzzer.GoEvent()
            FizzBuzzer.FizzBuzzing += FizzBuzzer_FizzBuzzing;


            //Uncomment an option and go >

            FizzBuzzer.Go();
            
            //FizzBuzzer.Go(50);
            //FizzBuzzer.Go(50, "aaa", "bbb");
            //FizzBuzzer.Go(50,plist);
            
            //FizzBuzzer.GoEvent();
            
            //FizzBuzzer.GoParallel(50, plist);
            //FizzBuzzer.GoParallel(50, plist, true);
            
            //FizzBuzzer.GoTasks(50, plist);
            //FizzBuzzer.GoTasks(50, plist, true);
            Console.ReadLine();
        }

        /// <summary>
        /// Handler for the FizzBuzzer.FizzBuzzing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void FizzBuzzer_FizzBuzzing(object sender, string e)
        {
            Console.WriteLine(e);
        }
    }
}
