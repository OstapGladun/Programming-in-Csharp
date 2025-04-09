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

        private string _firstNameText;
        private string _lastNameText;
        private string _emailText;
        private string _birthDateText;
        private string _isAdultText;
        private string _sunSignText;
        private string _chineseSignText;
        private string _isBirthdayText;

        private bool _isCalculating = false;
        private List<Person> people = new List<Person>();

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

        //public string ResultText
        //{
        //    get { return _resultText; }
        //    set
        //    {
        //        _resultText = value;
        //        OnPropertyChanged(nameof(ResultText));
        //    }
        //}

        public string FirstNameText
        {
            get { return _firstNameText; }
            set
            {
                _firstNameText = value;
                OnPropertyChanged(nameof(FirstNameText));
            }
        }
        public string LastNameText
        {
            get { return _lastNameText; }
            set
            {
                _lastNameText = value;
                OnPropertyChanged(nameof(LastNameText));
            }
        }
        public string EmailText
        {
            get { return _emailText; }
            set
            {
                _emailText = value;
                OnPropertyChanged(nameof(EmailText));
            }
        }
        public string BirthDateText
        {
            get { return _birthDateText; }
            set
            {
                _birthDateText = value;
                OnPropertyChanged(nameof(BirthDateText));
            }
        }
        public string IsAdultText
        {
            get { return _isAdultText; }
            set
            {
                _isAdultText = value;
                OnPropertyChanged(nameof(IsAdultText));
            }
        }
        public string SunSignText
        {
            get { return _sunSignText; }
            set
            {
                _sunSignText = value;
                OnPropertyChanged(nameof(SunSignText));
            }
        }
        public string ChineseSignText
        {
            get { return _chineseSignText; }
            set
            {
                _chineseSignText = value;
                OnPropertyChanged(nameof(ChineseSignText));
            }
        }
        public string IsBirthdayText
        {
            get { return _isBirthdayText; }
            set
            {
                _isBirthdayText = value;
                OnPropertyChanged(nameof(IsBirthdayText));
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
            IsProceedPossible = !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email) && BirthDate != null && !_isCalculating;
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

            try
            {
                Person newPerson = await Task.Run(() => new Person(FirstName, LastName, Email, BirthDate));
                UpdateTextBoxes(newPerson);

                people.Add(newPerson);

                if (newPerson.IsBirthday)
                    MessageBox.Show("З Днем народження!", "Привітання", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (TooOldException ex)
            {
                MessageBox.Show(ex.Message, "Помилка дати", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (NotBornException ex)
            {
                MessageBox.Show(ex.Message, "Помилка дати", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (InvalidEmailException ex)
            {
                MessageBox.Show(ex.Message, "Помилка email", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невідома помилка: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _isCalculating = false;
            CheckIsProceedPossible();
        }
        private void UpdateTextBoxes(Person person)
        {
            FirstNameText = "Name: " + person.FirstName;
            LastNameText = "Surname: " + person.LastName;
            EmailText = "Name: " + person.Email;
            BirthDateText = "Date of birth: " + person.BirthDate.ToString();
            IsAdultText = "Is adult: " + person.IsAdult.ToString();
            SunSignText = "Western sign: " + person.SunSign;
            ChineseSignText = "Chinese sign: " + person.ChineseSign;
            IsBirthdayText = "Is birthday today: " + person.IsBirthday.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
