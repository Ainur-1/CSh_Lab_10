using System;

namespace CSh_Lab_10
{
    class Paper
    {
        //Поля
        string nameOfPublication;
        Person author;
        DateTime dateOfPublication;

        // Свойства
        public string NameOfPublication { get; set; }
        public Person Author { get; set; }
        public DateTime DateOfPublication { get; set; }

        //Конструкторы
        public Paper(string nameOfPublication, Person author, DateTime dateOfPublication)
        {
            this.nameOfPublication = nameOfPublication;
            this.author = author;
            this.dateOfPublication = dateOfPublication;
        }
        public Paper()
        {
            this.nameOfPublication = "No Name";
            this.author = new Person();
            this.dateOfPublication = new DateTime();
        }

        //Методы
        public override string ToString()
        {
            string paperProperties = NameOfPublication + author.ToString() + DateOfPublication;
            return paperProperties;
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            Paper paperObj = obj as Paper;
            if(paperObj == null)
            {
                return false;
            }
            return paperObj.nameOfPublication == NameOfPublication && paperObj.author == Author && paperObj.dateOfPublication == DateOfPublication;
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = NameOfPublication.ToCharArray();

            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += author.GetHashCode();
            hashcode += dateOfPublication.Year * dateOfPublication.Month * dateOfPublication.Day;
            return hashcode;
        }
        public virtual object DeepCopy()
        {
            Paper pepCopy = new Paper(this.nameOfPublication, new Person(this.author.Name, this.author.LastName, this.author.Bday), this.dateOfPublication);
            return pepCopy;
        }

        //Перегрузка операторов
        public static bool operator ==(Paper p1, Paper p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }
            if (p1 == null || p2 == null)
            {
                return false;
            }
            return p1.nameOfPublication == p2.nameOfPublication && p1.author == p2.author && p1.dateOfPublication == p2.dateOfPublication;
        }
        public static bool operator !=(Paper p1, Paper p2)
        {
            return !(p1 == p2);
        }
    }
}
