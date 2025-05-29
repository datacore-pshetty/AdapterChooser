using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdapterChooser.ViewModel
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
