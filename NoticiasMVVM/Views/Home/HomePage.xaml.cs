// Views/HomePage.xaml.cs
using System;
using NoticiasMVVM.Models;
using NoticiasMVVM.ViewModels;
using NoticiasMVVM.Views.Details;
using Xamarin.Forms;

namespace NoticiasMVVM.Views.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new ArticlesViewModel();
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = BindingContext as ArticlesViewModel;
            if (viewModel != null)
            {
                viewModel.SearchText = e.NewTextValue;
            }
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            // 
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Article selectedArticle)
            {
                
                await Navigation.PushAsync(new DetailsPage(selectedArticle));
            }
        }
    }
}
