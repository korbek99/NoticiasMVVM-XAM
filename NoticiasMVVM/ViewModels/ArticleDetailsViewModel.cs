using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NoticiasMVVM.Models;

namespace NoticiasMVVM.ViewModels
{
    public class ArticleDetailsViewModel : INotifyPropertyChanged
    {
        private Article _article;

        public string ImageUrl => _article.UrlToImage;
        public string Title => _article.Title;
        public string Description => _article.Description;

        public ArticleDetailsViewModel(Article article)
        {
            _article = article;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

