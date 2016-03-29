using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UniversalAppCsharp.Data;
using UniversalAppCsharp.Common;
using Windows.Storage;
using UniversalAppCsharp.DataModel;
using System.Collections.ObjectModel;

// Pour en savoir plus sur le modèle de projet Application Hub universelle, consultez la page http://go.microsoft.com/fwlink/?LinkID=391955

namespace UniversalAppCsharp
{
    /// <summary>
    /// Page affichant une collection groupée d'éléments.
    /// </summary>
    public sealed partial class HubPage : Page
    {
        private NavigationHelper navigationHelper;
        /// <summary>
        /// Obtient le NavigationHelper utilisé pour faciliter la navigation et la gestion de la durée de vie de processus.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        /// <summary>
        /// Obtient le DefaultViewModel. Cela peut être remplacé par un modèle d'affichage fortement typé.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        private PersonViewModel personViewModel = new PersonViewModel();
        public PersonViewModel PersonViewModel
        {
            get { return this.personViewModel; }
            set { this.personViewModel = value; }
        }

        public HubPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.PersonViewModel = new PersonViewModel();
        }

        /// <summary>
        /// Remplit la page à l'aide du contenu passé lors de la navigation. Tout état enregistré est également
        /// fourni lorsqu'une page est recréée à partir d'une session antérieure.
        /// </summary>
        /// <param name="sender">
        /// La source de l'événement ; en général <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Données d'événement qui fournissent le paramètre de navigation transmis à
        /// <see cref="Frame.Navigate(Type, object)"/> lors de la requête initiale de cette page et
        /// un dictionnaire d'état conservé par cette page durant une session
        /// antérieure.  L'état n'aura pas la valeur Null lors de la première visite de la page.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: créez un modèle de données approprié pour le domaine posant problème pour remplacer les exemples de données
            var sampleDataGroup = await SampleDataSource.GetGroupAsync("Group-4");
            this.DefaultViewModel["Section3Items"] = sampleDataGroup;
        }

        /// <summary>
        /// Appelé lorsqu'un utilisateur clique sur un en-tête de HubSection.
        /// </summary>
        /// <param name="sender">Le concentrateur qui contient le HubSection sur l'en-tête duquel l'utilisateur a cliqué.</param>
        /// <param name="e">Données d'événement décrivant la façon dont le clic a été initié.</param>
        void Hub_SectionHeaderClick(object sender, HubSectionHeaderClickEventArgs e)
        {
            HubSection section = e.Section;
            var group = section.DataContext;
            this.Frame.Navigate(typeof(SectionPage), ((SampleDataGroup)group).UniqueId);
        }

        /// <summary>
        /// Appelé lorsqu'un utilisateur clique sur un élément appartenant à une section.
        /// </summary>
        /// <param name="sender">GridView ou ListView
        /// affichant l'élément sur lequel l'utilisateur a cliqué.</param>
        /// <param name="e">Données d'événement décrivant l'élément sur lequel l'utilisateur a cliqué.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Accédez à la page de destination souhaitée, puis configurez la nouvelle page
            // en transmettant les informations requises en tant que paramètre de navigation.
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemPage), itemId);
        }
        #region Inscription de NavigationHelper

        /// <summary>
        /// Les méthodes fournies dans cette section sont utilisées simplement pour permettre
        /// NavigationHelper pour répondre aux méthodes de navigation de la page.
        /// La logique spécifique à la page doit être placée dans les gestionnaires d'événements pour  
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// et <see cref="Common.NavigationHelper.SaveState"/>.
        /// Le paramètre de navigation est disponible dans la méthode LoadState 
        /// en plus de l'état de page conservé durant une session antérieure.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void ParseFile_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            var dic = new Dictionary<string, string>();
            StorageFile sf = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/config.txt"));
            using (StreamReader sr = new StreamReader(await sf.OpenStreamForReadAsync()))
            {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    var lineKeyValue = line.Split(':');
                    dic.Add(lineKeyValue[0], lineKeyValue[1]);
                    
                }
            }

            foreach (var el in dic)
            {
                localSettings.Values[el.Key] = el.Value;
            }
        }

        private void GetLocalSettingCompany_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            var company = localSettings.Values["company"] as string;
            var test = company;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            var sf = new MySettingsFlyout();
            sf.ShowIndependent();
            sf.Unloaded += sf_Unloaded;
        }

        private void GoFlickrPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FlickrApiPage));
        }


        private void sf_Unloaded(object sender, RoutedEventArgs args)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["settings_name"] = ((MySettingsFlyout)sender).SettingsName;
            localSettings.Values["settings_coffee"] = ((MySettingsFlyout)sender).SettingsCoffee;
            localSettings.Values["settings_more"] = ((MySettingsFlyout)sender).SettingsMore;
        }
    }
}
