using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Lab04
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; private set; } = new ObservableCollection<Person>();
        private Person _selectedPerson;

        public string NameFilter { get; set; }
        public string SurnameFilter { get; set; }
        public string EmailFilter { get; set; }
        public DateTime? DateFilter { get; set; }
        public bool? IsAdultFilter { get; set; }
        public string SunSignFilter { get; set; }
        public string ChineseSignFilter { get; set; }
        public bool? IsBirthdayFilter { get; set; }

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
        public DelegateCommand FilterCommand { get; }
        public DelegateCommand ResetCommand { get; }

        public MainWindowViewModel()
        {
            LoadPeople();

            AddCommand = new DelegateCommand(AddUser);
            EditCommand = new DelegateCommand(EditUser, () => SelectedPerson != null).ObservesProperty(() => SelectedPerson);
            DeleteCommand = new DelegateCommand(DeleteUser, () => SelectedPerson != null).ObservesProperty(() => SelectedPerson);

            FilterCommand = new DelegateCommand(ApplyFilters);
            ResetCommand = new DelegateCommand(ResetFilters);
        }
        private void LoadPeople()
        {
            var users = DataManager.LoadOrCreateUsers();
            People.Clear();
            foreach (var person in users)
                People.Add(person);
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
        private void ApplyFilters()
        {
            var filtered = People.Where(p =>
                (string.IsNullOrWhiteSpace(NameFilter) || p.FirstName.ToLower().Contains(NameFilter.ToLower())) &&
                (string.IsNullOrWhiteSpace(SurnameFilter) || p.LastName.ToLower().Contains(SurnameFilter.ToLower())) &&
                (string.IsNullOrWhiteSpace(EmailFilter) || p.Email.ToLower().Contains(EmailFilter.ToLower())) &&
                (!DateFilter.HasValue || p.BirthDate.Date == DateFilter.Value.Date) &&
                (!IsAdultFilter.HasValue || p.IsAdult == IsAdultFilter.Value) &&
                (string.IsNullOrWhiteSpace(SunSignFilter) || p.SunSign.ToLower() == SunSignFilter.ToLower()) &&
                (string.IsNullOrWhiteSpace(ChineseSignFilter) || p.ChineseSign.ToLower() == ChineseSignFilter.ToLower()) &&
                (!IsBirthdayFilter.HasValue || p.IsBirthday == IsBirthdayFilter.Value)
            ).ToList();
            People.Clear();
            foreach (var person in filtered)
                People.Add(person);
        }

        private void ResetFilters()
        {
            NameFilter = SurnameFilter = EmailFilter = SunSignFilter = ChineseSignFilter = null;
            DateFilter = null;
            IsAdultFilter = null;
            IsBirthdayFilter = null;
            OnPropertyChanged(nameof(NameFilter));
            OnPropertyChanged(nameof(SurnameFilter));
            OnPropertyChanged(nameof(EmailFilter));
            OnPropertyChanged(nameof(SunSignFilter));
            OnPropertyChanged(nameof(ChineseSignFilter));
            OnPropertyChanged(nameof(DateFilter));
            OnPropertyChanged(nameof(IsAdultFilter));
            OnPropertyChanged(nameof(IsBirthdayFilter));
            LoadPeople();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
