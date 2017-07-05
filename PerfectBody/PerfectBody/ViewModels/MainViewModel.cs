﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PerfectBody.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private double _bmi;
        private string _category;
        public double Weight { get; set; }

        public double Height { get; set; }

        public double Bmi
        {
            get => _bmi;
            set
            {
                _bmi = value;
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateImcCommand
        {
            get
            {
                return new Command(() =>
                {
                    Bmi = Weight / Math.Pow(Height, 2);

                    if (Bmi <= 18.5)
                        Category = "Underweight";
                    else if (18.5 <= Bmi && Bmi <= 24.9)
                        Category = "Normal weight";
                    else if (25 <= Bmi && Bmi <= 29.9)
                        Category = "Overweight";
                    else if (30 <= Bmi)
                        Category = "Obesity";
                });
            }
        }

        public MainViewModel()
        {
            Height = 1.7;
            Weight = 66;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
