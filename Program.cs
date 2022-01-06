using System;
using System.Collections.Generic;

namespace CSh_Lab_10
{
    
    class Program
    { 
        static void Main(string[] args)
        {
            ResearchTeam RT1 = new ResearchTeam("one", "ural", 2, TimeFrame.Year);
            ResearchTeam RT2 = new ResearchTeam("two", "bash", 3, TimeFrame.TwoYears);
            ResearchTeam RT3 = new ResearchTeam("three", "tat", 5, TimeFrame.Year);
            ResearchTeamCollection RTs = new ResearchTeamCollection();
            RTs.AddDefaults();
            RTs.AddResearchTeams(RT1, RT2, RT3);
            Console.WriteLine(RTs.ToShortString());

            Console.WriteLine("Sorted by RegistrNumber");
            RTs.SortingByRegNum();
            Console.WriteLine(RTs.ToShortString());
            Console.WriteLine("Sorted by String");
            RTs.SortByTheme();
            Console.WriteLine(RTs.ToShortString());
            Console.WriteLine("Sorted by Bublications");
            RTs.SortByPublications();
            Console.WriteLine(RTs.ToShortString());

            Console.WriteLine();
            Console.WriteLine(RTs.MinRegNumber.ToString());
            Console.WriteLine(RTs.TwoYearsLong.ToString());
        }
    }
}