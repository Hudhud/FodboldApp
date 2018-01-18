﻿using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
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

        private ObservableCollection<NewsData> _newsList = new ObservableCollection<NewsData>();
        public ObservableCollection<NewsData> NewsList
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

        public NewsVM()
        {
            Console.WriteLine("DIPSET CITY");
            NewsCommand = new Command(News_Tapped);
            _newsList.Add(new NewsData() { Title = "U23 kommet godt fra start", Date = "10. august 2017", Resume = "Siden 20 juli har Boldklubben FREMs nye setup været igang. Truppen begynder at tage form, og skarpheden til træning og i kamp viser en klar positiv tendens.", ImageURL = "http://www.bkfrem.dk/images/image2(9).JPG" });
            _newsList.Add(new NewsData() { Title = "Exit i pokalen", Date = "8. august 2017", Resume = "1 runde blev endestationen. Et feststemt stadion i Hvidovre med flotte 1.126 tilskuere på lægterne blev vidne til et opgør, hvor hjemmeholdet straks fra start trykkede på for at få et hurtigt...", ImageURL = "http://www.bkfrem.dk/images/20746806_1630657970299346_218944165_o.jpg" });
        }

        void News_Tapped()
        {
            Console.WriteLine("WE ON IT");

            CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage());
            HeaderVM.UpdateContent();
        }
    }
}