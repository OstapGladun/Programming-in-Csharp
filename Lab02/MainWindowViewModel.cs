using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab02
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate = DateTime.Now;
        private string _resultText;
        private bool _isCalculating = false;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                CheckIsProceedPossible();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                CheckIsProceedPossible();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                CheckIsProceedPossible();
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
                CheckIsProceedPossible();
            }
        }

        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged(nameof(ResultText));
            }
        }

        public bool IsProceedPossible { get; set; }
        public DelegateCommand ProceedCommand { get; }

        public MainWindowViewModel()
        {
            ProceedCommand = new DelegateCommand(async () => await ProceedAsync());
        }

        private void CheckIsProceedPossible()
        {
            IsProceedPossible = !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email) && BirthDate != null/* && !_isCalculating*/;
            OnPropertyChanged(nameof(IsProceedPossible));
        }

        private async Task ProceedAsync()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (today.DayOfYear < BirthDate.DayOfYear)
                age--;
            if (age < 0)
            {
                MessageBox.Show($"Помилка: вказана дата ({BirthDate.Year}.{BirthDate.Month}.{BirthDate.Day}) ще не настала", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (age > 135)
            {
                MessageBox.Show("Помилка: вам більше 135 років", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _isCalculating = true;
            CheckIsProceedPossible();

            Person newPerson = new Person(FirstName, LastName, Email, BirthDate);
            await newPerson.CalculatePropertiesAsync();

            _isCalculating = false;
            CheckIsProceedPossible();

            ResultText = newPerson.AllPropertiesString();
            if (newPerson.IsBirthday)
                MessageBox.Show("З Днем народження!", "Привітання", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler  PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
