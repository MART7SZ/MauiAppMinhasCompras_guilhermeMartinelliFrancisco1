using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    private object txt_quantidade;
    private object txt_descricao;
    private object txt_preco;

    public EditarProduto()
    {
   
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;
            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = (string)txt_descricao,
                Quantidade = Convert.ToDouble(txt_quantidade),
                Preco = Convert.ToDouble(txt_preco)
            };
            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
