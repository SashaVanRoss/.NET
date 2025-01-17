﻿using System;
using System.ComponentModel;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private readonly Employee _monEmployee;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Employee MonEmployee
        {
            get { return _monEmployee; }
        }

        public EmployeeModel(Employee current)
        {
            this._monEmployee = current;
        }

        public String DisplayBirthDate
        {
            get
            {
                if (_monEmployee.BirthDate.HasValue)
                {
                    return _monEmployee.BirthDate.Value.ToShortDateString();
                }

                return "";
            }
        }

        public String FullName
        {
            get
            {
                return String.Format("{0} {1}", _monEmployee.FirstName, _monEmployee.LastName).Trim();
            }
        }

        public String LastName
        {
            get { return _monEmployee.LastName; }
            set
            {
                _monEmployee.LastName = value;
                OnPropertyChanged("FullName");
            }
        }
        public String FirstName
        {
            get { return _monEmployee.FirstName; }
            set
            {
                _monEmployee.FirstName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string TitleOfCourtesy
        {
            get { return _monEmployee.TitleOfCourtesy; }
            set
            {
                _monEmployee.TitleOfCourtesy = value;
            }
        }

        public DateTime? BirthDate
        {
            get { return _monEmployee.BirthDate; }
            set
            {
                _monEmployee.BirthDate = value;
                OnPropertyChanged("DisplayBirthDate");
            }
        }

        public DateTime? HireDate
        {
            get { return _monEmployee.HireDate; }
            set
            {
                _monEmployee.HireDate = value;
            }
        }
    }
}
