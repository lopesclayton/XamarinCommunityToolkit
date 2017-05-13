﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsCommunityToolkit.Samples.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EffectsPage : ContentPage
    {
        public EffectsPage()
        {
            InitializeComponent();
        }

        private async void OnEntryButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EffectsEntryPage());
        }
    }
}