using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CopaFilmesApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public readonly Page page;

        public BaseViewModel(Page page)
        {
            this.page = page ?? throw new System.ArgumentNullException(nameof(page));
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task Logout()
        {
            SecureStorage.RemoveAll();
            await page.Navigation.PopToRootAsync(true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task Inicialize() {
            return Task.FromResult(default(object));
        }

        public virtual Task Destroy()
        {
            return Task.FromResult(default(object));
        }

        private bool isRefresh;
        public bool IsRefresh
        {
            get { return isRefresh; }
            set
            {
                isRefresh = value;
                NotifyPropertyChanged();
            }
        }

        public Command LogoutCommand { get; }
    }
}
