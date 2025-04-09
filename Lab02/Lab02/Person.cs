using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime BirthDate { get; }

        public bool IsAdult { get; private set; }
        public string SunSign { get; private set; }
        public string ChineseSign { get; private set; }
        public bool IsBirthday { get; private set; }

        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            CalculateProperties();
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.MinValue) { CalculateProperties(); }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, "", birthDate) { CalculateProperties(); }

        public void CalculateProperties()
        {
            if (BirthDate > DateTime.Now)
                throw new NotBornException(BirthDate);

            if (BirthDate.Year < DateTime.Today.Year - 135)
                throw new TooOldException(BirthDate);

            if (!IsEmailValid())
                throw new InvalidEmailException(Email);

            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (today.DayOfYear < BirthDate.DayOfYear)
                age--;
            IsAdult = (age >= 18);
            SunSign = GetWesternZodiac(BirthDate);
            ChineseSign = GetChineseZodiac(BirthDate.Year);
            IsBirthday = (today.Month == BirthDate.Month && today.Day == BirthDate.Day);
        }

        //public string AllPropertiesString()
        //{
        //    return $"Name: {FirstName}\nSurname: {LastName}\nEmail: {Email}\nDate of birth: {BirthDate.Day}.{BirthDate.Month}.{BirthDate.Year}\nYou are{(IsAdult ? " ":" not ")}/an/ adult \nWestern zodiac sign: {SunSign}\nChinese zodiac sign: {ChineseSign}\nToday is{(IsBirthday?" ":" not ")}your birthday";
        //}

        private string GetWesternZodiac(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;
            switch (month)
            {
                case 1:
                    return (day <= 20) ? "Козеріг" : "Водолій";
                case 2:
                    return (day <= 19) ? "Водолій" : "Риби";
                case 3:
                    return (day <= 20) ? "Риби" : "Овен";
                case 4:
                    return (day <= 20) ? "Овен" : "Телець";
                case 5:
                    return (day <= 21) ? "Телець" : "Близнюки";
                case 6:
                    return (day <= 21) ? "Близнюки" : "Рак";
                case 7:
                    return (day <= 22) ? "Рак" : "Лев";
                case 8:
                    return (day <= 22) ? "Лев" : "Діва";
                case 9:
                    return (day <= 23) ? "Діва" : "Терези";
                case 10:
                    return (day <= 23) ? "Терези" : "Скорпіон";
                case 11:
                    return (day <= 22) ? "Скорпіон" : "Стрілець";
                case 12:
                    return (day <= 21) ? "Стрілець" : "Козеріг";
                default:
                    return "Невідомий знак";
            };
        }

        private string GetChineseZodiac(int year)
        {
            string[] chineseZodiacs =
            {
                "Мавпа", "Півень", "Собака", "Свиня", "Щур", "Бик",
                "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза"
            };
            return chineseZodiacs[year % 12];
        }

        private bool IsEmailValid()
        {
            string[] split_email = Email.Split('@');
            return (split_email.Length == 2) && (split_email[1].Split('.').Length == 2);
        }
    }
}
