using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniversalAppCsharp.Common;
using UniversalAppCsharp.DataModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalAppCsharp
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class FlickrApiPage : Page
    {
        public FlickrApiPage()
        {
            this.InitializeComponent();
            this.FlickrGridView.ItemsSource = FlickrApiManager.Photos;
        }

        private async void ApiRequest_Click(object sender, RoutedEventArgs e)
        {
            var photos = await FlickrApiManager.GetPhotos();
        }

        private void SeePhoto_Click(object sender, ItemClickEventArgs e)
        {
            var itemTitle = ((FlickrPhoto)e.ClickedItem).Title;//Can pass a complex object
            this.Frame.Navigate(typeof(FlickrPhotoPage), itemTitle);
        }
    }
}
