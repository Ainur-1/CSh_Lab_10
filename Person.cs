using System;

namespace CSh_Lab_10
{
    public class Person
    {
        #region Variables
        private string name;
        private string lastName;
        private DateTime bday;
        #endregion
        #region Constructors
        public Person()
        {
            name = "NoName";
            lastName = "NoLastName";
            bday = new DateTime();
        }
        public Person(string name, string lastName, DateTime bday)
        {
            this.name = name;
            this.lastName = lastName;
            this.bday = bday;
        }
        #endregion
        #region Properties
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }
        public DateTime Bday
        {
            get { return this.bday; }
            private set { this.bday = value; }
        }
        public int YearChanger
        {
            get { return Bday.Year; }
            set { this.Bday = new DateTime(value, this.Bday.Month, this.Bday.Day); }
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            string personProperties = Name + " " + LastName + " " + Convert.ToString(Bday);
            return personProperties;
        }
        public string ToShortString()
        {
            string personProperties = Name + " " + LastName;
            return personProperties;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Person objPers = obj as Person;
            if (obj as Person == null)
            {
                return false;
            }
            return objPers.name == Name && objPers.lastName == LastName && objPers.bday == Bday;
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = name.ToCharArray();

            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            char[] LastnameChar = lastName.ToCharArray();
            foreach (char ch in LastnameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += bday.Year * bday.Month * bday.Day;
            return hashcode;
        }
        public virtual object DeepCopy()
        {
            Person persCopy = new Person(this.Name, this.LastName, this.Bday);
            return persCopy;
        }
        #endregion
        //Перегрузка операторов
        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }
            if(p1 == null || p2 == null)
            {
                return false;
            }
            return p1.name == p2.name && p1.lastName == p2.lastName && p1.bday == p2.bday;
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }
    }
}