using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniversalAppCsharpBindings.Business;
using UniversalAppCsharpBindings.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UniversalAppCsharpBindings
{
    /// <summary>
    /// Source : https://channel9.msdn.com/events/WOWZAPP/WOWZAPP-2012/Data-Binding-with-XAML
    /// Two things important to remember : 
    /// - Use INotifyPropertyChanged, related method+event, and way to implement properties to be able to do two way data binding
    /// - Use ObservableCollection<Model>, to be able to bind collection and provide the possibility for the system to detect collection modifications (CRUD++)
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When page opened...
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //PAGE DATA CONTEXT
            this.DataContext = new PageModel { Name = "Simple binding" };

            //COMPONENT DATA CONTEXT
            //this.SelectedMoviePanel.DataContext = MovieManager.GetMovies().First(); REPLACE BY SELECTED ITEM INSIDE MYGRIDVIEW DATACONTEXT (XAML)
            this.MyGridView.ItemsSource = MovieManager.GetMovies();
        }
    }
}
