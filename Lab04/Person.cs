using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    [Serializable]
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsAdult { get; private set; }
        public string SunSign { get; private set; }
        public string ChineseSign { get; private set; }
        public bool IsBirthday { get; private set; }

        public Person() { }

        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
                throw new NotBornException(birthDate);
            if (birthDate.Year < DateTime.Today.Year - 135)
                throw new TooOldException(birthDate);
            if (!IsEmailValid(email))
                throw new InvalidEmailException(email);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;

            CalculateProperties();
        }

        public void CalculateProperties()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (today.DayOfYear < BirthDate.DayOfYear)
                age--;

            IsAdult = age >= 18;
            IsBirthday = today.Month == BirthDate.Month && today.Day == BirthDate.Day;
            SunSign = SelectWesternZodiac(BirthDate);
            ChineseSign = SelectChineseZodiac(BirthDate.Year);
        }


        private string SelectWesternZodiac(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;
            switch (month)
            {
                case 1:
                    return (day <= 20) ? "Capricorn" : "Aquarius";
                case 2:
                    return (day <= 19) ? "Aquarius" : "Pisces";
                case 3:
                    return (day <= 20) ? "Pisces" : "Aries";
                case 4:
                    return (day <= 20) ? "Aries" : "Taurus";
                case 5:
                    return (day <= 21) ? "Taurus" : "Gemini";
                case 6:
                    return (day <= 21) ? "Gemini" : "Cancer";
                case 7:
                    return (day <= 22) ? "Cancer" : "Leo";
                case 8:
                    return (day <= 22) ? "Leo" : "Virgo";
                case 9:
                    return (day <= 23) ? "Virgo" : "Libra";
                case 10:
                    return (day <= 23) ? "Libra" : "Scorpio";
                case 11:
                    return (day <= 22) ? "Scorpio" : "Sagittarius";
                case 12:
                    return (day <= 21) ? "Sagittarius" : "Capricorn";
                default:
                    return "Unknown";
            };
        }

        private string SelectChineseZodiac(int year)
        {
            string[] chineseZodiacs =
            {
                "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox",
                "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"
            };
            return chineseZodiacs[year % 12];
        }

        private bool IsEmailValid(string email)
        {
            string[] split_email = email.Split('@');
            return (split_email.Length == 2) && (split_email[1].Split('.').Length == 2);
        }
    }
}
