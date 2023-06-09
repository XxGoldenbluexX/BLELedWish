﻿using BLELedWish.Service;
using BLELedWish.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows;

namespace BLELedWish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            Title = "BLELedWish";
            
            var nav = Ioc.Default.GetService<NavigationService>();
            nav.Setup(this);
            nav.GoTo<ConnectionViewModel>();
        }
    }
}
