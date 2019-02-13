using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CopaFilmesApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public readonly Page page;

        public BaseViewModel(Page page)
        {
            this.page = page ?? throw new System.ArgumentNullException(nameof(page));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task Inicialize() {
            return Task.FromResult(default(object));
        }
    }
}
