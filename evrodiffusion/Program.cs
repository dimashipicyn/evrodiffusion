using System;
using System.Collections.Generic;
using System.Linq;

namespace evrodiffusion
{
    class Program
    {
        static int caseNumber = 0;
        static void Main(string[] args)
        {
            try
            {
                Input input = new Input();
                input.Load("../../evro.in");


                foreach (List<CountryInfo> items in input.countries)
                {
                    DiffusionSimulator dfSim = new DiffusionSimulator(items);
                    dfSim.Simulate();

                    PrintStats(dfSim.stats);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void PrintStats(Dictionary<string, int> stats)
        {
            caseNumber++;

            var listStats = stats.ToList();
            listStats.Sort(delegate (KeyValuePair<string, int> l, KeyValuePair<string, int> r)
            {
                if (l.Value == r.Value)
                {
                    return string.Compare(l.Key, r.Key);
                }
                return l.Value - r.Value;
            });

            Console.WriteLine($"Case Number {caseNumber}");
            foreach (var stat in listStats)
            {
                Console.WriteLine($"    {stat.Key}    {stat.Value}");
            }
        }
    }
}
