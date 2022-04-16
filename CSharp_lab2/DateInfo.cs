using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;

namespace CSharp_lab2
{
    public class DateInfo : INotifyPropertyChanged
    {
        private Person _person = new Person();
        private DateTime selectedDateFromUser;
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? new RelayCommand<object>(_ => proceed(), CanExecute);
            }
        }


        public string FirstName
        {
            get
            {
                return _person.FirstName;
            }
            set
            {
                _person.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _person.LastName;
            }
            set
            {
                _person.LastName = value;
            }
        }

        public string EmailAdress
        {
            get
            {
                return _person.EmailAdress;
            }
            set
            {
                _person.EmailAdress = value;
            }
        }

        public DateTime DateBirth
        {
            get
            {
                return _person.DateBirth;
            }
            set
            {
                _person.DateBirth = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                return Int32.Parse( countAgeOfUser()) >= 18;
            }
        }

        public string SunSign
        {
            get
            {
                return countWestAstroSign();
            }
        }

        public string ChineseSign
        {
            get
            {
                return countEastAstroSign();
            }
        }

        public int Age
        {
            get
            {
                return Int32.Parse(countAgeOfUser());
            }
        }
        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_person.FirstName) && !String.IsNullOrWhiteSpace(_person.LastName);
        }

        enum WestSigns
        {
            Aries = 1,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }

        enum EastSigns
        {
            Rat = 1,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat,
            Monkey,
            Rooster,
            Dog,
            Pig
        }

        public DateTime SelectedDateFromUser
        {
            get
            {
                return selectedDateFromUser;
            }
            set
            {
                selectedDateFromUser = value;
            }
        }

        public bool dateValid()
        {
            DateTime todayDate = DateTime.Today;
            int difference = todayDate.Year - SelectedDateFromUser.Year;
            if (difference > 135 || difference < 0)
            {
               MessageBox.Show("The date is wrong");
               return false;
            }
            return true;
        }

        public string countAgeOfUser()
        {
            DateTime? todayDate = DateTime.Today;
            int age = todayDate.Value.Year - selectedDateFromUser.Year;
            if ((todayDate.Value.Day < selectedDateFromUser.Day && todayDate.Value.Month == selectedDateFromUser.Month) || (todayDate.Value.Month < selectedDateFromUser.Month))
            {
                age--;
            }
            return age.ToString();
        }

        public string countWestAstroSign()
        {
            int month = SelectedDateFromUser.Month;
            int day = SelectedDateFromUser.Day;
            WestSigns astroSign;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                astroSign = WestSigns.Aries;
            } else if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
            {
                astroSign = WestSigns.Taurus;
            } else if ((month == 5 && day >= 22) || (month == 6 && day <= 21))
            {
                astroSign = WestSigns.Gemini;
            } else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                astroSign = WestSigns.Cancer; 
            } else if ((month == 7 && day >= 23) || (month == 8  && day <= 22))
            {
                astroSign = WestSigns.Leo;
            } else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                astroSign = WestSigns.Virgo;
            } else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                astroSign = WestSigns.Libra;
            } else if ((month == 10 && day >= 23) || (month == 11 && day <= 22))
            {
                astroSign = WestSigns.Scorpio;
            } else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                astroSign = WestSigns.Sagittarius;
            } else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                astroSign = WestSigns.Capricorn;
            } else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                astroSign = WestSigns.Aquarius;
            } else
            {
                astroSign = WestSigns.Pisces;
            }
            return astroSign.ToString();
        }

        public string countEastAstroSign()
        {
            int numOfSign = (SelectedDateFromUser.Year - 1900) % 12;
            EastSigns astroSign = (EastSigns)numOfSign;
            return astroSign.ToString();
        }

        private void proceed()
        {
            bool check = dateValid();
            if (check)
            {
                //PropertyChanged?.Invoke(this, nameof(SunSign));
                //AgeOfUser.Text = countAgeOfUser();
                //WestSign.Text = countWestAstroSign();
                //EastSign.Text = countEastAstroSign();
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }

        //private void update(object? sender, PropertyChangedEventArgs e)
        //{
        //    OnPropertyChanged?.Invoke(this, new(nameof()));

        //}
        //private void proceed(object? sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if(e.Property == nameof()
        //}
    }

}
