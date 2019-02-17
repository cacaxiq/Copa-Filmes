using CopaFilmesApp.Service;
using CopaFilmesApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CopaFilmesApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService service;

        public LoginViewModel(Page page) : base(page)
        {
            LoginCommand = new Command(async () => await Login(), () => CanExecuteLogin());
            service = DependencyService.Get<ILoginService>();
        }

        private bool CanExecuteLogin()
        {
            return !(string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Senha) ||
                                    UserName.Length < 6 || Senha.Length < 8);
        }

        private async Task Login()
        {
            IsRefresh = true;
            var result = await service.GetLogin(UserName, Senha);

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    await SecureStorage.SetAsync("oauth_token", result);
                    await page.Navigation.PushAsync(new MovieList());
                }
                catch (Exception ex)
                {
                    await page.DisplayAlert("Erro", $"Erro após login com sucesso: {ex.Message}", "Ok");
                }
            }
            else
            {
                await page.DisplayAlert("Erro", "Login nao concluído, tente novamente.", "Ok");
            }

            UserName = string.Empty;
            Senha = string.Empty;
            IsRefresh = false;
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                NotifyPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        public Command LoginCommand { get; }

        public override Task Inicialize()
        {
            return base.Inicialize();
        }
    }
}
