using System.Collections.ObjectModel;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListarProduto : ContentPage
    {

        ObservableCollection<Produto> listaProdutos;
        ObservableCollection<Produto> listaFiltrada;

        public ListarProduto()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listaProdutos = new ObservableCollection<Produto>(App.Db.GetAll());

            listaFiltrada = new ObservableCollection<Produto>(listaProdutos);

            ListaProdutos.ItemsSource = listaFiltrada;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busca = e.NewTextValue.ToLower();

            listaFiltrada.Clear();

            foreach (var item in listaProdutos)
            {
                if (item.Descricao.ToLower().Contains(busca))
                {
                    listaFiltrada.Add(item);
                }
            }
        }
    }
}