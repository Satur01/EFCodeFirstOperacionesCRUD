using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFCodeFirstOperacionesCRUD.Annotations;

namespace EFCodeFirstOperacionesCRUD.EntityFramework.Entities.Base
{
    public abstract class EntityBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
