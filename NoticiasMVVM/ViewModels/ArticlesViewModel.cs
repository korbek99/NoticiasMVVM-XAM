using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NoticiasMVVM.Models;

namespace NoticiasMVVM.ViewModels
{
    public class ArticlesViewModel : INotifyPropertyChanged
    {
        //private const string ApiKey = "";
        private const string ApiUrl = "http://demo3724643.mockable.io/news";

        private ObservableCollection<Article> articles;
        private ObservableCollection<Article> filteredArticles;
        private string searchText;

        public ObservableCollection<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Article> FilteredArticles
        {
            get { return filteredArticles; }
            set
            {
                filteredArticles = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();
                FilterArticles();
            }
        }

        public ArticlesViewModel()
        {
            Articles = new ObservableCollection<Article>();
            FilteredArticles = new ObservableCollection<Article>();
            LoadArticles();
        }

        private async void LoadArticles()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(ApiUrl);
                    ArticleList articleList = JsonConvert.DeserializeObject<ArticleList>(response);

                    if (articleList?.Articles != null)
                    {
                        Articles.Clear();
                        foreach (var article in articleList.Articles)
                        {
                            Articles.Add(article);
                        }
                        FilterArticles();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los artículos: {ex.Message}");
            }
        }

        private void FilterArticles()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredArticles = new ObservableCollection<Article>(Articles);
            }
            else
            {
                FilteredArticles = new ObservableCollection<Article>(
                    Articles.Where(article => article.Title.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
