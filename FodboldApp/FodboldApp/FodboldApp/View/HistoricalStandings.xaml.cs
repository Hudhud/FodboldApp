﻿using FodboldApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricalStandings : ContentPage, INotifyPropertyChanged
    {
        public string StadingsLabelText { get; set; } = "HEJSA";

        public HistoricalStandings()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = this;


            // putting data in the listview

            standingsList.ItemsSource = HistoricalStandingsData.HistoricalStandingsDataList;

            // seperator color
            standingsList.SeparatorColor = Color.Black;

            // Reducing listview to remove empty space : HeightRequest = (#items * itemHeight) +(Standard height + #items)
            standingsList.HeightRequest = (5 * standingsList.RowHeight) + (10 * 22.5);
        }

        private async void OnStackLayout_Tapped(object sender, EventArgs e)
        {
            standingsStackLayout.IsVisible = !standingsStackLayout.IsVisible;
        }

        Label previousLabel;
        private async void OnItemSelected(object sender, EventArgs e)
        {
            var entity = ((Label)sender);
            if (previousLabel != null) previousLabel.BackgroundColor = Color.White;
            entity.BackgroundColor = Color.Red;
            previousLabel = entity;
            StadingsLabelText = entity.Text;
        }
    }
}