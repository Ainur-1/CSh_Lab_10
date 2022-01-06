using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace CSh_Lab_10
{
    class ResearchTeamCollection : ResearchTeam, IComparable, IEnumerable
    {
        //Поля
        private List<ResearchTeam> researches;

        //Кострукторы 
        public ResearchTeamCollection()
        {
            researches = new List<ResearchTeam>();
        }

        //Свойства
        public int MinRegNumber
        {
            get
            {
                if (researches.Count == 0)
                {
                    return 0;
                }
                return researches.Min(teams => teams.RegistrationNumber);
            }
        }
        public IEnumerable<ResearchTeam> TwoYearsLong
        {
            get
            {
                IEnumerable<ResearchTeam> TwoTearsL = researches.Where(time => time.DurationOfResearch == TimeFrame.TwoYears);
                return TwoTearsL;
            }
        }

        //Методы
        public void AddDefaults()
        {
            researches.Add(new ResearchTeam());
        }
        public void AddResearchTeams(params ResearchTeam[] newResearchTeams)
        {
            researches.AddRange(newResearchTeams);
        }
        public override string ToString()
        {
            string stringResearches = "";
            foreach (var r in researches)
            {
                stringResearches += r.ToString() + "\r\n";
            }
            return stringResearches;
        }
        public override string ToShortString()
        {
            string stringResearches = "";
            foreach (var r in researches)
            {
                stringResearches += r.ToShortString() + "\r\n";
            }
            return stringResearches;
        }
        public void SortingByRegNum()
        {
           researches.Sort((x, y) => x.RegistrationNumber.CompareTo(y.RegistrationNumber));
        }
        public void SortByTheme()
        {
            researches.Sort();
        }
        public void SortByPublications()
        {
            ResearchTeamHelper comp = new ResearchTeamHelper();
            researches.Sort(comp);
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < researches.Count; i++)
            {
                yield return researches[i];
            }
        }
        public List<ResearchTeam> NGroup(int value)
        {
            IEnumerable<IGrouping<int, ResearchTeam>> someGroup = researches.GroupBy(team => team.ListOfParticipants.Count);

            foreach (IGrouping<int, ResearchTeam> teams in someGroup)
            {
                if (teams.Key == value)
                {
                    return teams.ToList<ResearchTeam>();
                }
                else
                {
                    throw new ArgumentNullException("There are no such number!");
                }
            }
            return null;
        }
    }
}