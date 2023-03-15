using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozharovLab02.View;
using System.Windows;
using System.Threading;
using System.Diagnostics;


namespace PozharovLab02.ViewModel
{
    internal class AgeCalculatorViewModel
    {
        private AgeCalculatorView _view;
        private List<Person> _person = new List<Person>();
        public AgeCalculatorViewModel(AgeCalculatorView view)
        {
            _view = view;
            _view.onPressed += calculate;
            _view.onTextChanged += updateButtonAvailability;
        }
        private bool isAgeCorrect(DateTime? birthday)
        {
            if (birthday == null) return false;
            return birthday.Value > DateTime.Now.AddYears(-135) && birthday.Value < DateTime.Now;
        }

        private void updateButtonAvailability()
        {
            String firstName = _view.FirstName;
            String lastName = _view.LastName;
            String email = _view.Email;
            DateTime? dateTime = _view.BirthDate;

            _view.ProceedButton.IsEnabled = !(string.IsNullOrEmpty(firstName) 
                || string.IsNullOrEmpty(lastName) 
                || string.IsNullOrEmpty(email)
                || dateTime.Equals(null));

        }

        private void interfaceEnable(bool b)
        {
            _view.ProceedButton.IsEnabled = b;
            _view.EmailTextBox.IsEnabled = b;
            _view.FirstNameTextBox.IsEnabled = b;
            _view.LastNameTextBox.IsEnabled = b;
            _view.BirthDatePicker.IsEnabled = b;
        }

        async Task<(bool, string, string, bool)> calculateData(Person person)
        {
            Task<bool> isAdultTask = Task.Run(() => person.IsAdult);
            Task<string> sunSignTask = Task.Run(() => person.SunSign);
            Task<string> chineseSignTask = Task.Run(() => person.ChineseSign);
            Task<bool> isBirthdayTask = Task.Run(() => person.IsBirthday);

            var isAdult = await isAdultTask;
            var sunSign = await sunSignTask;
            var chineseSign = await chineseSignTask;
            var isBirthday = await isBirthdayTask;

            return (isAdult, sunSign, chineseSign, isBirthday);
        }

        private async void calculate()
        {
            String firstName = _view.FirstName;
            String lastName = _view.LastName;
            String email = _view.Email;
            DateTime? birthDate = _view.BirthDate;

            _view.OutputTextBox.Text = "";

            if (!isAgeCorrect(birthDate))
            {
                MessageBox.Show("Enter valid date");
                return;
            }


            if (birthDate.HasValue)
                _person.Add(new Person(firstName, lastName, email, birthDate.Value));

            Task<(bool isAdult, string sunSign, string chineseSign, bool isBirthday)> task1 = calculateData(_person.Last());
            interfaceEnable(false);
            var data = await task1;         

            string output = "FirstName: " + _person.Last().FirstName + "\n" +
                "LastName: " + _person.Last().LastName + "\n" +
                "Email: " + _person.Last().Email + "\n" +
                "Birthdate: " + _person.Last().Birthdate.ToShortDateString() + "\n" +
                "Is Adult: " + data.isAdult + "\n" +
                "Sun Sign: " + data.sunSign + "\n" +
                "Chinese Sign: " + data.chineseSign + "\n" +
                "Is Birthday: " + data.isBirthday;

            _view.OutputTextBox.Text = output;

            interfaceEnable(true);

            if (data.isBirthday)
            {
                MessageBox.Show("Happy birthday");
            }



        }
        
    }

}
