using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Prism.Commands;

namespace Lab01
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private DateTime _birthDate = DateTime.Today;
        private string _ageText;
        private string _westernZodiac;
        private string _chineseZodiac;
        List<DateTime> birthDates = new List<DateTime>();

        public DateTime BirthDate {
            get { return _birthDate;}
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public string AgeText
        {
            get { return _ageText; }
            set
            {
                _ageText = value;
                OnPropertyChanged(nameof(AgeText));
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                if (_westernZodiac != value)
                {
                    _westernZodiac = value;
                    OnPropertyChanged(nameof(WesternZodiac));
                }
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                if (_chineseZodiac != value)
                {
                    _chineseZodiac = value;
                    OnPropertyChanged(nameof(ChineseZodiac));
                }
            }
        }

        public DelegateCommand SubmitCommand { get; }

        public MainWindowViewModel()
        {
            SubmitCommand = new DelegateCommand(Submit);
        }

        private void Submit()
        {
            DateTime today = DateTime.Today;
            DateTime newBirthDate = BirthDate;
            int age =  today.Year - newBirthDate.Year;
            if (today.DayOfYear < newBirthDate.DayOfYear)
                age--;

            if (age < 0)
            {
                MessageBox.Show($"Помилка: вказана дата ({newBirthDate.Year}.{newBirthDate.Month}.{newBirthDate.Day}) ще не настала", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            else if (age > 135)
            {
                MessageBox.Show("Помилка: вам більше 135 років", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            birthDates.Add(newBirthDate);
            AgeText = $"Вам {age} років";
            WesternZodiac = $"За західним знаком зодіака ви {GetWesternZodiac(newBirthDate)}";
            ChineseZodiac = $"За китайським знаком зодіака ви {GetChineseZodiac(newBirthDate.Year)}";

            if (today.Month == newBirthDate.Month && today.Day == newBirthDate.Day)
                MessageBox.Show("З днем народження!", "Привітання", MessageBoxButton.OK, MessageBoxImage.Information);
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
