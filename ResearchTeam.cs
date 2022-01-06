using System;
using System.Collections;
using System.Collections.Generic;

namespace CSh_Lab_10
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long,
    }
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        //Поля
        private string theme;
        private TimeFrame durationOfResearch;
        private List<Person> projectParticipants = new List<Person>(); //тип Person
        private List<Paper> publications = new List<Paper>(); //тип Peper

        //Реализация интерфейса
        string INameAndCopy.Name
        {
            get
            {
                return theme;
            }
            set
            {
                this.theme = value;
            }
        }
        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y)
        {
            return String.Compare(x.theme, y.theme);
        }

        //Конструкторы
        public ResearchTeam(string theme, string nameOfOrganization, int regNum, TimeFrame durationOfResearch)
        {
            this.theme = theme;
            Organization = nameOfOrganization;
            RegistrationNumber = regNum;
            this.durationOfResearch = durationOfResearch;
        }
        public ResearchTeam()
        {
            this.theme = "Empty";
            Organization = "Empty";
            RegistrationNumber = 1;
            this.durationOfResearch = new TimeFrame();
        }

        //Свойства
        public List<Paper> ListOfPublication
        {
            get 
            { 
                return publications; 
            }
            set 
            { 
                publications = value; 
            }
        }
        public List<Person> ListOfParticipants 
        { 
            get 
            { 
                return projectParticipants; 
            } 
            set 
            { 
                projectParticipants = value; 
            } 
        }
        public Paper LastPublication
        {
            get
            {
                if (publications.Count == 0)
                {
                    return null;
                }
                int MaxIndex = 0;
                DateTime MaxDateTime = ((Paper)publications[0]).DateOfPublication;
                for (int i = 0; i < publications.Count; i++)
                {
                    if (((Paper)publications[i]).DateOfPublication > MaxDateTime)
                    {
                        MaxIndex = i;
                        MaxDateTime = ((Paper)publications[i]).DateOfPublication;
                    }
                }
                return (Paper)publications[MaxIndex];
            }
        }
        public Team getTeamType
        {
            get
            {
                return new Team(Organization, RegistrationNumber);
            }
            set
            {
                this.organization = value.Organization;
                this.registrationNumber = value.RegistrationNumber;
            }
        }
        public TimeFrame DurationOfResearch
        {
            get 
            { 
                return this.durationOfResearch; 
            } 
        }


        //Методы
        public void AddPepers(params Paper[] additionalPapers)
        {
            publications.AddRange(additionalPapers);
        }
        public void AddMembers(params Person[] AdditionalMembers)
        {
            projectParticipants.AddRange(AdditionalMembers);
        }
        public override string ToString()
        {
            string stringListOfPublications = "";
            foreach (Paper p in publications)
            {
                stringListOfPublications = p.ToString() + "\r\n";
            }
            string stringListOfParticipants = "";
            foreach (Person pers in projectParticipants)
            {
                stringListOfParticipants += pers.ToString() + "\r\n";
            }
            return base.ToString() + string.Format("\r\n Theme: {0}, Duration: {1} \r\n Participants: {2} \r\n Publications: {3}", theme, durationOfResearch, stringListOfParticipants, stringListOfPublications);
        }
        public virtual string ToShortString()
        {
            return base.ToString() + string.Format("\r\n Theme: {0}, Duration: {1} \r\n ", theme, durationOfResearch);
        }
        public override object DeepCopy()
        {
            Team teamcopy = new Team(this.organization, this.registrationNumber);
            ResearchTeam researchCopy = new ResearchTeam(this.theme, teamcopy.Organization, teamcopy.RegistrationNumber, this.durationOfResearch);
            researchCopy.ListOfParticipants = ListOfParticipants;
            researchCopy.ListOfPublication = ListOfPublication;
            return researchCopy;

        }

        //Итераторы
        public IEnumerable<Person> MembersWithoutPublications()
        {
            ArrayList AutorsWithoutP = new ArrayList();
            bool someBool;
            foreach (Person pers in projectParticipants)
            {
                someBool = true;
                foreach (Paper pap in publications)
                {
                    if (pap.Author == pers)
                    {
                        someBool = false;
                        break;
                    }
                }
                if (someBool)
                {
                    AutorsWithoutP.Add(pers);
                    //Console.WriteLine(pers.ToShortString());
                }

            }
            for (int i = 0; i < AutorsWithoutP.Count; i++)
            {
                yield return (Person)AutorsWithoutP[i];
                //Console.Write(((Person)AutorsWithoutP[i]).ToShortString());
            }

        }
        public IEnumerable<Paper> LastPapers(int N_years)
        {
            for (int i = 0; i < publications.Count; i++)
            {
                if (((Paper)publications[i]).DateOfPublication.Year >= DateTime.Now.Year - N_years)
                {
                    yield return (Paper)publications[i];
                    //Console.Write(((Paper)Publications[i]).ToString());
                }
            }
        }
    }
}
