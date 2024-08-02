using System;
using System.Collections.Generic;
using NoticiasMVVM.Models;
using NoticiasMVVM.ViewModels;
using Xamarin.Forms;

namespace NoticiasMVVM.Views.Details
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Article article)
        {
            InitializeComponent();
            BindingContext = new ArticleDetailsViewModel(article);
        }
    }
}