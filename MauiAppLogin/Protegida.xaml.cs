using System.Threading.Tasks;

namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
    public Protegida()
    {
        InitializeComponent();

        string? usuario_logado = null;

        Task.Run(async () =>
        {
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            lbl_nome_usuario.Text = $"Bem-vindo(a) {usuario_logado}";
        }
        );



    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem certeza?", "Sair do App?", "Sim", "N�o");

        if (confirmacao)
        {
            SecureStorage.Default.Remove("usuario_logado");
            App.Current.MainPage = new Login();
        }

    }
}


