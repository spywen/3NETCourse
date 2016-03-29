using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using UniversalAppCsharp.DataModel;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace UniversalAppCsharp.Common
{
    public class FlickrApiManager
    {
        public static ObservableCollection<FlickrPhoto> Photos = new ObservableCollection<FlickrPhoto>();

        public async static Task<ObservableCollection<FlickrPhoto>> GetPhotos()
        {
            if (IsInternet())
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = await client.GetAsync(new Uri("http://api.flickr.com/services/feeds/photos_public.gne?format=json&nojsoncallback=1"));

                string json = await message.Content.ReadAsStringAsync();

                var response = JObject.Parse(json);
                var items = response["items"];
                foreach(var photo in items){
                    var title = (string)photo["title"];
                    var image = (string)photo["media"]["m"];
                    Photos.Add(new FlickrPhoto{Title = title, Image = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(image, UriKind.Absolute))});
                }
            }
            return Photos;
        }
        public static bool IsInternet()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool internet = connections != null &&
                connections.GetNetworkConnectivityLevel() ==
               NetworkConnectivityLevel.InternetAccess;
            return internet;
        }

    }
}
