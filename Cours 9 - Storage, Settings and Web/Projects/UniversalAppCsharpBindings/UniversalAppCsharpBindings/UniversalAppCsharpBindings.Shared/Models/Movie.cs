using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UniversalAppCsharpBindings.Models
{
    /// <summary>
    /// DO NON FORGET TO EXTEND INOTIFY INTERFACE
    /// </summary>
    public class Movie : INotifyPropertyChanged
    {

        private string name;
        public string Name 
        { 
            get {
                return name;
            }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string image;
        public string Image {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        private string director;
        public string Director {
            get
            {
                return director;
            }
            set
            {
                director = value;
                OnPropertyChanged("Director");
            }
        }

        private DateTime year;
        public DateTime Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }


        //TO ADD BY HEART
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
