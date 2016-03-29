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

// Pour en savoir plus sur le modèle d'élément du menu volant des paramètres, consultez la page http://go.microsoft.com/fwlink/?LinkId=273769

namespace UniversalAppCsharp
{
    public sealed partial class MySettingsFlyout : SettingsFlyout
    {
        public string SettingsName { get { return NameTb.Text; } }
        public double SettingsCoffee { get { return CoffeeSd.Value; } }
        public bool SettingsMore { get { return MoreTs.IsOn; } }

        public MySettingsFlyout()
        {
            this.InitializeComponent();
        }
    }
}
