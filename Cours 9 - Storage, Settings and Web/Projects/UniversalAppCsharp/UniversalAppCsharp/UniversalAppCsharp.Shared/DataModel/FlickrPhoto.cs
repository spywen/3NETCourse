using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace UniversalAppCsharp.DataModel
{
    public class FlickrPhoto : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private BitmapImage image;
        public BitmapImage Image
        {
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

    public class Media
    {
        public string m { get; set; }
    }

    public class Item
    {
        public string title { get; set; }
        public string link { get; set; }
        public Media media { get; set; }
        public string date_taken { get; set; }
        public string description { get; set; }
        public string published { get; set; }
        public string author { get; set; }
        public string author_id { get; set; }
        public string tags { get; set; }
    }

    public class RootObject
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string modified { get; set; }
        public string generator { get; set; }
        public List<Item> items { get; set; }
    }
}
