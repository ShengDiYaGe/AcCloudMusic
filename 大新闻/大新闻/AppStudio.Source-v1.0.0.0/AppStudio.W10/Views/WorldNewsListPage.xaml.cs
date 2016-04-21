//---------------------------------------------------------------------------
//
// <copyright file="WorldNewsListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/24/2015 6:37:00 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Rss;
using AppStudio.Sections;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class WorldNewsListPage : Page
    {
        public WorldNewsListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new WorldNewsConfig());
            this.InitializeComponent();
        }

        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
