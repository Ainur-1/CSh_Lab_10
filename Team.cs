using System;

namespace CSh_Lab_10
{
    class Team : INameAndCopy, IComparable
    {
        //Поля
        protected string organization;
        protected int registrationNumber;

        //Реализация интерфейсов
        string INameAndCopy.Name
        {
            get
            {
                return organization;
            }
            set
            {
                this.organization = value;
            }
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Team otherTeam = obj as Team;
            if (otherTeam != null)
                return this.RegistrationNumber.CompareTo(otherTeam.RegistrationNumber);
            else
                throw new ArgumentException("Object is not a Team");
        }

        //Конструкторы
        public Team()
        {
            this.organization = "No organization";
            this.registrationNumber = 0;
        }
        public Team(string organization, int registrationNumber)
        {
            this.organization = organization;
            this.registrationNumber = registrationNumber;
        }

        //Свойства
        public string Organization
        {
            get { return this.organization; }
            set { this.organization = value; }
        }
        public int RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be more than 0 ");
                }
                else
                {
                    registrationNumber = value;
                }
            }
        }

        //Методы
        public virtual object DeepCopy()
        {
            return new Team(this.organization, this.registrationNumber);
        }

        //Перегрузка операторов
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Team objAsTeam = obj as Team;
            if (objAsTeam as Team == null)
            {
                return false;
            }
            return objAsTeam.Organization == this.Organization && objAsTeam.RegistrationNumber == this.RegistrationNumber;

        }
        static public bool operator ==(Team l_Team, Team r_Team)
        {
            if (ReferenceEquals(l_Team, r_Team))
            {
                return true;
            }
            if ((((object)l_Team) == null) || (((object)r_Team) == null))
            {
                return false;
            }
            return (l_Team.Organization == r_Team.Organization) && (l_Team.RegistrationNumber==r_Team.RegistrationNumber);

        }
        static public bool operator !=(Team l_Team, Team r_Team)
        {
            return !(l_Team == r_Team);
        }
        public override int GetHashCode()
        {
            int HashCode = 0;
            foreach (char ch in organization.ToCharArray())
            {
                HashCode += (int)Convert.ToUInt32(ch);
            }
            HashCode += registrationNumber;
            return HashCode;
        }
        public virtual new string ToString()
        {
            return string.Format("Team of organisation {0} with registration number {1}", organization, registrationNumber);
        }
    }
}
