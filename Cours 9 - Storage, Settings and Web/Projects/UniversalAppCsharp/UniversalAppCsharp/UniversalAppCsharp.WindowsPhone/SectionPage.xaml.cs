using UniversalAppCsharp.Common;
using UniversalAppCsharp.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle de projet Application Hub universelle, consultez la page http://go.microsoft.com/fwlink/?LinkID=391955

namespace UniversalAppCsharp
{
    /// <summary>
    /// Page affichant une vue d'ensemble d'un groupe, ainsi qu'un aperçu des éléments
    /// qu'il contient.
    /// </summary
    public sealed partial class SectionPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

        public SectionPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Obtient le <see cref="NavigationHelper"/> associé à ce <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Obtient le modèle d'affichage pour ce <see cref="Page"/>.
        /// Cela peut être remplacé par un modèle d'affichage fortement typé.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Remplit la page à l'aide du contenu passé lors de la navigation.  Tout état enregistré est également
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
            // TODO: créer un modèle de données approprié pour le domaine posant problème afin de remplacer les exemples de données.
            var group = await SampleDataSource.GetGroupAsync((string)e.NavigationParameter);
            this.DefaultViewModel["Group"] = group;
        }

        /// <summary>
        /// Conserve l'état associé à cette page en cas de suspension de l'application ou de
        /// suppression de la page du cache de navigation.  Les valeurs doivent être conformes aux
        /// exigences en matière de sérialisation de <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">La source de l'événement ; en général <see cref="NavigationHelper"/></param>
        /// <param name="e">Données d'événement qui fournissent un dictionnaire vide à remplir à l'aide de l'
        /// état sérialisable.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: enregistrer l'état unique de la page ici.
        }

        /// <summary>
        /// Affiche les détails d'un élément sur lequel l'utilisateur a cliqué dans <see cref="ItemPage"/>.
        /// </summary>
        /// <param name="sender">GridView qui affiche l'élément sur lequel l'utilisateur a cliqué.</param>
        /// <param name="e">Données d'événement décrivant l'élément sur lequel l'utilisateur a cliqué.</param>
        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            if (!Frame.Navigate(typeof(ItemPage), itemId))
            {
                var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
                throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        #region Inscription de NavigationHelper

        /// <summary>
        /// Les méthodes fournies dans cette section sont utilisées simplement pour permettre
        /// NavigationHelper pour répondre aux méthodes de navigation de la page.
        /// <para>
        /// La logique spécifique à la page doit être placée dans les gestionnaires d'événements pour le
        /// <see cref="NavigationHelper.LoadState"/>
        /// et <see cref="NavigationHelper.SaveState"/>.
        /// Le paramètre de navigation est disponible dans la méthode LoadState
        /// en plus de l'état de page conservé durant une session antérieure.
        /// </para>
        /// </summary>
        /// <param name="e">Données d'événement décrivant la manière dont l'utilisateur a accédé à cette page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}