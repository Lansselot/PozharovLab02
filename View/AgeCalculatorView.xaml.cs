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
using PozharovLab02.ViewModel;

namespace PozharovLab02.View
{

    public partial class AgeCalculatorView : Window
    {
        public AgeCalculatorView()
        {
            InitializeComponent();
            DataContext = new AgeCalculatorViewModel(this);
        }

        public delegate void OnButtonClicked();
        public event OnButtonClicked onPressed;

        public delegate void OnTextChanged();
        public event OnTextChanged onTextChanged;

        public string FirstName
        {
            get { return FirstNameTextBox.Text; }
        }

        public string LastName
        {
            get { return LastNameTextBox.Text; }
        }

        public string Email
        {
            get { return EmailTextBox.Text; }
        }

        public DateTime? BirthDate
        {
            get { return (DateTime?)BirthDatePicker.SelectedDate; }
        }


        private void onButtonClicked(object sender, RoutedEventArgs e)
        {
            onPressed();
        }

        private void onTextChanged_func(object sender, TextChangedEventArgs e)
        {
            onTextChanged();
        }

        private void onTextChanged_func(object sender, SelectionChangedEventArgs e)
        {
            onTextChanged();
        }
    }
}
