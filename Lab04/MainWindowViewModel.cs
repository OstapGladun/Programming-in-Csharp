using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab04
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; set; }
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set 
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson)); 
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand EditCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public MainWindowViewModel()
        {
            People = new ObservableCollection<Person>(DataManager.LoadOrCreateUsers());

            AddCommand = new DelegateCommand(AddUser);
            EditCommand = new DelegateCommand(EditUser, () => SelectedPerson != null).ObservesProperty(() => SelectedPerson);
            DeleteCommand = new DelegateCommand(DeleteUser, () => SelectedPerson != null).ObservesProperty(() => SelectedPerson);
        }

        private void AddUser()
        {
            var window = new PersonWindow();
            if (window.ShowDialog() == true)
            {
                People.Add(window.ResultPerson);
                DataManager.SaveUsers(People.ToList());
            }
        }

        private void EditUser()
        {
            if (SelectedPerson == null)
                return;

            var personCopy = new Person(
                SelectedPerson.FirstName,
                SelectedPerson.LastName,
                SelectedPerson.Email,
                SelectedPerson.BirthDate
            );

            var window = new PersonWindow(personCopy);
            if (window.ShowDialog() == true)
            {
                int index = People.IndexOf(SelectedPerson);
                People[index] = window.ResultPerson;
                SelectedPerson = window.ResultPerson;
                DataManager.SaveUsers(People.ToList());
            }
        }

        private void DeleteUser()
        {
            if (SelectedPerson != null)
            {
                People.Remove(SelectedPerson);
                DataManager.SaveUsers(People.ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
