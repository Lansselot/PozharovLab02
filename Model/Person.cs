using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozharovLab02
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public Person(string firstName, string lastName, string email, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthdate = birthdate;
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.MinValue) { }

        public Person(string firstName, string lastName, DateTime birthdate)
            : this(firstName, lastName, "", birthdate) { }

    
        public bool IsAdult
        {
            get
            {
                DateTime birthdayToBeAdult = DateTime.Today.AddYears(-18);
                return Birthdate < birthdayToBeAdult;
            }
        }

        public string SunSign
        {
            get
            {
                int month = Birthdate.Month;
                int day = Birthdate.Day;

                if (month == 1)
                {
                    if (day <= 20) return "Capricorn";
                    else return "Aquarius";
                }
                else if (month == 2)
                {
                    if (day <= 19) return "Aquarius";
                    else return "Pisces";
                }
                else if (month == 3)
                {
                    if (day <= 20) return "Pisces";
                    else return "Aries";
                }
                else if (month == 4)
                {
                    if (day <= 20) return "Aries";
                    else return "Taurus";
                }
                else if (month == 5)
                {
                    if (day <= 21) return "Taurus";
                    else return "Gemini";
                }
                else if (month == 6)
                {
                    if (day <= 21) return "Gemini";
                    else return "Cancer";
                }
                else if (month == 7)
                {
                    if (day <= 22) return "Cancer";
                    else return "Leo";
                }
                else if (month == 8)
                {
                    if (day <= 23) return "Leo";
                    else return "Virgo";
                }
                else if (month == 9)
                {
                    if (day <= 23) return "Virgo";
                    else return "Libra";
                }
                else if (month == 10)
                {
                    if (day <= 23) return "Libra";
                    else return "Scorpio";
                }
                else if (month == 11)
                {
                    if (day <= 22) return "Scorpio";
                    else return "Sagittarius";
                }
                else // month == 12
                {
                    if (day <= 21) return "Sagittarius";
                    else return "Capricorn";
                }
            }
        }

        public string ChineseSign
        {
            get
            {
                int year = Birthdate.Year;
                String sign = ((year - 4) % 12) switch
                {
                    0 => "Rat",
                    1 => "Ox",
                    2 => "Tiger",
                    3 => "Rabbit",
                    4 => "Dragon",
                    5 => "Snake",
                    6 => "Horse",
                    7 => "Goat",
                    8 => "Monkey",
                    9 => "Rooster",
                    10 => "Dog",
                    11 => "Pig",
                    _ => ""
                };
                return sign;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return Birthdate.Day == DateTime.Now.Day && Birthdate.Month == DateTime.Now.Month;
            }
        }
    }
}
