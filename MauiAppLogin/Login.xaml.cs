using System.Threading.Tasks;

namespace MauiAppLogin;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<DadosUsuario> listaUsuarios = new List<DadosUsuario>()
            {
                new DadosUsuario()
                {
                    Usuario = "Pedro",
                    Senha = "1234"
                },
                new DadosUsuario()
                {
                    Usuario ="Joao",
                    Senha = "1234"
                }
            };

            DadosUsuario dadosDigitados = new DadosUsuario()
            {
                Usuario = txt_usuario.Text,
                Senha = txt_senha.Text
            };

            if (listaUsuarios.Any(i => dadosDigitados.Usuario == i.Usuario && dadosDigitados.Senha == i.Senha))
            {
                await DisplayAlert(" Deu Certo!", "Acesso Permitido!", "OK");
                await SecureStorage.Default.SetAsync("usuario_logado", dadosDigitados.Usuario);
                App.Current.MainPage = new Protegida();
            }
            else
            {
                throw new Exception("Usuario/Senha incorretos");
            }


        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }
}