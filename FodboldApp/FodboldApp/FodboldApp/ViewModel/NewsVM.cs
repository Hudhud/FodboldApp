﻿using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class NewsVM : INotifyPropertyChanged
    {
        private Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ICommand NewsCommand { get; private set; }
        public string TestText { get; } = "NÆSTE KAMP";

        private IEnumerable<NewsModel> _newsList = new ObservableCollection<NewsModel>();
        public IEnumerable<NewsModel> NewsList
        {
            get
            {
                return _newsList;
            }
            set
            {
                _newsList = value;
                OnPropertyChanged(nameof(NewsList));
            }
        }

        public async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/news"));
            _realm = Realm.GetInstance(config);
            _realm.Write(() =>
            {
                _realm.RemoveAll();
                _realm.Add(new NewsModel { Title = "U23 kommet godt fra start", Date = "10. august 2017", Resume = "Siden 20 juli har Boldklubben FREMs nye setup været igang. Truppen begynder at tage form, og skarpheden til træning og i kamp viser en klar positiv tendens.", ImageURL = "http://www.bkfrem.dk/images/image2(9).JPG" });
                _realm.Add(new NewsModel() { Title = "Exit i pokalen", Date = "8. august 2017", Resume = "1 runde blev endestationen. Et feststemt stadion i Hvidovre med flotte 1.126 tilskuere på lægterne blev vidne til et opgør, hvor hjemmeholdet straks fra start trykkede på for at få et hurtigt...", ImageURL = "http://www.bkfrem.dk/images/20746806_1630657970299346_218944165_o.jpg" });
            });
            NewsList = _realm.All<NewsModel>();
        }

        public NewsVM()
        {
            SetupRealm();
            
            Console.WriteLine("DIPSET CITY");
            NewsCommand = new Command(News_Tapped);
        }

        void News_Tapped()
        {
            Console.WriteLine("WE ON IT");

            CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage());
            HeaderVM.UpdateContent();
        }
    }
}
