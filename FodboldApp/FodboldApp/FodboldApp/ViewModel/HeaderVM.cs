﻿using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using static FodboldApp.Model.Categories;

namespace FodboldApp.ViewModel
{
    class HeaderVM : INotifyPropertyChanged
    {
        Color SelectedColor = Color.FromHex("#315baa");
        Color UnSelectedColor = Color.FromHex("#545454");


        private Color _newsIconColor;
        private Color _playerIconColor;
        private Color _matchIconColor;
        private Color _tournamentIconColor;
        private Color _historyIconColor;
        private static ContentView contentPage;

        private static CategoryType currentCategory;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void SetContent(ContentView content)
        {
            contentPage = content;
        }

        public Color NewsIconColor
        {
            get
            {
                return _newsIconColor;
            }
            private set
            {
                _newsIconColor = value;
                OnPropertyChanged(nameof(NewsIconColor));
            }
        }
        public Color PlayerIconColor
        {
            get
            {
                return _playerIconColor;
            }
            private set
            {
                _playerIconColor = value;
                OnPropertyChanged(nameof(PlayerIconColor));
            }
        }
        public Color MatchIconColor
        {
            get
            {
                return _matchIconColor;
            }
            private set
            {
                _matchIconColor = value;
                OnPropertyChanged(nameof(MatchIconColor));
            }
        }
        public Color TournamentIconColor
        {
            get
            {
                return _tournamentIconColor;
            }
            private set
            {
                _tournamentIconColor = value;
                OnPropertyChanged(nameof(TournamentIconColor));
            }
        }
        public Color HistoryIconColor
        {
            get
            {
                return _historyIconColor;
            }
            private set
            {
                _historyIconColor = value;
                OnPropertyChanged(nameof(HistoryIconColor));
            }
        }

        public static CustomStack stack;

        public HeaderVM()
        {
            stack = CustomStack.Instance;

            ResetTint();
        }

        private void ResetTint()
        {
            NewsIconColor = UnSelectedColor;
            PlayerIconColor = UnSelectedColor;
            MatchIconColor = UnSelectedColor;
            TournamentIconColor = UnSelectedColor;
            HistoryIconColor = UnSelectedColor;
        }

        public async void NewsTap()
        {
            ResetTint();
            NewsIconColor = SelectedColor;
            if (currentCategory == CategoryType.NewsType)
            {
                await stack.NewsContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.NewsType;
            contentPage.Content = ((ContentPage)stack.NewsContent.CurrentPage).Content;
        }

        public async void PlayerTap()
        {
            ResetTint();
            PlayerIconColor = SelectedColor;
            if (currentCategory == CategoryType.PlayerType)
            {
                await stack.PlayerContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.PlayerType;
            contentPage.Content = ((ContentPage)stack.PlayerContent.CurrentPage).Content;
        }

        public async void MatchTap()
        {
            ResetTint();
            MatchIconColor = SelectedColor;
            if (currentCategory == CategoryType.MatchType)
            {
                await stack.MatchContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.MatchType;
            contentPage.Content = ((ContentPage)stack.MatchContent.CurrentPage).Content;
        }

        public async void TournamentTap()
        {
            ResetTint();
            TournamentIconColor = SelectedColor;
            if (currentCategory == CategoryType.TournamentType)
            {
                await stack.TournamentContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.TournamentType;
            contentPage.Content = ((ContentPage)stack.TournamentContent.CurrentPage).Content;
        }

        public async void HistoryTap()
        {
            ResetTint();
            HistoryIconColor = SelectedColor;
            if (currentCategory == CategoryType.HistoryType)
            {
                await stack.HistoryContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.HistoryType;
            contentPage.Content = ((ContentPage)stack.HistoryContent.CurrentPage).Content;
        }

        public static void UpdateContent()
        {
            switch(currentCategory)
            {
                case CategoryType.NewsType:
                    contentPage.Content = ((ContentPage)stack.NewsContent.CurrentPage).Content;
                    break;
                case CategoryType.PlayerType:
                    contentPage.Content = ((ContentPage)stack.PlayerContent.CurrentPage).Content;
                    break;
                case CategoryType.MatchType:
                    contentPage.Content = ((ContentPage)stack.MatchContent.CurrentPage).Content;
                    break;
                case CategoryType.TournamentType:
                    contentPage.Content = ((ContentPage)stack.TournamentContent.CurrentPage).Content;
                    break;
                case CategoryType.HistoryType:
                    contentPage.Content = ((ContentPage)stack.HistoryContent.CurrentPage).Content;
                    break;
            }
        }

        public static async void BackButtonPressed()
        {
            Type type = Application.Current.MainPage.Navigation.NavigationStack[0].GetType();
            if (type == typeof(News))
            {
                await stack.NewsContent.Navigation.PopAsync();
            }
            else if (type == typeof(Players))
            {
                await stack.PlayerContent.Navigation.PopAsync();
            }
            else if (type == typeof(Matches))
            {
                await stack.MatchContent.Navigation.PopAsync();
            }
            else if (type == typeof(Tournament))
            {
                await stack.TournamentContent.Navigation.PopAsync();
            }
            else if (type == typeof(History))
            {
                await stack.HistoryContent.Navigation.PopAsync();
            }
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
