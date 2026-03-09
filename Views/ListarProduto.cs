using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views
{
    public class ListarProduto : ContentPage
    {
        SearchBar busca;
        ListView listaProdutos;

        ObservableCollection<Produto> produtos;
        ObservableCollection<Produto> produtosFiltrados;

        public ListarProduto()
        {
            Title = "Lista de Produtos";

            busca = new SearchBar
            {
                Placeholder = "Buscar produto..."
            };

            busca.TextChanged += SearchBar_TextChanged;

            listaProdutos = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    TextCell cell = new TextCell();
                    cell.SetBinding(TextCell.TextProperty, "Descricao");
                    cell.SetBinding(TextCell.DetailProperty, "Quantidade");
                    return cell;
                })
            };

            Content = new StackLayout
            {
                Padding = 10,
                Children =
                {
                    busca,
                    listaProdutos
                }
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var lista = await App.Db.GetAll();

            produtos = new ObservableCollection<Produto>(lista);

            produtosFiltrados = new ObservableCollection<Produto>(produtos);

            listaProdutos.ItemsSource = produtosFiltrados;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = e.NewTextValue?.ToLower() ?? "";

            produtosFiltrados.Clear();

            foreach (var item in produtos)
            {
                if (item.Descricao.ToLower().Contains(texto))
                {
                    produtosFiltrados.Add(item);
                }
            }
        }
    }
}