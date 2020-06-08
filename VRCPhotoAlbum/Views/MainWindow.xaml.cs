﻿using Gatosyocora.VRCPhotoAlbum.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Windows.Controls;

namespace Gatosyocora.VRCPhotoAlbum.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IDisposable
    {
        public static MainWindow Instance { get; private set; }

        private MainViewModel _mainViewModel;

        static MainWindow()
        {
            Instance = new MainWindow();
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_OnLoaded;
        }

        private void MainWindow_OnLoaded(object sender, EventArgs args)
        {
            _mainViewModel = new MainViewModel(this);
            DataContext = _mainViewModel;
            PhotoListBox.ItemsSource = _mainViewModel.ShowedPhotoList;
        }

        public void Reload()
        {
            _mainViewModel.UpdatePhotoList();
        }
        public void Reboot()
        {
            _mainViewModel.LoadResources();
        }


        public void SearchWithUserName(string userName)
        {
            _mainViewModel.SearchWithUserName(userName);
        }

        public void SearchWithWorldName(string worldName)
        {
            _mainViewModel.SearchWithWorldName(worldName);
        }

        public void SearchWithDate(string date)
        {
            _mainViewModel.SearchWithDateString(date);
        }

        private void PhotoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhotoListBox.SelectedItem = null;
        }

        public void Dispose()
        {
            _mainViewModel.Dispose();
        }
    }
}
