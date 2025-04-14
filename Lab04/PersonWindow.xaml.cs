using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab04
{
    public partial class PersonWindow : Window
    {
        public Person ResultPerson { get; private set; }

        public PersonWindow(Person existingPerson = null)
        {
            InitializeComponent();

            var viewModel = new PersonWindowViewModel(existingPerson);
            viewModel.CloseRequested += (sender, person) =>
            {
                ResultPerson = person;
                DialogResult = true;
                Close();
            };

            DataContext = viewModel;
        }
    }
}
