using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab04
{
    internal class PersonWindowViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate = DateTime.Now;

        private bool _isCalculating = false;

        public event EventHandler<Person> CloseRequested;

        public string FirstName
        {
            get => _firstName;
            set 
            { 
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                CheckIsProceedPossible();
            }
        }

        public string LastName
        {
            get => _lastName;
            set 
            { 
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                CheckIsProceedPossible();
            }
        }

        public string Email
        {
            get => _email;
            set 
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                CheckIsProceedPossible();
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set 
            { 
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
                CheckIsProceedPossible(); 
            }
        }

        public bool IsProceedPossible { get; set; }
        public DelegateCommand ProceedCommand { get; }

        public PersonWindowViewModel(Person existingPerson = null)
        {
            if (existingPerson != null)
            {
                FirstName = existingPerson.FirstName;
                LastName = existingPerson.LastName;
                Email = existingPerson.Email;
                BirthDate = existingPerson.BirthDate;
            }

            ProceedCommand = new DelegateCommand(async () => await ProceedAsync());
        }

        private void CheckIsProceedPossible()
        {
            IsProceedPossible = !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email) && BirthDate != null && !_isCalculating;
            OnPropertyChanged(nameof(IsProceedPossible));
        }

        private async Task ProceedAsync()
        {
            try
            {
                _isCalculating = true;
                CheckIsProceedPossible();
                Person newPerson = await Task.Run(() => new Person(FirstName, LastName, Email, BirthDate));

                if (newPerson.IsBirthday)
                    MessageBox.Show("Happy birthday!", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

                CloseRequested?.Invoke(this, newPerson);
            }
            catch (TooOldException ex)
            {
                MessageBox.Show(ex.Message, "Date error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (NotBornException ex)
            {
                MessageBox.Show(ex.Message, "Date error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (InvalidEmailException ex)
            {
                MessageBox.Show(ex.Message, "Email error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error: " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _isCalculating = false;
                CheckIsProceedPossible();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
