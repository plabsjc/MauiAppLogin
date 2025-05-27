
namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ContentPage();
            InitAsync();
           
            
        }
        private async void InitAsync()
        {
            var usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            if (string.IsNullOrEmpty(usuario_logado))
            {
                MainPage = new Login();
            }
            else
            {
                MainPage = new Protegida();
            }
        }





        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 700;
            return window;
        }

    }
}