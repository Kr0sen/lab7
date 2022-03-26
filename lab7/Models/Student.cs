using System;
using Avalonia.Media;

namespace lab7.Models
{
    public class Student
    {
        public Student(string fn, string sn, string p, string[] control)
        {
            FirstName = fn;
            SecondName = sn;
            Patronymic = p;
            Control = control;
            BoxChecked = false;
            resetAverage();
        }
        public Student(string fn, string sn, string p, string[] control, bool check) : this(fn, sn, p, control)
        {
            BoxChecked = check;
        }

        string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        string secondName;
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }

        string patronymic;
        public string Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                patronymic = value;
            }
        }

        string[] control = new string[5];
        public string[] Control
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
            }
        }

        public string this[int i]
        {
            get
            {
                return control[i];
            }
            set
            {
                int x;
                if (Int32.TryParse(value, out x))
                {
                    if (x > -1 && x < 3)
                    {
                        control[i] = value;
                    }
                    else
                    {
                        control[i] = "#ERROR";
                    }
                }
                else
                {
                    control[i] = "#ERROR";
                }
                resetAverage();
            }
        }

        public ISolidColorBrush Brush
        {
            get
            {
                double x;
                if (Double.TryParse(average, out x))
                {
                    if (x < 1) return Brushes.Red;
                    if (x >= 1.5) return Brushes.Green;
                    if (x >= 1 && x < 1.5) return Brushes.Yellow;
                    return Brushes.Purple;
                }
                else
                {
                    return Brushes.White;
                }
            }
        }

        bool boxChecked;
        public bool BoxChecked
        {
            get { return boxChecked; }
            set { boxChecked = value; }
        }

        string average;
        public string Average
        {
            get
            {
                return average;
            }
            set
            {
                average = value;
            }
        }

        private void resetAverage()
        {
            bool err = false;
            double averageL = 0;
            double x;
            foreach (var item in control)
            {
                if (Double.TryParse(item, out x))
                    averageL += x;
                else
                {
                    err = true;
                    break;
                }
            }
            if (!err)
            {
                averageL /= 5;
                Average = averageL.ToString();
            }
            else
                Average = "#ERROR";
        }
    }
}
