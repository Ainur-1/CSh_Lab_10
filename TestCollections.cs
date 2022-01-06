using System;
using System.Collections.Generic;

namespace CSh_Lab_10
{
    class TestCollections
    {
        //Поля
        private List<Team> ListOfTeam = new List<Team>();
        private List<string> ListOfString = new List<string>();
        private Dictionary<Team, ResearchTeam> TeamResDict = new Dictionary<Team, ResearchTeam>();
        private Dictionary<string, ResearchTeam> StringResDict = new Dictionary<string, ResearchTeam>();

        //Конструкторы
        public TestCollections(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                ListOfTeam.Add(new Team());
                TeamResDict.Add(new Team(), new ResearchTeam());
                ListOfString.Add("");
                StringResDict.Add("", new ResearchTeam());

            }
        }

        //Методы
        public static ResearchTeam GenerateElement(int value)
        {
            ResearchTeam a = new ResearchTeam();
            a.RegistrationNumber = value;
            return a;
        }
        public void TimeOfSearching(string str, Team team, ResearchTeam resT)
        {

            int time1 = Environment.TickCount;
            ListOfTeam.BinarySearch(team);
            Console.WriteLine((time1 - Environment.TickCount).ToString());

            int time2 = Environment.TickCount;
            ListOfString.BinarySearch(str);
            Console.WriteLine((time2 - Environment.TickCount).ToString());

            int time3 = Environment.TickCount;
            ResearchTeam a = TeamResDict[team];
            Console.WriteLine((time3 - Environment.TickCount).ToString());

            int time4 = Environment.TickCount;
            ResearchTeam b = StringResDict[str];
            Console.WriteLine((time4 - Environment.TickCount).ToString());
        }
    }
}
